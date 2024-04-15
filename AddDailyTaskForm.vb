Imports MySql.Data.MySqlClient

Public Class AddDailyTaskForm
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("INSERT INTO dailytask_tbl (DTNAME, UID, UN, DateCompleted) VALUES (@DTNAME, @UID, @UN, @DateCompleted)", conn)

                cmd.Parameters.AddWithValue("@DTNAME", Guna2TextBox1.Text)
                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)
                cmd.Parameters.AddWithValue("@UN", OnlineUser.UserName)
                cmd.Parameters.AddWithValue("@DateCompleted", Date.Today.AddDays(-1))

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        MessageBox.Show("Added Successfully")
        Close()

    End Sub

    Private Sub AddDailyTaskForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class