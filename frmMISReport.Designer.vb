<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMISReport
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
        dtpFromDate = New DateTimePicker()
        dtpToDate = New DateTimePicker()
        lblFrom = New Label()
        lblTo = New Label()
        txtFromDate = New TextBox()
        txtToDate = New TextBox()
        grpGrocery = New GroupBox()
        Label1 = New Label()
        dgvGrocery = New DataGridView()
        cboLow = New ComboBox()
        lblShowLow = New Label()
        cboTop = New ComboBox()
        lblShowTop = New Label()
        btnCreateGrocery = New Button()
        grpMembers = New GroupBox()
        Label2 = New Label()
        dgvMembers = New DataGridView()
        btnCreateMembers = New Button()
        grpGrocery.SuspendLayout()
        CType(dgvGrocery, ComponentModel.ISupportInitialize).BeginInit()
        grpMembers.SuspendLayout()
        CType(dgvMembers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Arial", 15.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Red
        lblTitle.Location = New Point(360, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(270, 24)
        lblTitle.TabIndex = 0
        lblTitle.Text = "MANAGEMENT REPORTS"
        ' 
        ' dtpFromDate
        ' 
        dtpFromDate.CustomFormat = "dddd, dd MMMM yyyy"
        dtpFromDate.Format = DateTimePickerFormat.Custom
        dtpFromDate.Location = New Point(243, 49)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(212, 23)
        dtpFromDate.TabIndex = 1
        ' 
        ' dtpToDate
        ' 
        dtpToDate.CustomFormat = "dddd, dd MMMM yyyy"
        dtpToDate.Format = DateTimePickerFormat.Custom
        dtpToDate.Location = New Point(524, 49)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(207, 23)
        dtpToDate.TabIndex = 2
        ' 
        ' lblFrom
        ' 
        lblFrom.AutoSize = True
        lblFrom.Location = New Point(243, 99)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(43, 15)
        lblFrom.TabIndex = 3
        lblFrom.Text = "FROM:"
        ' 
        ' lblTo
        ' 
        lblTo.AutoSize = True
        lblTo.Location = New Point(524, 99)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(24, 15)
        lblTo.TabIndex = 4
        lblTo.Text = "TO:"
        ' 
        ' txtFromDate
        ' 
        txtFromDate.Location = New Point(292, 91)
        txtFromDate.Name = "txtFromDate"
        txtFromDate.ReadOnly = True
        txtFromDate.Size = New Size(163, 23)
        txtFromDate.TabIndex = 5
        ' 
        ' txtToDate
        ' 
        txtToDate.Location = New Point(554, 96)
        txtToDate.Name = "txtToDate"
        txtToDate.ReadOnly = True
        txtToDate.Size = New Size(177, 23)
        txtToDate.TabIndex = 6
        ' 
        ' grpGrocery
        ' 
        grpGrocery.BackColor = SystemColors.ControlDark
        grpGrocery.Controls.Add(Label1)
        grpGrocery.Controls.Add(dgvGrocery)
        grpGrocery.Controls.Add(cboLow)
        grpGrocery.Controls.Add(lblShowLow)
        grpGrocery.Controls.Add(cboTop)
        grpGrocery.Controls.Add(lblShowTop)
        grpGrocery.Controls.Add(btnCreateGrocery)
        grpGrocery.Location = New Point(12, 136)
        grpGrocery.Name = "grpGrocery"
        grpGrocery.Size = New Size(486, 391)
        grpGrocery.TabIndex = 7
        grpGrocery.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(160, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(245, 22)
        Label1.TabIndex = 6
        Label1.Text = "GROCERY ORDERS REPORT"
        ' 
        ' dgvGrocery
        ' 
        dgvGrocery.AllowUserToAddRows = False
        dgvGrocery.BackgroundColor = SystemColors.Control
        dgvGrocery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvGrocery.Location = New Point(6, 111)
        dgvGrocery.Name = "dgvGrocery"
        dgvGrocery.ReadOnly = True
        dgvGrocery.Size = New Size(474, 274)
        dgvGrocery.TabIndex = 5
        ' 
        ' cboLow
        ' 
        cboLow.DropDownStyle = ComboBoxStyle.DropDownList
        cboLow.FormattingEnabled = True
        cboLow.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        cboLow.Location = New Point(316, 82)
        cboLow.Name = "cboLow"
        cboLow.Size = New Size(50, 23)
        cboLow.TabIndex = 4
        ' 
        ' lblShowLow
        ' 
        lblShowLow.AutoSize = True
        lblShowLow.Location = New Point(242, 85)
        lblShowLow.Name = "lblShowLow"
        lblShowLow.Size = New Size(68, 15)
        lblShowLow.TabIndex = 3
        lblShowLow.Text = "Show LOW:"
        ' 
        ' cboTop
        ' 
        cboTop.DropDownStyle = ComboBoxStyle.DropDownList
        cboTop.FormattingEnabled = True
        cboTop.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        cboTop.Location = New Point(178, 82)
        cboTop.Name = "cboTop"
        cboTop.Size = New Size(46, 23)
        cboTop.TabIndex = 2
        ' 
        ' lblShowTop
        ' 
        lblShowTop.AutoSize = True
        lblShowTop.Location = New Point(109, 85)
        lblShowTop.Name = "lblShowTop"
        lblShowTop.Size = New Size(63, 15)
        lblShowTop.TabIndex = 1
        lblShowTop.Text = "Show TOP:"
        ' 
        ' btnCreateGrocery
        ' 
        btnCreateGrocery.Location = New Point(194, 46)
        btnCreateGrocery.Name = "btnCreateGrocery"
        btnCreateGrocery.Size = New Size(116, 30)
        btnCreateGrocery.TabIndex = 0
        btnCreateGrocery.Text = "CREATE REPORT"
        btnCreateGrocery.UseVisualStyleBackColor = True
        ' 
        ' grpMembers
        ' 
        grpMembers.BackColor = Color.Teal
        grpMembers.Controls.Add(Label2)
        grpMembers.Controls.Add(dgvMembers)
        grpMembers.Controls.Add(btnCreateMembers)
        grpMembers.Location = New Point(524, 136)
        grpMembers.Name = "grpMembers"
        grpMembers.Size = New Size(465, 391)
        grpMembers.TabIndex = 8
        grpMembers.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(105, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(257, 22)
        Label2.TabIndex = 2
        Label2.Text = "MEMBERS ACTIVITY REPORT"
        ' 
        ' dgvMembers
        ' 
        dgvMembers.AllowUserToAddRows = False
        dgvMembers.BackgroundColor = SystemColors.Control
        dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembers.Location = New Point(6, 111)
        dgvMembers.Name = "dgvMembers"
        dgvMembers.ReadOnly = True
        dgvMembers.Size = New Size(453, 274)
        dgvMembers.TabIndex = 1
        ' 
        ' btnCreateMembers
        ' 
        btnCreateMembers.Location = New Point(173, 46)
        btnCreateMembers.Name = "btnCreateMembers"
        btnCreateMembers.Size = New Size(110, 30)
        btnCreateMembers.TabIndex = 0
        btnCreateMembers.Text = "CREATE REPORT"
        btnCreateMembers.UseVisualStyleBackColor = True
        ' 
        ' frmMISReport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1011, 524)
        Controls.Add(grpMembers)
        Controls.Add(grpGrocery)
        Controls.Add(txtToDate)
        Controls.Add(txtFromDate)
        Controls.Add(lblTo)
        Controls.Add(lblFrom)
        Controls.Add(dtpToDate)
        Controls.Add(dtpFromDate)
        Controls.Add(lblTitle)
        Name = "frmMISReport"
        Text = "MIS REPORTS"
        grpGrocery.ResumeLayout(False)
        grpGrocery.PerformLayout()
        CType(dgvGrocery, ComponentModel.ISupportInitialize).EndInit()
        grpMembers.ResumeLayout(False)
        grpMembers.PerformLayout()
        CType(dgvMembers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents txtFromDate As TextBox
    Friend WithEvents txtToDate As TextBox
    Friend WithEvents grpGrocery As GroupBox
    Friend WithEvents btnCreateGrocery As Button
    Friend WithEvents cboLow As ComboBox
    Friend WithEvents lblShowLow As Label
    Friend WithEvents cboTop As ComboBox
    Friend WithEvents lblShowTop As Label
    Friend WithEvents dgvGrocery As DataGridView
    Friend WithEvents grpMembers As GroupBox
    Friend WithEvents btnCreateMembers As Button
    Friend WithEvents dgvMembers As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
