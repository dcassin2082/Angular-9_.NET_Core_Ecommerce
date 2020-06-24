using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal? LineTotal { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public int? ItemCount { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public byte[] LargePhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public string DetailedDescription { get; set; }
    }
}
