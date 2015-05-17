<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModLocations
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModLocations))
		Me.clbModLocations = New System.Windows.Forms.CheckedListBox()
		Me.btnAdd = New System.Windows.Forms.Button()
		Me.Delete = New System.Windows.Forms.Button()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'clbModLocations
		'
		Me.clbModLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.clbModLocations.FormattingEnabled = True
		Me.clbModLocations.HorizontalScrollbar = True
		Me.clbModLocations.IntegralHeight = False
		Me.clbModLocations.Location = New System.Drawing.Point(8, 37)
		Me.clbModLocations.Name = "clbModLocations"
		Me.clbModLocations.Size = New System.Drawing.Size(237, 103)
		Me.clbModLocations.TabIndex = 0
		'
		'btnAdd
		'
		Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.btnAdd.Location = New System.Drawing.Point(50, 8)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 1
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = True
		'
		'Delete
		'
		Me.Delete.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.Delete.Location = New System.Drawing.Point(128, 8)
		Me.Delete.Name = "Delete"
		Me.Delete.Size = New System.Drawing.Size(75, 23)
		Me.Delete.TabIndex = 3
		Me.Delete.Text = "Delete"
		Me.Delete.UseVisualStyleBackColor = True
		'
		'btnOK
		'
		Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnOK.Location = New System.Drawing.Point(89, 146)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 4
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'frmModLocations
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(252, 175)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.Delete)
		Me.Controls.Add(Me.btnAdd)
		Me.Controls.Add(Me.clbModLocations)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(262, 205)
		Me.Name = "frmModLocations"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Modfolder Locations"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents clbModLocations As System.Windows.Forms.CheckedListBox
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents Delete As System.Windows.Forms.Button
	Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
