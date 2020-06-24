using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class SalesHistory
    {
        public int SalesHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? SalesDate { get; set; }
        public decimal? Amount { get; set; }
        public int MonthId { get; set; }
        public string Month { get; set; }
    }
}
