﻿Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        CheckLeave.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Payslip.Show()
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        OTform.Show()
    End Sub
End Class