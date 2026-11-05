Imports Microsoft.Data.SqlClient
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports PdfSharp.Fonts
Imports System.IO
Imports System.Diagnostics
Imports System.Drawing

Public Class frmGenerateOrderList

    Private Sub frmGenerateOrderList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize PDFsharp License and Fonts
        PdfSharp.PdfSharpLicense.SetAgplLicense()
        GlobalFontSettings.FontResolver = New WindowsFontResolver()

        txtCutoffDate.Text = GetCutoffFriday().ToString("dd/MM/yyyy")

        ' Set the calendar to today and display the label
        calOrderDate.TodayDate = Date.Today
        calOrderDate.SetDate(Date.Today)

        ' Clear grids and totals
        dgvCombinedList.DataSource = Nothing
        dgvIndividualOrders.DataSource = Nothing
        txtGrandTotal.Text = "0.00"
    End Sub

    ' --- Cutoff Friday Helpers ---
    Private Function GetCutoffFriday() As Date
        Dim today As Date = Date.Today
        Dim daysUntilFriday As Integer = (DayOfWeek.Friday - today.DayOfWeek + 7) Mod 7
        If daysUntilFriday = 0 Then daysUntilFriday = 7
        Return today.AddDays(daysUntilFriday)
    End Function

    Private Function GetPeriodStart() As Date
        Return GetCutoffFriday().AddDays(-7)
    End Function

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        LoadCombinedList()
    End Sub

    Private Sub LoadCombinedList()
        Dim periodStart As Date = GetPeriodStart()
        Dim periodEnd As Date = GetCutoffFriday()

        Dim query As String =
            "SELECT gi.ItemID, gi.Description AS Item, " &
            "ISNULL(SUM(o.Quantity), 0) AS Quantity, " &
            "ISNULL(SUM(o.Quantity * gi.Price), 0) AS Total " &
            "FROM dbo.tblGroceryItems gi " &
            "INNER JOIN dbo.tblMemberOrders o ON gi.ItemID = o.ItemID " &
            "WHERE CAST(o.OrderDate AS DATE) >= @PeriodStart " &
            "  AND CAST(o.OrderDate AS DATE) < @PeriodEnd " &
            "GROUP BY gi.ItemID, gi.Description " &
            "HAVING ISNULL(SUM(o.Quantity), 0) > 0 " &
            "ORDER BY gi.ItemID"

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvCombinedList.DataSource = table
            End Using
        End Using

        If dgvCombinedList.Columns.Count > 0 Then
            dgvCombinedList.Columns("ItemID").HeaderText = "ItemID"
            dgvCombinedList.Columns("Item").HeaderText = "Item"
            dgvCombinedList.Columns("Quantity").HeaderText = "Quantity"
            dgvCombinedList.Columns("Total").HeaderText = "Total R"
            dgvCombinedList.AutoResizeColumns()
        End If

        Dim grandTotal As Decimal = 0
        For Each row As DataGridViewRow In dgvCombinedList.Rows
            If row.Cells("Total").Value IsNot Nothing Then
                grandTotal += Convert.ToDecimal(row.Cells("Total").Value)
            End If
        Next
        txtGrandTotal.Text = grandTotal.ToString("F2")
    End Sub

    Private Sub btnViewIndividual_Click(sender As Object, e As EventArgs) Handles btnViewIndividual.Click
        LoadFormattedIndividualOrders()
    End Sub

    ' Load and Format Individual Orders
    Private Sub LoadFormattedIndividualOrders()
        Dim periodStart As Date = GetPeriodStart()
        Dim periodEnd As Date = GetCutoffFriday()

        Dim query As String =
            "SELECT o.MemberID, m.Name + ' ' + m.Surname AS MemberName, " &
            "gi.Description AS Item, o.Quantity AS Qty, " &
            "(o.Quantity * gi.Price) AS Total " &
            "FROM dbo.tblMemberOrders o " &
            "INNER JOIN dbo.tblMembers m ON o.MemberID = m.MemberID " &
            "INNER JOIN dbo.tblGroceryItems gi ON o.ItemID = gi.ItemID " &
            "WHERE CAST(o.OrderDate AS DATE) >= @PeriodStart " &
            "  AND CAST(o.OrderDate AS DATE) < @PeriodEnd " &
            "ORDER BY o.MemberID, gi.Description"

        Dim formattedTable As New DataTable()
        formattedTable.Columns.Add("Member", GetType(String))
        formattedTable.Columns.Add("Item", GetType(String))
        formattedTable.Columns.Add("Qty", GetType(String))
        formattedTable.Columns.Add("Total", GetType(String))

        Dim currentMemberID As String = ""
        Dim memberTotal As Decimal = 0
        Dim grandTotal As Decimal = 0

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim memberID As String = reader("MemberID").ToString()
                        Dim memberName As String = reader("MemberName").ToString()

                        ' Check if we have moved to a new member
                        If memberID <> currentMemberID Then
                            ' Add subtotal for previous member if not the first one
                            If currentMemberID <> "" Then
                                formattedTable.Rows.Add("", "TOTAL", "", memberTotal.ToString("F2"))
                                grandTotal += memberTotal
                            End If

                            ' Add new member header
                            formattedTable.Rows.Add(memberID & " - " & memberName, "", "", "")
                            currentMemberID = memberID
                            memberTotal = 0
                        End If

                        ' Add the item row
                        Dim item As String = reader("Item").ToString()
                        Dim qty As String = reader("Qty").ToString()
                        Dim total As Decimal = Convert.ToDecimal(reader("Total"))
                        formattedTable.Rows.Add("", item, qty, total.ToString("F2"))
                        memberTotal += total
                    End While
                End Using
            End Using
        End Using

        ' Add final member subtotal and grand total
        If currentMemberID <> "" Then
            formattedTable.Rows.Add("", "TOTAL", "", memberTotal.ToString("F2"))
            grandTotal += memberTotal
        End If
        ' Grand Total row
        formattedTable.Rows.Add("", "TOTAL", "", grandTotal.ToString("F2"))

        ' Bind to DataGridView
        dgvIndividualOrders.DataSource = formattedTable

        ' Apply formatting (Headers, Subtotals, and Grand Total)
        dgvIndividualOrders.Columns("Member").Width = 150
        dgvIndividualOrders.Columns("Item").Width = 200
        dgvIndividualOrders.Columns("Qty").Width = 50
        dgvIndividualOrders.Columns("Total").Width = 80

        For i As Integer = 0 To dgvIndividualOrders.Rows.Count - 1
            Dim row As DataGridViewRow = dgvIndividualOrders.Rows(i)
            Dim memberVal As String = row.Cells("Member").Value.ToString()
            Dim itemVal As String = row.Cells("Item").Value.ToString()

            If Not String.IsNullOrEmpty(memberVal) Then
                ' Member Header Row
                row.DefaultCellStyle.BackColor = Color.LightGray
                row.DefaultCellStyle.Font = New Font(dgvIndividualOrders.Font, FontStyle.Bold)
            ElseIf itemVal = "TOTAL" Then
                ' Subtotal / Grand Total Row
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204)
                row.DefaultCellStyle.Font = New Font(dgvIndividualOrders.Font, FontStyle.Bold)
            End If
        Next
    End Sub

    Private Sub btnCreatePDFBulk_Click(sender As Object, e As EventArgs) Handles btnCreatePDFBulk.Click
        If dgvCombinedList.Rows.Count = 0 Then
            MessageBox.Show("Please click 'Show' to load the combined list first.",
                            "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim fileName As String = "BulkOrder_" & GetCutoffFriday().ToString("yyyy_MM_dd") & ".pdf"
        Dim projectRoot As String = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.StartupPath, "..\..\.."))
        Dim outputDir As String = Path.Combine(projectRoot, "PDFs", Date.Today.ToString("yyyy-MM-dd"))

        If Not Directory.Exists(outputDir) Then Directory.CreateDirectory(outputDir)
        Dim pdfPath As String = Path.Combine(outputDir, fileName)

        Try
            Dim document As New PdfDocument()
            document.Info.Title = "Weekly Combined Grocery Order"
            Dim page As PdfPage = document.AddPage()
            Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

            Dim titleFont As New XFont("Arial", 16, XFontStyleEx.Bold)
            Dim headerFont As New XFont("Arial", 10, XFontStyleEx.Bold)
            Dim bodyFont As New XFont("Arial", 10)

            gfx.DrawString("Weekly Combined Grocery Order", titleFont, XBrushes.Black,
                           New XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter)
            gfx.DrawString("Cutoff: " & GetCutoffFriday().ToString("dddd, dd MMMM yyyy"),
                           bodyFont, XBrushes.Black, New XRect(0, 50, page.Width.Point, 20), XStringFormats.TopCenter)

            Dim yPos As Double = 90
            Dim col1 As Double = 40, col2 As Double = 120, col3 As Double = 400, col4 As Double = 500

            gfx.DrawString("ItemID", headerFont, XBrushes.Black, col1, yPos)
            gfx.DrawString("Item", headerFont, XBrushes.Black, col2, yPos)
            gfx.DrawString("Quantity", headerFont, XBrushes.Black, col3, yPos)
            gfx.DrawString("Total (R)", headerFont, XBrushes.Black, col4, yPos)
            yPos += 20

            For Each row As DataGridViewRow In dgvCombinedList.Rows
                gfx.DrawString(row.Cells("ItemID").Value.ToString(), bodyFont, XBrushes.Black, col1, yPos)
                gfx.DrawString(row.Cells("Item").Value.ToString(), bodyFont, XBrushes.Black, col2, yPos)
                gfx.DrawString(row.Cells("Quantity").Value.ToString(), bodyFont, XBrushes.Black, col3, yPos)
                gfx.DrawString(Convert.ToDecimal(row.Cells("Total").Value).ToString("F2"), bodyFont, XBrushes.Black, col4, yPos)
                yPos += 18
            Next

            yPos += 10
            gfx.DrawString("Grand Total: R " & txtGrandTotal.Text,
                           New XFont("Arial", 12, XFontStyleEx.Bold), XBrushes.Black, col3, yPos)

            document.Save(pdfPath)
            MessageBox.Show("PDF created successfully at:" & Environment.NewLine & pdfPath, "PDF Created", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim psi As New ProcessStartInfo(pdfPath)
            psi.UseShellExecute = True
            Process.Start(psi)

        Catch ex As Exception
            MessageBox.Show("Error creating PDF: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGeneratePDFIndividual_Click(sender As Object, e As EventArgs) Handles btnGeneratePDFIndividual.Click
        Dim periodStart As Date = GetPeriodStart()
        Dim periodEnd As Date = GetCutoffFriday()

        ' Get a list of unique members who placed orders
        Dim membersQuery As String = "SELECT DISTINCT m.MemberID, m.Name, m.Surname " &
                                     "FROM dbo.tblMemberOrders o " &
                                     "INNER JOIN dbo.tblMembers m ON o.MemberID = m.MemberID " &
                                     "WHERE CAST(o.OrderDate AS DATE) >= @PeriodStart " &
                                     "  AND CAST(o.OrderDate AS DATE) < @PeriodEnd"

        Dim members As New List(Of Tuple(Of String, String)) ' MemberID, FullName

        Using conn As SqlConnection = GModDatabase.GetConnection()
            Using cmd As New SqlCommand(membersQuery, conn)
                cmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id As String = reader("MemberID").ToString()
                        Dim fullName As String = reader("Name").ToString() & " " & reader("Surname").ToString()
                        members.Add(New Tuple(Of String, String)(id, fullName))
                    End While
                End Using
            End Using
        End Using

        If members.Count = 0 Then
            MessageBox.Show("No individual orders found for this week.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Set up the output folder
        Dim projectRoot As String = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.StartupPath, "..\..\.."))
        Dim outputDir As String = Path.Combine(projectRoot, "PDFs", Date.Today.ToString("yyyy-MM-dd"))
        If Not Directory.Exists(outputDir) Then Directory.CreateDirectory(outputDir)

        Dim pdfsCreated As Integer = 0

        Try
            ' Loop through each member and create their PDF
            For Each m In members
                Dim memberID As String = m.Item1
                Dim memberName As String = m.Item2

                ' Sanitize name for filename & remove spaces
                Dim safeName As String = memberName.Replace(" ", "_")
                Dim fileName As String = safeName & "_" & GetCutoffFriday().ToString("yyyy_MM_dd") & ".pdf"
                Dim pdfPath As String = Path.Combine(outputDir, fileName)

                ' Get this member's specific orders
                Dim itemsQuery As String = "SELECT gi.Description AS Item, o.Quantity AS Qty, " &
                                           "(o.Quantity * gi.Price) AS Total " &
                                           "FROM dbo.tblMemberOrders o " &
                                           "INNER JOIN dbo.tblGroceryItems gi ON o.ItemID = gi.ItemID " &
                                           "WHERE o.MemberID = @MemberID " &
                                           "AND CAST(o.OrderDate AS DATE) >= @PeriodStart " &
                                           "AND CAST(o.OrderDate AS DATE) < @PeriodEnd " &
                                           "ORDER BY gi.Description"

                Dim document As New PdfDocument()
                document.Info.Title = "Grocery Order - " & memberName
                Dim page As PdfPage = document.AddPage()
                Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

                Dim titleFont As New XFont("Arial", 16, XFontStyleEx.Bold)
                Dim headerFont As New XFont("Arial", 10, XFontStyleEx.Bold)
                Dim bodyFont As New XFont("Arial", 10)

                gfx.DrawString("Grocery Order", titleFont, XBrushes.Black,
                               New XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter)
                gfx.DrawString(memberID & " - " & memberName, New XFont("Arial", 12, XFontStyleEx.Bold), XBrushes.Black,
                               New XRect(0, 50, page.Width.Point, 20), XStringFormats.TopCenter)
                gfx.DrawString("Cutoff: " & GetCutoffFriday().ToString("dddd, dd MMMM yyyy"),
                               bodyFont, XBrushes.Black, New XRect(0, 70, page.Width.Point, 20), XStringFormats.TopCenter)

                Dim yPos As Double = 110
                Dim col1 As Double = 40, col2 As Double = 300, col3 As Double = 400

                gfx.DrawString("Item", headerFont, XBrushes.Black, col1, yPos)
                gfx.DrawString("Qty", headerFont, XBrushes.Black, col2, yPos)
                gfx.DrawString("Total (R)", headerFont, XBrushes.Black, col3, yPos)
                yPos += 20

                Dim memberTotal As Decimal = 0

                Using conn As SqlConnection = GModDatabase.GetConnection()
                    Using cmd As New SqlCommand(itemsQuery, conn)
                        cmd.Parameters.AddWithValue("@MemberID", memberID)
                        cmd.Parameters.AddWithValue("@PeriodStart", periodStart)
                        cmd.Parameters.AddWithValue("@PeriodEnd", periodEnd)

                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim item As String = reader("Item").ToString()
                                Dim qty As String = reader("Qty").ToString()
                                Dim total As Decimal = Convert.ToDecimal(reader("Total"))
                                memberTotal += total

                                gfx.DrawString(item, bodyFont, XBrushes.Black, col1, yPos)
                                gfx.DrawString(qty, bodyFont, XBrushes.Black, col2, yPos)
                                gfx.DrawString(total.ToString("F2"), bodyFont, XBrushes.Black, col3, yPos)
                                yPos += 18
                            End While
                        End Using
                    End Using
                End Using

                yPos += 10
                gfx.DrawString("TOTAL: R " & memberTotal.ToString("F2"),
                               New XFont("Arial", 12, XFontStyleEx.Bold), XBrushes.Black, col2, yPos)

                document.Save(pdfPath)
                pdfsCreated += 1
            Next

            MessageBox.Show($"{pdfsCreated} individual PDFs created successfully at:" & Environment.NewLine & outputDir,
                            "PDFs Created", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open the folder in Windows Explorer
            Dim psi As New ProcessStartInfo(outputDir)
            psi.UseShellExecute = True
            Process.Start(psi)

        Catch ex As Exception
            MessageBox.Show("Error generating individual PDFs: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class