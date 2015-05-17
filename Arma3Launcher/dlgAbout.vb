Imports System.Windows.Forms

Public Class dlgAbout
	Private Sub dlgAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'txtCav.Focus()
		'linkCav.BackColor = Color.FromArgb(96, 255, 255, 255)
	End Sub

	Private Sub linkCav_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkCav.LinkClicked
		Process.Start("http://www.7thCavalry.us")
	End Sub

	Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
		Process.Start("ts3server://ts3.7thCavalry.us??password=7thCavalry&port=9987")
	End Sub
End Class
