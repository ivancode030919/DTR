Public Class loginform
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "p@ssw0rd" Then
            Me.Close()
            Home.Hide()
            Payslip.Show()
        Else
            MsgBox("Invalid Login")
        End If
    End Sub
End Class