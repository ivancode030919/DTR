Public Class Class_Update

    Public Shared Function GetEmployee() As System.Data.Linq.Table(Of tbl_EmployeeInformation)
        Return db.GetTable(Of tbl_EmployeeInformation)()
    End Function

    Public Shared Sub UpdatePVMReleasing(ByVal Emplid As String, ByVal InputLeave As Double)

        Dim Status As String = "Closed"
        Try

            Dim updatemode = (From p In db.GetTable(Of tbl_EmployeeInformation)()
                              Where (p.EmpID = Emplid)
                              Select p).FirstOrDefault()

            With updatemode
                .DaysLeave = InputLeave
            End With

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub


    Public Shared Sub RemoveManadatory(ByVal Empid As String, ByVal Pdate As Date,
                                       ByVal NOD As Double, ByVal HOLID As Double,
                                       ByVal OT As Double, ByVal SOthers As Double,
                                       ByVal SOtherDetails As String, ByVal SSS As Double,
                                       ByVal PhilHealth As Double, ByVal Pagibig As Double,
                                       ByVal SSSb As Double, ByVal PagibigB As Double,
                                       ByVal OthersB As Double, ByVal SSSLoan As Double,
                                       ByVal PagibigLoan As Double, ByVal Dothers As Double,
                                       ByVal DothersDetails As String, ByVal HolidayDetails As String, ByVal Wtax As Double)

        db.SP_PayrollAdjustment(Empid, Pdate, NOD, HOLID, OT, SOthers, SOtherDetails, SSS, PhilHealth, Pagibig,
                                SSSb, PagibigB, OthersB, SSSLoan, PagibigLoan, Dothers, DothersDetails, HolidayDetails, Wtax)

        MessageBox.Show("Successfully Updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
