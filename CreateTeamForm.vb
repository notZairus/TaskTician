Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class CreateTeamForm

    Dim memlist As New List(Of Integer)

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub CreateTeamForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Mutuals()

    End Sub

    Private Sub Load_Mutuals()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            For Each frnd In OnlineUser.Friends

                Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", frnd)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader

                    While reader.Read()

                        Dim panel As New Guna2Panel
                        panel.Size = New Size(335, 72)
                        panel.FillColor = Color.FromArgb(39, 39, 39)
                        panel.BorderRadius = 20
                        panel.Tag = frnd
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

                        Dim btn As New Guna2CircleButton()
                        btn.Size = New Size(45, 45)
                        btn.Location = New Point(280, 12)
                        btn.BackColor = Color.Transparent
                        btn.FillColor = Color.FromArgb(39, 39, 39)
                        btn.ForeColor = Color.White
                        btn.Font = New Font("Segoe UI", 18, FontStyle.Bold)
                        btn.Text = "+"
                        AddHandler btn.Click, AddressOf addrem_Member
                        panel.Controls.Add(btn)

                    End While

                    reader.Close()

                End Using

            Next

            conn.Close()

        End Using

    End Sub

    Private Sub addrem_Member(sender As Object, e As EventArgs)

        Dim btn As Guna2CircleButton = DirectCast(sender, Guna2CircleButton)

        If btn.Text = "+" Then
            btn.Text = "-"
            memlist.Add(btn.Parent.Tag)
            FlowLayoutPanel2.Controls.Add(btn.Parent)
            FlowLayoutPanel1.Controls.Remove(btn.Parent)
        Else
            btn.Text = "+"
            memlist.Remove(btn.Parent.Tag)
            FlowLayoutPanel1.Controls.Add(btn.Parent)
            FlowLayoutPanel2.Controls.Remove(btn.Parent)
        End If


    End Sub

    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click

        If Guna2TextBox1.Text = "" Then

            MessageBox.Show("Set the group name.")
            Return

        End If

        Using conn As New MySqlConnection(Connections.teamConnString)

            Dim qry As String = "CREATE TABLE " + OnlineUser.UserName + Guna2TextBox1.Text + "_chat (
                                    MID int primary key auto_increment,
                                    Message varchar(1000) not null,
                                    Sender int not null, 
                                    MessageDate Datetime not null 
                                );"

            conn.Open()

            Using cmd As New MySqlCommand(qry, conn)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        Using conn As New MySqlConnection(Connections.teamConnString)

            Dim qry As String = "CREATE TABLE " + OnlineUser.UserName + Guna2TextBox1.Text + "_task (
                                    TTID int primary key auto_increment,
                                    TaskName varchar(150) not null,
                                    TaskInfo varchar(600),
                                    Assigned varchar(100) not null,
                                    TaskStatus varchar(50) not null,
                                    TaskDeadline Date
                                );"

            conn.Open()

            Using cmd As New MySqlCommand(qry, conn)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("INSERT INTO group_tbl(GroupName, OwnerID, GroupMembers, DateCreated, ID_GroupName, TotalTask, CompletedTask, Progress) VALUES (@GroupName, @OwnerID, @GroupMembers, @DateCreated, @ID_GroupName, @TotalTask, @CompletedTask, @Progress)", conn)

                cmd.Parameters.AddWithValue("@GroupName", Guna2TextBox1.Text)
                cmd.Parameters.AddWithValue("@OwnerID", OnlineUser.UID)
                cmd.Parameters.AddWithValue("@GroupMembers", String.Join(",", memlist))
                cmd.Parameters.AddWithValue("@DateCreated", Date.Today)
                cmd.Parameters.AddWithValue("@ID_GroupName", OnlineUser.UserName + Guna2TextBox1.Text)
                cmd.Parameters.AddWithValue("@TotalTask", 0)
                cmd.Parameters.AddWithValue("@CompletedTask", 0)
                cmd.Parameters.AddWithValue("@Progress", 0.00)
                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        MessageBox.Show("Group Successfully Created!")
        Close()

    End Sub

End Class