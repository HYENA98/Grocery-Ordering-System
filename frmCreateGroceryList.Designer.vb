<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateGroceryList
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
        lblGroceryOrderFor = New Label()
        txtCutoffDate = New TextBox()
        lblCellphone = New Label()
        lblEmail = New Label()
        picGroceryItem = New PictureBox()
        txtSearch = New TextBox()
        btnSearch = New Button()
        dgvAvailableItems = New DataGridView()
        lblMyList = New Label()
        lblMemberID = New Label()
        lblMemberFullName = New Label()
        lblNumberOfItems = New Label()
        txtItemCount = New TextBox()
        lblRand = New Label()
        txtTotalPrice = New TextBox()
        dgvSelectedItems = New DataGridView()
        btnDone = New Button()
        btnRemoveItem = New Button()
        btnAdjustQty = New Button()
        CType(picGroceryItem, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAvailableItems, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvSelectedItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblGroceryOrderFor
        ' 
        lblGroceryOrderFor.AutoSize = True
        lblGroceryOrderFor.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGroceryOrderFor.Location = New Point(29, 27)
        lblGroceryOrderFor.Name = "lblGroceryOrderFor"
        lblGroceryOrderFor.Size = New Size(124, 17)
        lblGroceryOrderFor.TabIndex = 0
        lblGroceryOrderFor.Text = "Grocery Order For:"
        ' 
        ' txtCutoffDate
        ' 
        txtCutoffDate.BackColor = SystemColors.ControlDark
        txtCutoffDate.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCutoffDate.Location = New Point(159, 26)
        txtCutoffDate.Name = "txtCutoffDate"
        txtCutoffDate.ReadOnly = True
        txtCutoffDate.Size = New Size(143, 22)
        txtCutoffDate.TabIndex = 1
        ' 
        ' lblCellphone
        ' 
        lblCellphone.AutoSize = True
        lblCellphone.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCellphone.ForeColor = SystemColors.ActiveCaptionText
        lblCellphone.Location = New Point(29, 77)
        lblCellphone.Name = "lblCellphone"
        lblCellphone.Size = New Size(0, 17)
        lblCellphone.TabIndex = 2
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = SystemColors.ActiveCaptionText
        lblEmail.Location = New Point(29, 110)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(0, 17)
        lblEmail.TabIndex = 3
        ' 
        ' picGroceryItem
        ' 
        picGroceryItem.BorderStyle = BorderStyle.FixedSingle
        picGroceryItem.Location = New Point(324, 47)
        picGroceryItem.Name = "picGroceryItem"
        picGroceryItem.Size = New Size(131, 121)
        picGroceryItem.SizeMode = PictureBoxSizeMode.StretchImage
        picGroceryItem.TabIndex = 4
        picGroceryItem.TabStop = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(29, 145)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(155, 23)
        txtSearch.TabIndex = 5
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(202, 145)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(100, 23)
        btnSearch.TabIndex = 6
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dgvAvailableItems
        ' 
        dgvAvailableItems.AllowUserToAddRows = False
        dgvAvailableItems.AllowUserToDeleteRows = False
        dgvAvailableItems.BackgroundColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        dgvAvailableItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAvailableItems.Location = New Point(29, 174)
        dgvAvailableItems.MultiSelect = False
        dgvAvailableItems.Name = "dgvAvailableItems"
        dgvAvailableItems.ReadOnly = True
        dgvAvailableItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAvailableItems.Size = New Size(354, 339)
        dgvAvailableItems.TabIndex = 7
        ' 
        ' lblMyList
        ' 
        lblMyList.AutoSize = True
        lblMyList.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMyList.Location = New Point(471, 90)
        lblMyList.Name = "lblMyList"
        lblMyList.Size = New Size(57, 17)
        lblMyList.TabIndex = 8
        lblMyList.Text = "My List:"
        ' 
        ' lblMemberID
        ' 
        lblMemberID.AutoSize = True
        lblMemberID.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMemberID.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblMemberID.Location = New Point(552, 77)
        lblMemberID.Name = "lblMemberID"
        lblMemberID.Size = New Size(0, 18)
        lblMemberID.TabIndex = 9
        ' 
        ' lblMemberFullName
        ' 
        lblMemberFullName.AutoSize = True
        lblMemberFullName.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMemberFullName.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblMemberFullName.Location = New Point(552, 110)
        lblMemberFullName.Name = "lblMemberFullName"
        lblMemberFullName.Size = New Size(0, 18)
        lblMemberFullName.TabIndex = 10
        ' 
        ' lblNumberOfItems
        ' 
        lblNumberOfItems.AutoSize = True
        lblNumberOfItems.Location = New Point(497, 153)
        lblNumberOfItems.Name = "lblNumberOfItems"
        lblNumberOfItems.Size = New Size(102, 15)
        lblNumberOfItems.TabIndex = 11
        lblNumberOfItems.Text = "Number Of Items:"
        ' 
        ' txtItemCount
        ' 
        txtItemCount.BackColor = SystemColors.ButtonHighlight
        txtItemCount.Location = New Point(605, 150)
        txtItemCount.Name = "txtItemCount"
        txtItemCount.ReadOnly = True
        txtItemCount.Size = New Size(95, 23)
        txtItemCount.TabIndex = 12
        ' 
        ' lblRand
        ' 
        lblRand.AutoSize = True
        lblRand.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRand.Location = New Point(719, 151)
        lblRand.Name = "lblRand"
        lblRand.Size = New Size(16, 17)
        lblRand.TabIndex = 13
        lblRand.Text = "R"
        ' 
        ' txtTotalPrice
        ' 
        txtTotalPrice.BackColor = SystemColors.ButtonHighlight
        txtTotalPrice.Location = New Point(741, 150)
        txtTotalPrice.Name = "txtTotalPrice"
        txtTotalPrice.ReadOnly = True
        txtTotalPrice.Size = New Size(100, 23)
        txtTotalPrice.TabIndex = 14
        ' 
        ' dgvSelectedItems
        ' 
        dgvSelectedItems.AllowUserToAddRows = False
        dgvSelectedItems.AllowUserToDeleteRows = False
        dgvSelectedItems.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        dgvSelectedItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSelectedItems.Location = New Point(471, 179)
        dgvSelectedItems.MultiSelect = False
        dgvSelectedItems.Name = "dgvSelectedItems"
        dgvSelectedItems.ReadOnly = True
        dgvSelectedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSelectedItems.Size = New Size(408, 289)
        dgvSelectedItems.TabIndex = 15
        ' 
        ' btnDone
        ' 
        btnDone.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDone.Location = New Point(677, 487)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(111, 26)
        btnDone.TabIndex = 16
        btnDone.Text = "DONE"
        btnDone.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.Location = New Point(847, 136)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(102, 38)
        btnRemoveItem.TabIndex = 17
        btnRemoveItem.Text = "Remove Selected Item"
        btnRemoveItem.UseVisualStyleBackColor = True
        ' 
        ' btnAdjustQty
        ' 
        btnAdjustQty.Location = New Point(847, 90)
        btnAdjustQty.Name = "btnAdjustQty"
        btnAdjustQty.Size = New Size(102, 37)
        btnAdjustQty.TabIndex = 18
        btnAdjustQty.Text = "Adjust Quantity"
        btnAdjustQty.UseVisualStyleBackColor = True
        ' 
        ' frmCreateGroceryList
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(961, 525)
        Controls.Add(btnAdjustQty)
        Controls.Add(btnRemoveItem)
        Controls.Add(btnDone)
        Controls.Add(dgvSelectedItems)
        Controls.Add(txtTotalPrice)
        Controls.Add(lblRand)
        Controls.Add(txtItemCount)
        Controls.Add(lblNumberOfItems)
        Controls.Add(lblMemberFullName)
        Controls.Add(lblMemberID)
        Controls.Add(lblMyList)
        Controls.Add(dgvAvailableItems)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(picGroceryItem)
        Controls.Add(lblEmail)
        Controls.Add(lblCellphone)
        Controls.Add(txtCutoffDate)
        Controls.Add(lblGroceryOrderFor)
        Name = "frmCreateGroceryList"
        Text = "Create Grocery List:"
        CType(picGroceryItem, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAvailableItems, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvSelectedItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblGroceryOrderFor As Label
    Friend WithEvents txtCutoffDate As TextBox
    Friend WithEvents lblCellphone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents picGroceryItem As PictureBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgvAvailableItems As DataGridView
    Friend WithEvents lblMyList As Label
    Friend WithEvents lblMemberID As Label
    Friend WithEvents lblMemberFullName As Label
    Friend WithEvents lblNumberOfItems As Label
    Friend WithEvents txtItemCount As TextBox
    Friend WithEvents lblRand As Label
    Friend WithEvents txtTotalPrice As TextBox
    Friend WithEvents dgvSelectedItems As DataGridView
    Friend WithEvents btnDone As Button
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnAdjustQty As Button
End Class
