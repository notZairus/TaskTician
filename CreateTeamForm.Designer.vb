<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateTeamForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Guna2Button17 = New Guna.UI2.WinForms.Guna2Button()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        Label1 = New Label()
        Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label2 = New Label()
        Guna2Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.Controls.Add(Guna2Button2)
        Guna2Panel1.CustomizableEdges = CustomizableEdges7
        Guna2Panel1.Dock = DockStyle.Left
        Guna2Panel1.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        Guna2Panel1.Location = New Point(0, 0)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2Panel1.Size = New Size(122, 574)
        Guna2Panel1.TabIndex = 0
        ' 
        ' Guna2Button2
        ' 
        Guna2Button2.BackColor = Color.Transparent
        Guna2Button2.BorderRadius = 50
        Guna2Button2.CustomizableEdges = CustomizableEdges5
        Guna2Button2.DisabledState.BorderColor = Color.DarkGray
        Guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button2.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button2.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button2.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        Guna2Button2.Font = New Font("Algerian", 40F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Guna2Button2.ForeColor = Color.FromArgb(CByte(250), CByte(187), CByte(24))
        Guna2Button2.Location = New Point(10, 1)
        Guna2Button2.Name = "Guna2Button2"
        Guna2Button2.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2Button2.Size = New Size(103, 112)
        Guna2Button2.TabIndex = 41
        Guna2Button2.Text = "<"
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CacheAge = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.EnableCaching = False
        MySqlCommand1.Transaction = Nothing
        ' 
        ' Guna2Button17
        ' 
        Guna2Button17.BackColor = Color.Transparent
        Guna2Button17.BorderRadius = 20
        Guna2Button17.CustomizableEdges = CustomizableEdges3
        Guna2Button17.DisabledState.BorderColor = Color.DarkGray
        Guna2Button17.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button17.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button17.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button17.FillColor = Color.FromArgb(CByte(250), CByte(187), CByte(24))
        Guna2Button17.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2Button17.ForeColor = Color.Black
        Guna2Button17.Location = New Point(556, 474)
        Guna2Button17.Name = "Guna2Button17"
        Guna2Button17.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Button17.Size = New Size(346, 58)
        Guna2Button17.TabIndex = 39
        Guna2Button17.Text = "Create Team Project"
        Guna2Button17.TextOffset = New Point(0, -2)
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Location = New Point(556, 150)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(346, 305)
        FlowLayoutPanel2.TabIndex = 42
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(556, 101)
        Label1.Name = "Label1"
        Label1.Size = New Size(263, 46)
        Label1.TabIndex = 43
        Label1.Text = "Team Members"
        ' 
        ' Guna2TextBox1
        ' 
        Guna2TextBox1.AutoScroll = True
        Guna2TextBox1.AutoSize = True
        Guna2TextBox1.BorderRadius = 20
        Guna2TextBox1.CustomizableEdges = CustomizableEdges1
        Guna2TextBox1.DefaultText = ""
        Guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        Guna2TextBox1.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Font = New Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2TextBox1.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Location = New Point(556, 29)
        Guna2TextBox1.Margin = New Padding(23, 30, 23, 30)
        Guna2TextBox1.Name = "Guna2TextBox1"
        Guna2TextBox1.PasswordChar = ChrW(0)
        Guna2TextBox1.PlaceholderText = "Team Name"
        Guna2TextBox1.SelectedText = ""
        Guna2TextBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2TextBox1.Size = New Size(346, 58)
        Guna2TextBox1.TabIndex = 44
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Location = New Point(162, 78)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(346, 454)
        FlowLayoutPanel1.TabIndex = 40
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(162, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(151, 46)
        Label2.TabIndex = 41
        Label2.Text = "Mutuals"
        ' 
        ' CreateTeamForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(947, 574)
        Controls.Add(Guna2TextBox1)
        Controls.Add(Label1)
        Controls.Add(FlowLayoutPanel2)
        Controls.Add(Label2)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(Guna2Button17)
        Controls.Add(Guna2Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CreateTeamForm"
        Text = "CreateTeamForm"
        Guna2Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button17 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
