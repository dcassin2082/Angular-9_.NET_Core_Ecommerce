Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface ICompanyService
    Inherits IDisposable

    Function GetCompanies() As Task(Of List(Of Company))
    Function GetCompanies(predicate As Expression(Of Func(Of Company, Boolean))) As Task(Of List(Of Company))
    Function GetCompany(id As Integer) As Task(Of Company)
    Function GetCompany(predicate As Expression(Of Func(Of Company, Boolean))) As Task(Of Company)
    Function PutCompany(company As Company) As Task(Of Company)
    Function PostCompany(company As Company) As Task(Of Company)
    Function DeleteCompany(company As Company) As Task(Of Company)
End Interface
