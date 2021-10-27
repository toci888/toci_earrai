using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productsize
    {
        public int Id { get; set; }
        public int? Idsizes { get; set; }
        public int? Idproducts { get; set; }
        public string Value { get; set; }

        public virtual Product IdproductsNavigation { get; set; }
    }
}
