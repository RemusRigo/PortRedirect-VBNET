Imports System.IO
Imports System.IO.Ports
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class frmPortRedirect

   Private cfg As New AppSettings()
   Private legacyPort As LegacySerialCommunication
   Private WithEvents netPort As SerialPort

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
   ' Initialize Legacy Port Listening
   Private Sub InitializeLegacyPortListening()
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

      Try
         legacyPort = New LegacySerialCommunication(cfg.Port, comDCB,
              Sub(data, count)
                 Dim txt = System.Text.Encoding.ASCII.GetString(data, 0, count)
                 Me.BeginInvoke(Sub()
                                   If legacyPort Is Nothing Then Exit Sub

                                   lblData.Text = txt
                                   Try
                                      AppActivate(cfg.WindowTitle)
                                      ' Give the OS a moment to switch focus
                                      System.Windows.Forms.Application.DoEvents()
                                      'Thread.Sleep(50)
                                      SendKeys.SendWait(txt)
                                      Log.Instance.Info("Data sent to " & cfg.WindowTitle)
                                   Catch ex As ArgumentException
                                      Log.Instance.Error("Failed to activate window: [" & cfg.WindowTitle & "] " & ex.Message)
                                   Catch ex As Exception
                                      Log.Instance.Error("Unexpected error occurred. " & ex.Message)
                                   End Try
                                End Sub)
              End Sub)
      Catch ex As Exception
         Log.Instance.Error("Failed to open COM port" & ex.Message)
      End Try
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Terminate Legacy Port Listening
   Private Sub TerminateLegacyPortListening()
      Try
         If legacyPort IsNot Nothing Then
            legacyPort.Close()
            legacyPort = Nothing
         End If
      Catch ex As Exception
         Log.Instance.Error("Failed to close COM port" & ex.Message)
      End Try

      lblData.Text = "Waiting for data..."
      StatusStrip.Items(0).Text = "Port: - "
      StatusStrip.Items(1).Text = "Baud Rate: - "
      btnTSStart.Enabled = True
      btnTSStop.Enabled = False
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Initialize Net Port Listening
   Private Sub InitializeNetPortListening()
      Try
         Log.Instance.Info("Initialize .NET Framework Port Listening")
         netPort = New SerialPort(cfg.Port, cfg.BaudRate, cfg.Parity, cfg.DataBits, cfg.StopBits)

         ' Configure Flow Control using native Enumerations
         Select Case cfg.FlowControl
            Case 0 : netPort.Handshake = Handshake.None
            Case 1 : netPort.Handshake = Handshake.RequestToSend
            Case 2 : netPort.Handshake = Handshake.XOnXOff
         End Select

         netPort.Open()
         'Log.Instance.Info("Port opened: " & cfg.Port & " Baud Rate: " & cfg.BaudRate)

         ' fix: empty buffer / else send codes from previous session (when process is stopped)
         netPort.DiscardInBuffer()
         netPort.DiscardOutBuffer()
         'System.Threading.Thread.Sleep(200)
         'netPort.DiscardInBuffer()
         'netPort.DiscardOutBuffer()

      Catch ex As Exception
         Log.Instance.Error("Failed to open COM port: " & ex.Message)
      End Try
   End Sub

   Private Sub netPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles netPort.DataReceived
      ' Read the data immediately
      Dim incomingData As String = netPort.ReadExisting()

      ' Marshal back to UI thread for processing
      Me.BeginInvoke(Sub()
                        lblData.Text = incomingData
                        Try
                           AppActivate(cfg.WindowTitle)
                           System.Windows.Forms.Application.DoEvents()
                           SendKeys.SendWait(incomingData)
                           Log.Instance.Info("Data sent to " & cfg.WindowTitle)
                        Catch ex As ArgumentException
                           Log.Instance.Error("Failed to activate window: [" & cfg.WindowTitle & "] " & ex.Message)
                        Catch ex As Exception
                           Log.Instance.Error("Unexpected error occurred. " & ex.Message)
                        End Try
                     End Sub)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Terminate Net Port Listening
   Private Sub TerminateNetPortListening()
      Log.Instance.Info("Terminate .NET Framework Port Listening")
      If netPort IsNot Nothing Then
         If netPort.IsOpen Then netPort.Close()
         netPort.Dispose()
         netPort = Nothing
         Log.Instance.Info("Port closed: " & cfg.Port)
      End If

      lblData.Text = "Waiting for data..."
      StatusStrip.Items(0).Text = "Port: - "
      StatusStrip.Items(1).Text = "Baud Rate: - "
      btnTSStart.Enabled = True
      btnTSStop.Enabled = False
   End Sub


   '-----------------------------------------------------------------------------------------------
   ' btnTSStart onClick - Start Port Listening
   Private Sub btnTSStart_Click(sender As Object, e As EventArgs) Handles btnTSStart.Click
      If cfg.SerialCommMethod = 0 Then
         InitializeLegacyPortListening()
      ElseIf cfg.SerialCommMethod = 1 Then
         InitializeNetPortListening()
      End If

      StatusStrip.Items(0).Text = "Port: " & cfg.Port
      StatusStrip.Items(1).Text = "Baud Rate: " & cfg.BaudRate
      btnTSStart.Enabled = False
      btnTSStop.Enabled = True
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnTSStop onClick : Terminate Port Listening
   Private Sub btnTSStop_Click(sender As Object, e As EventArgs) Handles btnTSStop.Click
      If cfg.SerialCommMethod = 0 Then
         TerminateLegacyPortListening()
      ElseIf cfg.SerialCommMethod = 1 Then
         TerminateNetPortListening()
      End If
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnTSOpenLog onClick
   Private Sub btnTSOpenLog_Click(sender As Object, e As EventArgs) Handles btnTSOpenLog.Click
      Dim dt = Date.Now
      Dim logPath = Path.Combine(AppContext.BaseDirectory, "Logs", dt.ToString("yyyy"), dt.ToString("MM"), dt.ToString("dd"), $"{appName}.log")

      If File.Exists(logPath) Then
         Process.Start(New ProcessStartInfo() With {
           .FileName = logPath,
         .UseShellExecute = True
        })
      End If
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' toolStripBtnSettings onClick
   Private Sub toolStripBtnSettings_Click(sender As Object, e As EventArgs) Handles btnTSSettings.Click
      Using frm As New frmSettings()
         frm.ShowDialog()
      End Using
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmCOMRedirect onShow
   Private Sub frmPortRedirect_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Me.Text = AppData.appName & " " & AppData.appVersion & " by " & AppData.appAuthor
      lblData.Text = "Waiting for data..."
      cfg.LoadSettings()

      btnTSStart_Click(Nothing, Nothing)

      StatusStrip.Items(0).Text = "Port: " & cfg.Port
      StatusStrip.Items(1).Text = "Baud Rate: " & cfg.BaudRate
      btnTSStart.Enabled = False
      btnTSStop.Enabled = True
   End Sub

End Class
