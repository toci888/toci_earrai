using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Areasquantity
    {
        public int? Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Idcodesdimensions { get; set; }
        public int? Idarea { get; set; }
        public int? Iduser { get; set; }
        public int? Rowindex { get; set; }
        public string Quantity { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public DateTime? Createdat { get; set; }
        public string Areacode { get; set; }
        public string Areaname { get; set; }
        public string Initials { get; set; }
    }
}
