<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
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
        btnContinue = New Button()
        lblPassword = New Label()
        txtPassword = New TextBox()
        chkShowPassword = New CheckBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnContinue
        ' 
        btnContinue.BackColor = SystemColors.ActiveCaption
        btnContinue.Font = New Font("Microsoft Sans Serif", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnContinue.Location = New Point(265, 125)
        btnContinue.Margin = New Padding(3, 4, 3, 4)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(109, 63)
        btnContinue.TabIndex = 0
        btnContinue.Text = "Continue"
        btnContinue.UseVisualStyleBackColor = False
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Microsoft Sans Serif", 11.2499981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(181, 12)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(314, 24)
        lblPassword.TabIndex = 1
        lblPassword.Text = "Enter Matron Password To Continue"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(232, 73)
        txtPassword.Margin = New Padding(3, 4, 3, 4)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(182, 27)
        txtPassword.TabIndex = 2
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(433, 76)
        chkShowPassword.Margin = New Padding(3, 4, 3, 4)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(148, 27)
        chkShowPassword.TabIndex = 4
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(149, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(84, 23)
        Label1.TabIndex = 5
        Label1.Text = "Password:"
        ' 
        ' frmPassword
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(630, 204)
        Controls.Add(Label1)
        Controls.Add(chkShowPassword)
        Controls.Add(txtPassword)
        Controls.Add(lblPassword)
        Controls.Add(btnContinue)
        Margin = New Padding(3, 4, 3, 4)
        Name = "frmPassword"
        Text = "Password"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnContinue As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents Label1 As Label
End Class
