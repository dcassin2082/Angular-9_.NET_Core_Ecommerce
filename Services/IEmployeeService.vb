Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface IEmployeeService
    Function GetEmployees() As Task(Of List(Of Employee))
    Function GetEmployees(ByVal predicate As Expression(Of Func(Of Employee, Boolean))) As Task(Of List(Of Employee))
    Function GetEmployee(ByVal id As Integer) As Task(Of Employee)
    Function GetEmployee(ByVal predicate As Expression(Of Func(Of Employee, Boolean))) As Task(Of Employee)
    Function PostEmployee(ByVal employee As Employee) As Task(Of Employee)
    Function PutEmployee(ByVal employee As Employee) As Task(Of Employee)
    Function DeleteEmployee(ByVal employee As Employee) As Task(Of Employee)
End Interface
