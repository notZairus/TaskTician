Imports MySql.Data.MySqlClient

Public Class TaskOverview

    Public Property TID As Integer

    Private Sub TaskOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM personaltask_tbl WHERE TID = @TID", conn)

                cmd.Parameters.AddWithValue("@TID", TID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader

                While reader.Read()

                    Label2.Text = "Task Name: " + reader("TaskName").ToString()
                    Label3.Text = "Task Category: " + reader("TaskCategory").ToString()
                    Label4.Text = "Task Deadline: " + DirectCast(reader("TaskDeadline"), Date).ToString("D")
                    Label1.Text = "Task Info: " + reader("TaskInfo").ToString()

                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        Close()
    End Sub
End Class