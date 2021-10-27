using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productsprice
    {
        public int? Idproducts { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Valuation { get; set; }
    }
}
