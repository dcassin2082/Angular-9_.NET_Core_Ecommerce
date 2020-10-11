Public MustInherit Class ServicesBase
    Implements IDisposable

    Protected _dbContext As EmployeeDBEntities

    Public Sub New()
        _dbContext = New EmployeeDBEntities()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _dbContext.Dispose()
    End Sub
End Class
