using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class CustomerOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderTotal { get; set; }
        public decimal? OrderSubTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? ShippingCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Shipped { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? CreatedBy { get; set; }
        public string Carrier { get; set; }
        public int? ItemCount { get; set; }
    }
}
