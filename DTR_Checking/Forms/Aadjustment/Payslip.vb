Public Class Payslip
    Public PeriodFrom As Date
    Public Periodto As Date
    Public Dallowance As Double
    Private Sub Payslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Suggest()
        Comboxview()
        GetPeriodFrom()
        GetPeriodFrom()
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
        Label32.Text = "Daily Allowance : " + Dallowance.ToString
        Label35.Text = "Period from: " & PeriodFrom & " - Period to: " & Periodto
    End Sub

    Private Sub Emptxt_Leave(sender As Object, e As EventArgs) Handles Emptxt.Leave
        display()
    End Sub

    Private Sub GetPeriodFrom()
        Dim selectedItem As String = Periodtxt.SelectedItem.ToString()
        PeriodFrom = selectedItem.Substring(0, 10)
        Periodto = selectedItem.Substring(14, 10)

    End Sub
    Private Sub Comboxview()
        Periodtxt.DataSource = Class_Viewing.GetPayrolPeriod
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = True Then
            Nodtxt.Enabled = True
        Else
            Nodtxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            Ratetxt.Enabled = True
        Else
            Ratetxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = True Then
            Ottxt.Enabled = True
        Else
            Ottxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            Holidaytxt.Enabled = True
        Else
            Holidaytxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            otherstxt.Enabled = True
        Else
            otherstxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            tsalarytxt.Enabled = True
        Else
            tsalarytxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = True Then
            Tottxt.Enabled = True
        Else
            Tottxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            Tholidaytxt.Enabled = True
        Else
            Tholidaytxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            SOtherstxt.Enabled = True
        Else
            SOtherstxt.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SOtherstxt.Text = Dallowance * Nodtxt.Text

        If SOtherstxt.Text = 0 Then
            otherstxt.Text = String.Empty
        Else
            otherstxt.Text = "Allowance=" + SOtherstxt.Text
        End If


    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = True Then
            Ssstxt.Enabled = True
        Else
            Ssstxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged
        If CheckBox21.Checked = True Then
            Sssloantxt.Enabled = True
            SssloanBtxt.Enabled = True
        Else
            Sssloantxt.Enabled = False
            SssloanBtxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox23.CheckedChanged
        If CheckBox23.Checked = True Then
            pagibigloantxt.Enabled = True
            Pbaltxt.Enabled = True
        Else
            pagibigloantxt.Enabled = False
            Pbaltxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox22.CheckedChanged
        If CheckBox22.Checked = True Then
            pagibigtxt.Enabled = True
        Else
            pagibigtxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox26_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox26.CheckedChanged
        If CheckBox26.Checked = True Then
            Philtxt.Enabled = True
        Else
            Philtxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox27_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox27.CheckedChanged
        If CheckBox27.Checked = True Then
            WtaxAmounttxt.Enabled = True
        Else
            WtaxAmounttxt.Enabled = False
        End If
    End Sub

    Private Sub CheckBox29_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox29.CheckedChanged
        If CheckBox29.Checked = True Then
            Dotherstxt.Enabled = True
            OthersBtxt.Enabled = True
            OADettxt.Enabled = True
        Else
            Dotherstxt.Enabled = False
            OthersBtxt.Enabled = False
            OADettxt.Enabled = False
        End If
    End Sub

    Private Sub Periodtxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Periodtxt.SelectedIndexChanged
        GetPeriodFrom()
        display()
    End Sub

    Private Sub Periodtxt_Leave(sender As Object, e As EventArgs) Handles Periodtxt.Leave
        display()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Ssstxt.Text = 0
        pagibigtxt.Text = 0
        Philtxt.Text = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Class_Update.RemoveManadatory(EIDtxt.Text, PeriodFrom,
                                      Double.Parse(Nodtxt.Text), Double.Parse(Tholidaytxt.Text),
                                      Double.Parse(Ottxt.Text), Double.Parse(SOtherstxt.Text),
                                      otherstxt.Text,
                                      Double.Parse(Ssstxt.Text), Double.Parse(Philtxt.Text),
                                       Double.Parse(pagibigtxt.Text), Double.Parse(SssloanBtxt.Text),
                                       Double.Parse(Pbaltxt.Text), Double.Parse(OthersBtxt.Text),
                                       Double.Parse(Sssloantxt.Text), Double.Parse(pagibigloantxt.Text),
                                       Double.Parse(Dotherstxt.Text), OADettxt.Text, Holidaytxt.Text,
                                       Double.Parse(WtaxAmounttxt.Text))

        display()
        Uncheck()
    End Sub

    Private Sub Uncheck()
        CheckBox18.Checked = False
        CheckBox17.Checked = False
        CheckBox16.Checked = False
        CheckBox15.Checked = False
        CheckBox14.Checked = False
        CheckBox13.Checked = False
        CheckBox12.Checked = False
        CheckBox11.Checked = False
        CheckBox6.Checked = False

        CheckBox20.Checked = False
        CheckBox21.Checked = False
        CheckBox22.Checked = False
        CheckBox23.Checked = False
        CheckBox24.Checked = False
        CheckBox25.Checked = False
        CheckBox26.Checked = False
        CheckBox27.Checked = False
        CheckBox28.Checked = False
        CheckBox29.Checked = False
    End Sub
End Class