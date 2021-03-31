Imports System.Data.SqlClient

Public Class Form1
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        mostrardatos()
    End Sub

    Sub mostrardatos()
        Dim a As New SqlDataAdapter("select * from trabajador", con)
        Dim b As New DataSet
        a.Fill(b, "trabajador")
        DataGridView1.DataSource = b.Tables(0)

    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click

        Try
            Dim ab As New SqlCommand
            ab.Connection = con
            ab.CommandText = "insert into trabajador (codigo,nombre,direccion,ciudad) values ('" & txtCodigo.Text & "', '" & txtNombre.Text & "', '" & txtDireccion.Text & "', '" & txtCiudad.Text & "')"
            ab.ExecuteNonQuery()
            MessageBox.Show("Datos guardados")
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If DataGridView1.Rows.Count > 0 Then

            If DataGridView1.SelectedRows.Count > 0 Then

                txtCodigo.Text = DataGridView1.SelectedRows(0).Cells("Código").Value
                txtNombre.Text = DataGridView1.SelectedRows(0).Cells("Nombre").Value
                txtDireccion.Text = DataGridView1.SelectedRows(0).Cells("Dirección").Value
                txtCiudad.Text = DataGridView1.SelectedRows(0).Cells("Ciudad").Value

            End If
        End If
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim ab As New SqlCommand
            ab.Connection = con
            ab.CommandText = "update trabajador set codigo = '" & txtCodigo.Text & "', nombre= '" & txtNombre.Text & "', direccion= '" & txtDireccion.Text & "', ciudad= '" & txtCiudad.Text & "' where codigo = '" & txtCodigo.Text & "'"
            ab.ExecuteNonQuery()
            MessageBox.Show("Datos guardados")
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim ab As New SqlCommand
        ab.Connection = con
        ab.CommandText = "delete from trabajador where codigo = '" & txtCodigo.Text & "'"
        ab.ExecuteNonQuery()
        MessageBox.Show("Datos Eliminados")
        mostrardatos()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        limpiar()

    End Sub

    Sub limpiar()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtCiudad.Clear()

    End Sub
End Class
