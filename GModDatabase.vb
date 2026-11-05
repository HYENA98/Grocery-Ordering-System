Imports Microsoft.Data.SqlClient
Module GModDatabase

    Private Const CONNECTION_STRING As String =
            "Data Source=localhost\SQLEXPRESS;Initial Catalog=oldAgeGroceryDB;Integrated Security=True;TrustServerCertificate=True"

    Public Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(CONNECTION_STRING)
        conn.Open()
        Return conn
    End Function

End Module