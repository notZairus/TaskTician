Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class ShowMutualsForm

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub ShowMutualsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Friends()

    End Sub

    Private Sub Load_Friends()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            For Each frend In OnlineUser.Friends

                Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", frend)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim panel As New Guna2Panel
                        panel.Size = New Size(335, 72)
                        panel.FillColor = Color.FromArgb(39, 39, 39)
                        panel.BorderRadius = 20
                        panel.Tag = Val(reader("UID"))
                        FlowLayoutPanel1.Controls.Add(panel)

                        Dim picbox As New Guna2CirclePictureBox
                        picbox.Size = New Size(55, 55)
                        picbox.Location = New Point(10, 8)
                        picbox.BackColor = Color.Transparent
                        picbox.FillColor = Color.FromArgb(39, 39, 39)
                        picbox.Image = GlobalFunctions.ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        panel.Controls.Add(picbox)

                        Dim lbl As New Label()
                        lbl.Text = reader("FirstName") + " " + reader("LastName")
                        lbl.Location = New Point(80, 17)
                        lbl.BackColor = Color.Transparent
                        lbl.ForeColor = Color.White
                        lbl.Font = New Font("Segoe UI", 18, FontStyle.Regular)
                        lbl.Width = 200
                        lbl.Height = 40
                        panel.Controls.Add(lbl)

                    End While

                    reader.Close()

                End Using

            Next

            conn.Close()

        End Using

    End Sub

End Class