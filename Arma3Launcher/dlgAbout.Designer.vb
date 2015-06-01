<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAbout
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgAbout))
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.linkCav = New System.Windows.Forms.LinkLabel()
		Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Panel1.BackColor = System.Drawing.Color.Transparent
		Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
		Me.Panel1.Controls.Add(Me.linkCav)
		Me.Panel1.Controls.Add(Me.LinkLabel1)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.ForeColor = System.Drawing.Color.Transparent
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(277, 160)
		Me.Panel1.TabIndex = 4
		'
		'linkCav
		'
		Me.linkCav.BackColor = System.Drawing.Color.Transparent
		Me.linkCav.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.linkCav.ForeColor = System.Drawing.Color.White
		Me.linkCav.LinkColor = System.Drawing.Color.Gold
		Me.linkCav.Location = New System.Drawing.Point(12, 68)
		Me.linkCav.Name = "linkCav"
		Me.linkCav.Size = New System.Drawing.Size(252, 19)
		Me.linkCav.TabIndex = 5
		Me.linkCav.TabStop = True
		Me.linkCav.Text = "www.7thCavalry.us" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
		Me.linkCav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.linkCav.UseCompatibleTextRendering = True
		'
		'LinkLabel1
		'
		Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
		Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LinkLabel1.ForeColor = System.Drawing.Color.White
		Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(18, 40)
		Me.LinkLabel1.LinkColor = System.Drawing.Color.Gold
		Me.LinkLabel1.Location = New System.Drawing.Point(14, 100)
		Me.LinkLabel1.Name = "LinkLabel1"
		Me.LinkLabel1.Size = New System.Drawing.Size(249, 19)
		Me.LinkLabel1.TabIndex = 8
		Me.LinkLabel1.TabStop = True
		Me.LinkLabel1.Text = "Or find me on the 7th Cavalry Teamspeak"
		Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.LinkLabel1.UseCompatibleTextRendering = True
		'
		'Label2
		'
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Location = New System.Drawing.Point(11, 4)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(255, 30)
		Me.Label2.TabIndex = 7
		Me.Label2.Text = "Created by =7Cav=WO1.Raynor.D"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Location = New System.Drawing.Point(1, 36)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(275, 34)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Have questions or comments about the launcher?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Drop me a PM at:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Location = New System.Drawing.Point(7, 125)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(67, 26)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "v1.2.3 Beta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "01 Jun 2015"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dlgAbout
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(277, 160)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgAbout"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "About"
		Me.TopMost = True
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents linkCav As System.Windows.Forms.LinkLabel
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
	Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
