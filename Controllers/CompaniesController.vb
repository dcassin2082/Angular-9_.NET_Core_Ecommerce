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
    Public Class CompaniesController
        Inherits System.Web.Http.ApiController

        Private db As New EmployeeDBEntities
        Private ReadOnly _companyService As ICompanyService

        Public Sub New()
            _companyService = New CompanyService()
        End Sub

        ' GET: api/Companies
        Async Function GetCompanies() As Task(Of IEnumerable(Of Company))
            Return Await _companyService.GetCompanies()
        End Function

        ' GET: api/Companies/5
        <ResponseType(GetType(Company))>
        Async Function GetCompany(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim company As Company = Await _companyService.GetCompany(id)

            If IsNothing(company) Then
                Return NotFound()
            End If

            Return Ok(company)
        End Function

        ' PUT: api/Companies/5
        <ResponseType(GetType(Void))>
        Async Function PutCompany(ByVal id As Integer, ByVal company As Company) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = company.CompanyId Then
                Return BadRequest()
            End If

            Dim result = Await _companyService.GetCompany(id)
            Try
                Await _companyService.PutCompany(company)
            Catch ex As DbUpdateConcurrencyException
                If result Is Nothing Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Companies
        <ResponseType(GetType(Company))>
        Async Function PostCompany(ByVal company As Company) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            Await _companyService.PostCompany(company)

            Return CreatedAtRoute("DefaultApi", New With {.id = company.CompanyId}, company)
        End Function

        ' DELETE: api/Companies/5
        <ResponseType(GetType(Company))>
        Async Function DeleteCompany(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim company As Company = Await _companyService.GetCompany(id)
            If IsNothing(company) Then
                Return NotFound()
            End If

            Await _companyService.DeleteCompany(company)

            Return Ok(company)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _companyService.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace