Imports System.IO
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

        If Guna2TextBox4.Text = "" Or Guna2TextBox5.Text = "" Or Guna2TextBox6.Text = "" Or Guna2TextBox1.Text = "" Then

            MessageBox.Show("Fill out the Registration form")
            Return

        End If

        If Guna2TextBox3.Text = "" Then

            MessageBox.Show("Confirm your password")
            Return

        End If

        If Guna2TextBox2.Text.Length < 7 Or Guna2TextBox3.Text.Length < 7 Then

            MessageBox.Show("Password must be longer than 7 letters")
            Return

        End If

        If Guna2TextBox2.Text <> Guna2TextBox3.Text Then

            MessageBox.Show("The password doesn't match")
            Return

        End If

        Dim imgData As Byte()

        Using mem As New MemoryStream()

            Dim img As Image = PictureBox1.Image
            img.Save(mem, img.RawFormat)

            imgData = mem.ToArray()

        End Using

        If Guna2TextBox2.Text = Guna2TextBox3.Text Then

            Using conn As New MySqlConnection(Connections.connString)

                Dim qry As String = "INSERT INTO user_tbl(UN, PW, ImageData, FirstName, MiddleName, LastName, Email, Friends, TotalTask, CompletedTask, FailedTask) 
                                    VALUES (@UN, @PW, @ImageData, @FirstName, @MiddleName, @LastName, @Email, @Friends, @TotalTask, @CompletedTask, @FailedTask)"

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
                    cmd.Parameters.AddWithValue("@TotalTask", 0)
                    cmd.Parameters.AddWithValue("@CompletedTask", 0)
                    cmd.Parameters.AddWithValue("@FailedTask", 0)
                    cmd.ExecuteNonQuery()

                End Using

                MessageBox.Show("Registered Successfully!")
                conn.Close()

            End Using

            Close()

        End If

    End Sub
End Class