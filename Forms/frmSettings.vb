Public Class frmSettings

   Private cfg As New AppSettings()

   '------------------------------------------------------------------------------------------------
   ' Load Defaults
   Private Sub LoadDefaults()
      Dim comPorts As List(Of String) = EnumComPorts()
      cbPort.Items.Clear()
      If comPorts.Count > 0 Then
         cbPort.DataSource = comPorts
      End If

      cbBaudRate.Items.AddRange(New Object() {"110", "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"})

      ' 5: Baudot, teletype | 6: rarely used | 7: ASCII + parity | 8: Default For modern devices
      cbDataBits.Items.AddRange(New Object() {"5", "6", "7", "8"})

      ' NOPARITY | ODDPARITY | EVENPARITY | MARKPARITY | SPACEPARITY
      cbParity.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})

      ' ONESTOPBIT | ONE5STOPBITS | TWOSTOPBITS
      cbStopBits.Items.AddRange(New Object() {"0", "1", "2"})

      cbFlowControl.Items.AddRange(New Object() {"None", "RTS/CTS", "XON/XOFF"})
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSettings onLoad - Populate controls and load settings
   Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      'btnOk.Text = "OK"
      LoadDefaults()

      cfg.LoadSettings()

      ' MessageBox.Show(cfg.Method.ToString())
      '  MessageBox.Show(cfg.WindowTitle)

      If cfg.SerialCommMethod = 0 Then
         rBtnLegacy.Checked = True
      ElseIf cfg.SerialCommMethod = 1 Then
         rBtnDotNet.Checked = True
      End If

      cbPort.Text = cfg.Port
      cbBaudRate.Text = cfg.BaudRate.ToString()
      cbDataBits.Text = cfg.DataBits.ToString()
      cbParity.Text = cfg.Parity.ToString()
      cbStopBits.Text = cfg.StopBits.ToString()
      cbFlowControl.SelectedIndex = cfg.FlowControl

      cbWindowTitle.Text = cfg.WindowTitle
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmSettings onFormClosing - Save settings
   Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      If rBtnLegacy.Checked Then
         cfg.SerialCommMethod = 0
      ElseIf rBtnDotNet.Checked Then
         cfg.SerialCommMethod = 1
      End If

      cfg.Port = cbPort.Text
      cfg.BaudRate = CInt(cbBaudRate.Text)
      cfg.DataBits = CInt(cbDataBits.Text)
      cfg.Parity = CInt(cbParity.Text)
      cfg.StopBits = CInt(cbStopBits.Text)
      cfg.FlowControl = cbFlowControl.SelectedIndex

      cfg.WindowTitle = cbWindowTitle.Text

      cfg.SaveSettings()
   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
      Me.DialogResult = DialogResult.OK
   End Sub

End Class