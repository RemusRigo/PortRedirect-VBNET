Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class frmCOMRedirect

   Private com As LegacySerialCommunication

   Private Sub frmCOMRedirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim settings As New AppSettings
      settings.LoadSettings()

      Dim comDCB As New DCB()
      comDCB.DCBlength = Marshal.SizeOf(GetType(DCB))

      comDCB.BaudRate = settings.BaudRate
      comDCB.ByteSize = settings.DataBits
      comDCB.Parity = settings.Parity
      comDCB.StopBits = settings.StopBits
      comDCB.Flags = 0
      comDCB.Flags = comDCB.Flags Or &H1

      Select Case settings.FlowControl
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



      com = New LegacySerialCommunication("COM3", comDCB,
       Sub(data, count)
          Dim txt = System.Text.Encoding.ASCII.GetString(data, 0, count)
          Me.BeginInvoke(Sub()
                            TextBox1.AppendText(txt)
                            AppActivate("Untitled - Notepad")
                            Thread.Sleep(200)
                            SendKeys.SendWait(txt)
                         End Sub
          )
       End Sub)
   End Sub

End Class
