Imports MySql.Data.MySqlClient

Public Class AddTaskForm
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If Guna2DateTimePicker1.Value.Date < Date.Today Then

            MessageBox.Show("Set a proper Due Date.")

        Else

            Using conn As New MySqlConnection(Connections.connString)

                Dim qry As String = "INSERT INTO personaltask_tbl (TaskName, TaskCategory, TaskDeadline, TaskStatus, UID, UN, TaskInfo) 
                                VALUES (@TaskName, @TaskCategory, @TaskDeadline, @TaskStatus, @UID, @UN, @TaskInfo)"

                conn.Open()

                Using cmd As New MySqlCommand(qry, conn)

                    cmd.Parameters.AddWithValue("@TaskName", Guna2TextBox1.Text)
                    cmd.Parameters.AddWithValue("@TaskCategory", Guna2ComboBox1.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@TaskDeadline", Guna2DateTimePicker1.Value.Date)
                    If Guna2DateTimePicker1.Value.Date < Date.Today Then
                        cmd.Parameters.AddWithValue("@TaskStatus", "Failed")
                    Else
                        cmd.Parameters.AddWithValue("@TaskStatus", "Pending")
                    End If
                    cmd.Parameters.AddWithValue("@TaskInfo", Guna2TextBox2.Text)
                    cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                    cmd.Parameters.AddWithValue("@UN", OnlineUser.UserName)

                    cmd.ExecuteNonQuery()

                End Using

                Using cmd As New MySqlCommand("UPDATE user_tbl SET TotalTask = TotalTask + 1 WHERE UID = @UID", conn)

                    cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()
                MessageBox.Show("TASK ADDED SUCCESSFULLY!")
                Close()

            End Using

        End If

    End Sub

End Class