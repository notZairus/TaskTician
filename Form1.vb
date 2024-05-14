Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Dim registrationForm As New RegistrationForm()

        Hide()
        RegistrationForm.ShowDialog()
        Show()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UN = @UN", conn)

                cmd.Parameters.AddWithValue("@UN", Guna2TextBox1.Text)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then

                    While reader.Read

                        If Guna2TextBox2.Text = reader("PW").ToString() Then

                            OnlineUser.UID = Val(reader("UID"))
                            OnlineUser.UserName = reader("UN").ToString()
                            OnlineUser.UserImage = ToImage(DirectCast(reader("ImageData"), Byte()))
                            OnlineUser.FirstName = reader("FirstName").ToString()
                            OnlineUser.MiddleName = reader("MiddleName").ToString()
                            OnlineUser.LastName = reader("LastName").ToString()
                            OnlineUser.stringFriends = reader("Friends").ToString()
                            OnlineUser.TotalTask = Val(reader("TotalTask"))
                            OnlineUser.CompletedTask = Val(reader("CompletedTask"))
                            OnlineUser.FailedTask = Val(reader("FailedTask"))
                            Get_Friends(reader("Friends").ToString())

                            Dim mainForm As New MainForm()
                            Hide()
                            mainForm.ShowDialog()
                            Show()

                        Else

                            MessageBox.Show("Incorrect Username or Password.")

                        End If

                    End While
                Else

                    MessageBox.Show("Account Not Found.")

                End If

                reader.Close()

            End Using

            conn.Close()

        End Using



    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If Guna2TextBox2.PasswordChar <> "*" Then
            Guna2TextBox2.PasswordChar = "*"
        Else
            Guna2TextBox2.PasswordChar = ""
        End If
    End Sub

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub
End Class
