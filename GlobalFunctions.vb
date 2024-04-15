Imports System.IO
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Module GlobalFunctions

    Public Function ToImage(imgData As Byte())

        Using mem As New MemoryStream(imgData)

            Dim img As Image
            img = Image.FromStream(mem)
            Return img

        End Using

    End Function

    Public Sub Get_Friends(frnd As String)

        OnlineUser.Friends.Clear()

        Dim friendAsString As New List(Of String)(Split(frnd, ","))
        friendAsString.RemoveAt(0)

        For Each frnd In friendAsString

            OnlineUser.Friends.Add(Val(frnd))

        Next

    End Sub

End Module
