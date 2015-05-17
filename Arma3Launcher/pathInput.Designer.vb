<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pathInput
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
		Me.lblPath = New System.Windows.Forms.Label()
		Me.txtPath = New System.Windows.Forms.TextBox()
		Me.btnBrowse = New System.Windows.Forms.Button()
		Me.btnConfirm = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'lblPath
		'
		Me.lblPath.Location = New System.Drawing.Point(22, 18)
		Me.lblPath.Name = "lblPath"
		Me.lblPath.Size = New System.Drawing.Size(378, 38)
		Me.lblPath.TabIndex = 0
		Me.lblPath.Text = "Arma 3 could not be found in the usual location. Please browse to or paste your A" & _
			"rma 3 directory path here. (You'll only do this once)"
		'
		'txtPath
		'
		Me.txtPath.Location = New System.Drawing.Point(24, 88)
		Me.txtPath.Name = "txtPath"
		Me.txtPath.Size = New System.Drawing.Size(375, 22)
		Me.txtPath.TabIndex = 1
		Me.txtPath.WordWrap = False
		'
		'btnBrowse
		'
		Me.btnBrowse.Location = New System.Drawing.Point(174, 59)
		Me.btnBrowse.Name = "btnBrowse"
		Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
		Me.btnBrowse.TabIndex = 2
		Me.btnBrowse.Text = "Browse..."
		Me.btnBrowse.UseVisualStyleBackColor = True
		'
		'btnConfirm
		'
		Me.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnConfirm.Location = New System.Drawing.Point(133, 127)
		Me.btnConfirm.Name = "btnConfirm"
		Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
		Me.btnConfirm.TabIndex = 4
		Me.btnConfirm.Text = "OK"
		Me.btnConfirm.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Location = New System.Drawing.Point(214, 127)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(75, 23)
		Me.btnExit.TabIndex = 5
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'pathInput
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(422, 157)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnConfirm)
		Me.Controls.Add(Me.btnBrowse)
		Me.Controls.Add(Me.txtPath)
		Me.Controls.Add(Me.lblPath)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "pathInput"
		Me.ShowIcon = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Arma 3 Location Needed"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblPath As System.Windows.Forms.Label
	Friend WithEvents txtPath As System.Windows.Forms.TextBox
	Friend WithEvents btnBrowse As System.Windows.Forms.Button
	Friend WithEvents btnConfirm As System.Windows.Forms.Button
	Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
