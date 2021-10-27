using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productoptionvalue
    {
        public int Id { get; set; }
        public int? Idproductoptions { get; set; }
        public int? Idproducts { get; set; }
        public string Value { get; set; }

        public virtual Product IdproductsNavigation { get; set; }
    }
}
