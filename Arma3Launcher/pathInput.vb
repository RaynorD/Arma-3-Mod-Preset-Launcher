Public Class pathInput
	Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
		Dim dialog As New OpenFileDialog()

		dialog.InitialDirectory = Environment.SpecialFolder.MyComputer
		dialog.Filter = "Arma 3|arma3.exe"

		If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
			txtPath.Text = dialog.FileName
			Me.DialogResult = DialogResult.OK
			Me.Close()
		End If
	End Sub
End Class