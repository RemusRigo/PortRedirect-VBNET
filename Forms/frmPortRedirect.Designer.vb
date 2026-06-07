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
      btnTSStart = New ToolStripButton()
      btnTSStop = New ToolStripButton()
      btnTSSep1 = New ToolStripSeparator()
      btnTSOpenLog = New ToolStripButton()
      btnTSSep2 = New ToolStripSeparator()
      btnTSSettings = New ToolStripButton()
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
      ToolStrip.Items.AddRange(New ToolStripItem() {btnTSStart, btnTSStop, btnTSSep1, btnTSOpenLog, btnTSSep2, btnTSSettings})
      ToolStrip.Location = New Point(0, 0)
      ToolStrip.Name = "ToolStrip"
      ToolStrip.Size = New Size(438, 25)
      ToolStrip.TabIndex = 1
      ' 
      ' btnTSStart
      ' 
      btnTSStart.DisplayStyle = ToolStripItemDisplayStyle.Image
      btnTSStart.Image = CType(resources.GetObject("btnTSStart.Image"), Image)
      btnTSStart.ImageTransparentColor = Color.Magenta
      btnTSStart.Name = "btnTSStart"
      btnTSStart.Size = New Size(23, 22)
      btnTSStart.ToolTipText = "Start Port Listening"
      ' 
      ' btnTSStop
      ' 
      btnTSStop.DisplayStyle = ToolStripItemDisplayStyle.Image
      btnTSStop.Image = CType(resources.GetObject("btnTSStop.Image"), Image)
      btnTSStop.ImageTransparentColor = Color.Magenta
      btnTSStop.Name = "btnTSStop"
      btnTSStop.Size = New Size(23, 22)
      btnTSStop.ToolTipText = "Stop Port Listening"
      ' 
      ' btnTSSep1
      ' 
      btnTSSep1.Name = "btnTSSep1"
      btnTSSep1.Size = New Size(6, 25)
      ' 
      ' btnTSOpenLog
      ' 
      btnTSOpenLog.DisplayStyle = ToolStripItemDisplayStyle.Image
      btnTSOpenLog.Image = CType(resources.GetObject("btnTSOpenLog.Image"), Image)
      btnTSOpenLog.ImageTransparentColor = Color.Magenta
      btnTSOpenLog.Name = "btnTSOpenLog"
      btnTSOpenLog.Size = New Size(23, 22)
      btnTSOpenLog.ToolTipText = "Open current log (from today)"
      ' 
      ' btnTSSep2
      ' 
      btnTSSep2.Name = "btnTSSep2"
      btnTSSep2.Size = New Size(6, 25)
      ' 
      ' btnTSSettings
      ' 
      btnTSSettings.DisplayStyle = ToolStripItemDisplayStyle.Image
      btnTSSettings.Image = CType(resources.GetObject("btnTSSettings.Image"), Image)
      btnTSSettings.ImageTransparentColor = Color.Magenta
      btnTSSettings.Name = "btnTSSettings"
      btnTSSettings.Size = New Size(23, 22)
      btnTSSettings.ToolTipText = "Open Settings"
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
   Friend WithEvents btnTSStart As ToolStripButton
   Friend WithEvents btnTSStop As ToolStripButton
   Friend WithEvents btnTSSettings As ToolStripButton
   Friend WithEvents StatusStrip As StatusStrip
   Friend WithEvents imgListButtons As ImageList
   Friend WithEvents lblData As Label
   Friend WithEvents toolStripStatusLabelPort As ToolStripStatusLabel
   Friend WithEvents toolStripStatusLabelBaudRate As ToolStripStatusLabel
   Friend WithEvents btnTSSep1 As ToolStripSeparator
   Friend WithEvents btnTSOpenLog As ToolStripButton
   Friend WithEvents btnTSSep2 As ToolStripSeparator

End Class
