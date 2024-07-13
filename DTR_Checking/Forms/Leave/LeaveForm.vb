Imports System.Threading.Tasks
Public Class LeaveForm

    Private Start As Integer
    Private Sub LeaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        display()
        Suggest()
    End Sub

    Private Sub display()
        dgv.DataSource = Class_Viewing.GetEmployeeWithLeave(Txt1.Text)
    End Sub

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

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Async Sub progressbarloads(ByVal ProgCount As Integer)
        ' Set the minimum and maximum values for the progress bar
        ProgressBar1.Invoke(Sub()
                                ProgressBar1.Visible = True
                                dgv.Enabled = False
                                ProgressBar1.Minimum = 0
                                ProgressBar1.Maximum = ProgCount
                            End Sub)

        ' Loop to increment the progress bar's value
        For i As Integer = 0 To ProgCount
            ' Update the progress bar's value
            ProgressBar1.Invoke(Sub() ProgressBar1.Value = i)

            ' Pause for a short duration to simulate work being done
            Await Task.Delay(150)
        Next

        ' Show completion message and reset UI state
        MessageBox.Show("Successfully Updated...")

        ProgressBar1.Invoke(Sub()
                                ProgressBar1.Visible = False
                                dgv.Enabled = True
                            End Sub)
    End Sub

    Private Async Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EmpCount As Integer = Class_Viewing.GetEmployeeCOunt()

        ' Update the progress bar asynchronously
        Await Task.Run(Sub() progressbarloads(EmpCount))

        ' Perform the update after the progress bar is complete
        Await Task.Run(Sub() Class_Update.FixLeave())
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            display()
        End If
    End Sub
End Class