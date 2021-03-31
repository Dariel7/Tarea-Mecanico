Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection
    Public Sub conectar()
        con.ConnectionString = "Data Source=DESKTOP-SG7LTFG\DARIEL;Initial Catalog=mecanico;Integrated Security=True"
        con.Open()

    End Sub


End Module
