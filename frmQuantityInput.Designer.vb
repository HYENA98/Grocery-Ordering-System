<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuantityInput
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
        lblItemDescription = New Label()
        lblPrompt = New Label()
        txtQuantity = New TextBox()
        btnOK = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblItemDescription
        ' 
        lblItemDescription.AutoSize = True
        lblItemDescription.Location = New Point(12, 20)
        lblItemDescription.Name = "lblItemDescription"
        lblItemDescription.Size = New Size(0, 15)
        lblItemDescription.TabIndex = 0
        ' 
        ' lblPrompt
        ' 
        lblPrompt.AutoSize = True
        lblPrompt.Location = New Point(120, 81)
        lblPrompt.Name = "lblPrompt"
        lblPrompt.Size = New Size(86, 15)
        lblPrompt.TabIndex = 1
        lblPrompt.Text = "Enter Quantity:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(212, 78)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(58, 23)
        txtQuantity.TabIndex = 2
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(79, 142)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 3
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(231, 142)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 4
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' frmQuantityInput
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 211)
        Controls.Add(btnCancel)
        Controls.Add(btnOK)
        Controls.Add(txtQuantity)
        Controls.Add(lblPrompt)
        Controls.Add(lblItemDescription)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmQuantityInput"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Enter Quantity"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblItemDescription As Label
    Friend WithEvents lblPrompt As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
