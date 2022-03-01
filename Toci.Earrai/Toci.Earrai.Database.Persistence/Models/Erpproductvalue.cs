using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Erpproductvalue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? Iderpcolumn { get; set; }
        public int? Idproduct { get; set; }

        public virtual Erpcolumn IderpcolumnNavigation { get; set; }
        public virtual Product IdproductNavigation { get; set; }
    }
}
