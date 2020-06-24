using System;
using System.Collections.Generic;

namespace JungleApi.Web.Models
{
    public partial class Trackball
    {
        public int Id { get; set; }
        public DateTime? X { get; set; }
        public int? Y { get; set; }
        public int? Y1 { get; set; }
        public int? Y2 { get; set; }
        public int? Y3 { get; set; }
        public int? Y4 { get; set; }
    }
}
