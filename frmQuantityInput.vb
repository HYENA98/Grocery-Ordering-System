Imports Microsoft.Data.SqlClient
Imports System.ComponentModel

Public Class frmQuantityInput

    ' Property to hold the quantity entered
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Quantity As Integer = 0
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ItemDescription As String = ""

    Private Sub frmQuantityInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblItemDescription.Text = ItemDescription
        txtQuantity.Clear()
        txtQuantity.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim qty As Integer

        ' Validate input
        If Not Integer.TryParse(txtQuantity.Text, qty) Then
            MessageBox.Show("Please enter a valid number.", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Clear()
            txtQuantity.Focus()
            Exit Sub
        End If

        If qty <= 0 Then
            MessageBox.Show("Quantity must be greater than 0.", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Clear()
            txtQuantity.Focus()
            Exit Sub
        End If

        ' Set the quantity and close
        Quantity = qty
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Quantity = 0
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class