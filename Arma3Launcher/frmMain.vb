Imports System.Collections.Specialized
Imports System.IO
Imports System.Windows.Forms.ListBox
Imports Arma3ModPresetLauncher.DragManager

'TODO:
' Add tooltip of full folder path
' Make full paths part of Tag, not actual item name, DEBUG
' When typing custom arg, have preview arg box scroll to right

'============== CHANGELOG ===================

'v1.2.3 - 2015-??-??
'- Added: -malloc parameter (lists any dlls in Arma 3/Dlls)
'- Added: -name parameter
'- Added: Option to run Battleye (On by default, Fixes "battleye is not running" issue)
'- Removed: Option to run via command to steam client, as it no longer works
'- Fixed: Listviews now handle horizontal resizing better
'- Fixed: Adjusted wording of some tooltips to be clearer
'- Changed: List views no longer show full path of modfolders (An item's full path can be viewed by holding the mouse over that item)

'v1.2.2 - 2014-10-26
'- Added: Now searches one level down for modfolders in folders (Arma 3\@Mods\@JSRS), so you can declutter your Arma directory (Note: top folder must start with @)
'- Added: Alternate mod locations: mods can now be loaded from other locations, like other drives. (infinite number of locations)
'	* Note: Because I didn't design the program to do this from the beginning, it will show the full path in the list views when using the above features, so I suggest very short paths like: Arma 3\@Mods\(mods) or F:\Arma3\(mods) if on a separate drive
'- Added: Option to run Arma3.exe directly, in case of Steam issues (shortcuts also save with this option) (NOTE: This is not intended to, and does not, allow pirated games to be launched)
'- Added: Options menu with the above features
'- Added: Will now remember previously active preset
'- Added: Explanatory tooltips for all the parameters
'- Fixed: Can now only have one instance open at once
'- Removed some unused references and resources
'- Updated help dialogs

'v1.2.1 - 2014-02-26
'- Added: -window, -noLogs, -noFilePatching parameters
'- Added: Launcher action on game launch (nothing, minimize, or close)
'- Added: Horizontal resizing for both dialogs 
'- Added: Launcher position and sizes are now saved (intelligently checks and resets if off screen, in case resolution changed etc.)
'- Added: Gray hightlight in the mod list if mod is in current preset
'- Added: Red hightlight for mods in the active preset but not in the A3 directory (deleted/name changed), and warning in status bar
'- Added: Relevant mod coloring for groups dialog (gray and red)
'- Added: Shiny new About and Usage dialogs
'- Fixed: Possible crash when creating new group
'- Fixed: Modfolders with spaces in their name no longer break the command line
'- Fixed: Drive letter is now capitalized (didn't cause problems, just bugged me)
'- Fixed: Lots of semi-edge case fixes/improvements
'
'v1.1 - 2014-02-14
'- Implemented groups: Basically sub-presets. See Help > Usage for details
'- Now installed using the standard windows installer, instead of ClickOnce. The executable will now be stored in program files like every other normal program.
'- Added -exThreads parameter
'- Both main and group dialogs can be vertically resized
'- Minor UI fixes and squashed bugs
'- v1.1.1: Load order tweak - if a mod that's already part of an active group is manually added somewhere else in the current preset, it will load there instead of as part of the group.
'- v1.1.2: Hotfix for crash when deleting all mods from a preset. Also fixed a bug in highlighting mods.
'
'v1.0 - 2014-02-03 - Initial Release


