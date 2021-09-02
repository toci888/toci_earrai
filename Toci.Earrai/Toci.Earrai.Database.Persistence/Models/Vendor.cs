using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Quoteandprices = new HashSet<Quoteandprice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Quoteandprice> Quoteandprices { get; set; }
    }
}
