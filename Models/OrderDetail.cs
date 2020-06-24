using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApi.Web.Models
{
    public class OrderDetail
    {
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int OrderItemID { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public decimal LineTotal { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string LargePhotoFileName { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public int ItemCount { get; set; }
        public decimal Price { get; set; }

    }
    public class OrderSummary
    {
        /*OrderID	CustomerID	OrderDate	OrderTotal	OrderSubTotal	Tax	        ShippingCharge	CreatedDate	Shipped	ShipDate	CreatedBy	Carrier	ItemCount
           104	        10	    2018-07-06	51.92	    48.07	            3.85	0.00	        2018-07-06	1	    NULL	    1	        UPS	            1
           105	        10	    2018-03-24	331.08	    306.56              24.52	0.00	        2018-03-24	1	    NULL	    1	        UPS	        1
           106	        10	    2019-12-29	58.31	    53.99	            4.32	0.00	        2019-12-29	1	    NULL	    1	        UPS	        1
           107	        10	    2017-12-04	269.77	    249.79	            19.98	0.00	        2017-12-04	1	    NULL	    1	        UPS	        1
        * 
        * */
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCharge { get; set; }
        public bool Shipped { get; set; }
        public DateTime ShipDate { get; set; }
        public int CreatedBy { get; set; }
        public string Carrier { get; set; }
        public int ItemCount { get; set; }
        public decimal OrderSubTotal { get; set; }
        public List<OrderDetail> OrderItems { get; set; }
    }
}
