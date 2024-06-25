Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Reporting.WinForms

Public Class OTform
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub OTform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Suggest()


    End Sub

    'Public Sub DisplayInDatgrid()
    '    'Dgv.DataSource = Class_Viewing.GetOT(DateTimePicker1.Value, DateTimePicker2.Value, Txt1.Text)

    'End Sub

    Private Sub Suggest()
        Dim payList As List(Of String) = Class_Viewing.GetEmployee

        Dim suggestions As New AutoCompleteStringCollection()
        suggestions.AddRange(payList.ToArray())

        With Txt1
            .Text = ""
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = suggestions
        End With

    End Sub

    Private Sub OTform_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Home.Show()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ReportDisplay()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        ReportDisplay()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        ReportDisplay()
    End Sub


    Private Sub ReportDisplay()

        Me.SP_CheckOTTableAdapter.Fill(Me.SystemsDataSet.SP_CheckOT, DateTimePicker1.Value, DateTimePicker2.Value, Txt1.Text)

        Dim par1 As New ReportParameter("@Datefrom", DateTimePicker1.Value)
        Me.ReportViewer1.LocalReport.SetParameters(par1)

        Me.ReportViewer1.RefreshReport()

    End Sub

End Class