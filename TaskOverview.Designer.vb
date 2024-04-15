<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskOverview
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Guna2TileButton1 = New Guna.UI2.WinForms.Guna2TileButton()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Bahnschrift SemiBold", 32F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(10, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(705, 104)
        Label2.TabIndex = 16
        Label2.Text = "TaskName" & vbCrLf
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Bahnschrift SemiBold", 28F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(24, 240)
        Label1.Name = "Label1"
        Label1.Size = New Size(741, 326)
        Label1.TabIndex = 17
        Label1.Text = "Task Info: "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Bahnschrift SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(26, 184)
        Label3.Name = "Label3"
        Label3.Size = New Size(135, 33)
        Label3.TabIndex = 18
        Label3.Text = "Category: "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Bahnschrift SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(25, 130)
        Label4.Name = "Label4"
        Label4.Size = New Size(136, 33)
        Label4.TabIndex = 19
        Label4.Text = "Due Date: "
        ' 
        ' Guna2TileButton1
        ' 
        Guna2TileButton1.BackColor = Color.Transparent
        Guna2TileButton1.CustomizableEdges = CustomizableEdges1
        Guna2TileButton1.DisabledState.BorderColor = Color.DarkGray
        Guna2TileButton1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2TileButton1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2TileButton1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2TileButton1.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        Guna2TileButton1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2TileButton1.ForeColor = Color.White
        Guna2TileButton1.Location = New Point(736, -9)
        Guna2TileButton1.Name = "Guna2TileButton1"
        Guna2TileButton1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2TileButton1.Size = New Size(62, 58)
        Guna2TileButton1.TabIndex = 20
        Guna2TileButton1.Text = "x"
        ' 
        ' TaskOverview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        ClientSize = New Size(790, 585)
        Controls.Add(Guna2TileButton1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.None
        Name = "TaskOverview"
        Text = "TaskOverview"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Guna2TileButton1 As Guna.UI2.WinForms.Guna2TileButton
End Class
