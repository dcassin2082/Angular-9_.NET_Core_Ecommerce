Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface IContactService
    Function GetContacts() As Task(Of List(Of Contact))
    Function GetContacts(ByVal predicate As Expression(Of Func(Of Contact, Boolean))) As Task(Of List(Of Contact))
    Function GetContact(ByVal id As Integer) As Task(Of Contact)
    Function GetContact(ByVal predicate As Expression(Of Func(Of Contact, Boolean))) As Task(Of Contact)
    Function PostContact(ByVal contact As Contact) As Task(Of Contact)
    Function PutContact(ByVal contact As Contact) As Task(Of Contact)
    Function DeleteContact(ByVal contact As Contact) As Task(Of Contact)
End Interface
