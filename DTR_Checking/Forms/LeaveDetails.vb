Public Class LeaveDetails

    Public EmpID As String
    Public GetWp As Double
    Public GetHp As Double

    Private Sub LeaveDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeaveComputation()
        txt1.Text = String.Empty
        CheckBox2.Checked = True
        Label18.Text = EmpID
        dgvview()
    End Sub

    Private Sub LeaveComputation()
        GetWp = Class_Viewing.CountWP(EmpID)
        GetHp = Class_Viewing.CountHp(EmpID) / 2

        Label20.Text = Class_Viewing.GetCompany(EmpID)
        Label11.Text = GetWp + GetHp
        Label9.Text = Class_Viewing.GetLeaveIssue(EmpID)
        Label12.Text = Label9.Text - Label11.Text
        Label15.Text = Class_Viewing.GetPayslipLeave(EmpID)

        If Label12.Text = Label15.Text Then

            Button2.Visible = False

        Else

            Button2.Visible = True
        End If
    End Sub

    Private Sub txt1_TextChanged(sender As Object, e As EventArgs) Handles txt1.TextChanged
        If txt1.Text IsNot String.Empty Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub dgvview()
        If CheckBox1.Checked = True Then
            dgv.DataSource = Class_Viewing.GetAbsent(EmpID)

            With dgv
                .Columns(0).HeaderText = "Employee ID"
                .Columns(1).HeaderText = "Session"
                .Columns(2).HeaderText = "Count"
                .Columns(3).HeaderText = "Date"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End With

        ElseIf CheckBox2.Checked = True Then
            dgv.DataSource = Class_Viewing.GetSeeionsCount(EmpID)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If CheckBox3.Checked = True Then

            Dim result As DialogResult = MessageBox.Show("Are you sure to Update this Employee Issued Leave?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If result = DialogResult.Yes Then
                Class_Update.UpdateLeaveIssue(Label18.Text, TextBox1.Text)
                MessageBox.Show("Successfully Updated...", "Notification", MessageBoxButtons.OK)
                TextBox1.Text = String.Empty
                Button1.Enabled = False
                CheckBox3.Checked = False
                LeaveComputation()
            Else

            End If

        Else


            Dim result As DialogResult = MessageBox.Show("Are you sure to Update this Employee Leave?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If result = DialogResult.Yes Then

                Class_Update.UpdateLeave(Label18.Text, txt1.Text)
                MessageBox.Show("Successfully Updated...", "Notification", MessageBoxButtons.OK)

                txt1.Text = String.Empty
                Button1.Enabled = False
                LeaveComputation()
            Else

            End If

        End If
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked = True Then
            TextBox1.Enabled = True
            txt1.Enabled = False
            txt1.Text = String.Empty
            Button1.Enabled = True
        Else
            TextBox1.Enabled = False
            txt1.Enabled = True
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            TextBox1.Enabled = True
            txt1.Enabled = False
            txt1.Text = String.Empty
            Button1.Enabled = True
        Else
            TextBox1.Enabled = False
            txt1.Enabled = True
            Button1.Enabled = False
        End If
    End Sub
End Class