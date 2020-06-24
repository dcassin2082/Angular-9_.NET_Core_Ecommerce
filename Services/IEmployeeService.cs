using JungleApi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JungleApi.Web.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployees(Expression<Func<Employee, bool>> predicate);
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetEmployee(Expression<Func<Employee, bool>> predicate);
        Task<Employee> PostEmployee(Employee employee);
        Task<Employee> PutEmployee(Employee employee);
        Task<Employee> DeleteEmployee(Employee employee);
    }
}
