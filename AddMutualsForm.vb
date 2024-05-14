Imports System.IO.Pipelines
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class AddMutualsForm
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        If Guna2TextBox1.Text = OnlineUser.UserName.ToLower() Then

            MessageBox.Show("You want to be friend with yourself? really?")
            Return

        End If

        If Guna2TextBox1.Text <> OnlineUser.UserName Then

            FlowLayoutPanel1.Controls.Clear()

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID AND UN = @UN", conn)

                    cmd.Parameters.AddWithValue("@UID", Val(Guna2TextBox2.Text))
                    cmd.Parameters.AddWithValue("@UN", Guna2TextBox1.Text)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.HasRows = False Then

                        MessageBox.Show("Account not found")
                        Return

                    End If

                    While reader.Read()

                        Dim panel As New Guna2Panel
                        panel.Size = New Size(335, 68)
                        panel.FillColor = Color.FromArgb(39, 39, 39)
                        panel.BorderRadius = 20
                        panel.Tag = Val(reader("UID"))
                        FlowLayoutPanel1.Controls.Add(panel)

                        Dim picbox As New Guna2CirclePictureBox
                        picbox.Size = New Size(55, 55)
                        picbox.Location = New Point(10, 6)
                        picbox.BackColor = Color.Transparent
                        picbox.FillColor = Color.FromArgb(39, 39, 39)
                        picbox.Image = GlobalFunctions.ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        panel.Controls.Add(picbox)

                        Dim lbl As New Label()
                        lbl.Text = reader("FirstName") + " " + reader("LastName")
                        lbl.Location = New Point(80, 15)
                        lbl.BackColor = Color.Transparent
                        lbl.ForeColor = Color.White
                        lbl.Font = New Font("Segoe UI", 18, FontStyle.Regular)
                        lbl.Width = 200
                        lbl.Height = 40
                        panel.Controls.Add(lbl)

                        Dim isFriend As Boolean = False

                        For Each fren In OnlineUser.Friends

                            If fren = reader("UID") Then

                                isFriend = True

                            End If

                        Next

                        If Not isFriend Then

                            Dim btn As New Guna2CircleButton()
                            btn.Size = New Size(45, 45)
                            btn.Location = New Point(280, 12)
                            btn.BackColor = Color.Transparent
                            btn.FillColor = Color.FromArgb(39, 39, 39)
                            btn.ForeColor = Color.White
                            btn.Font = New Font("Segoe UI", 18, FontStyle.Bold)
                            btn.Text = "+"
                            AddHandler btn.Click, AddressOf add_mutual
                            panel.Controls.Add(btn)

                        End If

                    End While

                    reader.Close()

                End Using

                conn.Close()

            End Using

        Else

            MessageBox.Show("You want to be friend with yourself? really?")

        End If

    End Sub

    Private Sub add_mutual(sender As Object, e As EventArgs)

        Dim clckbtn As Guna2CircleButton = DirectCast(sender, Guna2CircleButton)

        If MessageBox.Show("Add as mutual?", "confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            clckbtn.Hide()

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("UPDATE user_tbl SET Friends = @Friends WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@Friends", OnlineUser.stringFriends + "," + clckbtn.Parent.Tag.ToString())
                    cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                    cmd.ExecuteNonQuery()

                End Using

                Using cmd As New MySqlCommand("UPDATE user_tbl SET Friends = CONCAT(Friends, @IDOfPerson) WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@IDOfPerson", "," + OnlineUser.UID.ToString())
                    cmd.Parameters.AddWithValue("@UID", clckbtn.Parent.Tag)

                    cmd.ExecuteNonQuery()

                End Using



                conn.Close()

            End Using

        End If

        OnlineUser.Friends.Add(clckbtn.Parent.Tag)
        OnlineUser.stringFriends += "," + clckbtn.Parent.Tag.ToString()

    End Sub

    Private Sub AddMutualsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class