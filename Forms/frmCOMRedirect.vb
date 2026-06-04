Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class frmCOMRedirect

   Private cfg As New AppSettings()
   Private comPort As LegacySerialCommunication
   Private currentSessionId As Integer = 0

   Private Const SYSMENU_ABOUT_ID As UInteger = 1000

   '-----------------------------------------------------------------------------------------------
   ' onHandleCreated - Add "About" to system menu
   Protected Overrides Sub OnHandleCreated(e As EventArgs)
      MyBase.OnHandleCreated(e)
      Dim hSysMenu As IntPtr = GetSystemMenu(Me.Handle, False)
      ' Add a separator and then your custom item
      AppendMenu(hSysMenu, MF_SEPARATOR, 0, String.Empty)
      AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "About")
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' WndProc override to handle system menu commands
   Protected Overrides Sub WndProc(ByRef m As Message)
      MyBase.WndProc(m)
      If m.Msg = WM_SYSCOMMAND Then
         If CUInt(m.WParam) = SYSMENU_ABOUT_ID Then
            frmAbout.ShowDialog()
         End If
      End If
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmCOMRedirect onLoad
   Private Sub frmCOMRedirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = AppData.appName & " " & AppData.appVersion & " by " & AppData.appAuthor
      toolStripBtnStart_Click(Nothing, Nothing) ' Auto-start on load
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' toolStripBtnStart onClick - Start COM redirect
   Private Sub toolStripBtnStart_Click(sender As Object, e As EventArgs) Handles toolStripBtnStart.Click
      lblData.Text = "Waiting for data..."
      cfg.LoadSettings()


      Dim comDCB As New DCB()
      comDCB.DCBlength = Marshal.SizeOf(GetType(DCB))

      comDCB.BaudRate = cfg.BaudRate
      comDCB.ByteSize = cfg.DataBits
      comDCB.Parity = cfg.Parity
      comDCB.StopBits = cfg.StopBits
      comDCB.Flags = 0
      comDCB.Flags = comDCB.Flags Or &H1

      Select Case cfg.FlowControl
         Case 0 ' None
            ' DTR_CONTROL_ENABLE = 1 << 4
            comDCB.Flags = comDCB.Flags Or (1 << 4)
            ' RTS_CONTROL_ENABLE = 1 << 12
            comDCB.Flags = comDCB.Flags Or (1 << 12)
         Case 1 ' RTS/CTS
            ' fOutxCtsFlow = 1 (bit 2)
            comDCB.Flags = comDCB.Flags Or (1 << 2)
            ' RTS_CONTROL_HANDSHAKE = 2 << 12
            comDCB.Flags = comDCB.Flags Or (2 << 12)
         Case 2 ' DTR/DSR
            ' fOutX = 1 (bit 8)
            comDCB.Flags = comDCB.Flags Or (1 << 8)
            ' fInX = 1 (bit 9)
            comDCB.Flags = comDCB.Flags Or (1 << 9)
      End Select

      currentSessionId += 1
      Dim sessionIdAtCapture = currentSessionId ' Capture current ID for this specific callback

      Try
         comPort = New LegacySerialCommunication(cfg.Port, comDCB,
              Sub(data, count)
                 Dim txt = System.Text.Encoding.ASCII.GetString(data, 0, count)
                 Me.BeginInvoke(Sub()
                                   If sessionIdAtCapture <> currentSessionId OrElse comPort Is Nothing Then Exit Sub

                                   lblData.Text = txt
                                   Try
                                      AppActivate(cfg.WindowTitle)
                                      ' Give the OS a moment to switch focus
                                      System.Windows.Forms.Application.DoEvents()
                                      Thread.Sleep(50)
                                      SendKeys.SendWait(txt)
                                      Log.Instance.Info("Data sent to " & cfg.WindowTitle)
                                   Catch ex As ArgumentException
                                      Log.Instance.Error("Failed to activate window: [" & cfg.WindowTitle & "] " & ex.Message)
                                   Catch ex As Exception
                                      Log.Instance.Error("Unexpected error occurred. " & ex.Message)
                                   End Try
                                End Sub)
              End Sub)

         StatusStrip.Items(0).Text = "Port: " & cfg.Port
         StatusStrip.Items(1).Text = "Baud Rate: " & cfg.BaudRate
         toolStripBtnStart.Enabled = False
         toolStripBtnStop.Enabled = True
         Log.Instance.Info("COM port opened" & cfg.Port)
      Catch ex As Exception
         Log.Instance.Error("Failed to open COM port" & ex.Message)
      End Try
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' toolStripBtnStop onClick - Stop COM redirect
   Private Sub toolStripBtnStop_Click(sender As Object, e As EventArgs) Handles toolStripBtnStop.Click
      currentSessionId += 1 ' Increment to invalidate all previous pending callbacks
      Try
         If comPort IsNot Nothing Then
            comPort.Close()
            comPort = Nothing
            Log.Instance.Info("COM port closed")
         End If
      Catch ex As Exception
         Log.Instance.Error("Failed to close COM port" & ex.Message)
      End Try

      While System.Windows.Forms.Application.MessageLoop
         System.Windows.Forms.Application.DoEvents()
         ' A tiny sleep allows the queue to process/discard messages
         Threading.Thread.Sleep(10)
         Exit While
      End While

      lblData.Text = "Waiting for data..."
      StatusStrip.Items(0).Text = "Port: - "
      StatusStrip.Items(1).Text = "Baud Rate: - "
      toolStripBtnStart.Enabled = True
      toolStripBtnStop.Enabled = False

   End Sub

   '-----------------------------------------------------------------------------------------------
   ' toolStripBtnSettings onClick - Show settings dialog
   Private Sub toolStripBtnSettings_Click(sender As Object, e As EventArgs) Handles toolStripBtnSettings.Click
      Using frm As New frmSettings()
         ' Show it as a modal dialog
         frm.ShowDialog()
      End Using
   End Sub
End Class
