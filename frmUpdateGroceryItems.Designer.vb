<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateGroceryItems
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
        dgvGroceryItems = New DataGridView()
        lblTitle = New Label()
        lblItemId = New Label()
        lblDescription = New Label()
        lblPrice = New Label()
        lblImageLink = New Label()
        lblGroceryList = New Label()
        mtbItemId = New MaskedTextBox()
        txtDescription = New TextBox()
        txtPrice = New TextBox()
        txtImageLink = New TextBox()
        btnAddNew = New Button()
        btnUpdate = New Button()
        btnSearch = New Button()
        txtSearch = New TextBox()
        radYes = New RadioButton()
        radNo = New RadioButton()
        lblAvailable = New Label()
        CType(dgvGroceryItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvGroceryItems
        ' 
        dgvGroceryItems.AllowUserToAddRows = False
        dgvGroceryItems.AllowUserToDeleteRows = False
        dgvGroceryItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvGroceryItems.Location = New Point(26, 283)
        dgvGroceryItems.Margin = New Padding(3, 4, 3, 4)
        dgvGroceryItems.MultiSelect = False
        dgvGroceryItems.Name = "dgvGroceryItems"
        dgvGroceryItems.ReadOnly = True
        dgvGroceryItems.RowHeadersWidth = 51
        dgvGroceryItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvGroceryItems.Size = New Size(1009, 415)
        dgvGroceryItems.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(29, 12)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(395, 28)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Update Existing Items in the Grocery List"
        ' 
        ' lblItemId
        ' 
        lblItemId.AutoSize = True
        lblItemId.Location = New Point(29, 76)
        lblItemId.Name = "lblItemId"
        lblItemId.Size = New Size(52, 20)
        lblItemId.TabIndex = 2
        lblItemId.Text = "ItemId"
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Location = New Point(192, 75)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(85, 20)
        lblDescription.TabIndex = 3
        lblDescription.Text = "Description"
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Location = New Point(456, 76)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(41, 20)
        lblPrice.TabIndex = 4
        lblPrice.Text = "Price"
        ' 
        ' lblImageLink
        ' 
        lblImageLink.AutoSize = True
        lblImageLink.Location = New Point(872, 75)
        lblImageLink.Name = "lblImageLink"
        lblImageLink.Size = New Size(99, 20)
        lblImageLink.TabIndex = 5
        lblImageLink.Text = "Link to Image"
        ' 
        ' lblGroceryList
        ' 
        lblGroceryList.AutoSize = True
        lblGroceryList.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblGroceryList.Location = New Point(26, 243)
        lblGroceryList.Name = "lblGroceryList"
        lblGroceryList.Size = New Size(159, 28)
        lblGroceryList.TabIndex = 6
        lblGroceryList.Text = "List Of Groceries"
        ' 
        ' mtbItemId
        ' 
        mtbItemId.Location = New Point(29, 99)
        mtbItemId.Margin = New Padding(3, 4, 3, 4)
        mtbItemId.Name = "mtbItemId"
        mtbItemId.ReadOnly = True
        mtbItemId.Size = New Size(114, 27)
        mtbItemId.TabIndex = 7
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(195, 101)
        txtDescription.Margin = New Padding(3, 4, 3, 4)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(221, 85)
        txtDescription.TabIndex = 8
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(459, 105)
        txtPrice.Margin = New Padding(3, 4, 3, 4)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(91, 27)
        txtPrice.TabIndex = 9
        ' 
        ' txtImageLink
        ' 
        txtImageLink.Location = New Point(878, 103)
        txtImageLink.Margin = New Padding(3, 4, 3, 4)
        txtImageLink.Name = "txtImageLink"
        txtImageLink.Size = New Size(157, 27)
        txtImageLink.TabIndex = 10
        ' 
        ' btnAddNew
        ' 
        btnAddNew.Location = New Point(878, 141)
        btnAddNew.Margin = New Padding(3, 4, 3, 4)
        btnAddNew.Name = "btnAddNew"
        btnAddNew.Size = New Size(121, 31)
        btnAddNew.TabIndex = 11
        btnAddNew.Text = "Add New Item"
        btnAddNew.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(878, 180)
        btnUpdate.Margin = New Padding(3, 4, 3, 4)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(121, 31)
        btnUpdate.TabIndex = 12
        btnUpdate.Text = "Update Item"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(405, 240)
        btnSearch.Margin = New Padding(3, 4, 3, 4)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(86, 31)
        btnSearch.TabIndex = 13
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(232, 239)
        txtSearch.Margin = New Padding(3, 4, 3, 4)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(165, 27)
        txtSearch.TabIndex = 14
        ' 
        ' radYes
        ' 
        radYes.AutoSize = True
        radYes.Location = New Point(693, 111)
        radYes.Margin = New Padding(3, 4, 3, 4)
        radYes.Name = "radYes"
        radYes.Size = New Size(54, 24)
        radYes.TabIndex = 15
        radYes.TabStop = True
        radYes.Text = "YES"
        radYes.UseVisualStyleBackColor = True
        ' 
        ' radNo
        ' 
        radNo.AutoSize = True
        radNo.Location = New Point(693, 144)
        radNo.Margin = New Padding(3, 4, 3, 4)
        radNo.Name = "radNo"
        radNo.Size = New Size(52, 24)
        radNo.TabIndex = 16
        radNo.TabStop = True
        radNo.Text = "NO"
        radNo.UseVisualStyleBackColor = True
        ' 
        ' lblAvailable
        ' 
        lblAvailable.AutoSize = True
        lblAvailable.Location = New Point(693, 75)
        lblAvailable.Name = "lblAvailable"
        lblAvailable.Size = New Size(71, 20)
        lblAvailable.TabIndex = 17
        lblAvailable.Text = "Available"
        ' 
        ' frmUpdateGroceryItems
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1075, 748)
        Controls.Add(lblItemId)
        Controls.Add(lblAvailable)
        Controls.Add(radNo)
        Controls.Add(radYes)
        Controls.Add(txtSearch)
        Controls.Add(btnSearch)
        Controls.Add(btnUpdate)
        Controls.Add(btnAddNew)
        Controls.Add(txtImageLink)
        Controls.Add(txtPrice)
        Controls.Add(txtDescription)
        Controls.Add(mtbItemId)
        Controls.Add(lblGroceryList)
        Controls.Add(lblImageLink)
        Controls.Add(lblPrice)
        Controls.Add(lblDescription)
        Controls.Add(lblTitle)
        Controls.Add(dgvGroceryItems)
        Margin = New Padding(3, 4, 3, 4)
        Name = "frmUpdateGroceryItems"
        Text = "Update Grocery Items"
        CType(dgvGroceryItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvGroceryItems As DataGridView
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblItemId As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblImageLink As Label
    Friend WithEvents lblGroceryList As Label
    Friend WithEvents mtbItemId As MaskedTextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtImageLink As TextBox
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents radYes As RadioButton
    Friend WithEvents radNo As RadioButton
    Friend WithEvents lblAvailable As Label
End Class
