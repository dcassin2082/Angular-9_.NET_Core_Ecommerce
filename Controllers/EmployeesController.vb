Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports WebApplication2

Namespace Controllers
    Public Class EmployeesController
        Inherits System.Web.Http.ApiController

        Private db As New EmployeeDBEntities
        Private ReadOnly _employeeService As IEmployeeService

        Public Sub New(employeeService As IEmployeeService)
            _employeeService = employeeService
        End Sub

        Public Sub New()
            _employeeService = New EmployeeService()
        End Sub

        ' GET: api/Employees1
        Async Function GetEmployees() As Task(Of IEnumerable(Of Employee))
            Return Await _employeeService.GetEmployees()
        End Function

        ' GET: api/Employees1/5
        <ResponseType(GetType(Employee))>
        Async Function GetEmployee(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim employee As Employee = Await _employeeService.GetEmployee(id)
            If IsNothing(employee) Then
                Return NotFound()
            End If

            Return Ok(employee)
        End Function

        ' PUT: api/Employees1/5
        <ResponseType(GetType(Void))>
        Async Function PutEmployee(ByVal id As Integer, ByVal employee As Employee) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = employee.EmployeeID Then
                Return BadRequest()
            End If

            Dim result = Await _employeeService.GetEmployee(id)

            Try
                Await _employeeService.PutEmployee(employee)
            Catch ex As DbUpdateConcurrencyException
                If result Is Nothing Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Employees1
        <ResponseType(GetType(Employee))>
        Async Function PostEmployee(ByVal employee As Employee) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Await _employeeService.PostEmployee(employee)
            Return CreatedAtRoute("DefaultApi", New With {.id = employee.EmployeeID}, employee)
        End Function

        ' DELETE: api/Employees1/5
        <ResponseType(GetType(Employee))>
        Async Function DeleteEmployee(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim employee As Employee = Await _employeeService.GetEmployee(id)
            If IsNothing(employee) Then
                Return NotFound()
            End If

            Await _employeeService.DeleteEmployee(employee)

            Return Ok(employee)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace