using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class Product1
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public byte[] LargePhoto { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public int? ProductSubcategoryId { get; set; }
    }
}
