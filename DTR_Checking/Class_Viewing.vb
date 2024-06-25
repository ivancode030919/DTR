
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

    Public Shared Function GetPayrolPeriod() As Object
        Dim curreteyear As Integer = DateTime.Now.Year

        Dim query = (From p In db.tbl_Payrolls
                     Where p.PeriodFrom.Value.Year = curreteyear
                     Order By p.PeriodFrom Descending
                     Let x = p.PeriodFrom.Value.Date + " to " + p.PeriodTo.Value.Date
                     Select x).Distinct().OrderByDescending(Function(period) period).ToList()
        Return query
    End Function

    Public Shared Sub GetEmployeeAllowance(ByVal PeriodFrom As Date, ByVal Empname As String)
        Try
            Dim q = (From p In db.tbl_Payrolls
                     Join y In db.tbl_EmployeeInformations On p.EmpID Equals y.EmpID
                     Join z In db.tbl_EmployeeRequirements On p.EmpID Equals z.EmpID
                     Join zz In db.tbl_OtherDetails On p.EmpID Equals zz.EmpID
                     Where (p.Name = Empname) And p.PeriodFrom.Value.Date = PeriodFrom And zz.DFrom.Value.Date = PeriodFrom
                     Select New With {
                            p.TSalary, zz.AbsentDate, p.Holiday, p.SOthers, p.ColaPD, p.Cola, p.Overtime, p.RatePD, p.Rate, p.NOD,
                             y.DAllowance, p.Name, p.EmpID, p.Pagibig, z.PagibigNumber, p.SSS, z.SSSNumber,
                             p.PhilHealth, z.PhiNumber, p.SSSLoan, p.SSSB, p.PLoan, p.PagibigB, p.Position, p.WTax, z.TINNUmber,
                             p.OD, p.ODB, p.TDeduction, p.Net, zz.OADet, p.F2S, p.F2SB, y.DaysLeave, zz.OSDet, zz.OTHours,
                             zz.HolDet, y.ZKNo, p.DOthers, p.OthersB, p.CalamityLoan, p.CalamityB, p.CalamitySSSB, p.CalamityLoanSSS
                         }).FirstOrDefault()
            If q IsNot Nothing Then
                'With Aadjustment
                '    .EIDtxt.Text = q.EmpID.ToString()
                '    .SSStxt.Text = Decimal.Parse(q.SSS.Value).ToString("F2")
                '    .Pagibigtxt.Text = Decimal.Parse(q.Pagibig.Value).ToString("F2")
                '    .Philtxt.Text = Decimal.Parse(q.PhilHealth.Value).ToString("F2")
                '    .Unittxt.Text = Integer.Parse(q.NOD.ToString)
                '    .allowancetxt.Text = Decimal.Parse(q.DAllowance).ToString("F2")
                '    .Pallowancetxt.Text = Decimal.Parse(q.SOthers).ToString("F2")
                '    .Adescription.Text = q.OSDet.ToString
                'End With

                With Payslip

                    .EIDtxt.Text = q.EmpID.ToString()
                    .Nodtxt.Text = Decimal.Parse(q.NOD).ToString("F1")
                    .Ratetxt.Text = Decimal.Parse(q.RatePD).ToString("F2")
                    .Ottxt.Text = q.OTHours.ToString
                    .Holidaytxt.Text = q.HolDet.ToString
                    .otherstxt.Text = q.OSDet.ToString
                    .Grosstxt.Text = Decimal.Parse(q.TSalary).ToString("F2")
                    .tsalarytxt.Text = Decimal.Parse(q.Rate).ToString("F2")
                    .Tottxt.Text = Decimal.Parse(q.Overtime).ToString("F2")
                    .Tholidaytxt.Text = Decimal.Parse(q.Holiday).ToString("F2")
                    .SOtherstxt.Text = Decimal.Parse(q.SOthers).ToString("F3")
                    .Ssstxt.Text = Decimal.Parse(q.SSS).ToString("F2")
                    .SssloanBtxt.Text = Decimal.Parse(q.SSSB).ToString("F2")
                    .Sssloantxt.Text = Decimal.Parse(q.SSSLoan).ToString("F2")
                    .Sssaccounttxt.Text = q.SSSNumber.ToString
                    .Pnotxt.Text = q.PagibigNumber.ToString
                    .pagibigtxt.Text = Decimal.Parse(q.Pagibig).ToString("F2")
                    .Pbaltxt.Text = Decimal.Parse(q.PagibigB).ToString("F2")
                    .pagibigloantxt.Text = Decimal.Parse(q.PLoan).ToString("F2")
                    .Philhealthtxt.Text = q.PhiNumber.ToString
                    .Philtxt.Text = Decimal.Parse(q.PhilHealth).ToString("F2")
                    .Label30.Text = "Leave : " + q.DaysLeave.ToString
                    .Nettxt.Text = "Php " + Decimal.Parse(q.Net).ToString("F2")
                    .TDeducttxt.Text = "        " + Decimal.Parse(q.TDeduction).ToString("F2")
                    .zktxt.Text = q.ZKNo.ToString
                    .postxt.Text = q.Position.ToString
                    .Dallowance = Decimal.Parse(q.DAllowance).ToString("F2")
                    .Dotherstxt.Text = Decimal.Parse(q.DOthers).ToString("F2")
                    .Wtaxnotxt.Text = q.TINNUmber.ToString
                    .OthersBtxt.Text = Decimal.Parse(q.OthersB).ToString("F2")
                    .WtaxAmounttxt.Text = Decimal.Parse(q.WTax).ToString("F2")
                    .CalLoanPagibigtxt.Text = Decimal.Parse(q.CalamityLoan).ToString("F2")
                    .CalLoanPagibigloantxt.Text = Decimal.Parse(q.CalamityB).ToString("F2")
                    .CalLoanSssBtxt.Text = Decimal.Parse(q.CalamitySSSB).ToString("F2")
                    .CalLoanSssloantxt.Text = Decimal.Parse(q.CalamityLoanSSS).ToString("F2")
                    .ODBtxt.Text = Decimal.Parse(q.ODB).ToString("F2")
                    .ODPtxt.Text = Decimal.Parse(q.OD).ToString("F2")
                    .OADettxt.Text = q.OADet.ToString
                End With
            End If
        Catch ex As Exception
            Console.WriteLine("Invalid Input..." & ex.Message)
        End Try
    End Sub

    Public Shared Function GetEmployee() As List(Of String)
        ' Retrieve top 10 distinct employee names from the tbl_Payrolls table
        Dim currentYear As Integer = Date.Now.Year

        ' Create the query to select distinct employee names for the current year
        Dim query = (From p In db.tbl_Payrolls
                     Where p.PeriodFrom.Value.Year = currentYear
                     Select p.Name).Distinct()

        ' Execute the query and return the results as a list
        Return query.ToList()
    End Function



    Public Shared Function GetOT(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal Empname As String)

        Dim query = db.SP_CheckOT(DateFrom, DateTo, Empname)

        Return query

    End Function





End Class
