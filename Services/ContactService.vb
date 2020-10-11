Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class ContactService
    Inherits ServicesBase
    Implements IContactService

    Private ReadOnly _contactRepo As IRepository(Of Contact)

    Public Sub New()
        If _contactRepo Is Nothing Then
            _contactRepo = New Repository(Of Contact)(_dbContext)
        End If
    End Sub

    Public Async Function GetContacts() As Task(Of List(Of Contact)) Implements IContactService.GetContacts
        Return Await _contactRepo.GetAll()
    End Function

    Public Async Function GetContacts(predicate As Expression(Of Func(Of Contact, Boolean))) As Task(Of List(Of Contact)) Implements IContactService.GetContacts
        Return Await _contactRepo.GetAll(predicate)
    End Function

    Public Async Function GetContact(id As Integer) As Task(Of Contact) Implements IContactService.GetContact
        Return Await _contactRepo.GetSingle(id)
    End Function

    Public Async Function GetContact(predicate As Expression(Of Func(Of Contact, Boolean))) As Task(Of Contact) Implements IContactService.GetContact
        Return Await _contactRepo.GetSingle(predicate)
    End Function

    Public Async Function PostContact(contact As Contact) As Task(Of Contact) Implements IContactService.PostContact
        Return Await _contactRepo.Post(contact)
    End Function

    Public Async Function PutContact(contact As Contact) As Task(Of Contact) Implements IContactService.PutContact
        Return Await _contactRepo.Put(contact)
    End Function

    Public Async Function DeleteContact(contact As Contact) As Task(Of Contact) Implements IContactService.DeleteContact
        Return Await _contactRepo.Delete(contact)
    End Function
End Class