Public Class frmMain
	Protected Friend modAllList As New ArrayList()
	Private Groups As New OrderedDictionary()
	Private Presets As New OrderedDictionary()
	Private launchString As String
	Private steamExe As String

	'Constants
	Protected Friend ReadOnly activeColor As Integer = 160 'Gray highlight brightness (0-255)
	Protected Friend ReadOnly frmMainDefaultSize = New Size(450, 620)

	Private dragger As DragManager

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		dragger = New DragManager(Me)

		'My.Settings.Reset()
		'My.Settings.Save()

		Try
			steamExe = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SteamExe", Nothing)
			steamExe = steamExe.Replace("/", "\")
		Catch ex As System.Security.SecurityException
			Console.WriteLine("Caught Security exception while reading Steam registry key")
		End Try

		'Couldn't find Steam installed
		If IsNothing(steamExe) Then
			MessageBox.Show(
			 "Could not find Steam installation. The launcher will now exit.",
			 "Error",
			 MessageBoxButtons.OK,
			 MessageBoxIcon.Error)
			End
		Else
			steamExe = steamExe.Substring(0, 1).ToUpper + steamExe.Substring(1)	'Capitalize drive letter
		End If

		If IsNothing(My.Settings.ModLocations) Then
			My.Settings.ModLocations = New StringCollection
			My.Settings.ModLocations.Add("1")
		End If

		'Create empty Vanilla preset on first run
		If IsNothing(My.Settings.PresetList) Then
			My.Settings.PresetList = New StringCollection()
			Presets = New OrderedDictionary()
			Presets.Add("Vanilla", "")
			savePresets()
		ElseIf My.Settings.PresetList.Count = 0 Then
			Presets.Add("Vanilla", "")
			savePresets()
		Else
			loadPresets()
		End If

		addParameterTooltips()

		loadWindowSizeLoc()

		lvModsAll.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
		lvModsCurrent.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
	End Sub

	Private Sub addParameterTooltips()
		Dim settingsTooltip As New ToolTip()
		settingsTooltip.AutoPopDelay = 15000
		settingsTooltip.InitialDelay = 500
		settingsTooltip.ReshowDelay = 50
		settingsTooltip.ShowAlways = False
		settingsTooltip.UseAnimation = True

		settingsTooltip.SetToolTip(chkNoSplash, "Disables splash screen at startup (decreases startup time).")
		settingsTooltip.SetToolTip(chkEmptyWorld, "Loads an empty world on startup (decreases startup time).")
		settingsTooltip.SetToolTip(chkShowScriptErrors, "Shows script errors for debugging.")
		settingsTooltip.SetToolTip(chkNoPause, "Does not pause game when minimized/not in focus.")
		settingsTooltip.SetToolTip(chkSkipIntro, "Disables intros in the main menu (decreases startup time).")
		settingsTooltip.SetToolTip(chkNoLogs, "Disables logging to .rpt file (may improve framerate).")
		settingsTooltip.SetToolTip(chkNoFilePatching, "Ensures that only PBOs are loaded and NO unpacked data.")
		settingsTooltip.SetToolTip(chkWindowed, "Starts Arma in windowed mode." + vbCrLf + "(Screen resolution / window size are set in game menu or arma3.cfg).")

		settingsTooltip.SetToolTip(chkMem, "Defines memory allocation limit (in MegaBytes)." + vbCrLf + "When blank, the engine uses automatic values (512-1536 MB).")
		settingsTooltip.SetToolTip(tbarMem, "Defines memory allocation limit (in MegaBytes)." + vbCrLf + "When blank, the engine uses automatic values (512-1536 MB).")

		settingsTooltip.SetToolTip(chkVRAM, "Defines Video Memory allocation limit (in MegaBytes).")
		settingsTooltip.SetToolTip(tBarVRAM, "Defines Video Memory allocation limit (in MegaBytes).")

		settingsTooltip.SetToolTip(chkCPU, "Change to a number less than or equal to number of available cores." + vbCrLf + "When blank, auto detection defaults to native core count.")
		settingsTooltip.SetToolTip(tBarCPUCount, "Change to a number less than or equal to number of available cores." + vbCrLf + "When blank, auto detection defaults to native core count.")

		settingsTooltip.SetToolTip(chkExThreads, "Change to a number 0,1,3,5,7." + vbCrLf + "When blank, default is 3 for dualcore and 7 for quadcore.")
		settingsTooltip.SetToolTip(tbarExThreads, "Change to a number 0,1,3,5,7." + vbCrLf + "When blank, default is 3 for dualcore and 7 for quadcore.")

		settingsTooltip.SetToolTip(cmbLaunchAction, "Launcher action when the game is launched.")

		settingsTooltip.SetToolTip(cmbCustomMemoryAllocator, "Shows any .dll file in Arma 3/DLLs.")
		settingsTooltip.SetToolTip(cmbProfileName, "Shows any profile under Documents/Arma 3 - Other Profiles/")
	End Sub

	Private Sub savePresets()
		My.Settings.PresetList.Clear()
		For Each preset In Presets.Keys
			My.Settings.PresetList.Add(preset + ";" + Presets.Item(preset))
		Next
		My.Settings.Save()
	End Sub

	Private Sub loadPresets()
		Presets.Clear()
		For Each preset In My.Settings.PresetList
			Dim key As String = preset.Substring(0, preset.IndexOf(";"))
			Dim value As String = preset.Substring(preset.IndexOf(";") + 1)
			Presets.Add(key, value)
		Next
	End Sub

	Private Sub loadGroups()
		Groups.Clear()
		For Each group In My.Settings.GroupList
			Dim key As String = group.Substring(0, group.IndexOf(";"))
			Dim value As String = group.Substring(group.IndexOf(";") + 1)
			Groups.Add(key, value)
		Next
	End Sub

	Private Sub saveWindowSizeLoc()
		My.Settings.Size = Me.Size
		My.Settings.FormLocation = Me.Location
		My.Settings.Save()
	End Sub

	Private Sub loadWindowSizeLoc()
		If IsNothing(My.Settings.Size) Then
			My.Settings.Size = frmMainDefaultSize
			My.Settings.Save()
		End If

		'Console.WriteLine("Form Height: " + My.Settings.Height.ToString)
		Me.Size = My.Settings.Size	'Load Size

		'Set center screen on first run, else load saved position
		If My.Settings.FormLocation.X = -1000 Or My.Settings.FormLocation.Y = -1000 Then
			resetLocation()
		Else
			'Console.WriteLine("Form Loc: " + My.Settings.FormLocation.ToString)
			Me.Location = My.Settings.FormLocation
		End If

		'Check if form is off screen and fix
		Dim myScreen = Screen.FromControl(Me)
		'Console.WriteLine("myScreen: " + myScreen.ToString)
		If Not myScreen.WorkingArea.Contains(New Point(Me.Left, Me.Top)) And
		Not myScreen.WorkingArea.Contains(New Point(Me.Right, Me.Top)) And
		Not myScreen.WorkingArea.Contains(New Point(Me.Left, Me.Bottom)) And
		Not myScreen.WorkingArea.Contains(New Point(Me.Right, Me.Bottom)) Then 'Form is off screen
			Console.WriteLine("Form not visible, resetting Location")
			resetLocation()
		End If

		'Make sure height is within screen
		Dim myWorkArea = myScreen.WorkingArea
		If Me.Size.Height > myWorkArea.Height Then
			'Console.WriteLine("Fixing Height: bottom")
			Me.Size = New Size(Me.Size.Width, myWorkArea.Height - Me.Location.Y) 'Move form bottom up to bottom of screen, but leave top where it is
		ElseIf Me.Location.Y < 0 Then
			'Console.WriteLine("Fixing Height: top")
			Me.Size = New Size(Me.Size.Width, Me.Size.Height - Math.Abs(Me.Location.Y))
			Me.Location = New Point(Me.Location.X, 0)
		End If

		'Console.WriteLine("Final Size: " + Me.Size.ToString)
		'Console.WriteLine("Final Location: " + Me.Location.ToString)
	End Sub

	Private Function getExecutable()
		If My.Settings.RunBattlEye Then
			Return "arma3battleye.exe"
		Else
			Return "arma3.exe"
		End If
	End Function

	Private Sub resetLocation()
		Dim workingArea As Rectangle = Screen.FromControl(Me).WorkingArea
		Dim xCenter As Integer = (workingArea.Width / 2) - (Me.Size.Width / 2)
		Dim yCenter As Integer = (workingArea.Height / 2) - (Me.Size.Height / 2)
		Me.Location = New Point(xCenter, yCenter)
		saveWindowSizeLoc()
	End Sub

	Private Sub refreshMemAllocators()
		If My.Settings.CustomMemoryAllocatorEnabled Then
			Dim dirInfo As New DirectoryInfo(My.Settings.A3Path.Replace("\" + getExecutable(), "") + "\dll")
			Dim dlls() = dirInfo.GetFiles("*.dll")

			cmbCustomMemoryAllocator.Items.Clear()

			For Each dll In dlls
				cmbCustomMemoryAllocator.Items.Add(dll.Name.Replace(".dll", ""))
			Next

			cmbCustomMemoryAllocator.Items.Add("System")

			Dim index = cmbCustomMemoryAllocator.FindStringExact(My.Settings.CustomMemoryAllocator)

			If index = -1 Then
				MessageBox.Show("Warning: Your saved custom memory allocator no longer exists in Arma 3\Dll!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				cmbCustomMemoryAllocator.SelectedIndex = 0
			Else
				cmbCustomMemoryAllocator.SelectedIndex = index
			End If
		End If
	End Sub

	Private Sub refreshProfiles()
		If My.Settings.ProfileNameEnabled Then
			Dim dirInfo As New DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Arma 3 - Other Profiles")
			cmbProfileName.Items.Clear()

			For Each f In dirInfo.GetDirectories()
				For Each fl In f.GetFiles()
					If fl.Name.EndsWith(".Arma3Profile") Then
						cmbProfileName.Items.Add(Uri.UnescapeDataString(f.Name))
						Exit For
					End If
				Next
			Next

			Dim index = cmbProfileName.FindStringExact(My.Settings.ProfileName)

			If index = -1 Then
				MessageBox.Show("Warning: Your saved profile no longer exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				cmbProfileName.SelectedIndex = 0
			Else
				cmbProfileName.SelectedIndex = index
			End If
		End If
	End Sub

	Private Function between(ByVal value As Integer, ByVal lower As Integer, ByVal upper As Integer) As Boolean
		If value >= lower And value <= upper Then
			Return True
		Else
			Return False
		End If
	End Function

	Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosing
		savePresets()
		saveWindowSizeLoc()
		Application.Exit()
	End Sub

	Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

		'Not working. Attempt to avoid Steam hook when run from the Steam library, so that it shows you as playing Arma 3, not the launcher
		'Dim args As New ArrayList
		'args.AddRange(My.Application.CommandLineArgs)
		'If My.Application.CommandLineArgs.Count > 0 Then
		'	If args(0) = "-steam" Then
		'		'MsgBox("-steam")
		'		Try
		'			'MsgBox(Application.ExecutablePath())
		'			'Process.Start("start", Application.ExecutablePath() + " & exit")
		'			Process.Start(Application.ExecutablePath(), " & exit")
		'			End
		'		Catch ex As Exception
		'			Console.WriteLine(ex.Message)
		'		End Try
		'	End If
		'Else
		'	'MsgBox("Count 0")
		'End If

		If My.Settings.A3Path Is Nothing Or My.Settings.A3Path = "" Then
			My.Settings.A3Path = locateA3()
		ElseIf Not File.Exists(My.Settings.A3Path) Then
			My.Settings.A3Path = relocateA3()
		End If

		If My.Settings.A3Path = "" Then Application.Exit()

		refreshPresetCmb()

		updateAllModsList()

		If IsNothing(My.Settings.CurrentPreset) Or My.Settings.CurrentPreset Is "" Then
			My.Settings.CurrentPreset = cmbPreset.Items(0).ToString()
			My.Settings.Save()
			cmbPreset.SelectedIndex = 0
			Console.WriteLine("CurrentPreset Empty, setting to first: " + My.Settings.CurrentPreset)
		Else
			If cmbPreset.Items.Contains(My.Settings.CurrentPreset) Then
				Console.WriteLine("Found CurrentPreset: " + My.Settings.CurrentPreset)
				cmbPreset.SelectedIndex = cmbPreset.FindStringExact(My.Settings.CurrentPreset)
			Else
				Console.WriteLine("CurrentPreset not found, resetting")
				cmbPreset.SelectedIndex = 0
			End If
		End If

		chkNoSplash.Checked = My.Settings.NoSplashScreen
		chkEmptyWorld.Checked = My.Settings.EmptyWorld
		chkShowScriptErrors.Checked = My.Settings.ShowScriptErrors
		chkNoPause.Checked = My.Settings.NoPause
		chkSkipIntro.Checked = My.Settings.SkipIntro
		chkNoLogs.Checked = My.Settings.NoLogs
		chkNoFilePatching.Checked = My.Settings.NoFilePatching
		chkWindowed.Checked = My.Settings.Windowed


		chkMem.Checked = My.Settings.MaxMemEnabled
		If chkMem.Checked Then
			tbarMem.Enabled = True
			tbarMem.Value = My.Settings.MaxMem
			'lblMem.Text = valueToRam(tbarMem.Value).ToString + " MB"
		End If

		chkVRAM.Checked = My.Settings.MaxVRAMEnabled
		If chkVRAM.Checked Then
			tBarVRAM.Enabled = True
			tBarVRAM.Value = My.Settings.MaxVRAM
			'lblVRAM.Text = valueToRam(tBarVRAM.Value).ToString + " MB"
		End If

		chkCPU.Checked = My.Settings.CPUEnabled
		If chkCPU.Checked Then
			tBarCPUCount.Enabled = True
			tBarCPUCount.Value = My.Settings.CPUCount / 2
		End If

		chkExThreads.Checked = My.Settings.ExThreadsEnable
		If chkExThreads.Checked Then
			tbarExThreads.Enabled = True
			tbarExThreads.Value = My.Settings.ExThreads
		End If

		If IsNothing(My.Settings.LaunchAction) Then
			My.Settings.LaunchAction = "Nothing"
		End If
		cmbLaunchAction.SelectedIndex = cmbLaunchAction.FindStringExact(My.Settings.LaunchAction)

		chkCustomMemoryAllocator.Checked = My.Settings.CustomMemoryAllocatorEnabled
		If chkCustomMemoryAllocator.Checked Then
			cmbCustomMemoryAllocator.Enabled = True
			refreshMemAllocators()
		End If

		chkProfileName.Checked = My.Settings.ProfileNameEnabled
		If chkProfileName.Checked Then
			cmbProfileName.Enabled = True
			refreshProfiles()
		End If

		setStatus("Successfully loaded " + lvModsAll.Items.Count.ToString + " mods and " + cmbPreset.Items.Count.ToString + " presets", True)

		lvModsAll.Columns.Item(0).Width = -2
		lvModsCurrent.Columns.Item(0).Width = -2

		checkForMissingMods()

		refreshMemAllocators()
	End Sub

	Private Function locateA3()
		Dim path As String = ""
		'Look for arma3.exe in steam installation
		Dim steamPath As String = steamExe.Replace("\steam.exe", "")

		'check if arma installed inside
		If (File.Exists(steamPath + "\steamapps\common\Arma 3\" + My.Settings.RunBattlEye)) Then	'return path and skip input dialog
			path = steamPath + "\steamapps\common\Arma 3\" + My.Settings.RunBattlEye

			MessageBox.Show(
			  "Detected Arma 3 Installation at:" + vbCrLf + vbCrLf + path + vbCrLf + vbCrLf + "Loading mods...",
			  "Found Arma 3 Installation",
			  MessageBoxButtons.OK,
			  MessageBoxIcon.Information)

			Return path
		End If


		'Otherwise, ask the user to find the game directory, loop until valid
		Dim lblTextOriginal As String = pathInput.lblPath.Text
		Dim valid = 0
		While valid = 0
			Dim inputPath = pathInput.ShowDialog()

			If inputPath = DialogResult.Cancel Then	'clicked Exit or X on window
				End
			End If

			If inputPath = DialogResult.OK Then	'Clicked OK
				If foundFile(pathInput.txtPath.Text, "arma3.exe") Then
					path = pathInput.txtPath.Text.Replace("/", "\")
					MessageBox.Show(
					  "Found Arma 3 Installation at:" + vbCrLf + vbCrLf + path + vbCrLf + vbCrLf + "Loading mods...",
					  "Found Arma 3 Installation",
					  MessageBoxButtons.OK,
					  MessageBoxIcon.Information)

					valid = 1
					'My.Settings.Save()
				Else
					'change dialog message to error prompt
					pathInput.lblPath.Text = "Unable to locate arma3.exe in the specified location, please try again."
				End If
			End If
		End While

		pathInput.lblPath.Text = lblTextOriginal
		Return path
	End Function

	Private Function relocateA3()
		Dim oldLabel As String = pathInput.lblPath.Text	 '* Lol, this is terrible, don't do this
		pathInput.lblPath.Text = "Arma3.exe could not be found at the saved location. Please browse to or paste its location."
		Dim path As String = locateA3()
		pathInput.lblPath.Text = oldLabel '*
		setStatus("Found Arma 3", True)
		Return path
	End Function

	Private Sub setStatus(ByVal text As String, ByVal success As Boolean)
		txtStatus.Text = text
		If success Then
			txtStatus.ForeColor = Color.Green
		Else
			txtStatus.ForeColor = Color.Red
		End If
	End Sub

	Private Sub statusChk(ByVal name As String, ByVal checked As Boolean, ByVal success As Boolean)
		If checked Then
			setStatus(name + " parameter enabled", success)
		Else
			setStatus(name + " parameter disabled", success)
		End If
	End Sub

	Private Function valueToRam(ByVal value As Integer)
		Return (value) * 512
	End Function

	Private Function getGroupNameFromString(ByVal group As String) As String
		Return group.Substring(0, group.IndexOf(";"))
	End Function

	Private Function getGroupModsFromString(ByVal group As String) As ArrayList
		Dim mods As New ArrayList

		If group = "" Then
			Return mods
		End If
		loadGroups()

		If group.Contains(";") Then	'full string was passed in, crop to only name
			group = group.Substring(0, group.IndexOf(";"))
		End If
		Dim modsStr As String = Groups.Item(group)
		If (modsStr <> "") Then
			mods.AddRange(modsStr.Split(","))
		End If
		Return mods
	End Function

	Private Sub updateAllModsList()
		modAllList.Clear()
		lvModsAll.Items.Clear()

		'add groups
		If (Not IsNothing(My.Settings.GroupList)) Then
			If My.Settings.GroupList.Count > 0 Then
				For Each group In My.Settings.GroupList
					Dim groupName = getGroupNameFromString(group)
					Dim item = lvModsAll.Items.Add(groupName)
				Next
			End If
		End If

		'trim off arma3.exe from path, get folders in directory
		Dim modfolderslist As New ArrayList
		For _i As Integer = 0 To My.Settings.ModLocations.Count - 1
			If _i = 0 Then
				If My.Settings.ModLocations(_i) = "1" Then
					modfolderslist.AddRange(getModFolders(My.Settings.A3Path.Remove(My.Settings.A3Path.LastIndexOf("\")), False))
				End If
			Else
				If Not My.Settings.ModLocations(_i).StartsWith("!") Then
					modfolderslist.AddRange(getModFolders(My.Settings.ModLocations(_i), True))
				End If
			End If
		Next
		For Each modfolder As String In modfolderslist
			modAllList.Add(modfolder)
			Dim modfolderName = modfolder

			If modfolderName.Contains("\") Then
				modfolderName = trimToFolderName(modfolder)
			End If
			
			Dim listItem = lvModsAll.Items.Add(modfolderName)
			listItem.Tag = modfolder
		Next

		lvModsAll.Columns.Item(0).Width = -2
		lvModsCurrent.Columns.Item(0).Width = -2

		'ToolTipAll.Dispose()
		'MsgBox(str)
	End Sub

	Private Function getModFolders(ByVal folder As String, ByVal prefixWithFolder As Boolean) As ArrayList
		Dim folderslist
		Dim modList As New ArrayList

		If Directory.Exists(folder) Then
			folderslist = New ArrayList(Directory.GetDirectories(folder))
			For Each folder In folderslist
				'if folder starts with @ and has an addons folder inside it, add it to the modList
				Dim folderName = folder.Substring(folder.LastIndexOf("\") + 1)
				If folderName.StartsWith("@") Then
					Dim info As New System.IO.DirectoryInfo(folder)
					Dim name = info.Name
					Dim subInfoAddon = New ArrayList(info.GetDirectories("addons"))
					'Console.WriteLine("Top:" + folder)
					If prefixWithFolder Then
						name = folder
					End If
					If subInfoAddon.Count = 1 Then
						modList.Add(name)
					Else
						Dim subInfoMod = New ArrayList(info.GetDirectories("@*"))
						For Each subfolder As DirectoryInfo In subInfoMod
							Dim subName = subfolder.Name
							'Console.WriteLine("Sub:" + subName)
							modList.Add(name + "\" + subName)
						Next
					End If
				End If
			Next
		End If

		Return modList
	End Function

	Private Function trimToFolderName(ByVal path As String)
		Dim start = path.LastIndexOf("\") + 1
		Dim length = path.Length - path.LastIndexOf("\") - 1
		Return path.Substring(start, length)
	End Function

	Private Sub cmbPreset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPreset.SelectedIndexChanged
		'Console.WriteLine("cmbPreset_SelectedIndexChanged: " + cmbPreset.SelectedIndex.ToString)
		My.Settings.CurrentPreset = cmbPreset.SelectedItem.ToString()
		My.Settings.Save()
		Console.WriteLine("Saved CurrentPreset: " + My.Settings.CurrentPreset)
		updateCurrentPreset()
	End Sub

	Private Sub refreshPresetCmb()
		Dim oldSelected As String = cmbPreset.SelectedItem
		cmbPreset.Items.Clear()
		For Each preset In Presets.Keys
			cmbPreset.Items.Add(preset)
		Next
		cmbPreset.SelectedItem = oldSelected
	End Sub

	Private Sub updateCurrentPreset()
		'Console.WriteLine("updateCurrentProject: " + cmbPreset.SelectedItem)
		Dim items As ArrayList = getPreset(cmbPreset.SelectedItem) 'get array from settings

		lvModsCurrent.Items.Clear()
		For Each item As String In items
			Dim itemName = trimToFolderName(item)
			Dim itemPath = item.ToString()
			Dim listItem = lvModsCurrent.Items.Add(itemName)
			listItem.Tag = itemPath
			If Not item.ToString.StartsWith("@") Then	'item is a group
				listItem.ForeColor = Color.Blue
			End If
		Next

		ToolTipCurrent.Dispose()
		updateLaunchStringAndColors()

		'lvModsAll.Columns.Item(0).Width = -2
		'lvModsCurrent.Columns.Item(0).Width = -2
	End Sub

	Private Function getPreset(ByVal preset As String)
		'Console.WriteLine("getPreset: " + preset.ToString)
		Dim presetArray = Presets.Item(preset).Split(",")

		Dim presetArrayList = New ArrayList
		presetArrayList.AddRange(presetArray)
		Return presetArrayList
	End Function


	Private Sub savePreset(ByVal preset As String, ByVal mods As ArrayList)
		Dim modStr As String = String.Join(",", mods.ToArray)
		Presets.Item(preset) = modStr
	End Sub


	' ================================= REORDER CURRENT MODS =====================================

	'Not working
	'Private Sub ctrlArrowKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvModsCurrent.KeyDown
	'	If e.Modifiers = Keys.Control Then
	'		If e.KeyCode = Keys.Up Then
	'			moveSelectedItemUp()
	'		ElseIf e.KeyCode = Keys.Down Then
	'			moveSelectedItemUp()
	'		End If
	'	End If
	'End Sub

	Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUp.MouseUp
		moveSelectedItemUp()
	End Sub

	Protected Friend Sub moveSelectedItemUp()
		If lvModsCurrent.SelectedIndices.Count = 0 Then
			setStatus("You must select an item to move", False)
			Return
		End If

		Dim selectedIndex = lvModsCurrent.SelectedIndices(0)

		If selectedIndex = 0 Then
			'Do nothing, can't move up
			setStatus("This mod is already at the top of the list!", False)
		Else
			Dim preset = cmbPreset.SelectedItem
			Dim selectedMod = lvModsCurrent.SelectedItems(0).Text

			Dim modList As ArrayList = getPreset(preset)

			modList.Insert(selectedIndex - 1, selectedMod) ' insert mod one up and delete later location
			modList.RemoveAt(modList.LastIndexOf(selectedMod))

			savePreset(preset, modList)
			updateCurrentPreset()

			lvModsCurrent.Focus()
			lvModsCurrent.Items.Item(selectedIndex - 1).Selected = True	' Set selection back to same mod
		End If
	End Sub

	Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDown.MouseUp
		moveSelectedItemDown()
	End Sub

	Protected Friend Sub moveSelectedItemDown()
		If lvModsCurrent.SelectedIndices.Count = 0 Then
			setStatus("You must select an item to move", False)
			Return
		End If

		Dim selectedIndex = lvModsCurrent.SelectedIndices(0)

		If selectedIndex = (lvModsCurrent.Items.Count - 1) Then
			'Do nothing, can't move down
			setStatus("This mod is already at the bottom of the list!", False)
		Else
			Dim preset = cmbPreset.SelectedItem
			Dim selectedMod = lvModsCurrent.SelectedItems(0).Text

			Dim modList As ArrayList = getPreset(preset)

			modList.Insert(selectedIndex + 2, selectedMod) ' insert mod one down and delete earlier location
			modList.RemoveAt(modList.IndexOf(selectedMod))

			savePreset(preset, modList)
			updateCurrentPreset()

			lvModsCurrent.Focus()
			lvModsCurrent.Items.Item(selectedIndex + 1).Selected = True	' Set selection back to same mod
		End If
	End Sub

	' ============================ CUSTOM DRAG AND DROP, GROUP TOOLTIPS =================================

	Private Sub lvModsCurrent_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvModsCurrent.MouseDown
		'Console.WriteLine("MouseDown: " + e.Y.ToString)
		dragger.MouseDown(sender, e)
	End Sub

	Private Sub lvModsCurrent_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvModsCurrent.MouseUp
		'Console.WriteLine("MouseUp: " + e.Y.ToString)
		dragger.MouseUp(sender, e)
	End Sub

	Private Sub lvModsCurrent_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsCurrent.MouseLeave
		'Console.WriteLine("MouseLeave")
		dragger.MouseLeave(sender, e)
		ToolTipCurrent.RemoveAll()
	End Sub

	Private Sub lvModsCurrent_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvModsCurrent.MouseMove
		'Console.WriteLine("MouseMove: " + e.Y.ToString)
		dragger.MouseMove(sender, e)

		Dim item = lvModsCurrent.GetItemAt(e.X, e.Y)
		If IsNothing(item) Then
			ToolTipCurrent.RemoveAll()
		Else
			If Not item.ForeColor = Color.Blue And Not item.ForeColor = Color.CornflowerBlue Then
				ToolTipCurrent.RemoveAll()
			End If
		End If
	End Sub

	Private Sub lvModsCurrent_ItemMouseHover(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvModsCurrent.ItemMouseHover
		If (e.Item.ForeColor = Color.Blue Or e.Item.ForeColor = Color.CornflowerBlue) And e.Item.Text <> "" Then
			ToolTipCurrent = New ToolTip

			Dim groupName As String = e.Item.Text
			Dim groupMods As ArrayList = getGroupModsFromString(groupName)

			If groupMods.Count = 0 Then
				ToolTipCurrent.SetToolTip(lvModsCurrent, "(Empty Group)")
			Else
				ToolTipCurrent.SetToolTip(lvModsCurrent, String.Join(vbCrLf, groupMods.ToArray))
			End If
		End If
	End Sub

	Private Sub lvModsAll_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsAll.MouseLeave
		'Console.WriteLine("MouseLeave")
		ToolTipAll.Dispose()
	End Sub

	Private Sub lvModsAll_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvModsAll.MouseMove
		'Console.WriteLine("MouseMove: " + e.Y.ToString)
		dragger.MouseMove(sender, e)

		Dim item = lvModsAll.GetItemAt(e.X, e.Y)
		If IsNothing(item) Then
			ToolTipAll.RemoveAll()
		End If
	End Sub

	Private Sub lvModsAll_ItemMouseHover(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvModsAll.ItemMouseHover
		If (e.Item.ForeColor = Color.Blue Or e.Item.ForeColor = Color.CornflowerBlue) Then
			ToolTipAll = New ToolTip

			Dim groupName As String = e.Item.Text
			Dim groupMods As ArrayList = getGroupModsFromString(groupName)
			If groupMods.Count = 0 Then
				ToolTipAll.SetToolTip(lvModsAll, "(Empty Group)")
			Else
				ToolTipAll.SetToolTip(lvModsAll, String.Join(vbCrLf, groupMods.ToArray))
			End If
		Else 'it's a mod in a different folder
			ToolTipAll = New ToolTip

			If (Not IsNothing(e.Item.Tag)) Then
				Dim TooltipText As String = e.Item.Tag

				If TooltipText.StartsWith("@") Then
					TooltipText = My.Settings.A3Path.Substring(0, My.Settings.A3Path.LastIndexOf("\") + 1) & e.Item.Tag
				End If

				ToolTipAll.SetToolTip(lvModsAll, TooltipText)
			End If
		End If
	End Sub

	' ================== UPDATE LAUNCH STRING =========================

	Private Sub updateLaunchStringAndColors()
		'Console.WriteLine("updateLaunchStringAndColors()")
		Dim launchParams As New ArrayList()

		Dim modArray As New ArrayList
		Dim modString As String = "-mod="
		Dim groupedAddedMods As New ArrayList

		If (lvModsCurrent.Items.Count > 0 And lvModsCurrent.Items.IndexOfKey("") <> 0) Then
			For Each item As ListViewItem In lvModsCurrent.Items
				If (item.Text.StartsWith("@")) Then	'item is a single mod
					If modArray.Contains(item.Tag) Then	'mod was added by group
						modArray.Remove(item.Tag)
						modArray.Add(item.Tag)	'so move it up to the current position of the list
					Else
						modArray.Add(item.Tag)
					End If
				ElseIf item.Text <> "" Then	'item is a group
					For Each m In getGroupModsFromString(item.Text)
						If Not modArray.Contains(m) Then
							modArray.Add(m)
						End If
						If Not groupedAddedMods.Contains(m) Then
							groupedAddedMods.Add(m)
						End If
					Next
				End If
			Next

			For Each item As ListViewItem In lvModsAll.Items 'Reset all mods to forecolor black, color groups
				If item.Text.StartsWith("@") Then
					item.ForeColor = Color.Black
				Else	  'item is a group
					Dim itemInCurrentList = findInListView(item.Text, lvModsCurrent)
					If IsNothing(itemInCurrentList) Then 'group is active
						item.ForeColor = Color.Blue
					Else
						item.ForeColor = Color.CornflowerBlue
					End If
				End If
			Next

			For Each item As ListViewItem In lvModsCurrent.Items 'Reset all mods to forecolor black and color gray in lvModsAll
				If item.Text.StartsWith("@") Then
					Dim itemInAllList = findInListView(item.Text, lvModsAll)
					If IsNothing(itemInAllList) Then	'Mod has been removed or name changed
						item.ForeColor = Color.Red
					Else
						itemInAllList.ForeColor = Color.FromArgb(activeColor, activeColor, activeColor)
						item.ForeColor = Color.Black
					End If
				End If
			Next

			For Each m In groupedAddedMods 'Highlight mods that are added as part of a group
				'Dim itemInAllList As ListViewItem = findInListView(m.ToString, lvModsAll)
				Dim itemInAllList As ListViewItem

				For Each item In lvModsAll.Items
					If item.Tag = m Then
						itemInAllList = item
					End If
				Next

				If Not IsNothing(itemInAllList) Then
					itemInAllList.ForeColor = Color.DarkOrange
				End If

				Dim itemInCurrentList As ListViewItem = findInListView(m.ToString, lvModsCurrent)
				If Not IsNothing(itemInCurrentList) Then
					itemInCurrentList.ForeColor = Color.DarkOrange
				End If
			Next

			If modArray.Count > 0 Then
				modString += String.Join(";", modArray.ToArray)
				If modString.Contains(" ") Then	'surround with quotes
					modString = """" + modString + """"
				End If
				launchParams.Add(modString)
			End If
		End If

		If My.Settings.NoSplashScreen Then launchParams.Add("-nosplash")
		If My.Settings.EmptyWorld Then launchParams.Add("-world=empty")
		If My.Settings.ShowScriptErrors Then launchParams.Add("-showScriptErrors")
		If My.Settings.NoPause Then launchParams.Add("-noPause")
		If My.Settings.SkipIntro Then launchParams.Add("-skipIntro")
		If My.Settings.NoLogs Then launchParams.Add("-noLogs")
		If My.Settings.NoFilePatching Then launchParams.Add("-noFilePatching")
		If My.Settings.Windowed Then launchParams.Add("-window")
		If My.Settings.MaxMemEnabled Then launchParams.Add("-maxMem=" + valueToRam(tbarMem.Value).ToString)
		If My.Settings.MaxVRAMEnabled Then launchParams.Add("-maxVRAM=" + valueToRam(tBarVRAM.Value).ToString)
		If My.Settings.CPUEnabled Then launchParams.Add("-cpuCount=" + lblCPUCount.Text)
		If My.Settings.ExThreadsEnable Then launchParams.Add("-ExThreads=" + lblExThreads.Text)
		If My.Settings.CustomArgumentsEnabled Then launchParams.Add(txtCustomParameters.Text)

		If cmbCustomMemoryAllocator.SelectedItem <> "None" And Not IsNothing(cmbCustomMemoryAllocator.SelectedItem) Then
			launchParams.Add("-malloc=" + cmbCustomMemoryAllocator.Text.ToLower())
		End If

		If cmbProfileName.SelectedItem <> "None" And Not IsNothing(cmbProfileName.SelectedItem) Then
			launchParams.Add("-name=""" + cmbProfileName.Text + """")
		End If

		launchString = String.Join(" ", launchParams.ToArray)

		txtLaunchString.Text = My.Settings.A3Path + " "

		txtLaunchString.Text += launchString
	End Sub

	Private Function modIsActiveInGroup(ByVal _mod As String) As Boolean
		For Each item As ListViewItem In lvModsCurrent.Items
			If Not item.Text.StartsWith("@") Then 'item is a group
				If getGroupModsFromString(item.Text).Contains(_mod) Then 'mod is already active in a group
					'Console.WriteLine(item.Text + " already contains " + _mod)
					Return True
				End If
			End If
		Next
		Return False
	End Function

	Protected Friend Function findInListView(ByVal text As String, ByRef view As ListView) As ListViewItem
		For Each item In view.Items
			If item.Text = text Then Return item
		Next
		Return Nothing
	End Function

	Private Sub checkForMissingMods()
		Dim modsWereNotFound As Boolean = False
		Dim numNotFound As Integer = 0

		For Each item As ListViewItem In lvModsCurrent.Items
			If item.Text.StartsWith("@") Then
				If IsNothing(findInListView(item.Text, lvModsAll)) Then	'Mod has been removed or name changed
					numNotFound += 1
				End If
			End If
		Next
		If numNotFound > 0 Then
			If numNotFound = 1 Then
				setStatus("A mod in " + cmbPreset.Text + " could not be found in the A3 folder!", False)
			Else
				setStatus(numNotFound.ToString + " mods in " + cmbPreset.Text + " could not be found in the A3 folder!", False)
			End If
		End If
	End Sub

	'================================================================================
	'===================== ADD AND REMOVE MODS FROM PRESETS =========================

	Private Sub btnPresetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresetAdd.Click
		addModsToCurrent()
	End Sub

	Private Sub lvModsAll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsAll.DoubleClick
		addModsToCurrent()
	End Sub

	Private Sub addModsToCurrent()
		Dim modsToAdd = lvModsAll.SelectedItems

		If modsToAdd.Count = 0 Then
			setStatus("You must select a mod to add", False)
			Return
		End If

		If IsNothing(cmbPreset.SelectedItem) Then
			Presets.Add("New Preset", "")
			refreshPresetCmb()
			cmbPreset.SelectedItem = "New Preset"
			savePresets()
			setStatus("There were no presets, new preset created.", True)
		End If

		Dim preset As ArrayList = getPreset(cmbPreset.SelectedItem)

		Dim numAdded As Integer = 0
		Dim modsAdded As New ArrayList
		modsAdded.AddRange(modsToAdd)
		For Each m As ListViewItem In modsToAdd
			Dim modname = m.Text
			If Not preset.Contains(modname) And modname <> "" Then
				preset.Add(modname)
				numAdded += 1
			Else
				modsAdded.Remove(m)
			End If
		Next
		If preset.Contains("") Then	'this is the first mod added, remove empty entry
			preset.Remove("")
		End If
		savePreset(cmbPreset.SelectedItem, preset)
		updateCurrentPreset()

		lvModsCurrent.Select()
		lvModsAll.SelectedItems.Clear()

		For Each m In modsAdded
			'lvModsCurrent.FindItemWithText(m.Text, True, 0).Selected = True

			For Each itemInCurrent As ListViewItem In lvModsCurrent.Items
				If m.Tag = itemInCurrent.Tag Then
					itemInCurrent.Selected = True
				End If
			Next
		Next

		If modsToAdd.Count = 1 Then
			If modsAdded.Count = 1 Then
				Dim itemText As String = modsAdded.Item(0).Text
				If itemText.StartsWith("@") Then	'it was a mod
					setStatus("Added " + itemText + " to " + cmbPreset.SelectedItem, True)
				Else 'it was a group
					If getGroupModsFromString(itemText).Count = 0 Then
						setStatus("Group " + itemText + " doesn't contain any mods!", False)
					End If
				End If

			Else 'modsAdded.Count = 0
				If modsToAdd.Item(0).Tag.ToString().StartsWith("@") Or modsToAdd.Item(0).Tag.ToString().Contains("\") Then	'it was a mod
					setStatus("That mod is already in the current preset", False)
				Else
					setStatus("That group is already in the current preset", False)
				End If
			End If
		ElseIf numAdded = 0 And modsToAdd.Count > 1 Then
			setStatus("All of those items are already in the current preset", False)
		Else
			setStatus("Added " + modsAdded.Count.ToString + " items to " + cmbPreset.SelectedItem, True)
		End If
	End Sub

	Private Sub btnPresetRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresetRemove.Click
		removeModsFromCurrent()
	End Sub

	Private Sub lvModsCurrent_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsCurrent.DoubleClick
		removeModsFromCurrent()
	End Sub

	Private Sub removeModsFromCurrent()
		Dim modsToRemove = lvModsCurrent.SelectedItems

		If modsToRemove.Count = 0 Then
			setStatus("You must select a mod to remove", False)
			Return
		End If

		Dim preset As ArrayList = getPreset(cmbPreset.SelectedItem)

		Dim numRemoved As Integer = 0
		Dim modsRemoved As New ArrayList
		modsRemoved.AddRange(modsToRemove)
		For Each m In modsToRemove
			preset.Remove(m.Tag)
			numRemoved += 1
		Next
		savePreset(cmbPreset.SelectedItem, preset)
		updateCurrentPreset()

		lvModsCurrent.Focus()

		If modsToRemove.Count = 1 Then
			setStatus("Removed " + numRemoved.ToString + " from " + cmbPreset.SelectedItem, True)
		Else
			setStatus("Removed " + modsRemoved.Count.ToString + " items from " + cmbPreset.SelectedItem, True)
		End If
	End Sub

	'================================================================================
	'================================================================================


	'============================== ADDITIONAL PARAMETERS ===========================

	Private Sub chkNoSplash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoSplash.CheckedChanged
		'Console.WriteLine("chkNoSplash_CheckedChanged: " + chkNoSplash.Checked.ToString)
		My.Settings.NoSplashScreen = chkNoSplash.Checked
		statusChk("NoSplash", chkNoSplash.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkEmptyWorld_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmptyWorld.CheckedChanged
		'Console.WriteLine("chkEmptyWorld_CheckedChanged: " + chkEmptyWorld.Checked.ToString)
		My.Settings.EmptyWorld = chkEmptyWorld.Checked
		statusChk("Empty World", chkEmptyWorld.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkShowScriptErrors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowScriptErrors.CheckedChanged
		'Console.WriteLine("chkShowScriptErrors_CheckedChanged: " + chkShowScriptErrors.Checked.ToString)
		My.Settings.ShowScriptErrors = chkShowScriptErrors.Checked
		statusChk("ShowScriptErrors", chkShowScriptErrors.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkNoPause_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoPause.CheckedChanged
		'Console.WriteLine("chkNoPause_CheckedChanged: " + chkNoPause.Checked.ToString)
		My.Settings.NoPause = chkNoPause.Checked
		statusChk("NoPause", chkNoPause.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkSkipIntro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSkipIntro.CheckedChanged
		'Console.WriteLine("chkSkipIntro_CheckedChanged: " + chkSkipIntro.Checked.ToString)
		My.Settings.SkipIntro = chkSkipIntro.Checked
		statusChk("SkipIntro", chkSkipIntro.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkNoLogs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoLogs.CheckedChanged
		Console.WriteLine("chkNoLogs_CheckedChanged: " + chkNoLogs.Checked.ToString)
		My.Settings.NoLogs = chkNoLogs.Checked
		statusChk("NoLogs", chkNoLogs.Checked, True)
		updateLaunchStringAndColors()
	End Sub


	Private Sub chkNoFilePatching_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoFilePatching.CheckedChanged
		Console.WriteLine("chkNoFilePatching_CheckedChanged: " + chkNoFilePatching.Checked.ToString)
		My.Settings.NoFilePatching = chkNoFilePatching.Checked
		statusChk("NoFilePatching", chkNoFilePatching.Checked, True)
		updateLaunchStringAndColors()
	End Sub


	Private Sub chkWindowed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWindowed.CheckedChanged
		Console.WriteLine("chkWindowed_CheckedChanged: " + chkWindowed.Checked.ToString)
		My.Settings.Windowed = chkWindowed.Checked
		statusChk("Windowed", chkWindowed.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkCustomMemoryAllocator_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomMemoryAllocator.CheckedChanged
		Console.WriteLine("chkCustomMemoryAllocator_CheckedChanged: " + chkCustomMemoryAllocator.Checked.ToString)
		My.Settings.CustomMemoryAllocatorEnabled = chkCustomMemoryAllocator.Checked
		My.Settings.Save()
		If Not chkCustomMemoryAllocator.Checked Then
			cmbCustomMemoryAllocator.Text = ""
		End If
		cmbCustomMemoryAllocator.Enabled = chkCustomMemoryAllocator.Checked
		statusChk("Custom Memory Allocator", chkCustomMemoryAllocator.Checked, True)
		refreshMemAllocators()
	End Sub

	Private Sub chkProfileName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProfileName.CheckedChanged
		Console.WriteLine("chkProfileName_CheckedChanged: " + chkProfileName.Checked.ToString)
		My.Settings.ProfileNameEnabled = chkProfileName.Checked
		My.Settings.Save()
		If Not chkProfileName.Checked Then
			cmbProfileName.Text = ""
		End If
		cmbProfileName.Enabled = chkProfileName.Checked
		statusChk("Profile Name", chkProfileName.Checked, True)
		refreshProfiles()
	End Sub

	Private Sub chkCustomArguments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomArguments.CheckedChanged
		Console.WriteLine("chkCustomArguments_CheckedChanged: " + chkCustomArguments.Checked.ToString)
		My.Settings.CustomArgumentsEnabled = chkCustomArguments.Checked
		statusChk("Custom Arguments", chkCustomArguments.Checked, True)
		updateLaunchStringAndColors()
	End Sub

	Private Sub chkMem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMem.CheckedChanged
		'Console.WriteLine("chkMem_CheckedChanged: " + chkMem.Checked.ToString)
		My.Settings.MaxMemEnabled = chkMem.Checked
		statusChk("MaxMem", chkMem.Checked, True)
		updateLaunchStringAndColors()

		tbarMem.Enabled = chkMem.Checked
		lblMem.Enabled = chkMem.Checked

		If chkMem.Checked Then
			tbarMem.Value = My.Settings.MaxMem
			lblMem.Text = valueToRam(tbarMem.Value).ToString + " MB"
		Else
			tbarMem.Value = 4
			lblMem.Text = "Auto"
		End If
	End Sub

	Private Sub chkVRAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVRAM.CheckedChanged
		Console.WriteLine("chkVRAM_CheckedChanged: " + chkVRAM.Checked.ToString)
		My.Settings.MaxVRAMEnabled = chkVRAM.Checked
		statusChk("MaxVRAM", chkVRAM.Checked, True)
		updateLaunchStringAndColors()

		tBarVRAM.Enabled = chkVRAM.Checked
		lblVRAM.Enabled = chkVRAM.Checked

		If chkVRAM.Checked Then
			tBarVRAM.Value = My.Settings.MaxVRAM
			lblVRAM.Text = valueToRam(tBarVRAM.Value).ToString + " MB"
		Else
			tBarVRAM.Value = 4
			lblVRAM.Text = "Auto"
		End If
	End Sub

	Private Sub chkCPU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCPU.CheckedChanged
		Console.WriteLine("chkCPU_CheckedChanged: " + chkCPU.Checked.ToString)
		My.Settings.CPUEnabled = chkCPU.Checked
		statusChk("CpuCount", chkCPU.Checked, True)
		updateLaunchStringAndColors()

		tBarCPUCount.Enabled = chkCPU.Checked
		lblCPUCount.Enabled = chkCPU.Checked

		If chkCPU.Checked Then
			lblCPUCount.Text = My.Settings.CPUCount
			tBarCPUCount.Value = My.Settings.CPUCount / 2
		Else
			lblCPUCount.Text = "Auto"
			tBarCPUCount.Value = 4
		End If
	End Sub

	Private Sub chkExThreads_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExThreads.CheckedChanged
		Console.WriteLine("chkExThreads_CheckedChanged: " + chkExThreads.Checked.ToString)
		My.Settings.ExThreadsEnable = chkExThreads.Checked
		statusChk("ExThreads", chkExThreads.Checked, True)
		updateLaunchStringAndColors()

		tbarExThreads.Enabled = chkExThreads.Checked
		lblExThreads.Enabled = chkExThreads.Checked
		If chkExThreads.Checked Then
			If My.Settings.ExThreads > 0 Then
				tbarExThreads.Value = My.Settings.ExThreads
				lblExThreads.Text = (tbarExThreads.Value * 2 - 1).ToString()
			Else
				tbarExThreads.Value = 0
				lblExThreads.Text = "0"
			End If
		Else
			lblExThreads.Text = "Auto"
			tbarExThreads.Value = 4
		End If

	End Sub

	Private Sub tbarMem_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarMem.Scroll
		'Console.WriteLine("tbarMem_Scroll: " + tbarMem.Value.ToString)
		My.Settings.MaxMem = tbarMem.Value
		'My.Settings.Save()

		lblMem.Text = valueToRam(tbarMem.Value).ToString + " MB"
		updateLaunchStringAndColors()
	End Sub

	Private Sub tbarVRAM_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBarVRAM.Scroll
		'Console.WriteLine("tBarVRAM_Scroll: " + tBarVRAM.Value.ToString)
		My.Settings.MaxVRAM = tBarVRAM.Value
		'My.Settings.Save()

		lblVRAM.Text = valueToRam(tBarVRAM.Value).ToString + " MB"
		updateLaunchStringAndColors()
	End Sub

	Private Sub tBarCPUCount_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBarCPUCount.Scroll
		'Console.WriteLine("tBarCPUCount_Scroll: " + (tBarCPUCount.Value * 2).ToString)
		My.Settings.CPUCount = tBarCPUCount.Value * 2
		lblCPUCount.Text = My.Settings.CPUCount.ToString
		'My.Settings.Save()
		updateLaunchStringAndColors()
	End Sub

	Private Sub tbarExThreads_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarExThreads.Scroll
		'Console.WriteLine("tbarExThreads_Scroll: " + (tBarExThreads.Value * 2).ToString)
		If tbarExThreads.Value = 0 Then
			My.Settings.ExThreads = tbarExThreads.Value
		Else
			My.Settings.ExThreads = tbarExThreads.Value * 2 - 1
		End If

		lblExThreads.Text = My.Settings.ExThreads

		'My.Settings.Save()
		updateLaunchStringAndColors()
	End Sub

	Private Sub cmbLaunchAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLaunchAction.SelectedIndexChanged
		My.Settings.LaunchAction = cmbLaunchAction.SelectedItem
	End Sub

	Private Sub cmbCustomMemoryAllocator_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomMemoryAllocator.SelectedIndexChanged
		My.Settings.CustomMemoryAllocator = cmbCustomMemoryAllocator.SelectedItem
		'My.Settings.Save()
		updateLaunchStringAndColors()
	End Sub

	Private Sub cmbProfileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProfileName.SelectedIndexChanged
		My.Settings.ProfileName = cmbProfileName.SelectedItem
		'My.Settings.Save()
		updateLaunchStringAndColors()
	End Sub

	Private Function foundFile(ByVal path As String, ByVal filename As String)
		If path.EndsWith(filename) Then
			Return File.Exists(path)
		Else
			Return File.Exists(path + "/" + filename)
		End If
	End Function

	Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
		'Process.Start("cmd.exe /C " + Application.ExecutablePath)

		savePresets()
		updateAllModsList()
		updateLaunchStringAndColors()

		setStatus("Successfully refreshed with " + lvModsAll.Items.Count.ToString + " mods and " + cmbPreset.Items.Count.ToString + " presets", True)
		checkForMissingMods()
	End Sub

	Private Sub btnLaunch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaunch.Click
		savePresets()
		setStatus("Launching with preset: " + cmbPreset.SelectedItem, True)
		'MsgBox("steam://rungameid/107410" + launchString)

		Dim p As New Process
		p.StartInfo.WorkingDirectory = My.Settings.A3Path.Substring(0, My.Settings.A3Path.LastIndexOf("\"))
		p.StartInfo.FileName = getExecutable()
		p.StartInfo.Arguments = launchString
		p.Start()
		'Process.Start(txtLaunchString.Text.Substring(0, txtLaunchString.Text.IndexOf(" -mod")), txtLaunchString.Text.Substring(txtLaunchString.Text.IndexOf(" -mod")))

		Select Case cmbLaunchAction.SelectedItem
			Case "Nothing"
				'Do Nothing
			Case "Minimize"
				Me.WindowState = FormWindowState.Minimized
			Case "Close"
				frmMain_FormClosing(sender, e)
		End Select
	End Sub


	'============================= PRESET MANAGEMENT ==================================

	Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
		Dim title As String = InputBox("Enter a name for the preset:", "New Preset", "")

		Try
			If title = "" Then
				setStatus("Preset not created", False)
				Return
			ElseIf Not IsNothing(cmbPreset.SelectedItem) Then
				If title = cmbPreset.SelectedItem.ToString Then
					setStatus("Preset not created", False)
					Return
				End If
			End If

			If Presets.Contains(title) Then
				setStatus("There is already a preset with this name.", False)
			Else
				Presets.Add(title, "")
				refreshPresetCmb()
				cmbPreset.SelectedItem = title

				setStatus("New preset created", True)
				savePresets()
			End If
		Catch ex As Exception
			setStatus("Preset not created", False)
		End Try
	End Sub


	Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
		If IsNothing(cmbPreset.SelectedItem) Then
			Return
		End If

		Dim title As String = InputBox("Enter a new name for the preset:", "Rename Preset", cmbPreset.SelectedItem)
		If title = "" Or title = cmbPreset.SelectedItem.ToString Then	'nothing was entered, cancel was clicked, or name was not changed
			setStatus("Preset not renamed", False)
		ElseIf Presets.Contains(title) Then
			setStatus("There is already a preset with this name.", False)
		Else
			Dim presetOriginal = Presets.Item(cmbPreset.SelectedItem)
			Dim index = cmbPreset.SelectedIndex

			Presets.Remove(cmbPreset.SelectedItem)
			Presets.Insert(index, title, presetOriginal)
			refreshPresetCmb()
			cmbPreset.SelectedItem = title
			savePresets()
			setStatus("Preset renamed", True)
		End If


	End Sub

	Private Sub btnDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicate.Click
		If IsNothing(cmbPreset.SelectedItem) Then
			Return
		End If

		Dim title As String = InputBox("Enter a name for the Preset:", "Duplicate Preset", cmbPreset.SelectedItem + " 2")
		If title = "" Or title = cmbPreset.SelectedItem.ToString Then
			setStatus("Preset not duplicated", False)
		ElseIf Presets.Contains(title) Then
			setStatus("There is already a preset with this name.", False)
		Else
			Dim presetOriginal = Presets.Item(cmbPreset.SelectedItem)

			Presets.Add(title, presetOriginal)
			refreshPresetCmb()
			cmbPreset.SelectedItem = title
			savePresets()
			setStatus("Preset duplicated", True)
		End If

	End Sub

	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		If IsNothing(cmbPreset.SelectedItem) Then
			Return
		End If

		Dim result = MessageBox.Show(
		 "Are you sure you want to delete this preset? This cannot be undone!",
		 "Confirm Deletion",
		 MessageBoxButtons.YesNo,
		 MessageBoxIcon.Warning)

		If (result = DialogResult.Yes) Then
			Presets.Remove(cmbPreset.SelectedItem)
			If cmbPreset.SelectedIndex > 0 Then
				cmbPreset.SelectedIndex = cmbPreset.SelectedIndex - 1
			ElseIf cmbPreset.SelectedIndex = 0 And cmbPreset.Items.Count > 1 Then
				cmbPreset.SelectedIndex = cmbPreset.SelectedIndex + 1
			Else 'selected preset is the last one
				cmbPreset.Items.Clear()
				cmbPreset.Text = ""
				lvModsCurrent.Items.Clear()
			End If
			refreshPresetCmb()
			savePresets()
			updateLaunchStringAndColors()
			setStatus("Preset deleted", True)
		Else
			setStatus("Preset not deleted", True)
		End If
	End Sub

	'===================================================================================

	Private Sub OnDesktopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnDesktopToolStripMenuItem.Click
		Dim wsh As Object = CreateObject("WScript.Shell")
		Dim desktopPath = wsh.SpecialFolders("Desktop")
		Dim shortcutName As String

		If IsNothing(cmbPreset.SelectedItem) Then
			shortcutName = "Arma 3 with Parameters"
		Else
			shortcutName = cmbPreset.SelectedItem
		End If

		Dim shortcut = wsh.CreateShortcut(desktopPath + "\" + shortcutName + ".lnk")

		shortcut.TargetPath = wsh.ExpandEnvironmentStrings("""" + My.Settings.A3Path + """")
		shortcut.Arguments = wsh.ExpandEnvironmentStrings(launchString)
		shortcut.WorkingDirectory = My.Settings.A3Path.Substring(0, My.Settings.A3Path.LastIndexOf("\"))

		shortcut.IconLocation = wsh.ExpandEnvironmentStrings(My.Settings.A3Path)
		shortcut.WindowStyle = 4

		shortcut.save()
		setStatus("Shortcut of preset " + cmbPreset.SelectedItem + " created", True)
	End Sub

	Private Sub ChooseLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseLocationToolStripMenuItem.Click
		Dim dialog As New SaveFileDialog
		dialog.Filter = ".lnk files (*.lnk)|*.lnk|All Files (*.*)|*.*"
		Dim shortcutName As String

		If IsNothing(cmbPreset.SelectedItem) Then
			shortcutName = "Arma 3 with Parameters"
		Else
			shortcutName = cmbPreset.SelectedItem
		End If

		dialog.FileName = shortcutName + ".lnk"
		Dim result = dialog.ShowDialog()
		Dim path As String
		If result = DialogResult.OK Then
			path = dialog.FileName

			Dim wsh As Object = CreateObject("WScript.Shell")
			Dim desktopPath = wsh.SpecialFolders("Desktop")
			Dim shortcut = wsh.CreateShortcut(path)

			shortcut.TargetPath = wsh.ExpandEnvironmentStrings("""" + My.Settings.A3Path + """")
			shortcut.Arguments = wsh.ExpandEnvironmentStrings(launchString)
			Dim workingDirPath As String = My.Settings.A3Path.Substring(0, My.Settings.A3Path.LastIndexOf("\"))
			shortcut.WorkingDirectory = workingDirPath


			shortcut.IconLocation = wsh.ExpandEnvironmentStrings(My.Settings.A3Path)
			shortcut.WindowStyle = 4

			shortcut.save()
			setStatus("Shortcut of preset " + cmbPreset.SelectedItem + " created", True)
		Else
			setStatus("Shortcut creation canceled", True)
		End If
	End Sub

	Private Sub tsbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAbout.Click
		dlgAbout.ShowDialog()
	End Sub

	Private Sub tsbUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUsage.Click
		dlgUsage.ShowDialog()
	End Sub

	'In case I ever find a way to get this working from the Steam Library
	'Private Sub InSteamLibraryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InSteamLibraryToolStripMenuItem.Click
	'	Process.Start("steam://AddNonSteamGame")
	'End Sub

	Private Sub A3StartupParametersWikiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A3StartupParametersWikiToolStripMenuItem.Click
		Process.Start("http://community.bistudio.com/wiki/Arma3:_Startup_Parameters")
	End Sub

	Private Sub btnGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroups.Click
		frmGroups.ShowDialog()
		updateAllModsList()
		updateLaunchStringAndColors()
	End Sub

	Private Sub tsiSetAltLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsiSetAltLoc.Click
		frmModLocations.ShowDialog()
		updateAllModsList()
		updateLaunchStringAndColors()
		checkForMissingMods()
		Dim count As Integer = 0
		For _i As Integer = 0 To My.Settings.ModLocations.Count - 1
			If _i = 0 Then
				If My.Settings.ModLocations(_i) = "1" Then
					count += 1
				End If
			ElseIf Not My.Settings.ModLocations(_i).StartsWith("!") Then
				count += 1
			End If
		Next
		Dim modCount As Integer = 0
		For Each item As ListViewItem In lvModsAll.Items
			If item.ForeColor = Color.Black Then
				modCount += 1
			End If
		Next
		setStatus("Refreshed with " + count.ToString + " modfolder locations and " + modCount.ToString + " modfolders", True)
	End Sub

	Private Sub RunBattleEyeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsiRunBattlEye.Click
		My.Settings.RunBattlEye = tsiRunBattlEye.Checked
		My.Settings.Save()
		My.Settings.A3Path = My.Settings.A3Path.Substring(0, (My.Settings.A3Path.LastIndexOf("\") + 1)) & getExecutable()
		My.Settings.Save()
		updateLaunchStringAndColors()
	End Sub

	Private Sub txtCustomParameters_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomParameters.TextChanged
		updateLaunchStringAndColors()
		My.Settings.CustomArguments = txtCustomParameters.Text
		My.Settings.Save()
	End Sub
End Class
