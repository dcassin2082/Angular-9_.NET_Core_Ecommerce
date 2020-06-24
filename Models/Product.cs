using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class Product
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
        public decimal? Weight { get; set; }
        public string Size { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public int? LineCount { get; set; }
    }
}
