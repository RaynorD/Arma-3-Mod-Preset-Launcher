<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroups
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
		Me.btnRename = New System.Windows.Forms.Button()
		Me.cmbGroup = New System.Windows.Forms.ComboBox()
		Me.btnRemove = New System.Windows.Forms.Button()
		Me.btnNew = New System.Windows.Forms.Button()
		Me.btnAdd = New System.Windows.Forms.Button()
		Me.btnDuplicate = New System.Windows.Forms.Button()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.lvModsCurrent = New System.Windows.Forms.ListView()
		Me.colModsCurrent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.lvModsAll = New System.Windows.Forms.ListView()
		Me.colModsAll = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnDown = New System.Windows.Forms.Button()
		Me.btnUp = New System.Windows.Forms.Button()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.GroupBox3.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnRename
		'
		Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnRename.Location = New System.Drawing.Point(248, 6)
		Me.btnRename.Name = "btnRename"
		Me.btnRename.Size = New System.Drawing.Size(62, 23)
		Me.btnRename.TabIndex = 18
		Me.btnRename.Text = "Rena&me"
		Me.btnRename.UseVisualStyleBackColor = True
		'
		'cmbGroup
		'
		Me.cmbGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmbGroup.FormattingEnabled = True
		Me.cmbGroup.Location = New System.Drawing.Point(6, 7)
		Me.cmbGroup.MaxDropDownItems = 20
		Me.cmbGroup.Name = "cmbGroup"
		Me.cmbGroup.Size = New System.Drawing.Size(178, 21)
		Me.cmbGroup.TabIndex = 1
		'
		'btnRemove
		'
		Me.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnRemove.Location = New System.Drawing.Point(-1, 99)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(75, 23)
		Me.btnRemove.TabIndex = 8
		Me.btnRemove.Text = "&Remove >>"
		Me.btnRemove.UseVisualStyleBackColor = True
		'
		'btnNew
		'
		Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnNew.Location = New System.Drawing.Point(190, 6)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(52, 23)
		Me.btnNew.TabIndex = 2
		Me.btnNew.Text = "&New"
		Me.btnNew.UseVisualStyleBackColor = True
		'
		'btnAdd
		'
		Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnAdd.Location = New System.Drawing.Point(-1, 70)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnAdd.TabIndex = 7
		Me.btnAdd.Text = "<< &Add"
		Me.btnAdd.UseVisualStyleBackColor = True
		'
		'btnDuplicate
		'
		Me.btnDuplicate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDuplicate.Location = New System.Drawing.Point(316, 6)
		Me.btnDuplicate.Name = "btnDuplicate"
		Me.btnDuplicate.Size = New System.Drawing.Size(65, 23)
		Me.btnDuplicate.TabIndex = 3
		Me.btnDuplicate.Text = "Du&plicate"
		Me.btnDuplicate.UseVisualStyleBackColor = True
		'
		'btnDelete
		'
		Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDelete.Location = New System.Drawing.Point(387, 6)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(52, 23)
		Me.btnDelete.TabIndex = 4
		Me.btnDelete.Text = "&Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.lvModsCurrent)
		Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(180, 236)
		Me.GroupBox3.TabIndex = 16
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Current Group"
		'
		'lvModsCurrent
		'
		Me.lvModsCurrent.AllowDrop = True
		Me.lvModsCurrent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lvModsCurrent.CausesValidation = False
		Me.lvModsCurrent.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colModsCurrent})
		Me.lvModsCurrent.FullRowSelect = True
		Me.lvModsCurrent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
		Me.lvModsCurrent.HideSelection = False
		Me.lvModsCurrent.LabelWrap = False
		Me.lvModsCurrent.Location = New System.Drawing.Point(6, 14)
		Me.lvModsCurrent.Name = "lvModsCurrent"
		Me.lvModsCurrent.Size = New System.Drawing.Size(168, 217)
		Me.lvModsCurrent.TabIndex = 19
		Me.lvModsCurrent.UseCompatibleStateImageBehavior = False
		Me.lvModsCurrent.View = System.Windows.Forms.View.Details
		'
		'colModsCurrent
		'
		Me.colModsCurrent.Text = "Mods"
		Me.colModsCurrent.Width = 147
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.lvModsAll)
		Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox4.Location = New System.Drawing.Point(262, 3)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(181, 236)
		Me.GroupBox4.TabIndex = 17
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "All Detected Mods"
		'
		'lvModsAll
		'
		Me.lvModsAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lvModsAll.CausesValidation = False
		Me.lvModsAll.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colModsAll})
		Me.lvModsAll.FullRowSelect = True
		Me.lvModsAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
		Me.lvModsAll.HideSelection = False
		Me.lvModsAll.LabelWrap = False
		Me.lvModsAll.Location = New System.Drawing.Point(6, 14)
		Me.lvModsAll.Name = "lvModsAll"
		Me.lvModsAll.Size = New System.Drawing.Size(169, 217)
		Me.lvModsAll.TabIndex = 20
		Me.lvModsAll.UseCompatibleStateImageBehavior = False
		Me.lvModsAll.View = System.Windows.Forms.View.Details
		'
		'colModsAll
		'
		Me.colModsAll.Text = "Mods"
		Me.colModsAll.Width = 147
		'
		'btnOK
		'
		Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(-1, 201)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 25)
		Me.btnOK.TabIndex = 19
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnDown
		'
		Me.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.btnDown.Image = Global.Arma3ModPresetLauncher.My.Resources.Resources.down_arrow_16px
		Me.btnDown.Location = New System.Drawing.Point(6, 6)
		Me.btnDown.Name = "btnDown"
		Me.btnDown.Size = New System.Drawing.Size(28, 32)
		Me.btnDown.TabIndex = 11
		Me.btnDown.UseVisualStyleBackColor = True
		Me.btnDown.Visible = False
		'
		'btnUp
		'
		Me.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.btnUp.Image = Global.Arma3ModPresetLauncher.My.Resources.Resources.up_arrow_16px
		Me.btnUp.Location = New System.Drawing.Point(40, 6)
		Me.btnUp.Name = "btnUp"
		Me.btnUp.Size = New System.Drawing.Size(28, 32)
		Me.btnUp.TabIndex = 10
		Me.btnUp.UseVisualStyleBackColor = True
		Me.btnUp.Visible = False
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 3
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 2, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 28)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(446, 242)
		Me.TableLayoutPanel1.TabIndex = 20
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnOK)
		Me.Panel1.Controls.Add(Me.btnRemove)
		Me.Panel1.Controls.Add(Me.btnAdd)
		Me.Panel1.Controls.Add(Me.btnDown)
		Me.Panel1.Controls.Add(Me.btnUp)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(186, 0)
		Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(73, 242)
		Me.Panel1.TabIndex = 0
		'
		'frmGroups
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(446, 270)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.btnRename)
		Me.Controls.Add(Me.cmbGroup)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.btnDuplicate)
		Me.Controls.Add(Me.btnNew)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(800, 1000)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(456, 200)
		Me.Name = "frmGroups"
		Me.ShowIcon = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Group Manager"
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnRename As System.Windows.Forms.Button
	Friend WithEvents btnDown As System.Windows.Forms.Button
	Friend WithEvents btnUp As System.Windows.Forms.Button
	Friend WithEvents cmbGroup As System.Windows.Forms.ComboBox
	Friend WithEvents btnRemove As System.Windows.Forms.Button
	Friend WithEvents btnNew As System.Windows.Forms.Button
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents btnDuplicate As System.Windows.Forms.Button
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
	Friend WithEvents lvModsCurrent As System.Windows.Forms.ListView
	Friend WithEvents colModsCurrent As System.Windows.Forms.ColumnHeader
	Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
	Friend WithEvents lvModsAll As System.Windows.Forms.ListView
	Friend WithEvents colModsAll As System.Windows.Forms.ColumnHeader
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
