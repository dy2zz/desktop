Imports System.Data.SqlClient
Imports System.IO
Imports Guna.UI2.WinForms
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient

Public Class ManagePostingApp
    Private Sub ManagePostingApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_PostingApplicationData()
    End Sub

    Sub Load_PostingApplicationData()
        dgvPostingApplication.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM `internship`", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read
                        dgvPostingApplication.Rows.Add(dgvPostingApplication.Rows.Count + 1, dr.Item("Internship_ID"), dr.Item("Title"), dr.Item("Description"), dr.Item("Requirements"), dr.Item("Company_ID"))
                    End While
                End Using
            End Using
        End Using

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs)
        dgvPostingApplication.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM `internship` WHERE Internship_ID LIKE '%" & txtsearch.Text & "%' OR Title LIKE '%" & txtsearch.Text & "%' OR Description LIKE '%" & txtsearch.Text & "%' OR Requirements LIKE '%" & txtsearch.Text & "%' Or Company_ID Like '%" & txtsearch.Text & "%'", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read
                        dgvPostingApplication.Rows.Add(dgvPostingApplication.Rows.Count + 1, dr.Item("Internship_ID"), dr.Item("Title"), dr.Item("Description"), dr.Item("Requirements"), dr.Item("Company_ID"))
                    End While
                End Using
            End Using
        End Using

    End Sub
    Private Sub btnLoadEmployer_Click(sender As Object, e As EventArgs)
        dgvPostingApplication.Rows.Clear()
        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()
            Using cmd As New MySqlCommand("SELECT * FROM `internship` WHERE `applied_online` = 1", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        dgvPostingApplication.Rows.Add(dgvPostingApplication.Rows.Count + 1, dr.Item("Internship_ID"), dr.Item("Title"), dr.Item("Description"), dr.Item("Requirements"), dr.Item("Company_ID"))
                    End While
                End Using
            End Using
        End Using
    End Sub
End Class