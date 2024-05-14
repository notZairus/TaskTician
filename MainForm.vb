Imports System.Drawing.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms.Design
Imports System.Xml
Imports Guna.UI2.WinForms
Imports Guna.UI2.WinForms.Suite
Imports K4os.Compression.LZ4.Internal
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1
Imports Org.BouncyCastle.Asn1.Cms
Imports Org.BouncyCastle.Crypto.Digests

Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna2CirclePictureBox1.Image = OnlineUser.UserImage
        Label1.Text = OnlineUser.FirstName + " " + OnlineUser.MiddleName(0) + ". " + OnlineUser.LastName
        Label5.Text = "ID: " + OnlineUser.UID.ToString()

        PersonalPanel.BringToFront()

        Get_Task()
        Load_PersonalTask()
        Load_Quote()
        Load_Dailies()

        Get_Teams()
        Load_Teams()

    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        OnlineUser.TaskList.Clear()
        OnlineUser.Failed_TaskList.Clear()
        OnlineUser.Pending_TaskList.Clear()
        OnlineUser.Completed_TaskList.Clear()

        Close()

    End Sub


    'PERSONAL TAB
    'PERSONAL TAB
    'PERSONAL TAB


    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Guna2Button2.Checked = 1
        Guna2Button3.Checked = 0
        Guna2Button4.Checked = 0
        Guna2Button5.Checked = 0
        Guna2Button6.Checked = 0

        Load_PersonalTask()

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        Guna2Button2.Checked = 0
        Guna2Button3.Checked = 1
        Guna2Button4.Checked = 0
        Guna2Button5.Checked = 0
        Guna2Button6.Checked = 0

        Categorize_PersonalTask(sender, e)

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click

        Guna2Button2.Checked = 0
        Guna2Button3.Checked = 0
        Guna2Button4.Checked = 1
        Guna2Button5.Checked = 0
        Guna2Button6.Checked = 0

        Categorize_PersonalTask(sender, e)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        Guna2Button2.Checked = 0
        Guna2Button3.Checked = 0
        Guna2Button4.Checked = 0
        Guna2Button5.Checked = 1
        Guna2Button6.Checked = 0

        Categorize_PersonalTask(sender, e)

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click

        Guna2Button2.Checked = 0
        Guna2Button3.Checked = 0
        Guna2Button4.Checked = 0
        Guna2Button5.Checked = 0
        Guna2Button6.Checked = 1

        Categorize_PersonalTask(sender, e)

    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs)

        Dim addTaskForm As New AddTaskForm()

        addTaskForm.ShowDialog()

        Load_PersonalTask()

    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs)

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("UPDATE user_tbl SET Quote = @Quote WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@Quote", Guna2TextBox2.Text)
                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs)
        Dim addDilyTaskForm As New AddDailyTaskForm()
        AddDailyTaskForm.ShowDialog()
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click

        Guna2Button11.Checked = True
        Guna2Button12.Checked = False

        PersonalPanel.BringToFront()

    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click

        Guna2Button11.Checked = False
        Guna2Button12.Checked = True

        TeamsPanel.BringToFront()

    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click

        Dim deleteDailyForm As New DeleteDailyForm()
        deleteDailyForm.ShowDialog()
        Load_Dailies()

    End Sub

    Private Sub Guna2Button10_Click_1(sender As Object, e As EventArgs) Handles Guna2Button10.Click

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("UPDATE user_tbl SET Quote = @Quote WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@Quote", Guna2TextBox2.Text)
                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Guna2Button7_Click_1(sender As Object, e As EventArgs) Handles Guna2Button7.Click

        Dim addDailyTaskForm As New AddDailyTaskForm()
        addDailyTaskForm.ShowDialog()

        Load_Dailies()

    End Sub

    Private Sub Guna2Button9_Click_1(sender As Object, e As EventArgs) Handles Guna2Button9.Click

        Dim addTaskForm As New AddTaskForm()
        addTaskForm.ShowDialog()

        Load_PersonalTask()
    End Sub

    Private Sub Get_Task()

        Using conn As New MySqlConnection(Connections.connString)

            Dim qry As String = "SELECT * FROM personaltask_tbl WHERE UID = @UID"

            conn.Open()

            Using cmd As New MySqlCommand(qry, conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim task As New Task

                    task.TID = Val(reader("TID"))
                    task.TaskName = reader("TaskName").ToString()
                    task.TaskCategory = reader("TaskCategory").ToString()
                    task.TaskDeadline = DirectCast(reader("TaskDeadline"), Date)
                    task.TaskStatus = reader("TaskStatus").ToString()
                    task.UID = Val(reader("UID"))
                    task.UN = reader("UN").ToString()

                    OnlineUser.TaskList.Add(task)

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        For Each task In OnlineUser.TaskList

            If task.TaskStatus = "Pending" Then

                If task.TaskDeadline.Date < Date.Today Then

                    task.TaskStatus = "Failed"
                    OnlineUser.Failed_TaskList.Add(task)

                    Using conn As New MySqlConnection(Connections.connString)

                        conn.Open()

                        Using cmd As New MySqlCommand("UPDATE personaltask_tbl SET TaskStatus = @Failed WHERE TID = @TID", conn)

                            cmd.Parameters.AddWithValue("@Failed", "Failed")
                            cmd.Parameters.AddWithValue("@TID", task.TID)

                            cmd.ExecuteNonQuery()

                        End Using

                        Using cmd As New MySqlCommand("UPDATE user_tbl SET FailedTask = FailedTask + 1 WHERE UID = @UID", conn)

                            cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                            cmd.ExecuteNonQuery()

                        End Using

                        conn.Close()

                    End Using

                Else

                    OnlineUser.Pending_TaskList.Add(task)

                End If

            ElseIf task.TaskStatus = "Failed" Then

                OnlineUser.Failed_TaskList.Add(task)

            ElseIf task.TaskStatus = "Completed" Then

                OnlineUser.Completed_TaskList.Add(task)

            End If

        Next

    End Sub

    Private Sub Load_PersonalTask()

        FlowLayoutPanel1.Controls.Clear()

        Dim childSize As Size = New Size(393, 90)

        Using conn As New MySqlConnection(Connections.connString)

            Dim qry As String = "SELECT * FROM personaltask_tbl WHERE UID = @UID AND UN = @UN AND TaskStatus = @TaskStatus ORDER BY TaskDeadline"

            conn.Open()

            Using cmd As New MySqlCommand(qry, conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                cmd.Parameters.AddWithValue("@UN", OnlineUser.UserName)
                cmd.Parameters.AddWithValue("@TaskStatus", "Pending")

                Dim reader As MySqlDataReader = cmd.ExecuteReader

                While reader.Read()

                    Dim panel As New Guna2Panel
                    panel.Size = childSize
                    panel.FillColor = Color.FromArgb(39, 39, 39)
                    panel.BorderRadius = 25
                    panel.Tag = Val(reader("TID"))
                    FlowLayoutPanel1.Controls.Add(panel)

                    Dim label As New Label()
                    label.Size = New Size(320, 60)
                    label.Text = reader("TaskName").ToString()
                    label.ForeColor = Color.White
                    label.BackColor = Color.Transparent()
                    label.Font = New Font("Segoe UI", 17, FontStyle.Bold)
                    label.Location = New Point(8, 7)
                    AddHandler label.Click, AddressOf see_Task
                    panel.Controls.Add(label)

                    Dim label2 As New Label()
                    label2.Size = New Size(150, 40)
                    label2.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
                    label2.BackColor = Color.Transparent()
                    label2.Text = reader("TaskCategory").ToString()
                    label2.Font = New Font("Segoe UI", 15, FontStyle.Bold)
                    label2.Location = New Point(8, 58)
                    AddHandler label2.Click, AddressOf see_Task
                    panel.Controls.Add(label2)

                    Dim label3 As New Label()
                    Dim deadline As Date = DirectCast(reader("TaskDeadline"), Date)
                    label3.Size = New Size(200, 40)
                    label3.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
                    label3.BackColor = Color.Transparent()
                    label3.Text = deadline.ToString("d")
                    label3.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                    label3.Location = New Point(245, 67)
                    AddHandler label3.Click, AddressOf see_Task
                    panel.Controls.Add(label3)

                    Dim Guna2CustomCheckBox1 As New Guna2CustomCheckBox()
                    Guna2CustomCheckBox1.BackColor = Color.Transparent
                    Guna2CustomCheckBox1.CheckedState.BorderColor = Color.Black
                    Guna2CustomCheckBox1.CheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.CheckedState.BorderThickness = 0
                    Guna2CustomCheckBox1.CheckedState.FillColor = Color.Black
                    Guna2CustomCheckBox1.CheckMarkColor = Color.White
                    Guna2CustomCheckBox1.Location = New Point(330, 20)
                    Guna2CustomCheckBox1.Name = "Guna2CustomCheckBox1"
                    Guna2CustomCheckBox1.Size = New Size(42, 44)
                    Guna2CustomCheckBox1.TabIndex = 17
                    Guna2CustomCheckBox1.BorderStyle = BorderStyle.Fixed3D
                    Guna2CustomCheckBox1.UncheckedState.BorderColor = Color.White
                    Guna2CustomCheckBox1.UncheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.UncheckedState.BorderThickness = 1
                    Guna2CustomCheckBox1.UncheckedState.FillColor = Color.Black
                    AddHandler Guna2CustomCheckBox1.CheckedChanged, AddressOf complete_Task
                    panel.Controls.Add(Guna2CustomCheckBox1)

                    Dim line As New Panel()
                    line.Width = 390
                    line.Height = 1
                    line.BackColor = Color.Gray
                    FlowLayoutPanel1.Controls.Add(line)

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Load_Quote()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT Quote FROM user_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Guna2TextBox2.Text = reader("Quote").ToString()

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Load_Dailies()

        FlowLayoutPanel2.Controls.Clear()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM dailytask_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim panel As New Guna2Panel
                    panel.Size = New Size(370, 60)
                    panel.FillColor = Color.FromArgb(250, 187, 24)
                    panel.Tag = Val(reader("DTID"))
                    FlowLayoutPanel2.Controls.Add(panel)

                    Dim label As New Label()
                    label.Size = New Size(300, 53)
                    label.Text = reader("DTName").ToString()
                    label.BackColor = Color.Transparent
                    label.Font = New Font("Segoe UI", 17, FontStyle.Bold)
                    label.Location = New Point(3, 3)
                    panel.Controls.Add(label)

                    Dim Guna2CustomCheckBox1 As New Guna2CustomCheckBox()
                    Guna2CustomCheckBox1.BackColor = Color.Transparent
                    Guna2CustomCheckBox1.CheckedState.BorderColor = Color.FromArgb(CByte(250), CByte(187), CByte(24))
                    Guna2CustomCheckBox1.CheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.CheckedState.BorderThickness = 0
                    Guna2CustomCheckBox1.CheckedState.FillColor = Color.FromArgb(CByte(250), CByte(187), CByte(24))
                    Guna2CustomCheckBox1.CheckMarkColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
                    Guna2CustomCheckBox1.Location = New Point(315, 8)
                    Guna2CustomCheckBox1.Name = "Guna2CustomCheckBox1"
                    Guna2CustomCheckBox1.Size = New Size(42, 44)
                    Guna2CustomCheckBox1.TabIndex = 17
                    Guna2CustomCheckBox1.UncheckedState.BorderColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
                    Guna2CustomCheckBox1.UncheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.UncheckedState.BorderThickness = 0
                    Guna2CustomCheckBox1.UncheckedState.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
                    If DirectCast(reader("DateCompleted"), Date) = Date.Today Then
                        Guna2CustomCheckBox1.Checked = True
                    End If
                    AddHandler Guna2CustomCheckBox1.CheckedChanged, AddressOf complete_DailyTask
                    panel.Controls.Add(Guna2CustomCheckBox1)

                    Dim line As New Panel()
                    line.Width = 370
                    line.Height = 1
                    line.BackColor = Color.FromArgb(39, 39, 39)
                    FlowLayoutPanel2.Controls.Add(line)

                End While

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub complete_Task(sender As Object, e As EventArgs)

        Dim checkbox As Guna2CustomCheckBox = DirectCast(sender, Guna2CustomCheckBox)

        RemoveHandler checkbox.CheckedChanged, AddressOf complete_Task

        If MessageBox.Show("Complete the task?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("UPDATE personaltask_tbl SET TaskStatus = @TaskStatus WHERE TID = @TID", conn)

                    cmd.Parameters.AddWithValue("@TaskStatus", "Completed")
                    cmd.Parameters.AddWithValue("@TID", checkbox.Parent.Tag)

                    cmd.ExecuteNonQuery()

                End Using

                Using cmd As New MySqlCommand("UPDATE user_tbl SET CompletedTask = CompletedTask + 1 WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

            FlowLayoutPanel1.Controls.RemoveAt(FlowLayoutPanel1.Controls.IndexOf(checkbox.Parent) + 1)
            FlowLayoutPanel1.Controls.RemoveAt(FlowLayoutPanel1.Controls.IndexOf(checkbox.Parent))

        Else

            checkbox.Checked = 0

        End If

        AddHandler checkbox.CheckedChanged, AddressOf complete_Task

    End Sub

    Private Sub Categorize_PersonalTask(sender As Object, e As EventArgs)

        Dim btn As Guna2Button = DirectCast(sender, Guna2Button)

        FlowLayoutPanel1.Controls.Clear()

        Dim childSize As Size = New Size(393, 90)

        Using conn As New MySqlConnection(Connections.connString)

            Dim qry As String = "SELECT * FROM personaltask_tbl WHERE UID = @UID AND UN = @UN AND TaskStatus = @TaskStatus AND TaskCategory = @TaskCategory ORDER BY TaskDeadline"

            conn.Open()

            Using cmd As New MySqlCommand(qry, conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                cmd.Parameters.AddWithValue("@UN", OnlineUser.UserName)
                cmd.Parameters.AddWithValue("@TaskStatus", "Pending")
                cmd.Parameters.AddWithValue("@TaskCategory", btn.Text)

                Dim reader As MySqlDataReader = cmd.ExecuteReader

                While reader.Read()

                    Dim panel As New Guna2Panel
                    panel.Size = childSize
                    panel.FillColor = Color.FromArgb(39, 39, 39)
                    panel.BorderRadius = 25
                    panel.Tag = Val(reader("TID"))
                    FlowLayoutPanel1.Controls.Add(panel)

                    Dim label As New Label()
                    label.Size = New Size(320, 60)
                    label.Text = reader("TaskName").ToString()
                    label.ForeColor = Color.White
                    label.BackColor = Color.Transparent()
                    label.Font = New Font("Segoe UI", 17, FontStyle.Bold)
                    label.Location = New Point(8, 7)
                    AddHandler label.Click, AddressOf see_Task
                    panel.Controls.Add(label)

                    Dim label2 As New Label()
                    label2.Size = New Size(150, 40)
                    label2.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
                    label2.BackColor = Color.Transparent()
                    label2.Text = reader("TaskCategory").ToString()
                    label2.Font = New Font("Segoe UI", 15, FontStyle.Bold)
                    label2.Location = New Point(8, 58)
                    AddHandler label2.Click, AddressOf see_Task
                    panel.Controls.Add(label2)

                    Dim label3 As New Label()
                    Dim deadline As Date = DirectCast(reader("TaskDeadline"), Date)
                    label3.Size = New Size(200, 40)
                    label3.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
                    label3.BackColor = Color.Transparent()
                    label3.Text = deadline.ToString("d")
                    label3.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                    label3.Location = New Point(245, 67)
                    AddHandler label3.Click, AddressOf see_Task
                    panel.Controls.Add(label3)

                    Dim Guna2CustomCheckBox1 As New Guna2CustomCheckBox()
                    Guna2CustomCheckBox1.BackColor = Color.Transparent
                    Guna2CustomCheckBox1.CheckedState.BorderColor = Color.Black
                    Guna2CustomCheckBox1.CheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.CheckedState.BorderThickness = 0
                    Guna2CustomCheckBox1.CheckedState.FillColor = Color.Black
                    Guna2CustomCheckBox1.CheckMarkColor = Color.White
                    Guna2CustomCheckBox1.Location = New Point(330, 20)
                    Guna2CustomCheckBox1.Name = "Guna2CustomCheckBox1"
                    Guna2CustomCheckBox1.Size = New Size(42, 44)
                    Guna2CustomCheckBox1.TabIndex = 17
                    Guna2CustomCheckBox1.BorderStyle = BorderStyle.Fixed3D
                    Guna2CustomCheckBox1.UncheckedState.BorderColor = Color.White
                    Guna2CustomCheckBox1.UncheckedState.BorderRadius = 2
                    Guna2CustomCheckBox1.UncheckedState.BorderThickness = 1
                    Guna2CustomCheckBox1.UncheckedState.FillColor = Color.Black
                    AddHandler Guna2CustomCheckBox1.CheckedChanged, AddressOf complete_Task
                    panel.Controls.Add(Guna2CustomCheckBox1)

                    Dim line As New Panel()
                    line.Width = 393
                    line.Height = 1
                    line.BackColor = Color.Gray
                    FlowLayoutPanel1.Controls.Add(line)

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub see_Task(sender As Object, e As EventArgs)

        Dim lbl As Label = DirectCast(sender, Label)

        Dim taskOverview As New TaskOverview()
        taskOverview.TID = lbl.Parent.Tag
        taskOverview.Show()

    End Sub

    Private Sub complete_DailyTask(sender As Object, e As EventArgs)

        Dim checkbox As Guna2CustomCheckBox = DirectCast(sender, Guna2CustomCheckBox)

        RemoveHandler checkbox.CheckedChanged, AddressOf complete_DailyTask

        If checkbox.Checked = False Then
            checkbox.Checked = True
        Else

            If MessageBox.Show("Complete this daily task?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Using conn As New MySqlConnection(Connections.connString)

                    conn.Open()

                    Using cmd As New MySqlCommand("UPDATE dailytask_tbl SET DateCompleted = @DateCompleted WHERE DTID = @DTID", conn)

                        cmd.Parameters.AddWithValue("@DateCompleted", Date.Now)
                        cmd.Parameters.AddWithValue("@DTID", checkbox.Parent.Tag)

                        cmd.ExecuteNonQuery()

                    End Using

                    conn.Close()

                End Using

            Else

                checkbox.Checked = False

            End If

        End If

        AddHandler checkbox.CheckedChanged, AddressOf complete_DailyTask

    End Sub


    'TEAMS TAB
    'TEAMS TAB
    'TEAMS TAB

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        Dim showMutualsForm As New ShowMutualsForm()
        showMutualsForm.Show()
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        Dim addMutualsForm As New AddMutualsForm()
        addMutualsForm.Show()
    End Sub

    Private Sub Guna2Button16_Click(sender As Object, e As EventArgs) Handles Guna2Button16.Click
        Dim deleteMutualsForm As New DeleteMutualsForm()
        deleteMutualsForm.Show()
    End Sub

    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click
        Dim createTeamForm As New CreateTeamForm()
        createTeamForm.ShowDialog()
        Get_Teams()
        Load_Teams()
    End Sub

    Private Sub Get_Teams()

        Teams.Clear()
        OwnTeams.Clear()
        MemOfTeams.Clear()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM group_tbl WHERE OwnerID = @OwnerID ORDER BY GID DESC", conn)

                cmd.Parameters.AddWithValue("@OwnerID", OnlineUser.UID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim team As New Team()
                    team.GID = Val(reader("GID"))
                    team.GroupName = reader("GroupName").ToString()
                    team.OwnerID = Val(reader("OwnerID"))
                    team.TotalTask = Val(reader("TotalTask"))
                    team.CompletedTask = Val(reader("CompletedTask"))
                    team.Progress = Val(reader("Progress"))

                    For Each mem In Split(reader("GroupMembers").ToString, ",")
                        team.GroupMembers.Add(Val(mem))
                    Next

                    team.DateCreated = DirectCast(reader("DateCreated"), Date)
                    team.ID_GroupName = reader("ID_GroupName")

                    OnlineUser.Teams.Add(team)
                    OnlineUser.OwnTeams.Add(team)

                End While

                reader.Close()

            End Using

            Using cmd2 As New MySqlCommand("SELECT * FROM group_tbl ORDER BY GID DESC", conn)

                Dim reader As MySqlDataReader = cmd2.ExecuteReader()

                While reader.Read()

                    Dim team As New Team()
                    team.GID = Val(reader("GID"))
                    team.GroupName = reader("GroupName").ToString()
                    team.OwnerID = Val(reader("OwnerID"))

                    For Each mem In Split(reader("GroupMembers").ToString, ",")
                        team.GroupMembers.Add(Val(mem))
                    Next

                    team.DateCreated = DirectCast(reader("DateCreated"), Date)
                    team.ID_GroupName = reader("ID_GroupName")
                    team.TotalTask = Val(reader("TotalTask"))
                    team.CompletedTask = Val(reader("CompletedTask"))
                    team.Progress = Val(reader("Progress"))

                    Dim members As New List(Of String)(Split(reader("GroupMembers"), ","))

                    For Each mem In members

                        If Val(mem) = OnlineUser.UID Then

                            OnlineUser.Teams.Add(team)
                            OnlineUser.MemOfTeams.Add(team)

                        End If

                    Next

                End While

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Load_Teams()

        FlowTeams.Controls.Clear()

        For Each team In OwnTeams

            Dim panel As New Guna2Panel()
            panel.Size = New Size(345, 140)
            panel.FillColor = Color.FromArgb(250, 187, 24)
            panel.BorderRadius = 30
            panel.Tag = team.GID
            AddHandler panel.Click, AddressOf Open_Team
            FlowTeams.Controls.Add(panel)

            Dim lbl As New Label()
            lbl.Text = team.GroupName
            lbl.Location = New Point(10, 10)
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.Black
            lbl.Font = New Font("Segoe UI", 22, FontStyle.Bold)
            lbl.Width = 320
            lbl.Height = 40
            lbl.Tag = team.GID
            AddHandler lbl.Click, AddressOf Open_Team
            panel.Controls.Add(lbl)

            Dim progressBarHolder As New Guna2Panel()
            progressBarHolder.Size = New Size(260, 10)
            progressBarHolder.FillColor = Color.FromArgb(230 - 24, 187 - 24, 24 - 24)
            progressBarHolder.BorderRadius = 5
            progressBarHolder.Location = New Point(10, 110)
            AddHandler progressBarHolder.Click, AddressOf Open_Team
            panel.Controls.Add(progressBarHolder)

            Dim progressBar As New Guna2Panel()
            progressBar.Size = New Size(team.Progress / 100 * 260, 10)
            progressBar.FillColor = Color.FromArgb(39, 39, 39)
            progressBar.BorderRadius = 5
            AddHandler progressBar.Click, AddressOf Open_Team
            progressBarHolder.Controls.Add(progressBar)

            Dim progress As New Label()
            progress.Text = (team.Progress / 100 * 100).ToString("0") + "%"
            progress.Location = New Point(272, 97)
            progress.BackColor = Color.Transparent
            progress.ForeColor = Color.FromArgb(39, 39, 39)
            progress.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            progress.BackColor = Color.Transparent
            progress.AutoSize = True
            progress.Tag = team.GID
            AddHandler lbl.Click, AddressOf Open_Team
            panel.Controls.Add(progress)

            Dim x As Integer = 10

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", team.OwnerID)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim picbox As New Guna2CirclePictureBox()
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        picbox.Size = New Size(40, 40)
                        picbox.BackColor = Color.Transparent
                        picbox.Location = New Point(x, 60)
                        picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.Tag = team.GID
                        AddHandler picbox.Click, AddressOf Open_Team
                        panel.Controls.Add(picbox)

                    End While

                    reader.Close()

                End Using

                conn.Close()

            End Using

            x += 35

            For Each mem In team.GroupMembers

                Using conn As New MySqlConnection(Connections.connString)

                    conn.Open()

                    Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                        cmd.Parameters.AddWithValue("@UID", mem)

                        Dim reader As MySqlDataReader = cmd.ExecuteReader()

                        While reader.Read()

                            Dim picbox As New Guna2CirclePictureBox()
                            picbox.SizeMode = PictureBoxSizeMode.StretchImage
                            picbox.Size = New Size(40, 40)
                            picbox.BackColor = Color.Transparent
                            picbox.Location = New Point(x, 60)
                            picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                            picbox.Tag = team.GID
                            AddHandler picbox.Click, AddressOf Open_Team
                            panel.Controls.Add(picbox)

                        End While

                        reader.Close()

                    End Using

                    conn.Close()

                End Using

                x += 35

            Next

        Next

        For Each team In MemOfTeams

            Dim panel As New Guna2Panel()
            panel.Size = New Size(345, 140)
            panel.FillColor = Color.FromArgb(39, 39, 39)
            panel.BorderRadius = 30
            panel.Tag = team.GID
            AddHandler panel.Click, AddressOf Open_Team
            FlowTeams.Controls.Add(panel)

            Dim lbl As New Label()
            lbl.Text = team.GroupName
            lbl.Location = New Point(10, 10)
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.White
            lbl.Font = New Font("Segoe UI", 22, FontStyle.Bold)
            lbl.Width = 320
            lbl.Height = 40
            lbl.Tag = team.GID
            AddHandler lbl.Click, AddressOf Open_Team
            panel.Controls.Add(lbl)

            Dim progressBarHolder As New Guna2Panel()
            progressBarHolder.Size = New Size(260, 10)
            progressBarHolder.FillColor = Color.FromArgb(0, 0, 0)
            progressBarHolder.BorderRadius = 5
            progressBarHolder.Location = New Point(10, 110)
            AddHandler progressBarHolder.Click, AddressOf Open_Team
            panel.Controls.Add(progressBarHolder)

            Dim progressBar As New Guna2Panel()
            progressBar.Size = New Size(team.Progress / 100 * 260, 10)
            progressBar.FillColor = Color.FromArgb(250, 187, 24)
            progressBar.BorderRadius = 5
            AddHandler progressBar.Click, AddressOf Open_Team
            progressBarHolder.Controls.Add(progressBar)

            Dim progress As New Label()
            progress.Text = (team.Progress / 100 * 100).ToString("0") + "%"
            progress.Location = New Point(272, 97)
            progress.BackColor = Color.Transparent
            progress.ForeColor = Color.White
            progress.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            progress.BackColor = Color.Transparent
            progress.AutoSize = True
            progress.Tag = team.GID
            AddHandler lbl.Click, AddressOf Open_Team
            panel.Controls.Add(progress)


            Dim x As Integer = 10

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", team.OwnerID)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim picbox As New Guna2CirclePictureBox()
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        picbox.Size = New Size(40, 40)
                        picbox.BackColor = Color.Transparent
                        picbox.Location = New Point(x, 60)
                        picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.Tag = team.GID
                        AddHandler picbox.Click, AddressOf Open_Team
                        panel.Controls.Add(picbox)

                    End While

                    reader.Close()

                End Using

                conn.Close()

            End Using

            x += 35

            For Each mem In team.GroupMembers

                Using conn As New MySqlConnection(Connections.connString)

                    conn.Open()

                    Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                        cmd.Parameters.AddWithValue("@UID", mem)

                        Dim reader As MySqlDataReader = cmd.ExecuteReader()

                        While reader.Read()

                            Dim picbox As New Guna2CirclePictureBox()
                            picbox.SizeMode = PictureBoxSizeMode.StretchImage
                            picbox.Size = New Size(40, 40)
                            picbox.BackColor = Color.Transparent
                            picbox.Location = New Point(x, 60)
                            picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                            picbox.Tag = team.GID
                            AddHandler picbox.Click, AddressOf Open_Team
                            panel.Controls.Add(picbox)

                        End While

                        reader.Close()

                    End Using

                    conn.Close()

                End Using

                x += 35

            Next

        Next

    End Sub

    Private Sub Guna2Button18_Click(sender As Object, e As EventArgs) Handles Guna2Button18.Click

        Guna2Button18.Checked = True
        Guna2Button19.Checked = False

        taskpnl.Visible = True
        taskpnl.Enabled = True

        chatpnl.Visible = False
        chatpnl.Enabled = False

    End Sub

    Private Sub Guna2Button19_Click(sender As Object, e As EventArgs) Handles Guna2Button19.Click

        Guna2Button18.Checked = False
        Guna2Button19.Checked = True

        taskpnl.Visible = False
        taskpnl.Enabled = False

        chatpnl.Visible = True
        chatpnl.Enabled = True

    End Sub

    Private Sub Guna2Button20_Click(sender As Object, e As EventArgs) Handles Guna2Button20.Click

        Dim addTeamTaskForm As New AddTeamTaskForm()
        addTeamTaskForm.ID_GroupName = OG_ID_GroupName
        addTeamTaskForm.ShowDialog()

        Get_Teams()
        Load_Teams()
        Load_TeamTask(FlowTeamTasks.Tag)
        Load_TeamChat()

    End Sub

    Private Sub Open_Team(sender As Object, e As EventArgs)

        Using conn As New MySqlConnection(connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM group_tbl WHERE GID = @GID", conn)

                cmd.Parameters.AddWithValue("@GID", sender.tag)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Label8.Text = reader("GroupName") + "'s Task"
                    Label10.Text = reader("GroupName") + "'s Chat"
                    FlowTeamTasks.Tag = reader("GID")
                    OG_ID_GroupName = reader("ID_GroupName")

                    If TypeOf sender Is Guna2Panel Then
                        OG_Index = FlowTeams.Controls.IndexOf(sender)
                    Else
                        OG_Index = FlowTeams.Controls.IndexOf(sender.parent)
                    End If

                    FlowLayoutPanel3.Tag = reader("GID")
                    Guna2CircleButton1.Tag = reader("GID")

                    If reader("OwnerID") = OnlineUser.UID Then

                        Guna2Button20.Enabled = True
                        Guna2CircleButton1.Enabled = True
                        Guna2Button22.Enabled = True

                    Else

                        Guna2Button20.Enabled = False
                        Guna2CircleButton1.Enabled = False
                        Guna2Button22.Enabled = False

                    End If

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        Load_TeamTask(sender.tag)
        Load_TeamMembers(sender.tag)
        Load_TeamChat()

    End Sub

    Private Sub Load_TeamTask(GID As Integer)

        FlowTeamTasks.Controls.Clear()
        Dim TeamTasks As New List(Of TeamTask)

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM group_tbl WHERE GID = @GID", conn)

                cmd.Parameters.AddWithValue("@GID", GID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    OG_ID_GroupName = reader("ID_GroupName").ToString()

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        Using conn As New MySqlConnection(Connections.teamConnString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM " + OG_ID_GroupName + "_task", conn)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim tmtsk As New TeamTask()
                    tmtsk.TTID = reader("TTID")
                    tmtsk.TaskName = reader("TaskName")
                    tmtsk.TaskInfo = reader("TaskInfo")
                    tmtsk.Assigned = reader("Assigned")
                    tmtsk.TaskStatus = reader("TaskStatus")
                    tmtsk.TaskDeadline = DirectCast(reader("TaskDeadline"), Date)
                    TeamTasks.Add(tmtsk)

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        For Each tmtsk In TeamTasks

            Dim panel As New Guna2Panel()
            panel.Size = New Size(420, 100)
            panel.FillColor = Color.FromArgb(109, 109, 109)
            panel.BorderRadius = 30
            panel.Tag = tmtsk.TTID
            panel.Enabled = False
            FlowTeamTasks.Controls.Add(panel)

            Dim lbl As New Label()
            lbl.Text = tmtsk.TaskName
            lbl.Location = New Point(10, 8)
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.White
            lbl.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            lbl.Width = 320
            lbl.Height = 30
            panel.Controls.Add(lbl)

            Dim lbl2 As New Label()
            lbl2.Text = "Due Date: " + tmtsk.TaskDeadline.ToString("D")
            lbl2.Location = New Point(10, 40)
            lbl2.BackColor = Color.Transparent
            lbl2.ForeColor = Color.DarkGray
            lbl2.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lbl2.Width = 320
            lbl2.Height = 30
            panel.Controls.Add(lbl2)

            Dim fpanel As New FlowLayoutPanel()
            fpanel.Size = New Size(320, 30)
            fpanel.Location = New Point(10, 67)
            fpanel.BackColor = Color.Transparent
            panel.Controls.Add(fpanel)

            Dim lbl3 As New Label()
            lbl3.Text = "Assigned:"
            lbl3.Location = New Point(10, 40)
            lbl3.BackColor = Color.Transparent
            lbl3.ForeColor = Color.DarkGray
            lbl3.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            lbl3.AutoSize = True
            fpanel.Controls.Add(lbl3)

            Dim assignedMem As New List(Of String)(Split(tmtsk.Assigned, ","))

            Dim isAssigned As Boolean = False

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                For Each mem In assignedMem

                    Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                        cmd.Parameters.AddWithValue("@UID", Val(mem))

                        Dim reader As MySqlDataReader = cmd.ExecuteReader()

                        While reader.Read()

                            Dim picbox As New Guna2CirclePictureBox()
                            picbox.SizeMode = PictureBoxSizeMode.StretchImage
                            picbox.Size = New Size(23, 23)
                            picbox.BackColor = Color.Transparent
                            picbox.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                            fpanel.Controls.Add(picbox)

                        End While

                        reader.Close()

                    End Using

                    If Val(mem) = OnlineUser.UID Then

                        isAssigned = True

                    End If

                Next

                conn.Close()

            End Using

            Dim Guna2CustomCheckBox1 As New Guna2CustomCheckBox()

            If tmtsk.TaskStatus = "Completed" Then

                Guna2CustomCheckBox1.Checked = True

            End If

            If isAssigned Then

                panel.Enabled = True
                panel.FillColor = Color.FromArgb(39, 39, 39)
                Guna2CustomCheckBox1.BackColor = Color.Black
                Guna2CustomCheckBox1.CheckedState.BorderColor = Color.Black
                Guna2CustomCheckBox1.CheckedState.BorderRadius = 2
                Guna2CustomCheckBox1.CheckedState.BorderThickness = 0
                Guna2CustomCheckBox1.CheckedState.FillColor = Color.Black
                Guna2CustomCheckBox1.CheckMarkColor = Color.White
                Guna2CustomCheckBox1.Location = New Point(350, 25)
                Guna2CustomCheckBox1.Name = "Guna2CustomCheckBox1"
                Guna2CustomCheckBox1.Size = New Size(50, 50)
                Guna2CustomCheckBox1.TabIndex = 17
                Guna2CustomCheckBox1.BorderStyle = BorderStyle.Fixed3D
                Guna2CustomCheckBox1.UncheckedState.BorderColor = Color.White
                Guna2CustomCheckBox1.UncheckedState.BorderRadius = 2
                Guna2CustomCheckBox1.UncheckedState.BorderThickness = 1
                Guna2CustomCheckBox1.UncheckedState.FillColor = Color.Black
                AddHandler Guna2CustomCheckBox1.CheckedChanged, AddressOf complete_TeamTask
                panel.Controls.Add(Guna2CustomCheckBox1)

            End If

        Next

    End Sub

    Private Sub Load_TeamMembers(GID As Integer)

        FlowLayoutPanel3.Controls.Clear()

        Dim memberlist As New List(Of Integer)

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT GroupMembers FROM group_tbl WHERE GID = @GID", conn)

                cmd.Parameters.AddWithValue("@GID", GID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim stringmemlist As New List(Of String)(Split(reader("GroupMembers"), ","))

                    For Each mem In stringmemlist

                        memberlist.Add(Val(mem))

                    Next

                End While

                reader.Close()

            End Using

            For Each member In memberlist

                Using cmd As New MySqlCommand("SELECT ImageData FROM user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", member)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim picbox As New Guna2CirclePictureBox
                        picbox.Tag = member
                        picbox.Size = New Size(70, 70)
                        picbox.BackColor = Color.Transparent
                        picbox.FillColor = Color.FromArgb(39, 39, 39)
                        picbox.Image = GlobalFunctions.ToImage(DirectCast(reader("ImageData"), Byte()))
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage
                        AddHandler picbox.Click, AddressOf kick_Member
                        FlowLayoutPanel3.Controls.Add(picbox)

                    End While

                    reader.Close()

                End Using

            Next

            conn.Close()

        End Using

    End Sub

    Private Sub complete_TeamTask(sender As Object, e As EventArgs)

        Dim chkbx As Guna2CustomCheckBox = DirectCast(sender, Guna2CustomCheckBox)

        RemoveHandler chkbx.CheckedChanged, AddressOf complete_TeamTask

        If chkbx.Checked = False Then

            chkbx.Checked = True

        Else

            If MessageBox.Show("Complete Task?", "Confimation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Using conn As New MySqlConnection(Connections.teamConnString)

                    conn.Open()

                    Using cmd As New MySqlCommand("UPDATE " + OG_ID_GroupName + "_task SET TaskSTatus = @TaskStatus WHERE TTID = @TTID", conn)

                        cmd.Parameters.AddWithValue("@TTID", chkbx.Parent.Tag)
                        cmd.Parameters.AddWithValue("@TaskStatus", "Completed")

                        cmd.ExecuteNonQuery()

                    End Using

                    Dim Msg As New Message
                    Msg.Message = OnlineUser.UserName + " completed a Task!"
                    Msg.Sender = OnlineUser.UID
                    Msg.MessageDate = DateTime.Now()

                    Using cmd As New MySqlCommand("INSERT INTO " + OG_ID_GroupName + "_chat (Message, Sender, MessageDate) VALUES (@Message, @Sender, @MessageDate)", conn)

                        cmd.Parameters.AddWithValue("@Message", Msg.Message)
                        cmd.Parameters.AddWithValue("@Sender", Msg.Sender)
                        cmd.Parameters.AddWithValue("@MessageDate", Msg.MessageDate)

                        cmd.ExecuteNonQuery()

                    End Using

                    sendMessage(Msg)

                    conn.Close()

                    MessageBox.Show("Task Successfully Completed.")

                End Using

                Using conn As New MySqlConnection(Connections.connString)

                    conn.Open()

                    Using cmd As New MySqlCommand("UPDATE group_tbl SET CompletedTask = CompletedTask + 1 WHERE ID_GroupName = @ID_GroupName", conn)

                        cmd.Parameters.AddWithValue("@ID_GroupName", OG_ID_GroupName)
                        cmd.ExecuteNonQuery()

                    End Using

                    Using cmd As New MySqlCommand("UPDATE group_tbl SET Progress = CompletedTask / TotalTask  * 100 WHERE ID_GroupName = @ID_GroupName", conn)

                        cmd.Parameters.AddWithValue("@ID_GroupName", OG_ID_GroupName)
                        cmd.ExecuteNonQuery()

                    End Using

                    conn.Close()

                End Using

            Else

                chkbx.Checked = False

            End If

        End If

        AddHandler chkbx.CheckedChanged, AddressOf complete_TeamTask

        Get_Teams()
        Load_Teams()

    End Sub

    Private Sub kick_Member(sender As Object, e As EventArgs)

        Dim clicked = DirectCast(sender, Guna2CirclePictureBox)

        Using conn As New MySqlConnection(Connections.connString)

            Dim groupmem As New List(Of Integer)
            Dim OwnerID As Integer

            conn.Open()

            Using cmd As New MySqlCommand("SELECT GroupMembers, OwnerID FROM group_tbl WHERE GID = @GID", conn)

                cmd.Parameters.AddWithValue("@GID", clicked.Parent.Tag)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim memlist As New List(Of String)(Split(reader("GroupMembers"), ","))
                    OwnerID = reader("OwnerID")

                    For Each mem In memlist

                        groupmem.Add(Val(mem))

                    Next

                End While

                reader.Close()

            End Using

            groupmem.Remove(clicked.Tag)

            If OwnerID = OnlineUser.UID Then

                If MessageBox.Show("Kick the selected member?", "confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    Using cmd As New MySqlCommand("UPDATE group_tbl SET GroupMembers = @GroupMembers WHERE GID = @GID", conn)

                        cmd.Parameters.AddWithValue("@GroupMembers", String.Join(",", groupmem))
                        cmd.Parameters.AddWithValue("@GID", clicked.Parent.Tag)

                        cmd.ExecuteNonQuery()

                    End Using

                    MessageBox.Show("Successfully kicked.")

                End If

            End If

            conn.Close()

        End Using

        Load_TeamMembers(clicked.Parent.Tag)
        Get_Teams()
        Load_Teams()

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click

        Dim addMemForm As New AddMemForm
        addMemForm.ShowDialog()

        Get_Teams()
        Load_Teams()
        Load_TeamMembers(Guna2CircleButton1.Tag)

    End Sub

    Private Sub Guna2Button21_Click(sender As Object, e As EventArgs) Handles Guna2Button21.Click

        If Guna2TextBox3.Text = "" Then
            Return
        End If

        Using conn As New MySqlConnection(Connections.teamConnString)

            conn.Open()

            Using cmd As New MySqlCommand("INSERT INTO " + OG_ID_GroupName + "_chat (Message, Sender, MessageDate) VALUES (@Message, @Sender, @MessageDate)", conn)

                cmd.Parameters.AddWithValue("@Message", Guna2TextBox3.Text)
                cmd.Parameters.AddWithValue("@Sender", OnlineUser.UID)
                cmd.Parameters.AddWithValue("@MessageDate", DateTime.Now)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        Dim newMessage As New Message
        newMessage.Sender = OnlineUser.UID
        newMessage.Message = Guna2TextBox3.Text
        newMessage.MessageDate = DateTime.Now

        sendMessage(newMessage)

        Guna2TextBox3.Clear()

    End Sub

    Public Sub sendMessage(NewMessage As Message)

        Dim lineHeight As Integer = 1
        Dim messageLength As Integer = NewMessage.Message.Count

        While messageLength > 40
            messageLength -= 40
            lineHeight += 1
        End While

        Dim chatBubble As New Guna2TextBox
        chatBubble.Text = NewMessage.Message
        chatBubble.ForeColor = Color.Black
        chatBubble.BackColor = Color.Transparent
        chatBubble.FillColor = Color.FromArgb(250, 187, 24)
        chatBubble.BorderRadius = 20
        chatBubble.Multiline = True
        chatBubble.WordWrap = True
        chatBubble.ReadOnly = True
        chatBubble.BorderThickness = 0
        chatBubble.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        chatBubble.Width = 365
        chatBubble.Height = (40 * lineHeight)
        If lineHeight = 2 Then
            chatBubble.Height *= 0.76
        ElseIf lineHeight > 2 Then
            chatBubble.Height *= 0.62
        End If

        Dim container As New Guna2Panel
        container.Width = 430
        container.Height = chatBubble.Height + 25
        container.FillColor = Color.Transparent
        container.BorderRadius = 20

        container.Controls.Add(chatBubble)
        FlowLayoutPanel4.Controls.Add(container)

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("Select FirstName, ImageData From user_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", NewMessage.Sender)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim dp As New Guna2CirclePictureBox
                    dp.Size = New Size(50, 50)
                    dp.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                    dp.SizeMode = PictureBoxSizeMode.StretchImage
                    dp.Location = New Point(369, 0)
                    container.Controls.Add(dp)

                End While

                Dim label As New Label
                label.Text = NewMessage.MessageDate.ToString("F")
                label.TextAlign = ContentAlignment.MiddleCenter
                label.Width = 430
                label.ForeColor = Color.Gray
                FlowLayoutPanel4.Controls.Add(label)

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Load_TeamChat()

        FlowLayoutPanel4.Controls.Clear()

        Dim Messages As New List(Of Message)
        Messages.Clear()

        Using conn As New MySqlConnection(Connections.teamConnString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM " + OG_ID_GroupName + "_chat", conn)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim tempMessage As New Message

                    tempMessage.MID = Val(reader("MID"))
                    tempMessage.Message = reader("Message").ToString()
                    tempMessage.Sender = Val(reader("Sender"))
                    tempMessage.MessageDate = DirectCast(reader("MessageDate"), DateTime)

                    Messages.Add(tempMessage)

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        For Each mes In Messages

            Dim lineHeight As Integer = 1
            Dim messageLength As Integer = mes.Message.Count

            While messageLength > 40
                messageLength -= 40
                lineHeight += 1
            End While

            Dim chatBubble As New Guna2TextBox
            chatBubble.Text = mes.Message
            chatBubble.ForeColor = Color.Black
            chatBubble.BackColor = Color.Transparent
            chatBubble.FillColor = Color.FromArgb(250, 187, 24)
            chatBubble.BorderRadius = 20
            chatBubble.Multiline = True
            chatBubble.WordWrap = True
            chatBubble.ReadOnly = True
            chatBubble.BorderThickness = 0
            chatBubble.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            chatBubble.Width = 365
            chatBubble.Height = (40 * lineHeight)
            If lineHeight = 2 Then
                chatBubble.Height *= 0.76
            ElseIf lineHeight > 2 Then
                chatBubble.Height *= 0.62
            End If

            Dim container As New Guna2Panel
            container.Width = 430
            container.Height = chatBubble.Height + 25
            container.FillColor = Color.Transparent
            container.BorderRadius = 20

            container.Controls.Add(chatBubble)
            FlowLayoutPanel4.Controls.Add(container)

            Dim dp As New Guna2CirclePictureBox

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("Select FirstName, ImageData From user_tbl WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", mes.Sender)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        dp.Size = New Size(50, 50)
                        dp.Image = ToImage(DirectCast(reader("ImageData"), Byte()))
                        dp.SizeMode = PictureBoxSizeMode.StretchImage
                        dp.Location = New Point(369, 0)
                        container.Controls.Add(dp)

                    End While

                    Dim label As New Label
                    label.Text = mes.MessageDate.ToString("F")
                    label.TextAlign = ContentAlignment.MiddleCenter
                    label.Width = 430
                    label.ForeColor = Color.Gray
                    FlowLayoutPanel4.Controls.Add(label)

                End Using

                conn.Close()

            End Using

            If mes.Sender <> OnlineUser.UID Then

                chatBubble.ForeColor = Color.White
                chatBubble.FillColor = Color.FromArgb(39, 39, 39)
                chatBubble.Location = New Point(53)

                dp.Location = New Point(0)

            End If

        Next

    End Sub

    Private Sub Guna2Button22_Click(sender As Object, e As EventArgs) Handles Guna2Button22.Click

        Dim password As String

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT PW FROM user_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                Dim reader = cmd.ExecuteReader()

                While (reader.Read)

                    password = reader("PW").ToString()

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

        If (InputBox("Enter your password:", "Confirmation") = password) Then

            For Each team In OwnTeams

                If (team.ID_GroupName = OG_ID_GroupName) Then

                    OwnTeams.Remove(team)
                    Exit For

                End If

            Next

            For Each team In Teams

                If (team.ID_GroupName = OG_ID_GroupName) Then

                    OwnTeams.Remove(team)
                    Exit For

                End If

            Next

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("DELETE FROM group_tbl WHERE ID_GroupName = @ID_GN", conn)

                    cmd.Parameters.AddWithValue("@ID_GN", OG_ID_GroupName)

                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

            Using conn As New MySqlConnection(Connections.teamConnString)

                conn.Open()

                Using cmd As New MySqlCommand("DROP TABLE " + OG_ID_GroupName + "_chat, " + OG_ID_GroupName + "_task", conn)

                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

            FlowTeams.Controls.RemoveAt(OG_Index)
            Open_Team(FlowTeams.Controls.Item(0), e)

            OG_Index = -1
            OG_ID_GroupName = ""

        Else
            MessageBox.Show("Invalid Password.")
        End If

    End Sub

End Class
