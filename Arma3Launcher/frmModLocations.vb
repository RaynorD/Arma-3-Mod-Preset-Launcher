Imports System.Collections.Specialized
Imports System.IO

Public Class frmModLocations

	Private Sub frmModLocations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		clbModLocations.Items.Clear()
		clbModLocations.Items.Add("Arma 3 Directory")
		If My.Settings.ModLocations(0) = "1" Then
			clbModLocations.SetItemChecked(0, True)
		End If

		Dim foldersNotFound = New ArrayList
		For Each item In My.Settings.ModLocations
			If Not My.Settings.ModLocations.IndexOf(item) = 0 Then
				If item.StartsWith("!") Then '! is flag for unselected
					clbModLocations.Items.Add(item.Substring(1))
					clbModLocations.SetItemChecked(clbModLocations.Items.Count - 1, False)
				Else
					clbModLocations.Items.Add(item)
					clbModLocations.SetItemChecked(clbModLocations.Items.Count - 1, True)
				End If
			End If
			If Not Directory.Exists(item.Replace("!", "")) Then
				If item <> "1" Then
					foldersNotFound.Add(item.Replace("!", ""))
					clbModLocations.SetItemChecked(clbModLocations.Items.Count - 1, False)
				End If
			End If
		Next

		If foldersNotFound.Count > 0 Then
			Dim arrFoldersNotFound = foldersNotFound.ToArray
			MessageBox.Show("The following modfolders could not be found:" + vbCrLf + vbCrLf + String.Join(vbCrLf, arrFoldersNotFound),
			 "Warning",
			 MessageBoxButtons.OK,
			 MessageBoxIcon.Exclamation)
		End If
	End Sub

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim dialog As New FolderBrowserDialog
		dialog.Description = "Select a folder that contains modfolders for Arma 3:"
		dialog.RootFolder = Environment.SpecialFolder.MyComputer
		dialog.ShowNewFolderButton = True
		If dialog.ShowDialog = DialogResult.OK Then
			clbModLocations.Items.Add(dialog.SelectedPath, True)
		End If
	End Sub

	Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
		If clbModLocations.SelectedItem = "Arma 3 Directory" Then
			Return
		End If
		clbModLocations.Items.Remove(clbModLocations.SelectedItem)
	End Sub

	Private Sub frmModLocations_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		clbModLocations.SelectedItems.Clear()
		My.Settings.ModLocations = New StringCollection
		For _i As Integer = 0 To clbModLocations.Items.Count - 1
			If _i = 0 Then
				If clbModLocations.GetItemChecked(_i) Then
					My.Settings.ModLocations.Add("1")
				Else
					My.Settings.ModLocations.Add("0")
				End If
			Else
				If clbModLocations.GetItemChecked(_i) Then
					My.Settings.ModLocations.Add(clbModLocations.Items.Item(_i))
				Else
					My.Settings.ModLocations.Add("!" + clbModLocations.Items.Item(_i))
				End If
			End If
		Next
	End Sub

	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		Me.Dispose()
	End Sub
End Class