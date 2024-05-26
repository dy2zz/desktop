Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusername.Text = "Username"
        txtusername.ForeColor = Color.DarkGray

        txtpassword.Text = "Password"
        txtpassword.ForeColor = Color.DarkGray

    End Sub
    Private Sub txtusername_GotFocus(sender As Object, e As EventArgs) Handles txtusername.GotFocus
        If txtusername.Text = "Username" Then
            txtusername.Text = ""
            txtusername.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtusername_LostFocus(sender As Object, e As EventArgs) Handles txtusername.LostFocus
        If txtusername.Text = "" Then
            txtusername.Text = "Username"
            txtusername.ForeColor = Color.DarkGray
        End If
    End Sub
    Private Sub txtpassword_GotFocus(sender As Object, e As EventArgs) Handles txtpassword.GotFocus
        If txtpassword.Text = "Password" Then
            txtpassword.Text = ""
            txtpassword.PasswordChar = "•"
            txtpassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtpassword_LostFocus(sender As Object, e As EventArgs) Handles txtpassword.LostFocus
        If txtpassword.Text = "" Then
            txtpassword.Text = "Password"
            txtpassword.PasswordChar = ""
            txtpassword.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        If AuthenticateUser() Then
            Dim form2 As New Form2()
            form2.Show()
            Me.Hide() ' Hide the login form
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
    End Sub
    Private Function AuthenticateUser() As Boolean
        Dim username As String = txtusername.Text
        Dim password As String = txtpassword.Text

        ' Check if username and password match expected values
        If username = "admin" AndAlso password = "admin123" Then
            Return True ' Authentication successful
        Else
            Return False ' Authentication failed
        End If

    End Function

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        Application.Exit()
    End Sub
End Class
