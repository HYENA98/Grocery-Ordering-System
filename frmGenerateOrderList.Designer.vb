<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateOrderList
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
        lblGenerateWeek = New Label()
        txtCutoffDate = New TextBox()
        txtGrandTotal = New TextBox()
        lblRand = New Label()
        btnShow = New Button()
        calOrderDate = New MonthCalendar()
        btnCreatePDFBulk = New Button()
        btnViewIndividual = New Button()
        btnGeneratePDFIndividual = New Button()
        dgvCombinedList = New DataGridView()
        dgvIndividualOrders = New DataGridView()
        CType(dgvCombinedList, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvIndividualOrders, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblGenerateWeek
        ' 
        lblGenerateWeek.AutoSize = True
        lblGenerateWeek.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGenerateWeek.Location = New Point(114, 23)
        lblGenerateWeek.Name = "lblGenerateWeek"
        lblGenerateWeek.Size = New Size(199, 17)
        lblGenerateWeek.TabIndex = 0
        lblGenerateWeek.Text = "Generate Combined List Week:"
        ' 
        ' txtCutoffDate
        ' 
        txtCutoffDate.Location = New Point(319, 22)
        txtCutoffDate.Name = "txtCutoffDate"
        txtCutoffDate.ReadOnly = True
        txtCutoffDate.Size = New Size(155, 23)
        txtCutoffDate.TabIndex = 1
        ' 
        ' txtGrandTotal
        ' 
        txtGrandTotal.Location = New Point(398, 121)
        txtGrandTotal.Name = "txtGrandTotal"
        txtGrandTotal.ReadOnly = True
        txtGrandTotal.Size = New Size(76, 23)
        txtGrandTotal.TabIndex = 2
        txtGrandTotal.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblRand
        ' 
        lblRand.AutoSize = True
        lblRand.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRand.Location = New Point(367, 127)
        lblRand.Name = "lblRand"
        lblRand.Size = New Size(16, 17)
        lblRand.TabIndex = 3
        lblRand.Text = "R"
        ' 
        ' btnShow
        ' 
        btnShow.Location = New Point(346, 63)
        btnShow.Name = "btnShow"
        btnShow.Size = New Size(109, 35)
        btnShow.TabIndex = 4
        btnShow.Text = "Show"
        btnShow.UseVisualStyleBackColor = True
        ' 
        ' calOrderDate
        ' 
        calOrderDate.Location = New Point(486, 22)
        calOrderDate.Name = "calOrderDate"
        calOrderDate.TabIndex = 5
        ' 
        ' btnCreatePDFBulk
        ' 
        btnCreatePDFBulk.Location = New Point(525, 207)
        btnCreatePDFBulk.Name = "btnCreatePDFBulk"
        btnCreatePDFBulk.Size = New Size(154, 56)
        btnCreatePDFBulk.TabIndex = 6
        btnCreatePDFBulk.Text = "Create PDF (for bulk buy)"
        btnCreatePDFBulk.UseVisualStyleBackColor = True
        ' 
        ' btnViewIndividual
        ' 
        btnViewIndividual.Location = New Point(525, 295)
        btnViewIndividual.Name = "btnViewIndividual"
        btnViewIndividual.Size = New Size(154, 56)
        btnViewIndividual.TabIndex = 7
        btnViewIndividual.Text = "View Individual Orders"
        btnViewIndividual.UseVisualStyleBackColor = True
        ' 
        ' btnGeneratePDFIndividual
        ' 
        btnGeneratePDFIndividual.Location = New Point(525, 384)
        btnGeneratePDFIndividual.Name = "btnGeneratePDFIndividual"
        btnGeneratePDFIndividual.Size = New Size(154, 56)
        btnGeneratePDFIndividual.TabIndex = 8
        btnGeneratePDFIndividual.Text = "Generate PDFs for Individual Orders"
        btnGeneratePDFIndividual.UseVisualStyleBackColor = True
        ' 
        ' dgvCombinedList
        ' 
        dgvCombinedList.AllowUserToAddRows = False
        dgvCombinedList.AllowUserToDeleteRows = False
        dgvCombinedList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCombinedList.Location = New Point(38, 161)
        dgvCombinedList.Name = "dgvCombinedList"
        dgvCombinedList.ReadOnly = True
        dgvCombinedList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCombinedList.Size = New Size(436, 359)
        dgvCombinedList.TabIndex = 9
        ' 
        ' dgvIndividualOrders
        ' 
        dgvIndividualOrders.AllowUserToAddRows = False
        dgvIndividualOrders.AllowUserToDeleteRows = False
        dgvIndividualOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvIndividualOrders.GridColor = SystemColors.ScrollBar
        dgvIndividualOrders.Location = New Point(725, 161)
        dgvIndividualOrders.Name = "dgvIndividualOrders"
        dgvIndividualOrders.ReadOnly = True
        dgvIndividualOrders.Size = New Size(424, 359)
        dgvIndividualOrders.TabIndex = 10
        ' 
        ' frmGenerateOrderList
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1161, 611)
        Controls.Add(dgvIndividualOrders)
        Controls.Add(dgvCombinedList)
        Controls.Add(btnGeneratePDFIndividual)
        Controls.Add(btnViewIndividual)
        Controls.Add(btnCreatePDFBulk)
        Controls.Add(calOrderDate)
        Controls.Add(btnShow)
        Controls.Add(lblRand)
        Controls.Add(txtGrandTotal)
        Controls.Add(txtCutoffDate)
        Controls.Add(lblGenerateWeek)
        Name = "frmGenerateOrderList"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Generate This Week's Grocery List"
        CType(dgvCombinedList, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvIndividualOrders, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblGenerateWeek As Label
    Friend WithEvents txtCutoffDate As TextBox
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents lblRand As Label
    Friend WithEvents btnShow As Button
    Friend WithEvents calOrderDate As MonthCalendar
    Friend WithEvents btnCreatePDFBulk As Button
    Friend WithEvents btnViewIndividual As Button
    Friend WithEvents btnGeneratePDFIndividual As Button
    Friend WithEvents dgvCombinedList As DataGridView
    Friend WithEvents dgvIndividualOrders As DataGridView
End Class
