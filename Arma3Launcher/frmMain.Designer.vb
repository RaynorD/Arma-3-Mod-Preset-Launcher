<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.cmbPreset = New System.Windows.Forms.ComboBox()
		Me.btnNew = New System.Windows.Forms.Button()
		Me.btnDuplicate = New System.Windows.Forms.Button()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnPresetAdd = New System.Windows.Forms.Button()
		Me.btnPresetRemove = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.btnGroups = New System.Windows.Forms.Button()
		Me.btnDown = New System.Windows.Forms.Button()
		Me.btnUp = New System.Windows.Forms.Button()
		Me.gbCurrent = New System.Windows.Forms.GroupBox()
		Me.lvModsCurrent = New System.Windows.Forms.ListView()
		Me.colModsCurrent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.gbAll = New System.Windows.Forms.GroupBox()
		Me.lvModsAll = New System.Windows.Forms.ListView()
		Me.colModsAll = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.btnRename = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.txtCustomParameters = New System.Windows.Forms.TextBox()
		Me.chkCustomArguments = New System.Windows.Forms.CheckBox()
		Me.chkProfileName = New System.Windows.Forms.CheckBox()
		Me.chkCustomMemoryAllocator = New System.Windows.Forms.CheckBox()
		Me.cmbProfileName = New System.Windows.Forms.ComboBox()
		Me.cmbCustomMemoryAllocator = New System.Windows.Forms.ComboBox()
		Me.chkWindowed = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbLaunchAction = New System.Windows.Forms.ComboBox()
		Me.chkNoFilePatching = New System.Windows.Forms.CheckBox()
		Me.chkNoLogs = New System.Windows.Forms.CheckBox()
		Me.tbarExThreads = New System.Windows.Forms.TrackBar()
		Me.tBarCPUCount = New System.Windows.Forms.TrackBar()
		Me.lblExThreads = New System.Windows.Forms.Label()
		Me.lblCPUCount = New System.Windows.Forms.Label()
		Me.chkExThreads = New System.Windows.Forms.CheckBox()
		Me.lblVRAM = New System.Windows.Forms.Label()
		Me.tBarVRAM = New System.Windows.Forms.TrackBar()
		Me.lblMem = New System.Windows.Forms.Label()
		Me.tbarMem = New System.Windows.Forms.TrackBar()
		Me.chkCPU = New System.Windows.Forms.CheckBox()
		Me.chkVRAM = New System.Windows.Forms.CheckBox()
		Me.chkMem = New System.Windows.Forms.CheckBox()
		Me.chkSkipIntro = New System.Windows.Forms.CheckBox()
		Me.chkNoPause = New System.Windows.Forms.CheckBox()
		Me.chkShowScriptErrors = New System.Windows.Forms.CheckBox()
		Me.chkEmptyWorld = New System.Windows.Forms.CheckBox()
		Me.chkNoSplash = New System.Windows.Forms.CheckBox()
		Me.btnLaunch = New System.Windows.Forms.Button()
		Me.txtLaunchString = New System.Windows.Forms.TextBox()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.txtStatus = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
		Me.OnDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.InStartMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ChooseLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.InSteamLibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
		Me.tsiSetAltLoc = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsiRunBattlEye = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
		Me.tsbUsage = New System.Windows.Forms.ToolStripMenuItem()
		Me.tsbAbout = New System.Windows.Forms.ToolStripMenuItem()
		Me.A3StartupParametersWikiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolTipCurrent = New System.Windows.Forms.ToolTip(Me.components)
		Me.ToolTipAll = New System.Windows.Forms.ToolTip(Me.components)
		Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
		Me.GroupBox1.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.gbCurrent.SuspendLayout()
		Me.gbAll.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.tbarExThreads, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tBarCPUCount, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tBarVRAM, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tbarMem, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.ToolStrip1.SuspendLayout()
		CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'cmbPreset
		'
		Me.cmbPreset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPreset.FormattingEnabled = True
		Me.cmbPreset.Location = New System.Drawing.Point(5, 16)
		Me.cmbPreset.MaxDropDownItems = 20
		Me.cmbPreset.Name = "cmbPreset"
		Me.cmbPreset.Size = New System.Drawing.Size(183, 21)
		Me.cmbPreset.TabIndex = 1
		'
		'btnNew
		'
		Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnNew.Location = New System.Drawing.Point(194, 15)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(52, 23)
		Me.btnNew.TabIndex = 2
		Me.btnNew.Text = "&New"
		Me.btnNew.UseVisualStyleBackColor = True
		'
		'btnDuplicate
		'
		Me.btnDuplicate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDuplicate.Location = New System.Drawing.Point(320, 15)
		Me.btnDuplicate.Name = "btnDuplicate"
		Me.btnDuplicate.Size = New System.Drawing.Size(65, 23)
		Me.btnDuplicate.TabIndex = 3
		Me.btnDuplicate.Text = "Du&plicate"
		Me.btnDuplicate.UseVisualStyleBackColor = True
		'
		'btnDelete
		'
		Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnDelete.Location = New System.Drawing.Point(391, 15)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(50, 23)
		Me.btnDelete.TabIndex = 4
		Me.btnDelete.Text = "&Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnPresetAdd
		'
		Me.btnPresetAdd.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnPresetAdd.Location = New System.Drawing.Point(-1, 69)
		Me.btnPresetAdd.Name = "btnPresetAdd"
		Me.btnPresetAdd.Size = New System.Drawing.Size(75, 23)
		Me.btnPresetAdd.TabIndex = 7
		Me.btnPresetAdd.Text = "<< &Add"
		Me.btnPresetAdd.UseVisualStyleBackColor = True
		'
		'btnPresetRemove
		'
		Me.btnPresetRemove.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnPresetRemove.Location = New System.Drawing.Point(-1, 98)
		Me.btnPresetRemove.Name = "btnPresetRemove"
		Me.btnPresetRemove.Size = New System.Drawing.Size(75, 23)
		Me.btnPresetRemove.TabIndex = 8
		Me.btnPresetRemove.Text = "&Remove >>"
		Me.btnPresetRemove.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
		Me.GroupBox1.Controls.Add(Me.btnRename)
		Me.GroupBox1.Controls.Add(Me.cmbPreset)
		Me.GroupBox1.Controls.Add(Me.btnNew)
		Me.GroupBox1.Controls.Add(Me.btnDuplicate)
		Me.GroupBox1.Controls.Add(Me.btnDelete)
		Me.GroupBox1.Location = New System.Drawing.Point(6, 23)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(447, 279)
		Me.GroupBox1.TabIndex = 9
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Mod Presets"
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
		Me.TableLayoutPanel1.Controls.Add(Me.gbCurrent, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.gbAll, 2, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 39)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(443, 238)
		Me.TableLayoutPanel1.TabIndex = 20
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.btnGroups)
		Me.Panel1.Controls.Add(Me.btnPresetRemove)
		Me.Panel1.Controls.Add(Me.btnPresetAdd)
		Me.Panel1.Controls.Add(Me.btnDown)
		Me.Panel1.Controls.Add(Me.btnUp)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(185, 0)
		Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(73, 238)
		Me.Panel1.TabIndex = 0
		'
		'btnGroups
		'
		Me.btnGroups.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnGroups.Location = New System.Drawing.Point(-1, 198)
		Me.btnGroups.Name = "btnGroups"
		Me.btnGroups.Size = New System.Drawing.Size(75, 25)
		Me.btnGroups.TabIndex = 19
		Me.btnGroups.Text = "Groups..."
		Me.btnGroups.UseVisualStyleBackColor = True
		'
		'btnDown
		'
		Me.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.btnDown.Image = Global.Arma3ModPresetLauncher.My.Resources.Resources.down_arrow_16px
		Me.btnDown.Location = New System.Drawing.Point(5, 11)
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
		Me.btnUp.Location = New System.Drawing.Point(39, 11)
		Me.btnUp.Name = "btnUp"
		Me.btnUp.Size = New System.Drawing.Size(28, 32)
		Me.btnUp.TabIndex = 10
		Me.btnUp.UseVisualStyleBackColor = True
		Me.btnUp.Visible = False
		'
		'gbCurrent
		'
		Me.gbCurrent.Controls.Add(Me.lvModsCurrent)
		Me.gbCurrent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gbCurrent.Location = New System.Drawing.Point(3, 3)
		Me.gbCurrent.Name = "gbCurrent"
		Me.gbCurrent.Size = New System.Drawing.Size(179, 232)
		Me.gbCurrent.TabIndex = 16
		Me.gbCurrent.TabStop = False
		Me.gbCurrent.Text = "Current Preset"
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
		Me.lvModsCurrent.Location = New System.Drawing.Point(5, 13)
		Me.lvModsCurrent.Name = "lvModsCurrent"
		Me.lvModsCurrent.Size = New System.Drawing.Size(169, 214)
		Me.lvModsCurrent.TabIndex = 19
		Me.lvModsCurrent.UseCompatibleStateImageBehavior = False
		Me.lvModsCurrent.View = System.Windows.Forms.View.Details
		'
		'colModsCurrent
		'
		Me.colModsCurrent.Text = "Mods"
		Me.colModsCurrent.Width = 147
		'
		'gbAll
		'
		Me.gbAll.Controls.Add(Me.lvModsAll)
		Me.gbAll.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gbAll.Location = New System.Drawing.Point(261, 3)
		Me.gbAll.Name = "gbAll"
		Me.gbAll.Size = New System.Drawing.Size(179, 232)
		Me.gbAll.TabIndex = 17
		Me.gbAll.TabStop = False
		Me.gbAll.Text = "All Detected Mods"
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
		Me.lvModsAll.Location = New System.Drawing.Point(5, 13)
		Me.lvModsAll.Name = "lvModsAll"
		Me.lvModsAll.Size = New System.Drawing.Size(169, 214)
		Me.lvModsAll.TabIndex = 20
		Me.lvModsAll.UseCompatibleStateImageBehavior = False
		Me.lvModsAll.View = System.Windows.Forms.View.Details
		'
		'colModsAll
		'
		Me.colModsAll.Text = "Mods"
		Me.colModsAll.Width = 147
		'
		'btnRename
		'
		Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnRename.Location = New System.Drawing.Point(252, 15)
		Me.btnRename.Name = "btnRename"
		Me.btnRename.Size = New System.Drawing.Size(62, 23)
		Me.btnRename.TabIndex = 18
		Me.btnRename.Text = "Rena&me"
		Me.btnRename.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GroupBox2.Controls.Add(Me.txtCustomParameters)
		Me.GroupBox2.Controls.Add(Me.chkCustomArguments)
		Me.GroupBox2.Controls.Add(Me.chkProfileName)
		Me.GroupBox2.Controls.Add(Me.chkCustomMemoryAllocator)
		Me.GroupBox2.Controls.Add(Me.cmbProfileName)
		Me.GroupBox2.Controls.Add(Me.cmbCustomMemoryAllocator)
		Me.GroupBox2.Controls.Add(Me.chkWindowed)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Controls.Add(Me.cmbLaunchAction)
		Me.GroupBox2.Controls.Add(Me.chkNoFilePatching)
		Me.GroupBox2.Controls.Add(Me.chkNoLogs)
		Me.GroupBox2.Controls.Add(Me.tbarExThreads)
		Me.GroupBox2.Controls.Add(Me.tBarCPUCount)
		Me.GroupBox2.Controls.Add(Me.lblExThreads)
		Me.GroupBox2.Controls.Add(Me.lblCPUCount)
		Me.GroupBox2.Controls.Add(Me.chkExThreads)
		Me.GroupBox2.Controls.Add(Me.lblVRAM)
		Me.GroupBox2.Controls.Add(Me.tBarVRAM)
		Me.GroupBox2.Controls.Add(Me.lblMem)
		Me.GroupBox2.Controls.Add(Me.tbarMem)
		Me.GroupBox2.Controls.Add(Me.chkCPU)
		Me.GroupBox2.Controls.Add(Me.chkVRAM)
		Me.GroupBox2.Controls.Add(Me.chkMem)
		Me.GroupBox2.Controls.Add(Me.chkSkipIntro)
		Me.GroupBox2.Controls.Add(Me.chkNoPause)
		Me.GroupBox2.Controls.Add(Me.chkShowScriptErrors)
		Me.GroupBox2.Controls.Add(Me.chkEmptyWorld)
		Me.GroupBox2.Controls.Add(Me.chkNoSplash)
		Me.GroupBox2.Location = New System.Drawing.Point(6, 306)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(447, 298)
		Me.GroupBox2.TabIndex = 10
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Additional Parameters"
		'
		'txtCustomParameters
		'
		Me.txtCustomParameters.Location = New System.Drawing.Point(156, 265)
		Me.txtCustomParameters.Name = "txtCustomParameters"
		Me.txtCustomParameters.Size = New System.Drawing.Size(256, 22)
		Me.txtCustomParameters.TabIndex = 32
		'
		'chkCustomArguments
		'
		Me.chkCustomArguments.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkCustomArguments.AutoSize = True
		Me.chkCustomArguments.Location = New System.Drawing.Point(27, 268)
		Me.chkCustomArguments.Name = "chkCustomArguments"
		Me.chkCustomArguments.Size = New System.Drawing.Size(127, 17)
		Me.chkCustomArguments.TabIndex = 31
		Me.chkCustomArguments.Text = "Custom Arguments:"
		Me.chkCustomArguments.UseVisualStyleBackColor = True
		'
		'chkProfileName
		'
		Me.chkProfileName.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkProfileName.AutoSize = True
		Me.chkProfileName.Location = New System.Drawing.Point(27, 239)
		Me.chkProfileName.Name = "chkProfileName"
		Me.chkProfileName.Size = New System.Drawing.Size(94, 17)
		Me.chkProfileName.TabIndex = 29
		Me.chkProfileName.Text = "Profile Name:"
		Me.chkProfileName.UseVisualStyleBackColor = True
		'
		'chkCustomMemoryAllocator
		'
		Me.chkCustomMemoryAllocator.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkCustomMemoryAllocator.AutoSize = True
		Me.chkCustomMemoryAllocator.Location = New System.Drawing.Point(27, 212)
		Me.chkCustomMemoryAllocator.Name = "chkCustomMemoryAllocator"
		Me.chkCustomMemoryAllocator.Size = New System.Drawing.Size(161, 17)
		Me.chkCustomMemoryAllocator.TabIndex = 28
		Me.chkCustomMemoryAllocator.Text = "Custom Memory Allocator:"
		Me.chkCustomMemoryAllocator.UseVisualStyleBackColor = True
		'
		'cmbProfileName
		'
		Me.cmbProfileName.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.cmbProfileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbProfileName.Enabled = False
		Me.cmbProfileName.FormattingEnabled = True
		Me.cmbProfileName.Location = New System.Drawing.Point(127, 236)
		Me.cmbProfileName.Name = "cmbProfileName"
		Me.cmbProfileName.Size = New System.Drawing.Size(283, 21)
		Me.cmbProfileName.TabIndex = 26
		'
		'cmbCustomMemoryAllocator
		'
		Me.cmbCustomMemoryAllocator.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.cmbCustomMemoryAllocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCustomMemoryAllocator.Enabled = False
		Me.cmbCustomMemoryAllocator.FormattingEnabled = True
		Me.cmbCustomMemoryAllocator.Location = New System.Drawing.Point(192, 209)
		Me.cmbCustomMemoryAllocator.Name = "cmbCustomMemoryAllocator"
		Me.cmbCustomMemoryAllocator.Size = New System.Drawing.Size(218, 21)
		Me.cmbCustomMemoryAllocator.TabIndex = 24
		'
		'chkWindowed
		'
		Me.chkWindowed.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkWindowed.AutoSize = True
		Me.chkWindowed.Location = New System.Drawing.Point(27, 182)
		Me.chkWindowed.Name = "chkWindowed"
		Me.chkWindowed.Size = New System.Drawing.Size(83, 17)
		Me.chkWindowed.TabIndex = 23
		Me.chkWindowed.Text = "Windowed"
		Me.chkWindowed.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.Label1.Location = New System.Drawing.Point(195, 174)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(98, 21)
		Me.Label1.TabIndex = 22
		Me.Label1.Text = "On Game Launch:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cmbLaunchAction
		'
		Me.cmbLaunchAction.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.cmbLaunchAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbLaunchAction.FormattingEnabled = True
		Me.cmbLaunchAction.Items.AddRange(New Object() {"Nothing", "Minimize", "Close"})
		Me.cmbLaunchAction.Location = New System.Drawing.Point(296, 175)
		Me.cmbLaunchAction.Name = "cmbLaunchAction"
		Me.cmbLaunchAction.Size = New System.Drawing.Size(114, 21)
		Me.cmbLaunchAction.TabIndex = 21
		'
		'chkNoFilePatching
		'
		Me.chkNoFilePatching.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkNoFilePatching.AutoSize = True
		Me.chkNoFilePatching.Location = New System.Drawing.Point(27, 159)
		Me.chkNoFilePatching.Name = "chkNoFilePatching"
		Me.chkNoFilePatching.Size = New System.Drawing.Size(110, 17)
		Me.chkNoFilePatching.TabIndex = 20
		Me.chkNoFilePatching.Text = "No File Patching"
		Me.chkNoFilePatching.UseVisualStyleBackColor = True
		'
		'chkNoLogs
		'
		Me.chkNoLogs.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkNoLogs.AutoSize = True
		Me.chkNoLogs.Location = New System.Drawing.Point(27, 136)
		Me.chkNoLogs.Name = "chkNoLogs"
		Me.chkNoLogs.Size = New System.Drawing.Size(68, 17)
		Me.chkNoLogs.TabIndex = 19
		Me.chkNoLogs.Text = "No Logs"
		Me.chkNoLogs.UseVisualStyleBackColor = True
		'
		'tbarExThreads
		'
		Me.tbarExThreads.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.tbarExThreads.AutoSize = False
		Me.tbarExThreads.Enabled = False
		Me.tbarExThreads.LargeChange = 1
		Me.tbarExThreads.Location = New System.Drawing.Point(289, 133)
		Me.tbarExThreads.Maximum = 4
		Me.tbarExThreads.Name = "tbarExThreads"
		Me.tbarExThreads.Size = New System.Drawing.Size(99, 27)
		Me.tbarExThreads.TabIndex = 12
		Me.tbarExThreads.Value = 4
		'
		'tBarCPUCount
		'
		Me.tBarCPUCount.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.tBarCPUCount.AutoSize = False
		Me.tBarCPUCount.Enabled = False
		Me.tBarCPUCount.LargeChange = 1
		Me.tBarCPUCount.Location = New System.Drawing.Point(289, 95)
		Me.tBarCPUCount.Maximum = 4
		Me.tBarCPUCount.Minimum = 1
		Me.tBarCPUCount.Name = "tBarCPUCount"
		Me.tBarCPUCount.Size = New System.Drawing.Size(99, 27)
		Me.tBarCPUCount.SmallChange = 2
		Me.tBarCPUCount.TabIndex = 10
		Me.tBarCPUCount.Value = 4
		'
		'lblExThreads
		'
		Me.lblExThreads.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.lblExThreads.Enabled = False
		Me.lblExThreads.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblExThreads.Location = New System.Drawing.Point(385, 139)
		Me.lblExThreads.Name = "lblExThreads"
		Me.lblExThreads.Size = New System.Drawing.Size(51, 14)
		Me.lblExThreads.TabIndex = 18
		Me.lblExThreads.Text = "Auto"
		Me.lblExThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCPUCount
		'
		Me.lblCPUCount.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.lblCPUCount.Enabled = False
		Me.lblCPUCount.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCPUCount.Location = New System.Drawing.Point(385, 101)
		Me.lblCPUCount.Name = "lblCPUCount"
		Me.lblCPUCount.Size = New System.Drawing.Size(51, 14)
		Me.lblCPUCount.TabIndex = 17
		Me.lblCPUCount.Text = "Auto"
		Me.lblCPUCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'chkExThreads
		'
		Me.chkExThreads.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkExThreads.AutoSize = True
		Me.chkExThreads.Location = New System.Drawing.Point(198, 139)
		Me.chkExThreads.Name = "chkExThreads"
		Me.chkExThreads.Size = New System.Drawing.Size(97, 17)
		Me.chkExThreads.TabIndex = 11
		Me.chkExThreads.Text = "Extra Threads:"
		Me.chkExThreads.UseVisualStyleBackColor = True
		'
		'lblVRAM
		'
		Me.lblVRAM.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.lblVRAM.Enabled = False
		Me.lblVRAM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblVRAM.Location = New System.Drawing.Point(385, 64)
		Me.lblVRAM.Name = "lblVRAM"
		Me.lblVRAM.Size = New System.Drawing.Size(51, 14)
		Me.lblVRAM.TabIndex = 11
		Me.lblVRAM.Text = "Auto"
		Me.lblVRAM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tBarVRAM
		'
		Me.tBarVRAM.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.tBarVRAM.AutoSize = False
		Me.tBarVRAM.Enabled = False
		Me.tBarVRAM.LargeChange = 1
		Me.tBarVRAM.Location = New System.Drawing.Point(289, 58)
		Me.tBarVRAM.Maximum = 4
		Me.tBarVRAM.Minimum = 1
		Me.tBarVRAM.Name = "tBarVRAM"
		Me.tBarVRAM.Size = New System.Drawing.Size(99, 27)
		Me.tBarVRAM.SmallChange = 0
		Me.tBarVRAM.TabIndex = 8
		Me.tBarVRAM.Value = 4
		'
		'lblMem
		'
		Me.lblMem.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.lblMem.Enabled = False
		Me.lblMem.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMem.Location = New System.Drawing.Point(385, 25)
		Me.lblMem.Name = "lblMem"
		Me.lblMem.Size = New System.Drawing.Size(51, 14)
		Me.lblMem.TabIndex = 9
		Me.lblMem.Text = "Auto"
		Me.lblMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'tbarMem
		'
		Me.tbarMem.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.tbarMem.AutoSize = False
		Me.tbarMem.Enabled = False
		Me.tbarMem.LargeChange = 1
		Me.tbarMem.Location = New System.Drawing.Point(289, 19)
		Me.tbarMem.Maximum = 4
		Me.tbarMem.Minimum = 1
		Me.tbarMem.Name = "tbarMem"
		Me.tbarMem.Size = New System.Drawing.Size(99, 27)
		Me.tbarMem.SmallChange = 0
		Me.tbarMem.TabIndex = 6
		Me.tbarMem.Value = 4
		'
		'chkCPU
		'
		Me.chkCPU.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkCPU.AutoSize = True
		Me.chkCPU.Location = New System.Drawing.Point(198, 101)
		Me.chkCPU.Name = "chkCPU"
		Me.chkCPU.Size = New System.Drawing.Size(85, 17)
		Me.chkCPU.TabIndex = 9
		Me.chkCPU.Text = "CPU Count:"
		Me.chkCPU.UseVisualStyleBackColor = True
		'
		'chkVRAM
		'
		Me.chkVRAM.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkVRAM.AutoSize = True
		Me.chkVRAM.Location = New System.Drawing.Point(198, 64)
		Me.chkVRAM.Name = "chkVRAM"
		Me.chkVRAM.Size = New System.Drawing.Size(84, 17)
		Me.chkVRAM.TabIndex = 7
		Me.chkVRAM.Text = "Max VRAM:"
		Me.chkVRAM.UseVisualStyleBackColor = True
		'
		'chkMem
		'
		Me.chkMem.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkMem.AutoSize = True
		Me.chkMem.Location = New System.Drawing.Point(198, 25)
		Me.chkMem.Name = "chkMem"
		Me.chkMem.Size = New System.Drawing.Size(94, 17)
		Me.chkMem.TabIndex = 5
		Me.chkMem.Text = "Max Memory:"
		Me.chkMem.UseVisualStyleBackColor = True
		'
		'chkSkipIntro
		'
		Me.chkSkipIntro.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkSkipIntro.AutoSize = True
		Me.chkSkipIntro.Location = New System.Drawing.Point(27, 113)
		Me.chkSkipIntro.Name = "chkSkipIntro"
		Me.chkSkipIntro.Size = New System.Drawing.Size(76, 17)
		Me.chkSkipIntro.TabIndex = 4
		Me.chkSkipIntro.Text = "Skip Intro"
		Me.chkSkipIntro.UseVisualStyleBackColor = True
		'
		'chkNoPause
		'
		Me.chkNoPause.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkNoPause.AutoSize = True
		Me.chkNoPause.Location = New System.Drawing.Point(27, 90)
		Me.chkNoPause.Name = "chkNoPause"
		Me.chkNoPause.Size = New System.Drawing.Size(153, 17)
		Me.chkNoPause.TabIndex = 3
		Me.chkNoPause.Text = "No Pause on Task Switch"
		Me.chkNoPause.UseVisualStyleBackColor = True
		'
		'chkShowScriptErrors
		'
		Me.chkShowScriptErrors.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkShowScriptErrors.AutoSize = True
		Me.chkShowScriptErrors.Location = New System.Drawing.Point(27, 67)
		Me.chkShowScriptErrors.Name = "chkShowScriptErrors"
		Me.chkShowScriptErrors.Size = New System.Drawing.Size(120, 17)
		Me.chkShowScriptErrors.TabIndex = 2
		Me.chkShowScriptErrors.Text = "Show Script Errors"
		Me.chkShowScriptErrors.UseVisualStyleBackColor = True
		'
		'chkEmptyWorld
		'
		Me.chkEmptyWorld.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkEmptyWorld.AutoSize = True
		Me.chkEmptyWorld.Location = New System.Drawing.Point(27, 44)
		Me.chkEmptyWorld.Name = "chkEmptyWorld"
		Me.chkEmptyWorld.Size = New System.Drawing.Size(133, 17)
		Me.chkEmptyWorld.TabIndex = 1
		Me.chkEmptyWorld.Text = "Empty Default World"
		Me.chkEmptyWorld.UseVisualStyleBackColor = True
		'
		'chkNoSplash
		'
		Me.chkNoSplash.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.chkNoSplash.AutoSize = True
		Me.chkNoSplash.Location = New System.Drawing.Point(27, 21)
		Me.chkNoSplash.Name = "chkNoSplash"
		Me.chkNoSplash.Size = New System.Drawing.Size(115, 17)
		Me.chkNoSplash.TabIndex = 0
		Me.chkNoSplash.Text = "No Splash Screen"
		Me.chkNoSplash.UseVisualStyleBackColor = True
		'
		'btnLaunch
		'
		Me.btnLaunch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnLaunch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnLaunch.Location = New System.Drawing.Point(5, 610)
		Me.btnLaunch.Name = "btnLaunch"
		Me.btnLaunch.Size = New System.Drawing.Size(88, 40)
		Me.btnLaunch.TabIndex = 11
		Me.btnLaunch.Text = "&Launch"
		Me.btnLaunch.UseVisualStyleBackColor = True
		'
		'txtLaunchString
		'
		Me.txtLaunchString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtLaunchString.Location = New System.Drawing.Point(100, 611)
		Me.txtLaunchString.Multiline = True
		Me.txtLaunchString.Name = "txtLaunchString"
		Me.txtLaunchString.ReadOnly = True
		Me.txtLaunchString.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.txtLaunchString.Size = New System.Drawing.Size(353, 38)
		Me.txtLaunchString.TabIndex = 12
		Me.txtLaunchString.WordWrap = False
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStatus})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 654)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(458, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 13
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'txtStatus
		'
		Me.txtStatus.Name = "txtStatus"
		Me.txtStatus.Size = New System.Drawing.Size(10, 17)
		Me.txtStatus.Text = " "
		'
		'ToolStrip1
		'
		Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRefresh, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton3, Me.ToolStripDropDownButton2})
		Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(458, 25)
		Me.ToolStrip1.Stretch = True
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'btnRefresh
		'
		Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
		Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(95, 22)
		Me.btnRefresh.Text = "Re&fresh/Save"
		Me.btnRefresh.ToolTipText = "Reload list of modfolders"
		'
		'ToolStripDropDownButton1
		'
		Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnDesktopToolStripMenuItem, Me.InStartMenuToolStripMenuItem, Me.ChooseLocationToolStripMenuItem, Me.InSteamLibraryToolStripMenuItem})
		Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
		Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
		Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(118, 22)
		Me.ToolStripDropDownButton1.Text = "Create Shortcut"
		Me.ToolStripDropDownButton1.ToolTipText = "Create a shortcut to launch the current preset and settings"
		'
		'OnDesktopToolStripMenuItem
		'
		Me.OnDesktopToolStripMenuItem.Name = "OnDesktopToolStripMenuItem"
		Me.OnDesktopToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
		Me.OnDesktopToolStripMenuItem.Text = "On Desktop..."
		'
		'InStartMenuToolStripMenuItem
		'
		Me.InStartMenuToolStripMenuItem.Name = "InStartMenuToolStripMenuItem"
		Me.InStartMenuToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
		Me.InStartMenuToolStripMenuItem.Text = "In Start Menu..."
		Me.InStartMenuToolStripMenuItem.Visible = False
		'
		'ChooseLocationToolStripMenuItem
		'
		Me.ChooseLocationToolStripMenuItem.Name = "ChooseLocationToolStripMenuItem"
		Me.ChooseLocationToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
		Me.ChooseLocationToolStripMenuItem.Text = "Choose Location..."
		'
		'InSteamLibraryToolStripMenuItem
		'
		Me.InSteamLibraryToolStripMenuItem.Name = "InSteamLibraryToolStripMenuItem"
		Me.InSteamLibraryToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
		Me.InSteamLibraryToolStripMenuItem.Text = "In Steam Library..."
		Me.InSteamLibraryToolStripMenuItem.Visible = False
		'
		'ToolStripDropDownButton3
		'
		Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiSetAltLoc, Me.tsiRunBattlEye})
		Me.ToolStripDropDownButton3.Image = Global.Arma3ModPresetLauncher.My.Resources.Resources.options_16px
		Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
		Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(78, 22)
		Me.ToolStripDropDownButton3.Text = "Options"
		'
		'tsiSetAltLoc
		'
		Me.tsiSetAltLoc.Name = "tsiSetAltLoc"
		Me.tsiSetAltLoc.Size = New System.Drawing.Size(193, 22)
		Me.tsiSetAltLoc.Text = "Modfolder Locations..."
		'
		'tsiRunBattlEye
		'
		Me.tsiRunBattlEye.Checked = True
		Me.tsiRunBattlEye.CheckOnClick = True
		Me.tsiRunBattlEye.CheckState = System.Windows.Forms.CheckState.Checked
		Me.tsiRunBattlEye.Name = "tsiRunBattlEye"
		Me.tsiRunBattlEye.Size = New System.Drawing.Size(193, 22)
		Me.tsiRunBattlEye.Text = "Run BattlEye"
		'
		'ToolStripDropDownButton2
		'
		Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbUsage, Me.tsbAbout, Me.A3StartupParametersWikiToolStripMenuItem})
		Me.ToolStripDropDownButton2.Image = Global.Arma3ModPresetLauncher.My.Resources.Resources.info_16px
		Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
		Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(61, 22)
		Me.ToolStripDropDownButton2.Text = "Help"
		'
		'tsbUsage
		'
		Me.tsbUsage.Name = "tsbUsage"
		Me.tsbUsage.Size = New System.Drawing.Size(193, 22)
		Me.tsbUsage.Text = "Usage..."
		'
		'tsbAbout
		'
		Me.tsbAbout.Name = "tsbAbout"
		Me.tsbAbout.Size = New System.Drawing.Size(193, 22)
		Me.tsbAbout.Text = "About..."
		'
		'A3StartupParametersWikiToolStripMenuItem
		'
		Me.A3StartupParametersWikiToolStripMenuItem.Name = "A3StartupParametersWikiToolStripMenuItem"
		Me.A3StartupParametersWikiToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
		Me.A3StartupParametersWikiToolStripMenuItem.Text = "Startup Parameter Info"
		'
		'FileSystemWatcher1
		'
		Me.FileSystemWatcher1.EnableRaisingEvents = True
		Me.FileSystemWatcher1.SynchronizingObject = Me
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(458, 676)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.txtLaunchString)
		Me.Controls.Add(Me.btnLaunch)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(1000, 1440)
		Me.MinimumSize = New System.Drawing.Size(472, 712)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Arma 3 Mod Preset Launcher - v1.2.3"
		Me.GroupBox1.ResumeLayout(False)
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.gbCurrent.ResumeLayout(False)
		Me.gbAll.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.tbarExThreads, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tBarCPUCount, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tBarVRAM, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tbarMem, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
	Friend WithEvents cmbPreset As System.Windows.Forms.ComboBox
	Friend WithEvents btnNew As System.Windows.Forms.Button
	Friend WithEvents btnDuplicate As System.Windows.Forms.Button
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents btnPresetAdd As System.Windows.Forms.Button
	Friend WithEvents btnPresetRemove As System.Windows.Forms.Button
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents chkCPU As System.Windows.Forms.CheckBox
	Friend WithEvents chkVRAM As System.Windows.Forms.CheckBox
	Friend WithEvents chkMem As System.Windows.Forms.CheckBox
	Friend WithEvents chkSkipIntro As System.Windows.Forms.CheckBox
	Friend WithEvents chkNoPause As System.Windows.Forms.CheckBox
	Friend WithEvents chkShowScriptErrors As System.Windows.Forms.CheckBox
	Friend WithEvents chkEmptyWorld As System.Windows.Forms.CheckBox
	Friend WithEvents chkNoSplash As System.Windows.Forms.CheckBox
	Friend WithEvents btnLaunch As System.Windows.Forms.Button
	Friend WithEvents txtLaunchString As System.Windows.Forms.TextBox
	Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
	Friend WithEvents txtStatus As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents tbarMem As System.Windows.Forms.TrackBar
	Friend WithEvents lblMem As System.Windows.Forms.Label
	Friend WithEvents lblVRAM As System.Windows.Forms.Label
	Friend WithEvents tBarVRAM As System.Windows.Forms.TrackBar
	Friend WithEvents gbCurrent As System.Windows.Forms.GroupBox
	Friend WithEvents gbAll As System.Windows.Forms.GroupBox
	Friend WithEvents btnRename As System.Windows.Forms.Button
	Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
	Friend WithEvents OnDesktopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ChooseLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
	Friend WithEvents tsbUsage As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents tsbAbout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents lvModsCurrent As System.Windows.Forms.ListView
	Friend WithEvents colModsCurrent As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvModsAll As System.Windows.Forms.ListView
	Friend WithEvents colModsAll As System.Windows.Forms.ColumnHeader
	Friend WithEvents btnDown As System.Windows.Forms.Button
	Friend WithEvents btnUp As System.Windows.Forms.Button
	Friend WithEvents InStartMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents InSteamLibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents btnGroups As System.Windows.Forms.Button
	Friend WithEvents chkExThreads As System.Windows.Forms.CheckBox
	Friend WithEvents lblExThreads As System.Windows.Forms.Label
	Friend WithEvents lblCPUCount As System.Windows.Forms.Label
	Friend WithEvents tbarExThreads As System.Windows.Forms.TrackBar
	Friend WithEvents tBarCPUCount As System.Windows.Forms.TrackBar
	Friend WithEvents A3StartupParametersWikiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolTipCurrent As System.Windows.Forms.ToolTip
	Friend WithEvents ToolTipAll As System.Windows.Forms.ToolTip
	Friend WithEvents chkNoFilePatching As System.Windows.Forms.CheckBox
	Friend WithEvents chkNoLogs As System.Windows.Forms.CheckBox
	Friend WithEvents cmbLaunchAction As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents chkWindowed As System.Windows.Forms.CheckBox
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
	Friend WithEvents tsiSetAltLoc As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
	Friend WithEvents cmbCustomMemoryAllocator As System.Windows.Forms.ComboBox
	Friend WithEvents cmbProfileName As System.Windows.Forms.ComboBox
	Friend WithEvents chkProfileName As System.Windows.Forms.CheckBox
	Friend WithEvents chkCustomMemoryAllocator As System.Windows.Forms.CheckBox
	Friend WithEvents tsiRunBattlEye As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents txtCustomParameters As System.Windows.Forms.TextBox
	Friend WithEvents chkCustomArguments As System.Windows.Forms.CheckBox

End Class
