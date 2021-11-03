using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Quoteandprice
    {
        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Rowindex { get; set; }
        public string Price { get; set; }
        public int? Idvendor { get; set; }
        public int? Idquoteandmetric { get; set; }
        public int? Iduser { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Product IdproductsNavigation { get; set; }
        public virtual Quoteandmetric IdquoteandmetricNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
        public virtual Vendor IdvendorNavigation { get; set; }
    }
}
