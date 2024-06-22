Public Class Aadjustment
    Public PeriodFrom As Date

    Private Sub Aadjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Suggest()
        Comboxview()
        GetPeriodFrom()
    End Sub

    Private Sub Comboxview()
        Periodtxt.DataSource = Class_Viewing.GetPayrolPeriod
    End Sub

    Private Sub GetPeriodFrom()
        Dim selectedItem As String = Periodtxt.SelectedItem.ToString()
        PeriodFrom = selectedItem.Substring(0, 10)
    End Sub

    Private Sub Aadjustment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Home.Show()
    End Sub

    Public Sub Calculatetion()
        Dim totalallowance As Double

        totalallowance = Unittxt.Text * allowancetxt.Text

        WeeklyAllowance.Text = totalallowance
    End Sub



    Private Sub Suggest()
        Dim payList As List(Of String) = Class_Viewing.GetEmployee

        Dim suggestions As New AutoCompleteStringCollection()
        suggestions.AddRange(payList.ToArray())

        With Emptxt
            .Text = ""
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = suggestions
        End With

    End Sub

    Public Sub display()
        Class_Viewing.GetEmployeeAllowance(PeriodFrom, Emptxt.Text)
        Calculatetion()
    End Sub

    Private Sub Emptxt_Leave(sender As Object, e As EventArgs) Handles Emptxt.TextChanged, Emptxt.Leave
        If Emptxt.Text = String.Empty Then
            MsgBox("Invalid Employee")
        Else
            display()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Class_Update.RemoveManadatory(EIDtxt.Text, PeriodFrom, 1)
        'MsgBox("Successfully Remove")

        'display()

    End Sub

    Private Sub Emptxt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class