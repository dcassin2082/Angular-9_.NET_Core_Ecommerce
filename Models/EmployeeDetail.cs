using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal? Rate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string PayrollStatus { get; set; }
    }
}
