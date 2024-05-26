Imports System.Data.SqlClient
Imports System.IO
Imports Guna.UI2.WinForms
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient
Public Class Manage_Students

    ' Load student data when form loads
    Private Sub Manage_StudentsLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_studentData()
    End Sub

    ' Method to load student data from the database
    Sub Load_studentData()
        dgvStudents.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM `activated_student`", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read
                        dgvStudents.Rows.Add(dgvStudents.Rows.Count + 1, dr.Item("studentID"), dr.Item("NAME"), dr.Item("email"), dr.Item("course"), dr.Item("address"), dr.Item("contact_no"))
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Method to handle text changed event for search TextBox
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        dgvStudents.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()
            Using cmd As New MySqlCommand("SELECT * FROM `activated_student` WHERE studentID LIKE '%" & txt_search.Text & "%' OR NAME LIKE '%" & txt_search.Text & "%' OR email LIKE '%" & txt_search.Text & "%' OR address LIKE '%" & txt_search.Text & "%' OR contact_no LIKE '%" & txt_search.Text & "%'", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read
                        dgvStudents.Rows.Add(dgvStudents.Rows.Count + 1, dr.Item("studentID"), dr.Item("NAME"), dr.Item("email"), dr.Item("course"), dr.Item("address"), dr.Item("contact_no"))
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Method to handle load students button click
    Private Sub btnLoadStudents_Click(sender As Object, e As EventArgs) Handles btnLoadStudents.Click
        Load_studentData()
    End Sub

    ' Method to handle add student button click
    Private Sub btnAddStudents_Click(sender As Object, e As EventArgs) Handles btnAddStudents.Click
        AddStudents(txtStudentID.Text, txtName.Text, txtEmail.Text, txtCourse.Text, txtAddress.Text, ContactNo.Text)
    End Sub

    ' Method to add a new student to the database
    Private Sub AddStudents(studentID As String, name As String, email As String, course As String, address As String, contactNo As String)
        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()

            Using cmd As New MySqlCommand("INSERT INTO `activated_student` (studentID, NAME, email, course, address, contact_no) VALUES (@studentID, @name, @Email, @Course, @Address, @ContactNo)", conn)
                cmd.Parameters.AddWithValue("@studentID", studentID)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Course", course)
                cmd.Parameters.AddWithValue("@Address", address)
                cmd.Parameters.AddWithValue("@ContactNo", contactNo)

                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Reload student data to reflect the new addition
        Load_studentData()
    End Sub


End Class
