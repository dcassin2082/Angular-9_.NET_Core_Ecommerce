Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface IEmployeeInfoService
    Inherits IDisposable

    Function GetEmployees() As Task(Of IEnumerable(Of Employee))
    Function GetEmployees(ByVal predicate As Expression(Of Func(Of EmployeeInfo, Boolean))) As Task(Of List(Of EmployeeInfo))
    Function GetEmployee(ByVal id As Integer) As Task(Of Employee)
    Function GetEmployee(ByVal predicate As Expression(Of Func(Of EmployeeInfo, Boolean))) As Task(Of EmployeeInfo)
    Function PutEmployee(ByVal employee As EmployeeInfo) As Task(Of EmployeeInfo)
    Function PostEmployee(ByVal employee As EmployeeInfo) As Task(Of EmployeeInfo)
    Function DeleteEmployee(ByVal employee As EmployeeInfo) As Task(Of EmployeeInfo)
End Interface
