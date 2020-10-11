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
    Public Class ContactsController
        Inherits System.Web.Http.ApiController

        Private db As New EmployeeDBEntities

        Public Sub New()
        End Sub

        ' GET: api/Contacts
        Function GetContacts() As IQueryable(Of Contact)
            Return db.Contacts
        End Function

        ' GET: api/Contacts/5
        <ResponseType(GetType(Contact))>
        Async Function GetContact(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim contact As Contact = Await db.Contacts.FindAsync(id)
            If IsNothing(contact) Then
                Return NotFound()
            End If

            Return Ok(contact)
        End Function

        ' PUT: api/Contacts/5
        <ResponseType(GetType(Void))>
        Async Function PutContact(ByVal id As Integer, ByVal contact As Contact) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = contact.ContactID Then
                Return BadRequest()
            End If

            db.Entry(contact).State = EntityState.Modified

            Try
                Await db.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (ContactExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Contacts
        <ResponseType(GetType(Contact))>
        Async Function PostContact(ByVal contact As Contact) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Contacts.Add(contact)
            Await db.SaveChangesAsync()

            Return CreatedAtRoute("DefaultApi", New With {.id = contact.ContactID}, contact)
        End Function

        ' DELETE: api/Contacts/5
        <ResponseType(GetType(Contact))>
        Async Function DeleteContact(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim contact As Contact = Await db.Contacts.FindAsync(id)
            If IsNothing(contact) Then
                Return NotFound()
            End If

            db.Contacts.Remove(contact)
            Await db.SaveChangesAsync()

            Return Ok(contact)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ContactExists(ByVal id As Integer) As Boolean
            Return db.Contacts.Count(Function(e) e.ContactID = id) > 0
        End Function
    End Class
End Namespace