using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class SalesByCategoryAndYear
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Year { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public decimal? Amount { get; set; }
    }
}
