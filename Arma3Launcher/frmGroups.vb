Imports System.Collections.Specialized
Imports System.IO
Imports System.Windows.Forms.ListBox
Imports Arma3ModPresetLauncher.DragManager

Public Class frmGroups
	Private Groups As New OrderedDictionary()
	Private dragger As DragManager

	Protected Friend ReadOnly frmGroupsDefaultSize = New Size(450, 380)

	Private Sub frmGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		dragger = New DragManager(Me)

		If Not IsNothing(My.Settings.GroupList) Then
			loadGroups()
		End If

		lvModsAll.Items.Clear()
		For Each m In frmMain.modAllList
			lvModsAll.Items.Add(m)
		Next
		updateColors()
		loadSizeAndCenter()

		lvModsAll.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
		lvModsCurrent.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
	End Sub

	Private Sub loadSizeAndCenter()
		If IsNothing(My.Settings.GroupSize) Then
			My.Settings.GroupSize = frmGroupsDefaultSize
			My.Settings.Save()
		End If

		Me.Size = My.Settings.GroupSize

		Me.Location = New Point(frmMain.Left + (frmMain.Width / 2) - (Me.Size.Width / 2), frmMain.Top + (frmMain.Height / 2) - (Me.Size.Height / 2))
	End Sub

	Private Sub saveSize()
		My.Settings.GroupSize = Me.Size
		My.Settings.Save()
	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Me.Close()
	End Sub

	Private Sub frmGroups_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		saveGroups()
		saveSize()
	End Sub


	'============================= GROUP MANAGEMENT ==================================

	Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
		Dim enteredTitle = ""
		Dim title As String = InputBox("Enter a name for the group:", "New Group", enteredTitle)
		If title = "" Then
			'setStatus("You must enter a name for the group", False)
		ElseIf Groups.Contains(title) Then
			MsgBox("There is already a group with this name.", MsgBoxStyle.Critical, "Error")
			enteredTitle = title
		Else
			Groups.Add(title, "")
			refreshGroupCmb()

			cmbGroup.SelectedItem = title
			'setStatus("New group created", True)
			saveGroups()
		End If
		updateColors()
	End Sub


	Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
		If IsNothing(cmbGroup.SelectedItem) Then
			Return
		End If
		Dim title As String = InputBox("Enter a new name for the group:", "Rename Group", cmbGroup.SelectedItem)
		If title = "" Or title = cmbGroup.SelectedItem.ToString Then
			'setStatus("You didn't enter a name, group not renamed", False)
		ElseIf Groups.Contains(title) Then
			MsgBox("There is already a group with this name.", MsgBoxStyle.Critical, "Error")
		Else
			Dim groupOriginal = Groups.Item(cmbGroup.SelectedItem)
			Dim index = cmbGroup.SelectedIndex

			Groups.Remove(cmbGroup.SelectedItem)
			Groups.Insert(index, title, groupOriginal)
			refreshGroupCmb()
			cmbGroup.SelectedItem = title
			saveGroups()
			'setStatus("Group renamed", True)
		End If
	End Sub

	Private Sub btnDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicate.Click
		If IsNothing(cmbGroup.SelectedItem) Then
			Return
		End If
		'There aren't any groups, do nothing
		Dim title As String = InputBox("Enter a name for the Group:", "Duplicate Group", cmbGroup.SelectedItem + " 2")
		If title = "" Or title = cmbGroup.SelectedItem.ToString Then
			'setStatus("You must enter a name for the group", False)
		ElseIf Groups.Contains(title) Then
			MsgBox("There is already a group with this name.", MsgBoxStyle.Critical, "Error")
		Else
			Dim groupOriginal = Groups.Item(cmbGroup.SelectedItem)

			Groups.Add(title, groupOriginal)
			refreshGroupCmb()
			cmbGroup.SelectedItem = title
			saveGroups()
			'setStatus("Group duplicated", True)
		End If
	End Sub

	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		If IsNothing(cmbGroup.SelectedItem) Then
			Return
		End If
		Dim result = MessageBox.Show(
		 "Are you sure you want to delete this group? This cannot be undone!",
		 "Confirm Deletion",
		 MessageBoxButtons.YesNo,
		 MessageBoxIcon.Warning)

		If (result = DialogResult.Yes) Then
			Groups.Remove(cmbGroup.SelectedItem)
			If cmbGroup.SelectedIndex > 0 Then
				cmbGroup.SelectedIndex = cmbGroup.SelectedIndex - 1
			ElseIf cmbGroup.SelectedIndex = 0 And cmbGroup.Items.Count > 1 Then
				cmbGroup.SelectedIndex = cmbGroup.SelectedIndex + 1
			Else 'selected group is the last one
				cmbGroup.Items.Clear()
				cmbGroup.Text = ""
				lvModsCurrent.Items.Clear()
			End If
			refreshGroupCmb()
			saveGroups()
		End If

		updateColors()
	End Sub

	'==================================================================

	Private Sub saveGroups()
		If IsNothing(My.Settings.GroupList) Then
			My.Settings.GroupList = New StringCollection
		Else
			My.Settings.GroupList.Clear()
		End If
		For Each group In Groups.Keys
			My.Settings.GroupList.Add(group + ";" + Groups.Item(group))
		Next
		My.Settings.Save()
	End Sub

	Private Sub loadGroups()
		Groups.Clear()
		For Each group In My.Settings.GroupList
			Dim key As String = group.Substring(0, group.IndexOf(";"))
			Dim value As String = group.Substring(group.IndexOf(";") + 1)
			Groups.Add(key, value)
		Next
		refreshGroupCmb()
	End Sub

	Private Sub cmbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroup.SelectedIndexChanged
		'Console.WriteLine("cmbGroup_SelectedIndexChanged: " + cmbGroup.SelectedIndex.ToString)
		updateCurrentGroup()
	End Sub

	Private Sub refreshGroupCmb()
		Dim oldSelected As String = cmbGroup.SelectedItem
		cmbGroup.Items.Clear()
		For Each group In Groups.Keys
			cmbGroup.Items.Add(group)
		Next

		If IsNothing(oldSelected) And cmbGroup.Items.Count > 0 Then
			cmbGroup.SelectedIndex = 0
		Else
			cmbGroup.SelectedItem = oldSelected
		End If
	End Sub

	Private Sub updateColors()
		For Each item As ListViewItem In lvModsAll.Items
			If IsNothing(frmMain.findInListView(item.Text, lvModsCurrent)) Then
				item.ForeColor = Color.Black
			Else 'Mod is already in the active group
				item.ForeColor = Color.FromArgb(frmMain.activeColor, frmMain.activeColor, frmMain.activeColor)
			End If
		Next

		For Each item As ListViewItem In lvModsCurrent.Items
			If IsNothing(frmMain.findInListView(item.Text, lvModsAll)) Then	'Mod is in group but has been changed/removed from A3
				item.ForeColor = Color.Red
			Else
				item.ForeColor = Color.Black
			End If
		Next
	End Sub

	Private Sub updateCurrentGroup()
		'Console.WriteLine("updateCurrentGroup: " + cmbGroup.SelectedItem)
		Dim items As ArrayList = getGroup(cmbGroup.SelectedItem) 'get array from settings
		Dim itemsStrArr() As String = items.ToArray(GetType(String))

		lvModsCurrent.Items.Clear()
		For Each item In items
			lvModsCurrent.Items.Add(item.ToString)
		Next
	End Sub

	Private Function getGroup(ByVal group As String)
		'Console.WriteLine("getGroup: " + group.ToString)
		Dim groupArray = Groups.Item(group).Split(New Char() {","c})

		Dim groupArrayList = New ArrayList
		groupArrayList.AddRange(groupArray)
		Return groupArrayList
	End Function

	Private Sub saveGroup(ByVal group As String, ByVal mods As ArrayList)
		Dim modStr As String = String.Join(",", mods.ToArray)
		Groups.Item(group) = modStr
	End Sub

	' ================================= REORDER CURRENT MODS =====================================


	'Private Sub ctrlArrowKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvModsCurrent.KeyDown
	'	If e.Modifiers = Keys.Control Then
	'		If e.KeyCode = Keys.Up Then
	'			moveSelectedItemUp()
	'		ElseIf e.KeyCode = Keys.Down Then
	'			moveSelectedItemUp()
	'		End If
	'	End If
	'End Sub

	Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		moveSelectedItemUp()
	End Sub

	Protected Friend Sub moveSelectedItemUp()
		If lvModsCurrent.SelectedIndices.Count = 0 Then
			'setStatus("You must select an item to move", False)
			Return
		End If

		Dim selectedIndex = lvModsCurrent.SelectedIndices(0)

		If selectedIndex = 0 Then
			'Do nothing, can't move up
			'setStatus("This mod is already at the top of the list!", False)
		Else
			Dim group = cmbGroup.SelectedItem
			Dim selectedMod = lvModsCurrent.SelectedItems(0).Text

			Dim modList As ArrayList = getGroup(group)

			modList.Insert(selectedIndex - 1, selectedMod) ' insert mod one up and delete later location
			modList.RemoveAt(modList.LastIndexOf(selectedMod))

			saveGroup(group, modList)
			updateCurrentGroup()

			lvModsCurrent.Focus()
			lvModsCurrent.Items.Item(selectedIndex - 1).Selected = True	' Set selection back to same mod
		End If
	End Sub

	Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		moveSelectedItemDown()
	End Sub

	Protected Friend Sub moveSelectedItemDown()
		If lvModsCurrent.SelectedIndices.Count = 0 Then
			'setStatus("You must select an item to move", False)
			Return
		End If

		Dim selectedIndex = lvModsCurrent.SelectedIndices(0)

		If selectedIndex = (lvModsCurrent.Items.Count - 1) Then
			'Do nothing, can't move down
			'setStatus("This mod is already at the bottom of the list!", False)
		Else
			Dim group = cmbGroup.SelectedItem
			Dim selectedMod = lvModsCurrent.SelectedItems(0).Text

			Dim modList As ArrayList = getGroup(group)

			modList.Insert(selectedIndex + 2, selectedMod) ' insert mod one down and delete earlier location
			modList.RemoveAt(modList.IndexOf(selectedMod))

			saveGroup(group, modList)
			updateCurrentGroup()

			lvModsCurrent.Focus()
			lvModsCurrent.Items.Item(selectedIndex + 1).Selected = True	' Set selection back to same mod
		End If
	End Sub

	' ============================ CUSTOM DRAG AND DROP =================================

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
	End Sub

	Private Sub lvModsCurrent_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvModsCurrent.MouseMove
		'Console.WriteLine("MouseMove: " + e.Y.ToString)
		dragger.MouseMove(sender, e)
	End Sub

	'===================== ADD AND REMOVE MODS FROM GROUPS ==========================

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		addModsToCurrent()
	End Sub

	Private Sub lvModsAll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsAll.DoubleClick
		addModsToCurrent()
	End Sub

	Private Sub addModsToCurrent()
		Dim modsToAdd = lvModsAll.SelectedItems

		If modsToAdd.Count = 0 Then
			Return
		End If

		If IsNothing(cmbGroup.SelectedItem) Then
			Groups.Add("New Group", "")
			refreshGroupCmb()
			cmbGroup.SelectedItem = "New Group"
			saveGroups()
		End If

		Dim group As ArrayList = getGroup(cmbGroup.SelectedItem)

		Dim numAdded As Integer = 0
		Dim modsAdded As New ArrayList
		modsAdded.AddRange(modsToAdd)
		For Each m In modsToAdd	'm is listviewitem, have to get text to check for presence in group
			Dim modname = m.Text
			If Not group.Contains(modname) And modname <> "" Then
				group.Add(modname)
				numAdded += 1
			Else
				modsAdded.Remove(m)
			End If
		Next
		If group.Contains("") Then
			group.Remove("")
		End If
		saveGroup(cmbGroup.SelectedItem, group)
		updateCurrentGroup()

		lvModsCurrent.Focus()

		For Each m In modsAdded
			lvModsCurrent.FindItemWithText(m.text, True, 0).Selected = True
		Next

		lvModsCurrent.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
		updateColors()
	End Sub

	Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
		removeModsFromCurrent()
	End Sub

	Private Sub lvModsCurrent_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModsCurrent.DoubleClick
		removeModsFromCurrent()
	End Sub

	Private Sub removeModsFromCurrent()
		Dim modsToRemove = lvModsCurrent.SelectedItems

		If modsToRemove.Count = 0 Then
			Return
		End If

		Dim group As ArrayList = getGroup(cmbGroup.SelectedItem)

		Dim numRemoved As Integer = 0
		Dim modsRemoved As New ArrayList
		modsRemoved.AddRange(modsToRemove)
		For Each m In modsToRemove
			group.Remove(m.Text)
			numRemoved += 1
		Next
		saveGroup(cmbGroup.SelectedItem, group)
		updateCurrentGroup()

		lvModsCurrent.Focus()
		updateColors()
	End Sub


	'================================================================================

End Class