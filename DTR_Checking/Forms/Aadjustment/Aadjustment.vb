Public Class Aadjustment
    Private Sub Aadjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comboxview()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Leave(sender As Object, e As EventArgs) Handles Txt1.Leave
        Class_Viewing.GetEmployeeAllowance(Txt1.Text)
    End Sub

    Private Sub Comboxview()
        ComboBox1.DataSource = Class_Viewing.GetPayrolPeriod
    End Sub
End Class