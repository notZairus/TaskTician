Imports System.Runtime.CompilerServices
Imports Guna.UI2.WinForms
Imports K4os.Compression.LZ4.Internal
Imports MySql.Data.MySqlClient

Public Class AddTeamTaskForm

    Public ID_GroupName As String
    Dim OwnerID As Integer
    Dim memList As New List(Of Integer)
    Dim assignedMems As New List(Of Integer)

    Private Sub AddTeamTaskForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        memList.Clear()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM group_tbl WHERE ID_GroupName = @ID_GroupName", conn)

                cmd.Parameters.AddWithValue("@ID_GroupName", ID_GroupName)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    OwnerID = Val(reader("OwnerID"))

                    Dim memstring As New List(Of String)(Split(reader("GroupMembers"), ","))

                    For Each mem In memstring

                        memList.Add(Val(mem))

                    Next

                End While

                reader.Close()

            End Using

            Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", OwnerID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim picbox As New Guna2CirclePictureBox()
                    picbox.Size = New Size(50, 50)
                    picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                    picbox.SizeMode = PictureBoxSizeMode.StretchImage
                    picbox.Tag = Val(reader("UID"))
                    AddHandler picbox.Click, AddressOf assign_Member
                    FlowLayoutPanel1.Controls.Add(picbox)

                End While

                reader.Close()

            End Using

            For Each mem In memList

                Using cmd As New MySqlCommand("SELECT * FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", mem)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim picbox As New Guna2CirclePictureBox()
                        picbox.Size = New Size(50, 50)
                        picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        picbox.Tag = Val(reader("UID"))
                        AddHandler picbox.Click, AddressOf assign_Member
                        FlowLayoutPanel1.Controls.Add(picbox)

                    End While

                    reader.Close()

                End Using

            Next

            conn.Close()

        End Using

    End Sub

    Private Sub assign_Member(sender As Object, e As EventArgs)

        Dim assigned As Boolean

        Dim picbx As Guna2CirclePictureBox = DirectCast(sender, Guna2CirclePictureBox)

        For Each mem In assignedMems

            If mem = picbx.Tag Then

                assigned = True

            End If

        Next

        If Not assigned Then

            assignedMems.Add(picbx.Tag)
            FlowLayoutPanel1.Controls.Remove(picbx)
            FlowLayoutPanel2.Controls.Add(picbx)

        Else

            assignedMems.Remove(picbx.Tag)
            FlowLayoutPanel2.Controls.Remove(picbx)
            FlowLayoutPanel1.Controls.Add(picbx)

        End If

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Close()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If Date.Today > Guna2DateTimePicker1.Value.Date Then

            MessageBox.Show("Set a proper Due Date.")
            Return

        End If

        If Guna2TextBox1.Text = "" Then
            MessageBox.Show("You did not specify the task name.")
        Else

            Using conn As New MySqlConnection(Connections.teamConnString)

                conn.Open()

                Using cmd As New MySqlCommand("INSERT INTO " + ID_GroupName + "_task (TaskName, TaskInfo, Assigned, TaskStatus, TaskDeadline) VALUES (@TaskName, @TaskInfo, @Assigned, @TaskStatus, @TaskDeadline)", conn)

                    cmd.Parameters.AddWithValue("@TaskName", Guna2TextBox1.Text)
                    cmd.Parameters.AddWithValue("@TaskInfo", Guna2TextBox2.Text)
                    cmd.Parameters.AddWithValue("@Assigned", String.Join(",", assignedMems))
                    cmd.Parameters.AddWithValue("@TaskStatus", "Pending")
                    cmd.Parameters.AddWithValue("@TaskDeadline", Guna2DateTimePicker1.Value.Date)

                    cmd.ExecuteNonQuery()

                End Using

                Using cmd As New MySqlCommand("INSERT INTO " + OG_ID_GroupName + "_chat (Message, Sender, MessageDate) VALUES (@Message, @Sender, @MessageDate)", conn)

                    cmd.Parameters.AddWithValue("@Message", OnlineUser.UserName + " created a new Task!")
                    cmd.Parameters.AddWithValue("@Sender", OnlineUser.UID)
                    cmd.Parameters.AddWithValue("@MessageDate", DateTime.Now())

                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("UPDATE group_tbl SET TotalTask = TotalTask + 1 WHERE ID_GroupName = @ID_GroupName", conn)

                    cmd.Parameters.AddWithValue("@ID_GroupName", ID_GroupName)
                    cmd.ExecuteNonQuery()

                End Using

                Using cmd As New MySqlCommand("UPDATE group_tbl SET Progress = CompletedTask / TotalTask * 100 WHERE ID_GroupName = @ID_GroupName", conn)

                    cmd.Parameters.AddWithValue("@ID_GroupName", ID_GroupName)
                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

            MessageBox.Show("Task Added Successfully!")
            Close()

        End If

    End Sub

End Class