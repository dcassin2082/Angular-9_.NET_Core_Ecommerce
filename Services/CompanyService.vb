Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class CompanyService
    Inherits ServicesBase
    Implements ICompanyService

    Private _companyRepo As IRepository(Of Company)
    Public Sub New()
        If _companyRepo Is Nothing Then
            _companyRepo = New Repository(Of Company)(_dbContext)
        End If
    End Sub

    Public Async Function GetCompanies() As Task(Of List(Of Company)) Implements ICompanyService.GetCompanies
        Return Await _companyRepo.GetAll()
    End Function

    Public Async Function GetCompanies(predicate As Expression(Of Func(Of Company, Boolean))) As Task(Of List(Of Company)) Implements ICompanyService.GetCompanies
        Return Await _companyRepo.GetAll(predicate)
    End Function

    Public Async Function GetCompany(id As Integer) As Task(Of Company) Implements ICompanyService.GetCompany
        Return Await _companyRepo.GetSingle(id)
    End Function

    Public Async Function GetCompany(predicate As Expression(Of Func(Of Company, Boolean))) As Task(Of Company) Implements ICompanyService.GetCompany
        Return Await _companyRepo.GetSingle(predicate)
    End Function

    Public Async Function PutCompany(company As Company) As Task(Of Company) Implements ICompanyService.PutCompany
        Return Await _companyRepo.Put(company)
    End Function

    Public Async Function PostCompany(company As Company) As Task(Of Company) Implements ICompanyService.PostCompany
        Return Await _companyRepo.Post(company)
    End Function

    Public Async Function DeleteCompany(company As Company) As Task(Of Company) Implements ICompanyService.DeleteCompany
        Return Await _companyRepo.Delete(company)
    End Function
End Class
