Imports Microsoft.Data.SqlClient
Public Class frmGroceryDash

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ' Declares and instantiate the About form
        Dim aboutForm As New frmAbout

        ' Adds the text to the text box named txtAbout
        aboutForm.txtAbout.Text = "This project will enable members to place and view their weekly grocery orders"

        ' Displays the form after button is clicked
        aboutForm.Show()
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        ' Displays the context menu
        cmsAdmin.Show(btnAdmin, 0, btnAdmin.Height)
    End Sub

    Private Sub UpdateGroceryItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateGroceryItemsToolStripMenuItem.Click
        OpenAdminForm(New frmUpdateGroceryItems)

    End Sub

    Private Sub UpdateMembersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateMembersToolStripMenuItem.Click
        OpenAdminForm(New frmUpdateMembers)
    End Sub

    Private Sub GenerateTheOrderListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateTheOrderListToolStripMenuItem.Click
        OpenAdminForm(New frmGenerateOrderList)
    End Sub

    Private Sub MISReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MISReportToolStripMenuItem.Click
        OpenAdminForm(New frmMISReport)
    End Sub

    Private Sub btnMembers_Click(sender As Object, e As EventArgs) Handles btnMembers.Click
        Dim membersForm As New frmMembersOnly
        membersForm.Show()
    End Sub

    ' Opens the admin forms after a successful password check
    Private Sub OpenAdminForm(adminForm As Form)
        Dim passwordForm As New frmPassword
        passwordForm.ShowDialog()

        If passwordForm.PasswordOK Then
            adminForm.Show()
        End If
    End Sub
End Class
