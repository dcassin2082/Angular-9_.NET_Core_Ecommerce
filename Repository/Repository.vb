Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class Repository(Of T As Class)
    Implements IRepository(Of T)

    Friend _dbContext As DbContext
    Friend _dbSet As DbSet(Of T)

    Public Sub New(dbContext As DbContext)
        _dbContext = dbContext
        _dbSet = _dbContext.Set(Of T)
    End Sub

    Public Async Function GetAll() As Task(Of List(Of T)) Implements IRepository(Of T).GetAll
        Return Await _dbSet.ToListAsync()
    End Function

    Public Async Function GetAll(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of List(Of T)) Implements IRepository(Of T).GetAll
        Return Await _dbSet.AsQueryable().Where(predicate).ToListAsync()
    End Function

    Public Async Function GetSingle(id As Integer) As Task(Of T) Implements IRepository(Of T).GetSingle
        Return Await _dbSet.FindAsync(id)
    End Function

    Public Async Function GetSingle(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of T) Implements IRepository(Of T).GetSingle
        Return Await _dbSet.AsQueryable().Where(predicate).FirstOrDefaultAsync()
    End Function

    Public Async Function Post(entity As T) As Task(Of T) Implements IRepository(Of T).Post
        _dbSet.Add(entity)
        Await _dbContext.SaveChangesAsync()
        Return entity
    End Function

    Public Async Function Put(entity As T) As Task(Of T) Implements IRepository(Of T).Put
        _dbContext.Set(Of T).AddOrUpdate(entity)
        Await _dbContext.SaveChangesAsync()
        Return entity
    End Function

    Public Async Function Delete(entity As T) As Task(Of T) Implements IRepository(Of T).Delete
        _dbSet.Remove(entity)
        Await _dbContext.SaveChangesAsync()
        Return entity
    End Function
End Class
