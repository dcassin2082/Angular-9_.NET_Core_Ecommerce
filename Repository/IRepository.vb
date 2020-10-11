Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface IRepository(Of T)
    Function GetAll() As Task(Of List(Of T))
    Function GetAll(ByVal predicate As Expression(Of Func(Of T, Boolean))) As Task(Of List(Of T))
    Function GetSingle(ByVal id As Integer) As Task(Of T)
    Function GetSingle(ByVal predicate As Expression(Of Func(Of T, Boolean))) As Task(Of T)
    Function Post(ByVal entity As T) As Task(Of T)
    Function Put(ByVal entity As T) As Task(Of T)
    Function Delete(ByVal entity As T) As Task(Of T)

End Interface

