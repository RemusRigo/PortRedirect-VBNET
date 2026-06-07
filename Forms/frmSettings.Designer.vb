<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
      grpBoxInput = New GroupBox()
      cbFlowControl = New ComboBox()
      lblFlowControl = New Label()
      cbStopBits = New ComboBox()
      lblStopBits = New Label()
      cbParity = New ComboBox()
      lblParity = New Label()
      cbDataBits = New ComboBox()
      lblDataBits = New Label()
      cbBaudRate = New ComboBox()
      lblBaudRate = New Label()
      cbPort = New ComboBox()
      lblPort = New Label()
      grpBoxMethod = New GroupBox()
      rBtnDotNet = New RadioButton()
      rBtnLegacy = New RadioButton()
      btnOk = New Button()
      grpBoxTarget = New GroupBox()
      cbWindowTitle = New ComboBox()
      lblWindowTitle = New Label()
      grpBoxInput.SuspendLayout()
      grpBoxMethod.SuspendLayout()
      grpBoxTarget.SuspendLayout()
      SuspendLayout()
      ' 
      ' grpBoxInput
      ' 
      grpBoxInput.Controls.Add(cbFlowControl)
      grpBoxInput.Controls.Add(lblFlowControl)
      grpBoxInput.Controls.Add(cbStopBits)
      grpBoxInput.Controls.Add(lblStopBits)
      grpBoxInput.Controls.Add(cbParity)
      grpBoxInput.Controls.Add(lblParity)
      grpBoxInput.Controls.Add(cbDataBits)
      grpBoxInput.Controls.Add(lblDataBits)
      grpBoxInput.Controls.Add(cbBaudRate)
      grpBoxInput.Controls.Add(lblBaudRate)
      grpBoxInput.Controls.Add(cbPort)
      grpBoxInput.Controls.Add(lblPort)
      grpBoxInput.Location = New Point(2, 60)
      grpBoxInput.Name = "grpBoxInput"
      grpBoxInput.Size = New Size(223, 193)
      grpBoxInput.TabIndex = 0
      grpBoxInput.TabStop = False
      grpBoxInput.Text = "Input"
      ' 
      ' cbFlowControl
      ' 
      cbFlowControl.FormattingEnabled = True
      cbFlowControl.Location = New Point(92, 161)
      cbFlowControl.Name = "cbFlowControl"
      cbFlowControl.Size = New Size(121, 23)
      cbFlowControl.TabIndex = 11
      ' 
      ' lblFlowControl
      ' 
      lblFlowControl.AutoSize = True
      lblFlowControl.Location = New Point(9, 164)
      lblFlowControl.Name = "lblFlowControl"
      lblFlowControl.Size = New Size(78, 15)
      lblFlowControl.TabIndex = 10
      lblFlowControl.Text = "Flow Control:"
      ' 
      ' cbStopBits
      ' 
      cbStopBits.FormattingEnabled = True
      cbStopBits.Location = New Point(92, 132)
      cbStopBits.Name = "cbStopBits"
      cbStopBits.Size = New Size(121, 23)
      cbStopBits.TabIndex = 9
      ' 
      ' lblStopBits
      ' 
      lblStopBits.AutoSize = True
      lblStopBits.Location = New Point(9, 135)
      lblStopBits.Name = "lblStopBits"
      lblStopBits.Size = New Size(56, 15)
      lblStopBits.TabIndex = 8
      lblStopBits.Text = "Stop Bits:"
      ' 
      ' cbParity
      ' 
      cbParity.FormattingEnabled = True
      cbParity.Location = New Point(92, 103)
      cbParity.Name = "cbParity"
      cbParity.Size = New Size(121, 23)
      cbParity.TabIndex = 7
      ' 
      ' lblParity
      ' 
      lblParity.AutoSize = True
      lblParity.Location = New Point(9, 106)
      lblParity.Name = "lblParity"
      lblParity.Size = New Size(40, 15)
      lblParity.TabIndex = 6
      lblParity.Text = "Parity:"
      ' 
      ' cbDataBits
      ' 
      cbDataBits.FormattingEnabled = True
      cbDataBits.Location = New Point(92, 74)
      cbDataBits.Name = "cbDataBits"
      cbDataBits.Size = New Size(121, 23)
      cbDataBits.TabIndex = 5
      ' 
      ' lblDataBits
      ' 
      lblDataBits.AutoSize = True
      lblDataBits.Location = New Point(9, 77)
      lblDataBits.Name = "lblDataBits"
      lblDataBits.Size = New Size(56, 15)
      lblDataBits.TabIndex = 4
      lblDataBits.Text = "Data Bits:"
      ' 
      ' cbBaudRate
      ' 
      cbBaudRate.FormattingEnabled = True
      cbBaudRate.Location = New Point(92, 45)
      cbBaudRate.Name = "cbBaudRate"
      cbBaudRate.Size = New Size(121, 23)
      cbBaudRate.TabIndex = 3
      ' 
      ' lblBaudRate
      ' 
      lblBaudRate.AutoSize = True
      lblBaudRate.Location = New Point(9, 48)
      lblBaudRate.Name = "lblBaudRate"
      lblBaudRate.Size = New Size(63, 15)
      lblBaudRate.TabIndex = 2
      lblBaudRate.Text = "Baud Rate:"
      ' 
      ' cbPort
      ' 
      cbPort.FormattingEnabled = True
      cbPort.Location = New Point(92, 16)
      cbPort.Name = "cbPort"
      cbPort.Size = New Size(121, 23)
      cbPort.TabIndex = 1
      ' 
      ' lblPort
      ' 
      lblPort.AutoSize = True
      lblPort.Location = New Point(9, 19)
      lblPort.Name = "lblPort"
      lblPort.Size = New Size(32, 15)
      lblPort.TabIndex = 0
      lblPort.Text = "Port:"
      ' 
      ' grpBoxMethod
      ' 
      grpBoxMethod.Controls.Add(rBtnDotNet)
      grpBoxMethod.Controls.Add(rBtnLegacy)
      grpBoxMethod.Location = New Point(2, 2)
      grpBoxMethod.Name = "grpBoxMethod"
      grpBoxMethod.Size = New Size(223, 52)
      grpBoxMethod.TabIndex = 3
      grpBoxMethod.TabStop = False
      grpBoxMethod.Text = "Method"
      ' 
      ' rBtnDotNet
      ' 
      rBtnDotNet.AutoSize = True
      rBtnDotNet.Location = New Point(74, 22)
      rBtnDotNet.Name = "rBtnDotNet"
      rBtnDotNet.Size = New Size(47, 19)
      rBtnDotNet.TabIndex = 4
      rBtnDotNet.TabStop = True
      rBtnDotNet.Text = ".&Net"
      rBtnDotNet.UseVisualStyleBackColor = True
      ' 
      ' rBtnLegacy
      ' 
      rBtnLegacy.AutoSize = True
      rBtnLegacy.Location = New Point(6, 22)
      rBtnLegacy.Name = "rBtnLegacy"
      rBtnLegacy.Size = New Size(62, 19)
      rBtnLegacy.TabIndex = 3
      rBtnLegacy.TabStop = True
      rBtnLegacy.Text = "&Legacy"
      rBtnLegacy.UseVisualStyleBackColor = True
      ' 
      ' btnOk
      ' 
      btnOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnOk.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
      btnOk.ForeColor = Color.ForestGreen
      btnOk.Location = New Point(670, 255)
      btnOk.Name = "btnOk"
      btnOk.Size = New Size(23, 23)
      btnOk.TabIndex = 4
      btnOk.Text = "✓"
      btnOk.UseVisualStyleBackColor = True
      ' 
      ' grpBoxTarget
      ' 
      grpBoxTarget.Controls.Add(cbWindowTitle)
      grpBoxTarget.Controls.Add(lblWindowTitle)
      grpBoxTarget.Location = New Point(231, 2)
      grpBoxTarget.Name = "grpBoxTarget"
      grpBoxTarget.Size = New Size(462, 251)
      grpBoxTarget.TabIndex = 5
      grpBoxTarget.TabStop = False
      grpBoxTarget.Text = "Target"
      ' 
      ' cbWindowTitle
      ' 
      cbWindowTitle.FormattingEnabled = True
      cbWindowTitle.Location = New Point(91, 18)
      cbWindowTitle.Name = "cbWindowTitle"
      cbWindowTitle.Size = New Size(364, 23)
      cbWindowTitle.TabIndex = 15
      ' 
      ' lblWindowTitle
      ' 
      lblWindowTitle.AutoSize = True
      lblWindowTitle.Location = New Point(8, 21)
      lblWindowTitle.Name = "lblWindowTitle"
      lblWindowTitle.Size = New Size(80, 15)
      lblWindowTitle.TabIndex = 14
      lblWindowTitle.Text = "Window Title:"
      ' 
      ' frmSettings
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(698, 280)
      Controls.Add(grpBoxTarget)
      Controls.Add(btnOk)
      Controls.Add(grpBoxMethod)
      Controls.Add(grpBoxInput)
      FormBorderStyle = FormBorderStyle.FixedSingle
      Icon = CType(resources.GetObject("$this.Icon"), Icon)
      MaximizeBox = False
      MinimizeBox = False
      Name = "frmSettings"
      StartPosition = FormStartPosition.CenterParent
      Text = "Settings"
      grpBoxInput.ResumeLayout(False)
      grpBoxInput.PerformLayout()
      grpBoxMethod.ResumeLayout(False)
      grpBoxMethod.PerformLayout()
      grpBoxTarget.ResumeLayout(False)
      grpBoxTarget.PerformLayout()
      ResumeLayout(False)
   End Sub

   Friend WithEvents grpBoxInput As GroupBox
   Friend WithEvents cbPort As ComboBox
   Friend WithEvents lblPort As Label
   Friend WithEvents cbBaudRate As ComboBox
   Friend WithEvents lblBaudRate As Label
   Friend WithEvents cbDataBits As ComboBox
   Friend WithEvents lblDataBits As Label
   Friend WithEvents cbParity As ComboBox
   Friend WithEvents lblParity As Label
   Friend WithEvents cbFlowControl As ComboBox
   Friend WithEvents lblFlowControl As Label
   Friend WithEvents cbStopBits As ComboBox
   Friend WithEvents lblStopBits As Label
   Friend WithEvents grpBoxMethod As GroupBox
   Friend WithEvents rBtnDotNet As RadioButton
   Friend WithEvents rBtnLegacy As RadioButton
   Friend WithEvents btnOk As Button
   Friend WithEvents grpBoxTarget As GroupBox
   Friend WithEvents cbWindowTitle As ComboBox
   Friend WithEvents lblWindowTitle As Label
End Class
