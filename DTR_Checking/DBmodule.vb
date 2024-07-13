
Module DBmodule
    Public db As New DataClasses1DataContext("Data Source=172.16.2.3;Initial Catalog=Systems;User ID=sa;Password=0Oodgcdpay$vroO0;MultipleActiveResultSets=True;")
    'Public db As New DataClasses1DataContext("Data Source=172.16.10.218;Initial Catalog=Systems;User ID=HSDPI;Password=p@ssw0rd;MultipleActiveResultSets=True;")

    Sub New()
        db.CommandTimeout = 400
    End Sub

End Module
