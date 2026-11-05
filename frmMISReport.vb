Imports Microsoft.Data.SqlClient
Imports System.Drawing

Public Class frmMISReport

    Private Sub frmMISReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default dates
        dtpFromDate.Value = New Date(Date.Today.Year, 1, 1)
        dtpToDate.Value = Date.Today

        ' Set default ComboBox values/  default to 5(TOP&LOW)
        cboTop.SelectedIndex = 4
        cboLow.SelectedIndex = 4

        ' Trigger the date text updates
        UpdateDateTexts()
    End Sub

    Private Sub dtpFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromDate.ValueChanged
        UpdateDateTexts()
    End Sub

    Private Sub dtpToDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpToDate.ValueChanged
        UpdateDateTexts()
    End Sub

    Private Sub UpdateDateTexts()

        txtFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy")
        txtToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy")

        ' Validation: Ensure TO date is not before FROM date
        If dtpToDate.Value < dtpFromDate.Value Then
            MessageBox.Show("The 'TO' date cannot be earlier than the 'FROM' date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpToDate.Value = dtpFromDate.Value
            txtToDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy")
        End If
    End Sub

    Private Sub btnCreateGrocery_Click(sender As Object, e As EventArgs) Handles btnCreateGrocery.Click
        Dim startDate As Date = dtpFromDate.Value.Date
        Dim endDate As Date = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1)
        Dim topN As Integer = Convert.ToInt32(cboTop.SelectedItem)
        Dim lowN As Integer = Convert.ToInt32(cboLow.SelectedItem)

        ' Query: Combines TOP N and LOW N items
        Dim query As String =
            "SELECT * FROM (" &
            "   SELECT TOP (@TopN) gi.ItemID, gi.Description, ISNULL(SUM(o.Quantity), 0) AS TotalQuantities, 'TOP' AS Rank " &
            "   FROM dbo.tblGroceryItems gi " &
            "   INNER JOIN dbo.tblMemberOrders o ON gi.ItemID = o.ItemID " &
            "   WHERE o.OrderDate >= @StartDate AND o.OrderDate <= @EndDate " &
            "   GROUP BY gi.ItemID, gi.Description " &
            "   ORDER BY TotalQuantities DESC " &
            ") AS TopItems " &
            "UNION ALL " &
            "SELECT * FROM (" &
            "   SELECT TOP (@LowN) gi.ItemID, gi.Description, ISNULL(SUM(o.Quantity), 0) AS TotalQuantities, 'LOW' AS Rank " &
            "   FROM dbo.tblGroceryItems gi " &
            "   INNER JOIN dbo.tblMemberOrders o ON gi.ItemID = o.ItemID " &
            "   WHERE o.OrderDate >= @StartDate AND o.OrderDate <= @EndDate " &
            "   GROUP BY gi.ItemID, gi.Description " &
            "   ORDER BY TotalQuantities ASC " &
            ") AS LowItems"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TopN", topN)
                cmd.Parameters.AddWithValue("@LowN", lowN)
                cmd.Parameters.AddWithValue("@StartDate", startDate)
                cmd.Parameters.AddWithValue("@EndDate", endDate)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvGrocery.DataSource = table
            End Using
        End Using

        ' Format Headers
        If dgvGrocery.Columns.Count > 0 Then
            dgvGrocery.Columns("ItemID").HeaderText = "Item ID"
            dgvGrocery.Columns("Description").HeaderText = "Description"
            dgvGrocery.Columns("TotalQuantities").HeaderText = "Total Quanti..."
            dgvGrocery.Columns("Rank").HeaderText = "Rank"
            dgvGrocery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        ' Apply Colors (White for TOP, Light Yellow for LOW)
        For Each row As DataGridViewRow In dgvGrocery.Rows
            If row.Cells("Rank").Value.ToString() = "LOW" Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204)
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub btnCreateMembers_Click(sender As Object, e As EventArgs) Handles btnCreateMembers.Click
        Dim startDate As Date = dtpFromDate.Value.Date
        Dim endDate As Date = dtpToDate.Value.Date

        ' Calculate Total Opportunities (Count every Friday between startDate and endDate)
        Dim totalOpportunities As Integer = 0
        Dim tempDate As Date = startDate
        While tempDate <= endDate
            If tempDate.DayOfWeek = DayOfWeek.Friday Then
                totalOpportunities += 1
            End If
            tempDate = tempDate.AddDays(1)
        End While

        ' Prevent division by zero if the selected range has no Fridays
        If totalOpportunities = 0 Then totalOpportunities = 1

        ' The SQL Query
        ' - SET DATEFIRST 1: Ensures the week starts on Monday so Friday is the end of the week
        ' - INNER JOIN: Ensures ONLY members who placed orders are shown
        ' - DATEADD/DATEPART: Calculates the exact cutoff Friday for each order to count distinct weeks
        Dim query As String =
            "SET DATEFIRST 1; " &
            "SELECT m.MemberID, m.Name + ' ' + m.Surname AS Name, " &
            "   COUNT(DISTINCT DATEADD(day, " &
            "       CASE " &
            "           WHEN DATEPART(weekday, o.OrderDate) <= 5 THEN 5 - DATEPART(weekday, o.OrderDate) " &
            "           ELSE 12 - DATEPART(weekday, o.OrderDate) " &
            "       END, " &
            "       CAST(o.OrderDate AS DATE) " &
            "   )) AS OrdersMade, " &
            "   @TotalOpportunities AS Opportunities, " &
            "   CAST(ROUND((CAST(COUNT(DISTINCT DATEADD(day, " &
            "       CASE " &
            "           WHEN DATEPART(weekday, o.OrderDate) <= 5 THEN 5 - DATEPART(weekday, o.OrderDate) " &
            "           ELSE 12 - DATEPART(weekday, o.OrderDate) " &
            "       END, " &
            "       CAST(o.OrderDate AS DATE) " &
            "   )) AS DECIMAL) / @TotalOpportunities) * 100, 1) AS DECIMAL(5,1)) AS [Participation %] " &
            "FROM dbo.tblMembers m " &
            "INNER JOIN dbo.tblMemberOrders o ON m.MemberID = o.MemberID " &
            "WHERE m.Active = 'Y' " &
            "   AND CAST(o.OrderDate AS DATE) >= @StartDate " &
            "   AND CAST(o.OrderDate AS DATE) <= @EndDate " &
            "GROUP BY m.MemberID, m.Name, m.Surname " &
            "ORDER BY [Participation %] DESC, m.Name ASC"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StartDate", startDate)
                cmd.Parameters.AddWithValue("@EndDate", endDate)
                cmd.Parameters.AddWithValue("@TotalOpportunities", totalOpportunities)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvMembers.DataSource = table
            End Using
        End Using

        ' Format Headers
        If dgvMembers.Columns.Count > 0 Then
            dgvMembers.Columns("MemberID").HeaderText = "Member..."
            dgvMembers.Columns("Name").HeaderText = "Name"
            dgvMembers.Columns("OrdersMade").HeaderText = "Orders Made"
            dgvMembers.Columns("Opportunities").HeaderText = "Opportunities"
            dgvMembers.Columns("Participation %").HeaderText = "Participation %"
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        ' Apply Colors (White for Top 3, Light Yellow for the rest)
        For i As Integer = 0 To dgvMembers.Rows.Count - 1
            Dim row As DataGridViewRow = dgvMembers.Rows(i)
            If i < 3 Then
                ' Top 3 Members
                row.DefaultCellStyle.BackColor = Color.White
            Else
                ' The rest
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204)
            End If
        Next
    End Sub

End Class