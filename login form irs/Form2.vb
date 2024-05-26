Public Class Form2
    Sub switchPanel(ByVal panel As Form)
        Panel3.Controls.Clear()
        panel.TopLevel = False
        Panel3.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Close()
    End Sub





    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        switchPanel(Manage_Students)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        switchPanel(Manage_Employer)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        switchPanel(ManagePostingApp)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        switchPanel(Application_Internship)
    End Sub
End Class