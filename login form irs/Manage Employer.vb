Imports System.Data.SqlClient
Imports System.IO
Imports Guna.UI2.WinForms
Imports Microsoft.SqlServer
Imports MySql.Data.MySqlClient

Public Class Manage_Employer

    Private Sub Manage_EmployerLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_employerData()

    End Sub
    Sub Load_employerData()
        dgvEmployer.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
                conn.Open()

                Using cmd As New MySqlCommand("SELECT * FROM `activated_employer`", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read
                            dgvEmployer.Rows.Add(dgvEmployer.Rows.Count + 1, dr.Item("Company_ID"), dr.Item("NAME"), dr.Item("email"), dr.Item("access"), dr.Item("Contact_No"), dr.Item("Location"))
                        End While
                    End Using
                End Using
            End Using

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs)
        dgvEmployer.Rows.Clear()

        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM `activated_employer` WHERE Company_ID LIKE '%" & txtsearch.Text & "%' OR NAME LIKE '%" & txtsearch.Text & "%' OR email LIKE '%" & txtsearch.Text & "%' OR Contact_No LIKE '%" & txtsearch.Text & "%' Or access Like '%" & txtsearch.Text & "%' Or Location Like '%" & txtsearch.Text & "%'", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read
                        dgvEmployer.Rows.Add(dgvEmployer.Rows.Count + 1, dr.Item("Company_ID"), dr.Item("NAME"), dr.Item("email"), dr.Item("access"), dr.Item("Location"), dr.Item("Contact_No"))
                    End While
                End Using
            End Using
        End Using

    End Sub
    Private Sub btnLoadEmployer_Click(sender As Object, e As EventArgs)
        dgvEmployer.Rows.Clear()
        Using conn As New MySqlConnection("server=localhost;user=root;password=2474;database=cdm-internship-database")
            conn.Open()
            Using cmd As New MySqlCommand("SELECT * FROM `activated_employer` WHERE `applied_online` = 1", conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        dgvEmployer.Rows.Add(dgvEmployer.Rows.Count + 1, dr.Item("Company_ID"), dr.Item("NAME"), dr.Item("email"), dr.Item("access"), dr.Item("Contact_No"), dr.Item("Location"))
                    End While
                End Using
            End Using
        End Using
    End Sub




End Class