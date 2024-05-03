Module OnlineUser


    'USER INFO
    'USER INFO
    'USER INFO

    Public Property UID As Integer
    Public Property UserName As String
    Public Property UserImage As Image
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property Friends As New List(Of Integer)
    Public Property stringFriends As String
    Public Property TotalTask As Integer
    Public Property CompletedTask As Integer
    Public Property FailedTask As Integer


    'USER TASKS
    'USER TASKS
    'USER TASKS

    Public Property TaskList As New List(Of Task)

    Public Property Failed_TaskList As New List(Of Task)
    Public Property Pending_TaskList As New List(Of Task)
    Public Property Completed_TaskList As New List(Of Task)


    'USER TEAMS
    'USER TEAMS
    'USER TEAMS

    Public Property Teams As New List(Of Team)
    Public Property OwnTeams As New List(Of Team)
    Public Property MemOfTeams As New List(Of Team)

    'OPEN TEAM
    'OPEN TEAM
    'OPEN TEAM

    Public Property OG_ID_GroupName As String
    Public Property OG_Index As Integer

End Module
