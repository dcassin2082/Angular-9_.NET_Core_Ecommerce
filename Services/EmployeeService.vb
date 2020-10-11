Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class EmployeeService
    Inherits ServicesBase
    Implements IEmployeeService

    Private ReadOnly _employeeRepo As IRepository(Of Employee)

    Public Sub New()
        If _employeeRepo Is Nothing Then
            _employeeRepo = New Repository(Of Employee)(_dbContext)
        End If
    End Sub

    Public Async Function GetEmployees() As Task(Of List(Of Employee)) Implements IEmployeeService.GetEmployees
        Return Await _employeeRepo.GetAll()
    End Function

    Public Async Function GetEmployees(predicate As Expression(Of Func(Of Employee, Boolean))) As Task(Of List(Of Employee)) Implements IEmployeeService.GetEmployees
        Return Await _employeeRepo.GetAll(predicate)
    End Function

    Public Async Function GetEmployee(id As Integer) As Task(Of Employee) Implements IEmployeeService.GetEmployee
        Return Await _employeeRepo.GetSingle(id)
    End Function

    Public Async Function GetEmployee(predicate As Expression(Of Func(Of Employee, Boolean))) As Task(Of Employee) Implements IEmployeeService.GetEmployee
        Return Await _employeeRepo.GetSingle(predicate)
    End Function

    Public Async Function PostEmployee(employee As Employee) As Task(Of Employee) Implements IEmployeeService.PostEmployee
        Return Await _employeeRepo.Post(employee)
    End Function

    Public Async Function PutEmployee(employee As Employee) As Task(Of Employee) Implements IEmployeeService.PutEmployee
        Return Await _employeeRepo.Put(employee)
    End Function

    Public Async Function DeleteEmployee(employee As Employee) As Task(Of Employee) Implements IEmployeeService.DeleteEmployee
        Return Await _employeeRepo.Delete(employee)
    End Function
End Class
