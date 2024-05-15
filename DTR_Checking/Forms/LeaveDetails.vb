Public Class LeaveDetails

    Public EmpID As String
    Public GetWp As Double
    Public GetHp As Double

    Private Sub LeaveDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeaveComputation()
        txt1.Text = String.Empty
        CheckBox2.Checked = True
        dgvview()
    End Sub

    Private Sub LeaveComputation()
        GetWp = Class_Viewing.CountWP(EmpID)
        GetHp = Class_Viewing.CountHp(EmpID) / 2

        Label5.Text = Class_Viewing.GetCompany(EmpID)
        Label11.Text = GetWp + GetHp
        Label9.Text = Class_Viewing.GetLeaveIssue(EmpID)
        Label12.Text = Label9.Text - Label11.Text
        Label15.Text = Class_Viewing.GetPayslipLeave(EmpID)

        If Label12.Text = Label15.Text Then

            SimpleButton3.Visible = False

        Else

            SimpleButton3.Visible = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure to Update this Employee Leave?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If result = DialogResult.Yes Then

            Class_Update.UpdatePVMReleasing(Label6.Text, txt1.Text)
            MessageBox.Show("Successfully Updated...", "Notification", MessageBoxButtons.OK)

            txt1.Text = String.Empty
            SimpleButton1.Enabled = False
            LeaveComputation()
        Else

        End If

    End Sub

    Private Sub txt1_TextChanged(sender As Object, e As EventArgs) Handles txt1.TextChanged
        If txt1.Text IsNot String.Empty Then
            SimpleButton1.Enabled = True
        Else
            SimpleButton1.Enabled = False
        End If
    End Sub

    Private Sub dgvview()
        If CheckBox1.Checked = True Then
            dgv.DataSource = Class_Viewing.GetAbsent(EmpID)
        ElseIf CheckBox2.Checked = True Then
            dgv.DataSource = Class_Viewing.GetSeeionsCount(EmpID)
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
            dgvview()
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            dgvview()
        Else
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub LeaveDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        EmpID = ""
    End Sub
End Class