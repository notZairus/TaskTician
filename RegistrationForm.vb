﻿Imports System.IO
Imports MySql.Data.MySqlClient

Public Class RegistrationForm
    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim ofd As New OpenFileDialog()

        If ofd.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(ofd.FileName)
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Dim imgData As Byte()

        Using mem As New MemoryStream()

            Dim img As Image = PictureBox1.Image
            img.Save(mem, img.RawFormat)

            imgData = mem.ToArray()

        End Using

        If Guna2TextBox2.Text = Guna2TextBox3.Text Then

            Using conn As New MySqlConnection(Connections.connString)

                Dim qry As String = "INSERT INTO user_tbl(UN, PW, ImageData, FirstName, MiddleName, LastName, Email, Friends) 
                                    VALUES (@UN, @PW, @ImageData, @FirstName, @MiddleName, @LastName, @Email, @Friends)"

                conn.Open()

                Using cmd As New MySqlCommand(qry, conn)

                    cmd.Parameters.AddWithValue("@UN", Guna2TextBox1.Text)
                    cmd.Parameters.AddWithValue("@PW", Guna2TextBox2.Text)
                    cmd.Parameters.Add("@ImageData", MySqlDbType.LongBlob).Value = imgData
                    cmd.Parameters.AddWithValue("@FirstName", Guna2TextBox4.Text)
                    cmd.Parameters.AddWithValue("@MiddleName", Guna2TextBox5.Text)
                    cmd.Parameters.AddWithValue("@LastName", Guna2TextBox6.Text)
                    cmd.Parameters.AddWithValue("@Email", Guna2TextBox7.Text)
                    cmd.Parameters.AddWithValue("@Friends", "^")
                    cmd.ExecuteNonQuery()

                End Using

                MessageBox.Show("Registered Successfully!")
                conn.Close()

            End Using

            Close()

        End If

    End Sub
End Class