using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Quotesandprice
    {
        public int? Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Rowindex { get; set; }
        public string Price { get; set; }
        public int? Idvendor { get; set; }
        public int? Idquoteandmetric { get; set; }
        public int? Iduser { get; set; }
        public string Valuation { get; set; }
        public string Vendor { get; set; }
        public string Initials { get; set; }
        public DateTime? Createdat { get; set; }
    }
}
