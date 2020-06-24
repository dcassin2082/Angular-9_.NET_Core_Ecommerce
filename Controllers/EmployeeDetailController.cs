using JungleApi.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JungleApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        private JungleDbContext db = new JungleDbContext();

        public IEnumerable<EmployeeDetail> GetEmployees()
        {
            string[] departments = { "Sales South", "Sales North", "Sales East", "Sales West" };

            return db.EmployeeDetails.Where(d => departments.Any(e => e == d.Department)).OrderBy(f => f.FirstName).ToList();
        }

        [Route("saleshistory")]
        [HttpGet]
        public IEnumerable<SalesHistory> GetSalesHistories()
        {
            return db.SalesHistories;
        }
    }
}