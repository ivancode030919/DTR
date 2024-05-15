
Public Class Class_Viewing

    Public Shared Function CountWP(ByVal Empid As String) As Object
        Try
            Dim curreteyear As Integer = DateTime.Now.Year

            ' Assuming db is an instance of your database context
            Dim query = (From p In db.tbl_Absents
                         Where p.UserID = Empid AndAlso p.Session = "WP" AndAlso p.Date.Value.Year = curreteyear
                         Select p).Count()
            Return query
        Catch ex As Exception
            ' Proper error handling
            ' Log the exception message
            Console.WriteLine("Error.F-22: " & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function CountHp(ByVal Empid As String) As Object
        Try
            Dim curreteyear As Integer = DateTime.Now.Year

            ' Assuming db is an instance of your database context
            Dim query = (From p In db.tbl_Absents
                         Where p.UserID = Empid AndAlso p.Session = "HP" AndAlso p.Date.Value.Year = curreteyear
                         Select p).Count()
            Return query
        Catch ex As Exception
            ' Proper error handling
            ' Log the exception message
            Console.WriteLine("Error.F-23: " & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function GetCompany(ByVal Empid As String) As Object
        Dim query = (From p In db.tbl_EmployeeInformations
                     Where p.EmpID = Empid
                     Select p.Company).FirstOrDefault()
        Return query

    End Function

    Public Shared Function GetLeaveIssue(ByVal Empid As String) As Object
        Dim query = (From p In db.tbl_EmployeeInformations
                     Where p.EmpID = Empid
                     Select p.LeaveIssue).FirstOrDefault()
        Return query

    End Function

    Public Shared Function GetRemaining(ByVal Empid As String) As Object
        Dim curreteyear As Integer = DateTime.Now.Year
        Dim query = (From p In db.tbl_Absents
                     Where p.UserID = Empid AndAlso p.Date.Value.Year = curreteyear
                     Select p).Count()
        Return query
    End Function

    Public Shared Function GetSeeionsCount(ByVal Empid As String) As Object
        Dim curreteyear As Integer = DateTime.Now.Year
        Dim query = (From p In db.tbl_Absents
                     Where p.UserID = Empid AndAlso p.Date.Value.Year = curreteyear AndAlso (p.Session = "HP" Or p.Session = "WP")
                     Group p By p.UserID, p.Session Into SessionGroup = Group
                     Select New With {
                     .UserID = UserID,
                     .Session = Session,
                     .Count = SessionGroup.Count()
                 }).ToList()

        Return query
    End Function


    Public Shared Function GetAbsent(ByVal Empid As String) As Object
        Dim curreteyear As Integer = DateTime.Now.Year
        Dim query = (From p In db.tbl_Absents
                     Where p.UserID = Empid AndAlso p.Date.Value.Year = curreteyear
                     Let x = "1"
                     Select p.UserID, p.Session, x).ToList
        Return query
    End Function

    Public Shared Function GetPayslipLeave(ByVal Empid As String) As Object

        Dim query = (From p In db.tbl_EmployeeInformations
                     Where p.EmpID = Empid
                     Select p.DaysLeave).FirstOrDefault
        Return query

    End Function

    Public Shared Sub GetEmployeeAllowance(ByVal Empid As String)

        'Dim query = (From p In db.tbl_Payrolls
        '             Join y In db.tbl_EmployeeInformations On p.EmpID Equals y.EmpID
        '             Where p.EmpID = Empid
        '             Select New With {p.NOD, y.DAllowance}).FirstOrDefault()
        'With Aadjustment
        '    '.Label5.Text = query.NOD.ToString
        '    .Label6.Text = query.DAllowance.ToString
        'End With

    End Sub

    Public Shared Function GetPayrolPeriod() As Object
        Dim curreteyear As Integer = DateTime.Now.Year

        Dim query = (From p In db.tbl_Payrolls
                     Where p.PeriodFrom.Value.Year = curreteyear
                     Order By p.PeriodFrom Descending
                     Let x = p.PeriodFrom.Value.Date + " to " + p.PeriodTo.Value.Date
                     Select x).Distinct().OrderByDescending(Function(period) period).ToList()
        Return query
    End Function


End Class
