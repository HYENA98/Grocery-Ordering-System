Imports Microsoft.Data.SqlClient
Imports System.ComponentModel

Public Class frmCreateGroceryList

    ' Properties received from frmMembersOnly
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property MemberID As String = ""
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property MemberFullName As String = ""

    Private _totalQuantity As Integer = 0
    Private _totalPrice As Decimal = 0
    Private _isEditing As Boolean = False

    ' Form Load
    Private Sub frmCreateGroceryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sets the form title
        Me.Text = "Create Grocery List: " & MemberID & " " & MemberFullName

        ' Displays the currently open cutoff date
        txtCutoffDate.Text = GetCutoffFriday().ToString("yyyy/MM/dd") & " 00:00"

        lblMemberID.Text = MemberID
        lblMemberFullName.Text = MemberFullName

        ' Loads member's contact information
        LoadMemberContactInfo()

        ' Loads all available grocery items
        LoadAvailableItems()

        ' Initializes selected items grid
        InitializeSelectedItemsGrid()

        ' Loads existing order if one exists for the current open period
        LoadExistingOrder()

        ' Updates totals
        UpdateTotals()
    End Sub

    ' Get the cutoff Friday for the current open order period
    Private Function GetCutoffFriday() As Date
        Dim today As Date = Date.Today
        Dim daysUntilFriday As Integer = (DayOfWeek.Friday - today.DayOfWeek + 7) Mod 7
        If daysUntilFriday = 0 Then
            daysUntilFriday = 7
        End If
        Return today.AddDays(daysUntilFriday)
    End Function

    ' The period for the current order
    Private Function GetPeriodStart() As Date
        Return GetCutoffFriday().AddDays(-7)
    End Function

    ' Loads member contact info
    Private Sub LoadMemberContactInfo()
        Dim query As String = "SELECT Contact, Email FROM dbo.tblMembers WHERE MemberID = @MemberID"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@MemberID", MemberID)

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    lblCellphone.Text = "Cellphone: " & If(reader("Contact") Is DBNull.Value, "N/A", reader("Contact").ToString())
                    lblEmail.Text = "Email: " & If(reader("Email") Is DBNull.Value, "N/A", reader("Email").ToString())
                End If

                reader.Close()
            End Using
        End Using
    End Sub

    ' Loads all available grocery items into dgv
    Private Sub LoadAvailableItems()
        Dim query As String = "SELECT ItemID, Description, Price, Image FROM dbo.tblGroceryItems WHERE Available = 'Y' ORDER BY Description"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvAvailableItems.DataSource = table
            End Using
        End Using

        If dgvAvailableItems.Columns.Count > 0 Then
            dgvAvailableItems.Columns("ItemID").HeaderText = "Item ID"
            dgvAvailableItems.Columns("Description").HeaderText = "Description"
            dgvAvailableItems.Columns("Price").HeaderText = "Price (R)"
            dgvAvailableItems.Columns("Image").HeaderText = "Image"
            dgvAvailableItems.Columns("Image").Visible = False
            dgvAvailableItems.AutoResizeColumns()
        End If
    End Sub

    ' Loads filtered available items based on search
    Private Sub LoadAvailableItems(searchTerm As String)
        Dim query As String = "SELECT ItemID, Description, Price, Image FROM dbo.tblGroceryItems " &
                              "WHERE Available = 'Y' AND Description LIKE @Search ORDER BY Description"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Search", "%" & searchTerm & "%")
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvAvailableItems.DataSource = table
            End Using
        End Using

        If dgvAvailableItems.Columns.Count > 0 Then
            dgvAvailableItems.Columns("ItemID").HeaderText = "Item ID"
            dgvAvailableItems.Columns("Description").HeaderText = "Description"
            dgvAvailableItems.Columns("Price").HeaderText = "Price (R)"
            dgvAvailableItems.Columns("Image").HeaderText = "Image"
            dgvAvailableItems.Columns("Image").Visible = False
            dgvAvailableItems.AutoResizeColumns()
        End If
    End Sub

    ' Initializes the selected items grid
    Private Sub InitializeSelectedItemsGrid()
        Dim table As New DataTable()
        table.Columns.Add("ItemID", GetType(String))
        table.Columns.Add("Description", GetType(String))
        table.Columns.Add("Price", GetType(Decimal))
        table.Columns.Add("Qty", GetType(Integer))
        table.Columns.Add("Total", GetType(Decimal))

        dgvSelectedItems.DataSource = table
        dgvSelectedItems.ReadOnly = True
        dgvSelectedItems.AllowUserToAddRows = False
        dgvSelectedItems.AllowUserToDeleteRows = False
        dgvSelectedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSelectedItems.MultiSelect = False

        dgvSelectedItems.Columns("ItemID").HeaderText = "Item ID"
        dgvSelectedItems.Columns("Description").HeaderText = "Description"
        dgvSelectedItems.Columns("Price").HeaderText = "Price (R)"
        dgvSelectedItems.Columns("Qty").HeaderText = "Qty"
        dgvSelectedItems.Columns("Total").HeaderText = "Total (R)"
        dgvSelectedItems.AutoResizeColumns()
    End Sub

    ' Loads existing order for the member for the current open period
    Private Sub LoadExistingOrder()
        Dim periodStart As Date = GetPeriodStart()
        Dim periodEnd As Date = GetCutoffFriday()

        Dim query As String = "SELECT o.ItemID, gi.Description, gi.Price, o.Quantity " &
                              "FROM dbo.tblMemberOrders o " &
                              "INNER JOIN dbo.tblGroceryItems gi ON o.ItemID = gi.ItemID " &
                              "WHERE o.MemberID = @MemberID " &
                              "AND CAST(o.OrderDate AS DATE) >= @PeriodStart " &
                              "AND CAST(o.OrderDate AS DATE) < @PeriodEnd " &
                              "ORDER BY gi.Description"

        Dim table As New DataTable()
        table.Columns.Add("ItemID", GetType(String))
        table.Columns.Add("Description", GetType(String))
        table.Columns.Add("Price", GetType(Decimal))
        table.Columns.Add("Qty", GetType(Integer))
        table.Columns.Add("Total", GetType(Decimal))

        Dim rowsFound As Integer = 0

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@MemberID", MemberID)
                cmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                For Each row As DataRow In dt.Rows
                    Dim newRow As DataRow = table.NewRow()
                    newRow("ItemID") = row("ItemID").ToString()
                    newRow("Description") = row("Description").ToString()
                    newRow("Price") = Convert.ToDecimal(row("Price"))
                    newRow("Qty") = Convert.ToInt32(row("Quantity"))
                    newRow("Total") = Convert.ToDecimal(row("Price")) * Convert.ToInt32(row("Quantity"))
                    table.Rows.Add(newRow)
                    rowsFound += 1
                Next
            End Using
        End Using

        dgvSelectedItems.DataSource = table
        UpdateTotals()
        _isEditing = (rowsFound > 0)
    End Sub

    ' When user clicks an item in available items grid
    Private Sub dgvAvailableItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailableItems.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim selectedRow As DataGridViewRow = dgvAvailableItems.Rows(e.RowIndex)
        Dim itemID As String = selectedRow.Cells("ItemID").Value.ToString()
        Dim description As String = selectedRow.Cells("Description").Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(selectedRow.Cells("Price").Value)
        Dim imagePath As String = If(selectedRow.Cells("Image").Value Is DBNull.Value, "", selectedRow.Cells("Image").Value.ToString())

        LoadItemImage(imagePath)

        ' quantity input form
        Dim qtyForm As New frmQuantityInput()
        qtyForm.ItemDescription = description
        qtyForm.ShowDialog()

        If qtyForm.DialogResult = DialogResult.OK AndAlso qtyForm.Quantity > 0 Then
            AddItemToSelectedList(itemID, description, price, qtyForm.Quantity)
        End If
    End Sub

    ' Loads an item image into picGroceryItem
    Private Sub LoadItemImage(imagePath As String)
        ' Clears the picturebox
        If picGroceryItem.Image IsNot Nothing Then
            picGroceryItem.Image.Dispose()
            picGroceryItem.Image = Nothing
        End If

        If String.IsNullOrWhiteSpace(imagePath) Then
            Return
        End If

        Dim resolvedPath As String = imagePath.Trim()

        If Not System.IO.Path.IsPathRooted(resolvedPath) Then
            resolvedPath = System.IO.Path.Combine(Application.StartupPath, resolvedPath)
        End If

        If Not System.IO.File.Exists(resolvedPath) Then
            Return
        End If

        Try
            ' Read the file into memory first to avoid locking it on disk
            Dim bytes As Byte() = System.IO.File.ReadAllBytes(resolvedPath)
            Using ms As New System.IO.MemoryStream(bytes)
                picGroceryItem.Image = Image.FromStream(ms)
            End Using
        Catch
            picGroceryItem.Image = Nothing
        End Try
    End Sub

    ' Adds item to the selected items grid
    Private Sub AddItemToSelectedList(itemID As String, description As String, price As Decimal, qty As Integer)
        Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)

        For Each row As DataRow In table.Rows
            If row("ItemID").ToString() = itemID Then
                ' if Item already exists – increase quantity
                Dim existingQty As Integer = Convert.ToInt32(row("Qty"))
                Dim newQty As Integer = existingQty + qty

                ' not more than 12 items
                If newQty > 12 Then
                    MessageBox.Show("You cannot order more than 12 of the same item. Current quantity: " & existingQty,
                                    "Quantity Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Total limit
                Dim otherTotal As Integer = GetTotalSelectedQuantity() - existingQty
                If otherTotal + newQty > 12 Then
                    MessageBox.Show("Total items cannot exceed 12. You currently have " & otherTotal & " other items.",
                                    "Maximum Items Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Updates the row
                row("Qty") = newQty
                row("Total") = price * newQty
                UpdateTotals()
                Return
            End If
        Next

        ' New item – checks total limit
        Dim currentTotal As Integer = GetTotalSelectedQuantity()
        If currentTotal + qty > 12 Then
            MessageBox.Show("You can only select a maximum of 12 items in total. You currently have " & currentTotal & " items.",
                            "Maximum Items Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Adds the new row
        Dim newRow As DataRow = table.NewRow()
        newRow("ItemID") = itemID
        newRow("Description") = description
        newRow("Price") = price
        newRow("Qty") = qty
        newRow("Total") = price * qty
        table.Rows.Add(newRow)

        UpdateTotals()
    End Sub

    ' Adjusts Quantity button click
    Private Sub btnAdjustQty_Click(sender As Object, e As EventArgs) Handles btnAdjustQty.Click
        If dgvSelectedItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to adjust.", "No Item Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvSelectedItems.SelectedRows(0)
        Dim itemID As String = selectedRow.Cells("ItemID").Value.ToString()
        Dim description As String = selectedRow.Cells("Description").Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(selectedRow.Cells("Price").Value)
        Dim currentQty As Integer = Convert.ToInt32(selectedRow.Cells("Qty").Value)

        ' Opens quantity input form with current quantity
        Dim qtyForm As New frmQuantityInput()
        qtyForm.ItemDescription = description
        qtyForm.txtQuantity.Text = currentQty.ToString()
        qtyForm.ShowDialog()

        If qtyForm.DialogResult = DialogResult.OK AndAlso qtyForm.Quantity > 0 Then
            Dim newQty As Integer = qtyForm.Quantity

            ' Per-item limit
            If newQty > 12 Then
                MessageBox.Show("You cannot order more than 12 of the same item.",
                                "Quantity Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Total limit
            Dim otherTotal As Integer = GetTotalSelectedQuantity() - currentQty
            If otherTotal + newQty > 12 Then
                MessageBox.Show("Total items cannot exceed 12. You currently have " & otherTotal & " other items.",
                                "Maximum Items Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Updates the selected row
            Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)
            Dim rowIndex As Integer = selectedRow.Index
            table.Rows(rowIndex)("Qty") = newQty
            table.Rows(rowIndex)("Total") = price * newQty

            ' Refreshes the grid
            dgvSelectedItems.Refresh()
            UpdateTotals()
        End If
    End Sub

    ' Calculates total quantity of all selected items
    Private Function GetTotalSelectedQuantity() As Integer
        Dim total As Integer = 0
        Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)
        For Each row As DataRow In table.Rows
            total += Convert.ToInt32(row("Qty"))
        Next
        Return total
    End Function

    ' Updates the totals display
    Private Sub UpdateTotals()
        _totalQuantity = GetTotalSelectedQuantity()
        _totalPrice = 0
        Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)
        For Each row As DataRow In table.Rows
            _totalPrice += Convert.ToDecimal(row("Total"))
        Next
        txtItemCount.Text = _totalQuantity.ToString()
        txtTotalPrice.Text = _totalPrice.ToString("F2")
    End Sub

    ' Removes selected row from the grid
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvSelectedItems.SelectedRows.Count > 0 Then
            Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)
            Dim rowIndex As Integer = dgvSelectedItems.SelectedRows(0).Index
            table.Rows.RemoveAt(rowIndex)
            UpdateTotals()
        Else
            MessageBox.Show("Please select an item to remove.", "No Item Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Search button
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadAvailableItems()
        Else
            LoadAvailableItems(txtSearch.Text.Trim())
        End If
    End Sub

    ' DONE button
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If GetTotalSelectedQuantity() = 0 Then
            MessageBox.Show("Please select at least one item before completing your order.",
                            "No Items Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        SaveOrder()

        If _isEditing Then
            MessageBox.Show("Your changes have been saved!",
                            "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Your order has been submitted successfully! You may return before the cutoff to edit it.",
                            "Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Close()
    End Sub

    ' Save the order to the database
    Private Sub SaveOrder()
        Dim orderDate As Date = Date.Today
        Dim periodStart As Date = GetPeriodStart()
        Dim periodEnd As Date = GetCutoffFriday()
        Dim table As DataTable = DirectCast(dgvSelectedItems.DataSource, DataTable)

        Using conn As SqlConnection = GModDatabase.GetConnection()
            ' Deletes existing orders for this member and period
            Dim deleteQuery As String = "DELETE FROM dbo.tblMemberOrders " &
                                        "WHERE MemberID = @MemberID " &
                                        "AND CAST(OrderDate AS DATE) >= @PeriodStart " &
                                        "AND CAST(OrderDate AS DATE) < @PeriodEnd"
            Using deleteCmd As New SqlCommand(deleteQuery, conn)
                deleteCmd.Parameters.AddWithValue("@MemberID", MemberID)
                deleteCmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                deleteCmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)
                deleteCmd.ExecuteNonQuery()
            End Using

            ' Inserts new orders from the grid
            For Each row As DataRow In table.Rows
                Dim insertQuery As String = "INSERT INTO dbo.tblMemberOrders (MemberID, ItemID, OrderDate, Quantity) " &
                                            "VALUES (@MemberID, @ItemID, @OrderDate, @Quantity)"
                Using insertCmd As New SqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@MemberID", MemberID)
                    insertCmd.Parameters.AddWithValue("@ItemID", row("ItemID").ToString())
                    insertCmd.Parameters.AddWithValue("@OrderDate", orderDate)
                    insertCmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(row("Qty")))
                    insertCmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub

End Class