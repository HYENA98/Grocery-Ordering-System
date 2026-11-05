<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembersOnly
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
        lblEnterMember = New Label()
        btnContinue = New Button()
        gbxVerification = New GroupBox()
        lblMemberContact = New Label()
        lblMemberSurname = New Label()
        lblMemberName = New Label()
        lblAreYouMember = New Label()
        mtbMemberID = New MaskedTextBox()
        btnYes = New Button()
        btnNo = New Button()
        gbxVerification.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblEnterMember
        ' 
        lblEnterMember.AutoSize = True
        lblEnterMember.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEnterMember.Location = New Point(26, 22)
        lblEnterMember.Name = "lblEnterMember"
        lblEnterMember.Size = New Size(242, 20)
        lblEnterMember.TabIndex = 0
        lblEnterMember.Text = "ENTER YOUR MEMBER NUMBER:"
        ' 
        ' btnContinue
        ' 
        btnContinue.Location = New Point(338, 218)
        btnContinue.Margin = New Padding(3, 2, 3, 2)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(215, 60)
        btnContinue.TabIndex = 2
        btnContinue.Text = "Continue to order Groceries"
        btnContinue.UseVisualStyleBackColor = True
        ' 
        ' gbxVerification
        ' 
        gbxVerification.Controls.Add(btnNo)
        gbxVerification.Controls.Add(btnYes)
        gbxVerification.Controls.Add(lblMemberContact)
        gbxVerification.Controls.Add(lblMemberSurname)
        gbxVerification.Controls.Add(lblMemberName)
        gbxVerification.Controls.Add(lblAreYouMember)
        gbxVerification.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        gbxVerification.Location = New Point(26, 67)
        gbxVerification.Margin = New Padding(3, 2, 3, 2)
        gbxVerification.Name = "gbxVerification"
        gbxVerification.Padding = New Padding(3, 2, 3, 2)
        gbxVerification.Size = New Size(295, 212)
        gbxVerification.TabIndex = 3
        gbxVerification.TabStop = False
        gbxVerification.Visible = False
        ' 
        ' lblMemberContact
        ' 
        lblMemberContact.AutoSize = True
        lblMemberContact.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberContact.Location = New Point(25, 160)
        lblMemberContact.Name = "lblMemberContact"
        lblMemberContact.Size = New Size(0, 16)
        lblMemberContact.TabIndex = 5
        ' 
        ' lblMemberSurname
        ' 
        lblMemberSurname.AutoSize = True
        lblMemberSurname.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberSurname.Location = New Point(25, 128)
        lblMemberSurname.Name = "lblMemberSurname"
        lblMemberSurname.Size = New Size(0, 16)
        lblMemberSurname.TabIndex = 4
        ' 
        ' lblMemberName
        ' 
        lblMemberName.AutoSize = True
        lblMemberName.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMemberName.Location = New Point(25, 94)
        lblMemberName.Name = "lblMemberName"
        lblMemberName.Size = New Size(0, 16)
        lblMemberName.TabIndex = 3
        ' 
        ' lblAreYouMember
        ' 
        lblAreYouMember.AutoSize = True
        lblAreYouMember.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAreYouMember.Location = New Point(114, 17)
        lblAreYouMember.Name = "lblAreYouMember"
        lblAreYouMember.Size = New Size(86, 18)
        lblAreYouMember.TabIndex = 0
        lblAreYouMember.Text = "Is This You"
        ' 
        ' mtbMemberID
        ' 
        mtbMemberID.BeepOnError = True
        mtbMemberID.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mtbMemberID.Location = New Point(274, 19)
        mtbMemberID.Mask = "00-00"
        mtbMemberID.Name = "mtbMemberID"
        mtbMemberID.Size = New Size(100, 25)
        mtbMemberID.TabIndex = 4
        ' 
        ' btnYes
        ' 
        btnYes.Location = New Point(68, 55)
        btnYes.Name = "btnYes"
        btnYes.Size = New Size(75, 23)
        btnYes.TabIndex = 6
        btnYes.Text = "YES"
        btnYes.UseVisualStyleBackColor = True
        ' 
        ' btnNo
        ' 
        btnNo.Location = New Point(167, 55)
        btnNo.Name = "btnNo"
        btnNo.Size = New Size(75, 23)
        btnNo.TabIndex = 7
        btnNo.Text = "NO"
        btnNo.UseVisualStyleBackColor = True
        ' 
        ' frmMembersOnly
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(700, 338)
        Controls.Add(mtbMemberID)
        Controls.Add(gbxVerification)
        Controls.Add(btnContinue)
        Controls.Add(lblEnterMember)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMembersOnly"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Members Only Form"
        gbxVerification.ResumeLayout(False)
        gbxVerification.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblEnterMember As Label
    Friend WithEvents btnContinue As Button
    Friend WithEvents gbxVerification As GroupBox
    Friend WithEvents lblAreYouMember As Label
    Friend WithEvents lblMemberContact As Label
    Friend WithEvents lblMemberSurname As Label
    Friend WithEvents lblMemberName As Label
    Friend WithEvents mtbMemberID As MaskedTextBox
    Friend WithEvents btnNo As Button
    Friend WithEvents btnYes As Button
End Class
