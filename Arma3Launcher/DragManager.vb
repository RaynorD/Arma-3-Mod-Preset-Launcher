Public Class DragManager
	Private _currentIndex As Integer
	Private _mouseIsDown As Boolean
	Private _parent As Form

	Sub New(ByVal p As Form)
		_parent = p
	End Sub

	Public Property parent As Form
		Get
			Return _parent
		End Get
		Set(ByVal value As Form)
			_parent = value
		End Set
	End Property

	Public Sub MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		_mouseIsDown = True
	End Sub

	Public Sub MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		_mouseIsDown = False
	End Sub

	Public Sub MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
		_mouseIsDown = False
	End Sub

	Public Sub MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		If _mouseIsDown Then
			If sender.SelectedItems.count = 1 Then
				_currentIndex = sender.SelectedIndices(0)
			Else
				_currentIndex = -1
				Return
			End If

			Dim newIndex = sender.Items.IndexOf(sender.GetItemAt(e.X, e.Y))
			If newIndex <> _currentIndex And newIndex > -1 And _currentIndex > -1 Then
				'Console.WriteLine("Dragger.MouseMove: " + currentIndex.ToString + " to " + newIndex.ToString)

				If (_parent Is frmMain) Then
					If newIndex > _currentIndex Then	' Mouse moved down in list
						frmMain.moveSelectedItemDown()
					Else ' newIndex < currentIndex, Mouse moved up in list
						frmMain.moveSelectedItemUp()
					End If
				Else
					If newIndex > _currentIndex Then	' Mouse moved down in list
						frmGroups.moveSelectedItemDown()
					Else ' newIndex < currentIndex, Mouse moved up in list
						frmGroups.moveSelectedItemUp()
					End If
				End If

				_currentIndex = newIndex
			End If
		End If
	End Sub
End Class
