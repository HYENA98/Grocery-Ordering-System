<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGroceryDash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        btnAbout = New Button()
        btnMembers = New Button()
        cmsAdmin = New ContextMenuStrip(components)
        UpdateGroceryItemsToolStripMenuItem = New ToolStripMenuItem()
        UpdateMembersToolStripMenuItem = New ToolStripMenuItem()
        GenerateTheOrderListToolStripMenuItem = New ToolStripMenuItem()
        MISReportToolStripMenuItem = New ToolStripMenuItem()
        btnAdmin = New Button()
        cmsAdmin.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnAbout
        ' 
        btnAbout.BackColor = SystemColors.ActiveCaption
        btnAbout.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAbout.Location = New Point(373, 16)
        btnAbout.Margin = New Padding(3, 4, 3, 4)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(126, 47)
        btnAbout.TabIndex = 0
        btnAbout.Text = "About"
        btnAbout.UseVisualStyleBackColor = False
        ' 
        ' btnMembers
        ' 
        btnMembers.BackColor = SystemColors.ActiveCaption
        btnMembers.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMembers.Location = New Point(755, 16)
        btnMembers.Margin = New Padding(3, 4, 3, 4)
        btnMembers.Name = "btnMembers"
        btnMembers.Size = New Size(136, 47)
        btnMembers.TabIndex = 2
        btnMembers.Text = "Members Only"
        btnMembers.UseVisualStyleBackColor = False
        ' 
        ' cmsAdmin
        ' 
        cmsAdmin.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmsAdmin.ImageScalingSize = New Size(20, 20)
        cmsAdmin.Items.AddRange(New ToolStripItem() {UpdateGroceryItemsToolStripMenuItem, UpdateMembersToolStripMenuItem, GenerateTheOrderListToolStripMenuItem, MISReportToolStripMenuItem})
        cmsAdmin.Name = "cmsAdmin"
        cmsAdmin.Size = New Size(298, 108)
        cmsAdmin.Text = "Admin Functions"
        ' 
        ' UpdateGroceryItemsToolStripMenuItem
        ' 
        UpdateGroceryItemsToolStripMenuItem.Name = "UpdateGroceryItemsToolStripMenuItem"
        UpdateGroceryItemsToolStripMenuItem.Size = New Size(297, 26)
        UpdateGroceryItemsToolStripMenuItem.Text = "Update Grocery Items"
        ' 
        ' UpdateMembersToolStripMenuItem
        ' 
        UpdateMembersToolStripMenuItem.Name = "UpdateMembersToolStripMenuItem"
        UpdateMembersToolStripMenuItem.Size = New Size(297, 26)
        UpdateMembersToolStripMenuItem.Text = "Update Members"
        ' 
        ' GenerateTheOrderListToolStripMenuItem
        ' 
        GenerateTheOrderListToolStripMenuItem.Name = "GenerateTheOrderListToolStripMenuItem"
        GenerateTheOrderListToolStripMenuItem.Size = New Size(297, 26)
        GenerateTheOrderListToolStripMenuItem.Text = "Generate the Order List"
        ' 
        ' MISReportToolStripMenuItem
        ' 
        MISReportToolStripMenuItem.Name = "MISReportToolStripMenuItem"
        MISReportToolStripMenuItem.Size = New Size(297, 26)
        MISReportToolStripMenuItem.Text = "MIS Report"
        ' 
        ' btnAdmin
        ' 
        btnAdmin.BackColor = SystemColors.ActiveCaption
        btnAdmin.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAdmin.Location = New Point(544, 16)
        btnAdmin.Margin = New Padding(3, 4, 3, 4)
        btnAdmin.Name = "btnAdmin"
        btnAdmin.Size = New Size(168, 47)
        btnAdmin.TabIndex = 4
        btnAdmin.Text = "Admin Functions"
        btnAdmin.UseVisualStyleBackColor = False
        ' 
        ' frmGroceryDash
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.GroceryPic
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1300, 701)
        Controls.Add(btnAdmin)
        Controls.Add(btnMembers)
        Controls.Add(btnAbout)
        DoubleBuffered = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "frmGroceryDash"
        Text = "THE HAPPY HOPES PROJECT"
        cmsAdmin.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAbout As Button
    Friend WithEvents btnMembers As Button
    Friend WithEvents cmsAdmin As ContextMenuStrip
    Friend WithEvents UpdateGroceryItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateMembersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateTheOrderListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MISReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAdmin As Button

End Class
