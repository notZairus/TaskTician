<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteDailyForm
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Guna2TileButton1 = New Guna.UI2.WinForms.Guna2TileButton()
        Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label3 = New Label()
        Guna2Panel1.SuspendLayout()
        Guna2Panel2.SuspendLayout()
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
        Guna2Panel1.Controls.Add(Guna2TileButton1)
        Guna2Panel1.CustomizableEdges = CustomizableEdges5
        Guna2Panel1.Dock = DockStyle.Left
        Guna2Panel1.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        Guna2Panel1.Location = New Point(0, 0)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2Panel1.Size = New Size(102, 480)
        Guna2Panel1.TabIndex = 28
        ' 
        ' Guna2TileButton1
        ' 
        Guna2TileButton1.CustomizableEdges = CustomizableEdges3
        Guna2TileButton1.DisabledState.BorderColor = Color.DarkGray
        Guna2TileButton1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2TileButton1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2TileButton1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2TileButton1.FillColor = Color.FromArgb(CByte(39), CByte(39), CByte(39))
        Guna2TileButton1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2TileButton1.ForeColor = Color.White
        Guna2TileButton1.Location = New Point(0, 0)
        Guna2TileButton1.Name = "Guna2TileButton1"
        Guna2TileButton1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2TileButton1.Size = New Size(46, 43)
        Guna2TileButton1.TabIndex = 1
        Guna2TileButton1.Text = "x"
        ' 
        ' Guna2Panel2
        ' 
        Guna2Panel2.BackColor = Color.Transparent
        Guna2Panel2.BorderRadius = 20
        Guna2Panel2.Controls.Add(FlowLayoutPanel1)
        Guna2Panel2.CustomizableEdges = CustomizableEdges1
        Guna2Panel2.FillColor = Color.FromArgb(CByte(250), CByte(187), CByte(24))
        Guna2Panel2.Location = New Point(136, 102)
        Guna2Panel2.Name = "Guna2Panel2"
        Guna2Panel2.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Panel2.Size = New Size(309, 342)
        Guna2Panel2.TabIndex = 29
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Location = New Point(0, 4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(309, 335)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(136, 21)
        Label3.Name = "Label3"
        Label3.Size = New Size(309, 69)
        Label3.TabIndex = 30
        Label3.Text = "Choose the daily task you want to delete"
        ' 
        ' DeleteDailyForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(491, 480)
        Controls.Add(Label3)
        Controls.Add(Guna2Panel2)
        Controls.Add(Guna2Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "DeleteDailyForm"
        Text = "DeleteDailyForm"
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2TileButton1 As Guna.UI2.WinForms.Guna2TileButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
