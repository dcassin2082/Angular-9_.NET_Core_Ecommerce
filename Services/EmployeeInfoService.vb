Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class EmployeeInfoService
    Inherits ServicesBase
    Implements IEmployeeInfoService

    Public Function GetEmployees() As Task(Of IEnumerable(Of Employee)) Implements IEmployeeInfoService.GetEmployees
        Throw New NotImplementedException()
    End Function

    Public Function GetEmployees(predicate As Expression(Of Func(Of EmployeeInfo, Boolean))) As Task(Of List(Of EmployeeInfo)) Implements IEmployeeInfoService.GetEmployees
        Throw New NotImplementedException()
    End Function

    Public Function GetEmployee(id As Integer) As Task(Of Employee) Implements IEmployeeInfoService.GetEmployee
        Throw New NotImplementedException()
    End Function

    Public Function GetEmployee(predicate As Expression(Of Func(Of EmployeeInfo, Boolean))) As Task(Of EmployeeInfo) Implements IEmployeeInfoService.GetEmployee
        Throw New NotImplementedException()
    End Function

    Public Function PutEmployee(employee As EmployeeInfo) As Task(Of EmployeeInfo) Implements IEmployeeInfoService.PutEmployee
        Throw New NotImplementedException()
    End Function

    Public Function PostEmployee(employee As EmployeeInfo) As Task(Of EmployeeInfo) Implements IEmployeeInfoService.PostEmployee
        Throw New NotImplementedException()
    End Function

    Public Function DeleteEmployee(employee As EmployeeInfo) As Task(Of EmployeeInfo) Implements IEmployeeInfoService.DeleteEmployee
        Throw New NotImplementedException()
    End Function
End Class
