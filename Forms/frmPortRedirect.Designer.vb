<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortRedirect
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
      components = New ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPortRedirect))
      ToolStrip = New ToolStrip()
      toolStripBtnStart = New ToolStripButton()
      toolStripBtnStop = New ToolStripButton()
      toolStripBtnSettings = New ToolStripButton()
      StatusStrip = New StatusStrip()
      toolStripStatusLabelPort = New ToolStripStatusLabel()
      toolStripStatusLabelBaudRate = New ToolStripStatusLabel()
      imgListButtons = New ImageList(components)
      lblData = New Label()
      ToolStrip.SuspendLayout()
      StatusStrip.SuspendLayout()
      SuspendLayout()
      ' 
      ' ToolStrip
      ' 
      ToolStrip.Items.AddRange(New ToolStripItem() {toolStripBtnStart, toolStripBtnStop, toolStripBtnSettings})
      ToolStrip.Location = New Point(0, 0)
      ToolStrip.Name = "ToolStrip"
      ToolStrip.Size = New Size(438, 25)
      ToolStrip.TabIndex = 1
      ' 
      ' toolStripBtnStart
      ' 
      toolStripBtnStart.DisplayStyle = ToolStripItemDisplayStyle.Image
      toolStripBtnStart.Image = CType(resources.GetObject("toolStripBtnStart.Image"), Image)
      toolStripBtnStart.ImageTransparentColor = Color.Magenta
      toolStripBtnStart.Name = "toolStripBtnStart"
      toolStripBtnStart.Size = New Size(23, 22)
      ' 
      ' toolStripBtnStop
      ' 
      toolStripBtnStop.DisplayStyle = ToolStripItemDisplayStyle.Image
      toolStripBtnStop.Image = CType(resources.GetObject("toolStripBtnStop.Image"), Image)
      toolStripBtnStop.ImageTransparentColor = Color.Magenta
      toolStripBtnStop.Name = "toolStripBtnStop"
      toolStripBtnStop.Size = New Size(23, 22)
      ' 
      ' toolStripBtnSettings
      ' 
      toolStripBtnSettings.DisplayStyle = ToolStripItemDisplayStyle.Image
      toolStripBtnSettings.Image = CType(resources.GetObject("toolStripBtnSettings.Image"), Image)
      toolStripBtnSettings.ImageTransparentColor = Color.Magenta
      toolStripBtnSettings.Name = "toolStripBtnSettings"
      toolStripBtnSettings.Size = New Size(23, 22)
      ' 
      ' StatusStrip
      ' 
      StatusStrip.Items.AddRange(New ToolStripItem() {toolStripStatusLabelPort, toolStripStatusLabelBaudRate})
      StatusStrip.Location = New Point(0, 127)
      StatusStrip.Name = "StatusStrip"
      StatusStrip.Size = New Size(438, 22)
      StatusStrip.TabIndex = 2
      StatusStrip.Text = "StatusStrip1"
      ' 
      ' toolStripStatusLabelPort
      ' 
      toolStripStatusLabelPort.Name = "toolStripStatusLabelPort"
      toolStripStatusLabelPort.Size = New Size(32, 17)
      toolStripStatusLabelPort.Text = "Port:"
      ' 
      ' toolStripStatusLabelBaudRate
      ' 
      toolStripStatusLabelBaudRate.Name = "toolStripStatusLabelBaudRate"
      toolStripStatusLabelBaudRate.Size = New Size(60, 17)
      toolStripStatusLabelBaudRate.Text = "BaudRate:"
      ' 
      ' imgListButtons
      ' 
      imgListButtons.ColorDepth = ColorDepth.Depth32Bit
      imgListButtons.ImageStream = CType(resources.GetObject("imgListButtons.ImageStream"), ImageListStreamer)
      imgListButtons.TransparentColor = Color.Transparent
      imgListButtons.Images.SetKeyName(0, "play.png")
      imgListButtons.Images.SetKeyName(1, "stop.png")
      imgListButtons.Images.SetKeyName(2, "settings.png")
      ' 
      ' lblData
      ' 
      lblData.BorderStyle = BorderStyle.FixedSingle
      lblData.Dock = DockStyle.Fill
      lblData.Font = New Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
      lblData.Location = New Point(0, 25)
      lblData.Name = "lblData"
      lblData.Size = New Size(438, 102)
      lblData.TabIndex = 3
      lblData.Text = "Waiting for data..."
      lblData.TextAlign = ContentAlignment.MiddleCenter
      ' 
      ' frmPortRedirect
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(438, 149)
      Controls.Add(lblData)
      Controls.Add(StatusStrip)
      Controls.Add(ToolStrip)
      Icon = CType(resources.GetObject("$this.Icon"), Icon)
      Margin = New Padding(4, 3, 4, 3)
      Name = "frmPortRedirect"
      Text = "Port Redirect"
      ToolStrip.ResumeLayout(False)
      ToolStrip.PerformLayout()
      StatusStrip.ResumeLayout(False)
      StatusStrip.PerformLayout()
      ResumeLayout(False)
      PerformLayout()

   End Sub
   Friend WithEvents ToolStrip As ToolStrip
   Friend WithEvents toolStripBtnStart As ToolStripButton
   Friend WithEvents toolStripBtnStop As ToolStripButton
   Friend WithEvents toolStripBtnSettings As ToolStripButton
   Friend WithEvents StatusStrip As StatusStrip
   Friend WithEvents imgListButtons As ImageList
   Friend WithEvents lblData As Label
   Friend WithEvents toolStripStatusLabelPort As ToolStripStatusLabel
   Friend WithEvents toolStripStatusLabelBaudRate As ToolStripStatusLabel

End Class
