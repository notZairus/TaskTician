Imports Guna.UI2.WinForms
Imports Guna.UI2.WinForms.Suite
Imports MySql.Data.MySqlClient

Public Class DeleteDailyForm
    Private Sub DeleteDailyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Dailies()

    End Sub

    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        Close()
    End Sub

    Private Sub Load_Dailies()

        FlowLayoutPanel1.Controls.Clear()

        Using conn As New MySqlConnection(Connections.connString)

            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM dailytask_tbl WHERE UID = @UID", conn)

                cmd.Parameters.AddWithValue("@UID", OnlineUser.UID)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()

                    Dim panel As New Guna2Panel
                    panel.Size = New Size(300, 50)
                    panel.FillColor = Color.Transparent
                    panel.BorderRadius = 25
                    panel.Tag = Val(reader("DTID"))
                    FlowLayoutPanel1.Controls.Add(panel)

                    Dim label As New Label()
                    label.Size = New Size(200, 50)
                    label.Text = reader("DTName").ToString()
                    label.ForeColor = Color.FromArgb(39, 39, 39)
                    label.BackColor = Color.Transparent()
                    label.Font = New Font("Segoe UI", 14, FontStyle.Bold)
                    label.Location = New Point(8, 0)
                    panel.Controls.Add(label)

                    Dim guna2circlebutton1 As New Guna2CircleButton()
                    guna2circlebutton1.DisabledState.BorderColor = Color.DarkGray
                    guna2circlebutton1.DisabledState.CustomBorderColor = Color.DarkGray
                    guna2circlebutton1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
                    guna2circlebutton1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
                    guna2circlebutton1.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
                    guna2circlebutton1.Font = New Font("Segoe UI Semibold", 20.0F, FontStyle.Bold, GraphicsUnit.Point)
                    guna2circlebutton1.ForeColor = Color.White
                    guna2circlebutton1.Location = New Point(255, 2)
                    guna2circlebutton1.Name = "Guna2CircleButton1"
                    guna2circlebutton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
                    guna2circlebutton1.Size = New Size(44, 44)
                    guna2circlebutton1.TabIndex = 0
                    guna2circlebutton1.Text = "x"
                    guna2circlebutton1.TextOffset = New Point(2, -3)
                    AddHandler guna2circlebutton1.Click, AddressOf delete_Daily_Task
                    panel.Controls.Add(guna2circlebutton1)

                    Dim line As New Panel()
                    line.Width = 300
                    line.Height = 1
                    line.BackColor = Color.Black
                    FlowLayoutPanel1.Controls.Add(line)


                End While

                reader.Close()

            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub delete_Daily_Task(sender As Object, e As EventArgs)

        Dim btn As Guna2CircleButton = DirectCast(sender, Guna2CircleButton)

        If MessageBox.Show("Delete the daily task?", "confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            FlowLayoutPanel1.Controls.RemoveAt(FlowLayoutPanel1.Controls.IndexOf(btn.Parent) + 1)
            FlowLayoutPanel1.Controls.RemoveAt(FlowLayoutPanel1.Controls.IndexOf(btn.Parent))

            Using conn As New MySqlConnection(Connections.connString)

                conn.Open()

                Using cmd As New MySqlCommand("DELETE FROM dailytask_tbl WHERE DTID = @DTID", conn)

                    cmd.Parameters.AddWithValue("@DTID", btn.Parent.Tag)

                    cmd.ExecuteNonQuery()

                End Using

                conn.Close()

            End Using

        End If

    End Sub

End Class