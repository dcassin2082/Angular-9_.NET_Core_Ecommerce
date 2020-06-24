using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class SalesData
    {
        public int Id { get; set; }
        public int? Sales { get; set; }
        public DateTime? Day { get; set; }
        public string DateString { get; set; }
    }
}
