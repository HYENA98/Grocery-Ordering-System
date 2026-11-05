Imports Microsoft.Data.SqlClient

Public Class frmUpdateMembers

    ' Form Load 
    Private Sub frmUpdateMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMembers()
        ClearInputFields()
    End Sub

    ' Load all members into the DataGridView
    Private Sub LoadMembers()
        Dim query As String = "SELECT MemberID, Name, Surname, Contact, Email, Active FROM dbo.tblMembers ORDER BY MemberID"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvMembers.DataSource = table
            End Using
        End Using

        ' Format the DataGridView headers
        If dgvMembers.Columns.Count > 0 Then
            dgvMembers.Columns("MemberID").HeaderText = "Member ID"
            dgvMembers.Columns("Name").HeaderText = "Name"
            dgvMembers.Columns("Surname").HeaderText = "Surname"
            dgvMembers.Columns("Contact").HeaderText = "Contact Tel"
            dgvMembers.Columns("Email").HeaderText = "Email"
            dgvMembers.Columns("Active").HeaderText = "Active"
            dgvMembers.AutoResizeColumns()
        End If
    End Sub

    ' Load members filtered by search term (searches Name or Surname)
    Private Sub LoadMembers(searchTerm As String)
        Dim query As String = "SELECT MemberID, Name, Surname, Contact, Email, Active " &
                              "FROM dbo.tblMembers " &
                              "WHERE Name LIKE @Search OR Surname LIKE @Search " &
                              "ORDER BY MemberID"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Search", "%" & searchTerm & "%")
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvMembers.DataSource = table
            End Using
        End Using
    End Sub

    ' When a row is selected in the DataGridView, fill the input controls
    Private Sub dgvMembers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMembers.SelectionChanged
        If dgvMembers.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvMembers.SelectedRows(0)

            mtbMemberID.Text = row.Cells("MemberID").Value.ToString()
            txtName.Text = row.Cells("Name").Value.ToString()
            txtSurname.Text = row.Cells("Surname").Value.ToString()
            mtbContactTel.Text = row.Cells("Contact").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()

            ' Set the Active dropdown (Y/N)
            If row.Cells("Active").Value IsNot DBNull.Value Then
                Dim activeVal As String = row.Cells("Active").Value.ToString().ToUpper()
                If activeVal = "Y" Then
                    cboActive.SelectedIndex = cboActive.FindStringExact("Y")
                Else
                    cboActive.SelectedIndex = cboActive.FindStringExact("N")
                End If
            Else
                cboActive.SelectedIndex = -1
            End If
        End If
    End Sub

    ' Clear all input fields and deselect the grid
    Private Sub ClearInputFields()
        mtbMemberID.Clear()
        txtName.Clear()
        txtSurname.Clear()
        mtbContactTel.Clear()
        txtEmail.Clear()
        cboActive.SelectedIndex = -1
        dgvMembers.ClearSelection()
        mtbMemberID.Focus()
    End Sub

    ' Validate the input before Add/Update
    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(mtbMemberID.Text) Then
            MessageBox.Show("Member ID is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mtbMemberID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Name is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSurname.Text) Then
            MessageBox.Show("Surname is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSurname.Focus()
            Return False
        End If

        ' Validate phone number format (basic length check)
        ' Since MaskedTextBox may include hyphens, we can strip them and check.
        Dim phoneDigits As String = mtbContactTel.Text.Replace("-", "").Replace(" ", "")
        If phoneDigits.Length < 7 Then
            MessageBox.Show("Please enter a valid contact telephone number.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mtbContactTel.Focus()
            Return False
        End If

        ' Email is optional, but if entered, check for '@'
        If Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        If cboActive.SelectedIndex = -1 Then
            MessageBox.Show("Please select Active status (Y/N).", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboActive.Focus()
            Return False
        End If

        Return True
    End Function

    ' Add New Member button
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If Not ValidateInput() Then Exit Sub

        ' Check if MemberID already exists
        Dim checkQuery As String = "SELECT COUNT(*) FROM dbo.tblMembers WHERE MemberID = @MemberID"
        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(checkQuery, conn)
                cmd.Parameters.AddWithValue("@MemberID", mtbMemberID.Text.Trim())
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("A member with this ID already exists. Please use a different Member ID.",
                                    "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    mtbMemberID.Focus()
                    Exit Sub
                End If
            End Using
        End Using

        ' Insert the new member
        Dim insertQuery As String = "INSERT INTO dbo.tblMembers (MemberID, Name, Surname, Contact, Email, Active) " &
                                    "VALUES (@MemberID, @Name, @Surname, @Contact, @Email, @Active)"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@MemberID", mtbMemberID.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim())
                cmd.Parameters.AddWithValue("@Contact", mtbContactTel.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Active", cboActive.SelectedItem.ToString())

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Member added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadMembers()
        ClearInputFields()
    End Sub

    ' Update Member button
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(mtbMemberID.Text) Then
            MessageBox.Show("Please select a member from the list to update.", "No Member Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInput() Then Exit Sub

        ' Ensure the MemberID exists (should, if selected from DGV)
        Dim updateQuery As String = "UPDATE dbo.tblMembers " &
                                    "SET Name = @Name, Surname = @Surname, Contact = @Contact, " &
                                    "Email = @Email, Active = @Active " &
                                    "WHERE MemberID = @MemberID"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@MemberID", mtbMemberID.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim())
                cmd.Parameters.AddWithValue("@Contact", mtbContactTel.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Active", cboActive.SelectedItem.ToString())

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Member updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadMembers()
        ClearInputFields()
    End Sub

    ' Search button
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadMembers()                ' Empty search → show all
        Else
            LoadMembers(txtSearch.Text.Trim())
        End If
    End Sub

End Class