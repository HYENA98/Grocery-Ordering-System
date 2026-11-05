Imports Microsoft.Data.SqlClient

Public Class frmMembersOnly

    ' Form Load
    Private Sub frmMembersOnly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearForm()
    End Sub

    ' Continue button click
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        LookupMember()
    End Sub

    ' Allow Enter key to trigger Continue
    Private Sub mtbMemberID_KeyDown(sender As Object, e As KeyEventArgs) Handles mtbMemberID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnContinue.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Look up member and display details
    Private Sub LookupMember()
        ' Validate that the member ID is complete
        If Not mtbMemberID.MaskFull Then
            MessageBox.Show("Please enter your complete Member Number (e.g., 01-01).",
                            "Incomplete Member ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mtbMemberID.Focus()
            Exit Sub
        End If

        Dim memberID As String = mtbMemberID.Text.Trim()

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Dim query As String = "SELECT Name, Surname, Contact FROM dbo.tblMembers WHERE MemberID = @MemberID AND Active = 'Y'"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@MemberID", memberID)

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    ' Store the member details in class-level variables
                    _memberName = reader("Name").ToString()
                    _memberSurname = reader("Surname").ToString()
                    _memberContact = reader("Contact").ToString()

                    ' Display the details
                    lblMemberName.Text = "Name: " & _memberName
                    lblMemberSurname.Text = "Surname: " & _memberSurname
                    lblMemberContact.Text = "Contact: " & _memberContact

                    ' Show the verification group box and focus on YES button
                    gbxVerification.Visible = True
                    btnYes.Focus()
                Else
                    MessageBox.Show("Member Number not found or the member is inactive. Please try again.",
                                    "Member Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ClearForm()
                End If

                reader.Close()
            End Using
        End Using
    End Sub

    ' YES button click
    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        ' Open the Create Grocery List form with member details
        Dim groceryForm As New frmCreateGroceryList()
        groceryForm.MemberID = mtbMemberID.Text.Trim()
        groceryForm.MemberFullName = _memberName & " " & _memberSurname
        groceryForm.Show()

        Me.Close()
    End Sub

    ' NO button click
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        ClearForm()
    End Sub

    ' Clear the form and return to initial state
    Private Sub ClearForm()
        mtbMemberID.Clear()
        lblMemberName.Text = ""
        lblMemberSurname.Text = ""
        lblMemberContact.Text = ""
        gbxVerification.Visible = False
        _memberName = ""
        _memberSurname = ""
        _memberContact = ""
        mtbMemberID.Focus()
    End Sub

    ' Class-level variables to store member details
    Private _memberName As String = ""
    Private _memberSurname As String = ""
    Private _memberContact As String = ""

End Class