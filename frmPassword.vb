Imports System.ComponentModel
Public Class frmPassword
    ' Indicates if the password was validated successfully
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PasswordOK As Boolean = False

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click

        Const MATRON_PASSWORD As String = "Admin98"

        If txtPassword.Text = MATRON_PASSWORD Then
            PasswordOK = True
            Me.Close()
        Else
            MessageBox.Show("Incorrect password. Access denied.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            ' Show the password
            txtPassword.PasswordChar = ""
        Else
            ' Hide the password
            txtPassword.PasswordChar = "*"
        End If
    End Sub

End Class