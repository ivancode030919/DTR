Public Class CheckLeave


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        View()
    End Sub

    Public Sub View()

        Dgv.DataSource = db.SP_DTRWPAY(DateTimePicker1.Value, DateTimePicker2.Value, Txt1.Text)

        With Dgv
            .Columns(0).HeaderText = "Employee ID"
            .Columns(1).HeaderText = "Employee"
            .Columns(2).HeaderText = "Date"
            .Columns(3).HeaderText = "Leave"
        End With

    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        View()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        View()
    End Sub

    Private Sub CheckLeave_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Home.Show()
    End Sub

    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = Dgv.Rows(index)
            With LeaveDetails
                .EmpID = selectedrow.Cells(0).Value.ToString
                .Label4.Text = selectedrow.Cells(1).Value.ToString
                .Label6.Text = selectedrow.Cells(0).Value.ToString
                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        View()
    End Sub
End Class
