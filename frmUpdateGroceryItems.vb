Imports Microsoft.Data.SqlClient

Public Class frmUpdateGroceryItems

    ' --- Form Load ---
    Private Sub frmUpdateGroceryItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGroceryItems()
        ClearInputFields()
    End Sub

    ' --- Load all items ---
    Private Sub LoadGroceryItems()
        Dim query As String = "SELECT ItemId, Description, Price, Image, Available FROM dbo.tblGroceryItems ORDER BY ItemId"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvGroceryItems.DataSource = table
            End Using
        End Using

        If dgvGroceryItems.Columns.Count > 0 Then
            dgvGroceryItems.Columns("ItemId").HeaderText = "Item ID"
            dgvGroceryItems.Columns("Description").HeaderText = "Description"
            dgvGroceryItems.Columns("Price").HeaderText = "Price"
            dgvGroceryItems.Columns("Image").HeaderText = "Image"
            dgvGroceryItems.Columns("Available").HeaderText = "Available"
            dgvGroceryItems.AutoResizeColumns()
        End If
    End Sub

    ' --- Load filtered items ---
    Private Sub LoadGroceryItems(searchTerm As String)
        Dim query As String = "SELECT ItemId, Description, Price, Image, Available " &
                              "FROM dbo.tblGroceryItems " &
                              "WHERE Description LIKE @Search " &
                              "ORDER BY ItemId"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Search", "%" & searchTerm & "%")
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvGroceryItems.DataSource = table
            End Using
        End Using
    End Sub

    ' --- Selection changed in DataGridView ---
    Private Sub dgvGroceryItems_SelectionChanged(sender As Object, e As EventArgs) Handles dgvGroceryItems.SelectionChanged
        If dgvGroceryItems.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvGroceryItems.SelectedRows(0)

            mtbItemId.Text = selectedRow.Cells("ItemId").Value.ToString()
            txtDescription.Text = selectedRow.Cells("Description").Value.ToString()
            txtPrice.Text = selectedRow.Cells("Price").Value.ToString()
            txtImageLink.Text = selectedRow.Cells("Image").Value.ToString()

            If selectedRow.Cells("Available").Value IsNot DBNull.Value Then
                If selectedRow.Cells("Available").Value.ToString().ToUpper() = "Y" Then
                    radYes.Checked = True
                Else
                    radNo.Checked = True
                End If
            Else
                radYes.Checked = False
                radNo.Checked = False
            End If
        End If
    End Sub

    ' --- Clear input fields ---
    Private Sub ClearInputFields()
        mtbItemId.Clear()
        txtDescription.Clear()
        txtPrice.Clear()
        txtImageLink.Clear()
        radYes.Checked = False
        radNo.Checked = False
        dgvGroceryItems.ClearSelection()
        txtDescription.Focus()
    End Sub

    ' --- Validate input ---
    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Description is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return False
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price < 0 Then
            MessageBox.Show("Please enter a valid price.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If

        If radYes.Checked = False AndAlso radNo.Checked = False Then
            MessageBox.Show("Please select whether the item is available.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' --- Add new item ---
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If Not ValidateInput() Then Exit Sub

        Dim query As String = "INSERT INTO dbo.tblGroceryItems (Description, Price, Image, Available) " &
                              "VALUES (@Description, @Price, @Image, @Available)"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@Price", Decimal.Parse(txtPrice.Text))
                cmd.Parameters.AddWithValue("@Image", txtImageLink.Text.Trim())

                If radYes.Checked Then
                    cmd.Parameters.AddWithValue("@Available", "Y")
                Else
                    cmd.Parameters.AddWithValue("@Available", "N")
                End If

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Item added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadGroceryItems()
        ClearInputFields()
    End Sub

    ' --- Update item ---
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(mtbItemId.Text) Then
            MessageBox.Show("Please select an item from the list to update.", "No Item Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInput() Then Exit Sub

        Dim query As String = "UPDATE dbo.tblGroceryItems " &
                          "SET Description = @Description, Price = @Price, Image = @Image, Available = @Available " &
                          "WHERE ItemId = @ItemId"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@ItemId", mtbItemId.Text.Trim())
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@Price", Decimal.Parse(txtPrice.Text))
                cmd.Parameters.AddWithValue("@Image", txtImageLink.Text.Trim())

                If radYes.Checked Then
                    cmd.Parameters.AddWithValue("@Available", "Y")
                Else
                    cmd.Parameters.AddWithValue("@Available", "N")
                End If

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Item updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadGroceryItems()
        ClearInputFields()
    End Sub

    ' --- Search button ---
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadGroceryItems()
        Else
            LoadGroceryItems(txtSearch.Text.Trim())
        End If
    End Sub

End Class