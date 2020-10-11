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
    Public Class EmployeeInfoesController
        Inherits System.Web.Http.ApiController

        Private db As New EmployeeDBEntities

        ' GET: api/EmployeeInfoes
        Function GetEmployeeInfoes() As IQueryable(Of EmployeeInfo)
            Return db.EmployeeInfoes
        End Function

        ' GET: api/EmployeeInfoes/5
        <ResponseType(GetType(EmployeeInfo))>
        Async Function GetEmployeeInfo(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim employeeInfo As EmployeeInfo = Await db.EmployeeInfoes.FindAsync(id)
            If IsNothing(employeeInfo) Then
                Return NotFound()
            End If

            Return Ok(employeeInfo)
        End Function

        ' PUT: api/EmployeeInfoes/5
        <ResponseType(GetType(Void))>
        Async Function PutEmployeeInfo(ByVal id As Integer, ByVal employeeInfo As EmployeeInfo) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = employeeInfo.EmployeeID Then
                Return BadRequest()
            End If

            db.Entry(employeeInfo).State = EntityState.Modified

            Try
                Await db.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (EmployeeInfoExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/EmployeeInfoes
        <ResponseType(GetType(EmployeeInfo))>
        Async Function PostEmployeeInfo(ByVal employeeInfo As EmployeeInfo) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.EmployeeInfoes.Add(employeeInfo)
            Await db.SaveChangesAsync()

            Return CreatedAtRoute("DefaultApi", New With {.id = employeeInfo.EmployeeID}, employeeInfo)
        End Function

        ' DELETE: api/EmployeeInfoes/5
        <ResponseType(GetType(EmployeeInfo))>
        Async Function DeleteEmployeeInfo(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim employeeInfo As EmployeeInfo = Await db.EmployeeInfoes.FindAsync(id)
            If IsNothing(employeeInfo) Then
                Return NotFound()
            End If

            db.EmployeeInfoes.Remove(employeeInfo)
            Await db.SaveChangesAsync()

            Return Ok(employeeInfo)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function EmployeeInfoExists(ByVal id As Integer) As Boolean
            Return db.EmployeeInfoes.Count(Function(e) e.EmployeeID = id) > 0
        End Function
    End Class
End Namespace