<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateMembers
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
        lblTitle = New Label()
        lblMemberID = New Label()
        lblName = New Label()
        lblSurname = New Label()
        lblContactTel = New Label()
        lblEmail = New Label()
        mtbMemberID = New MaskedTextBox()
        txtName = New TextBox()
        txtSurname = New TextBox()
        mtbContactTel = New MaskedTextBox()
        txtEmail = New TextBox()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnAddNew = New Button()
        btnUpdate = New Button()
        lblActive = New Label()
        cboActive = New ComboBox()
        dgvMembers = New DataGridView()
        CType(dgvMembers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(10, 7)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(202, 20)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Select or Update A Member"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Location = New Point(10, 36)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(63, 15)
        lblMemberID.TabIndex = 1
        lblMemberID.Text = "MemberID"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(160, 36)
        lblName.Name = "lblName"
        lblName.Size = New Size(39, 15)
        lblName.TabIndex = 2
        lblName.Text = "Name"
        ' 
        ' lblSurname
        ' 
        lblSurname.AutoSize = True
        lblSurname.Location = New Point(319, 36)
        lblSurname.Name = "lblSurname"
        lblSurname.Size = New Size(54, 15)
        lblSurname.TabIndex = 3
        lblSurname.Text = "Surname"
        ' 
        ' lblContactTel
        ' 
        lblContactTel.AutoSize = True
        lblContactTel.Location = New Point(498, 36)
        lblContactTel.Name = "lblContactTel"
        lblContactTel.Size = New Size(66, 15)
        lblContactTel.TabIndex = 4
        lblContactTel.Text = "Contact Tel"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(654, 36)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(36, 15)
        lblEmail.TabIndex = 5
        lblEmail.Text = "Email"
        ' 
        ' mtbMemberID
        ' 
        mtbMemberID.Location = New Point(14, 58)
        mtbMemberID.Margin = New Padding(3, 2, 3, 2)
        mtbMemberID.Mask = "00-00"
        mtbMemberID.Name = "mtbMemberID"
        mtbMemberID.Size = New Size(110, 23)
        mtbMemberID.TabIndex = 6
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(160, 58)
        txtName.Margin = New Padding(3, 2, 3, 2)
        txtName.Name = "txtName"
        txtName.Size = New Size(134, 23)
        txtName.TabIndex = 7
        ' 
        ' txtSurname
        ' 
        txtSurname.Location = New Point(319, 58)
        txtSurname.Margin = New Padding(3, 2, 3, 2)
        txtSurname.Name = "txtSurname"
        txtSurname.Size = New Size(153, 23)
        txtSurname.TabIndex = 8
        ' 
        ' mtbContactTel
        ' 
        mtbContactTel.Location = New Point(498, 58)
        mtbContactTel.Margin = New Padding(3, 2, 3, 2)
        mtbContactTel.Mask = "000-000-0000"
        mtbContactTel.Name = "mtbContactTel"
        mtbContactTel.Size = New Size(110, 23)
        mtbContactTel.TabIndex = 9
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(654, 58)
        txtEmail.Margin = New Padding(3, 2, 3, 2)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(110, 23)
        txtEmail.TabIndex = 10
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(10, 95)
        txtSearch.Margin = New Padding(3, 2, 3, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(110, 23)
        txtSearch.TabIndex = 11
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(160, 94)
        btnSearch.Margin = New Padding(3, 2, 3, 2)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(82, 22)
        btnSearch.TabIndex = 12
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnAddNew
        ' 
        btnAddNew.Location = New Point(319, 94)
        btnAddNew.Margin = New Padding(3, 2, 3, 2)
        btnAddNew.Name = "btnAddNew"
        btnAddNew.Size = New Size(82, 22)
        btnAddNew.TabIndex = 13
        btnAddNew.Text = "New/Add"
        btnAddNew.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(459, 94)
        btnUpdate.Margin = New Padding(3, 2, 3, 2)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(82, 22)
        btnUpdate.TabIndex = 14
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' lblActive
        ' 
        lblActive.AutoSize = True
        lblActive.Location = New Point(579, 95)
        lblActive.Name = "lblActive"
        lblActive.Size = New Size(64, 15)
        lblActive.TabIndex = 15
        lblActive.Text = "Active Y/N"
        ' 
        ' cboActive
        ' 
        cboActive.DropDownStyle = ComboBoxStyle.DropDownList
        cboActive.FormattingEnabled = True
        cboActive.Items.AddRange(New Object() {"Y", "N"})
        cboActive.Location = New Point(654, 92)
        cboActive.Margin = New Padding(3, 2, 3, 2)
        cboActive.Name = "cboActive"
        cboActive.Size = New Size(133, 23)
        cboActive.TabIndex = 16
        ' 
        ' dgvMembers
        ' 
        dgvMembers.AllowUserToAddRows = False
        dgvMembers.AllowUserToDeleteRows = False
        dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembers.Location = New Point(14, 134)
        dgvMembers.Margin = New Padding(3, 2, 3, 2)
        dgvMembers.MultiSelect = False
        dgvMembers.Name = "dgvMembers"
        dgvMembers.ReadOnly = True
        dgvMembers.RowHeadersWidth = 51
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMembers.Size = New Size(772, 390)
        dgvMembers.TabIndex = 17
        ' 
        ' frmUpdateMembers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(816, 543)
        Controls.Add(dgvMembers)
        Controls.Add(cboActive)
        Controls.Add(lblActive)
        Controls.Add(btnUpdate)
        Controls.Add(btnAddNew)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(txtEmail)
        Controls.Add(mtbContactTel)
        Controls.Add(txtSurname)
        Controls.Add(txtName)
        Controls.Add(mtbMemberID)
        Controls.Add(lblEmail)
        Controls.Add(lblContactTel)
        Controls.Add(lblSurname)
        Controls.Add(lblName)
        Controls.Add(lblMemberID)
        Controls.Add(lblTitle)
        Name = "frmUpdateMembers"
        Text = "Members Add/Update"
        CType(dgvMembers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblMemberID As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblContactTel As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents mtbMemberID As MaskedTextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents mtbContactTel As MaskedTextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lblActive As Label
    Friend WithEvents cboActive As ComboBox
    Friend WithEvents dgvMembers As DataGridView
End Class
