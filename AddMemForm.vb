Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud

Public Class AddMemForm

    Dim groupMem As New List(Of Integer)
    Dim tempFriends As New List(Of Integer)

    Dim addedFriend As New List(Of Integer)

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub AddMemForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        groupMem.Clear()
        tempFriends.Clear()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT GroupMembers FROM group_tbl WHERE ID_GroupName = @ID_GroupName", conn)

                cmd.Parameters.AddWithValue("@ID_GroupName", OnlineUser.OG_ID_GroupName)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim memlist As New List(Of String)(Split(reader("GroupMembers"), ","))

                    For Each mem In memlist

                        groupMem.Add(Val(mem))

                    Next

                End While

            End Using

            conn.Close()

        End Using

        For Each fren In OnlineUser.Friends

            tempFriends.Add(fren)

        Next

        For i As Integer = 0 To Friends.Count - 1 Step 1

            For j As Integer = 0 To groupMem.Count - 1 Step 1

                If Friends(i) = groupMem(j) Then

                    tempFriends.Remove(groupMem(j))

                End If

            Next

        Next

        Load_NonMemberFriends()

    End Sub

    Private Sub Load_NonMemberFriends()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            For Each fren In tempFriends

                Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", fren)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim panel As New Guna2Panel
                        panel.Size = New Size(335, 72)
                        panel.FillColor = Color.FromArgb(39, 39, 39)
                        panel.BorderRadius = 20
                        panel.Tag = fren
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
                        AddHandler btn.Click, AddressOf add_Member
                        panel.Controls.Add(btn)

                    End While

                    reader.Close()

                End Using

            Next

            conn.Close()

        End Using

    End Sub

    Private Sub add_Member(sender As Object, e As EventArgs)

        Dim btn As Guna2CircleButton = DirectCast(sender, Guna2CircleButton)

        If btn.Text = "+" Then
            btn.Text = "-"
            addedFriend.Add(btn.Parent.Tag)
            FlowLayoutPanel2.Controls.Add(btn.Parent)
            FlowLayoutPanel1.Controls.Remove(btn.Parent)

        Else
            btn.Text = "+"
            addedFriend.Remove(btn.Parent.Tag)
            FlowLayoutPanel1.Controls.Add(btn.Parent)
            FlowLayoutPanel2.Controls.Remove(btn.Parent)
        End If

    End Sub

    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("UPDATE group_tbl SET GroupMembers = CONCAT(GroupMembers, @GroupMembers) WHERE ID_GroupName = @ID_GroupName", conn)

                cmd.Parameters.AddWithValue("@GroupMembers", "," + String.Join(",", addedFriend))
                cmd.Parameters.AddWithValue("@ID_GroupName", OG_ID_GroupName)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        MessageBox.Show("Added Successfully.")

        Close()

    End Sub

End Class