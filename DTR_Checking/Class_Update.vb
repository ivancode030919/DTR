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

End Class
