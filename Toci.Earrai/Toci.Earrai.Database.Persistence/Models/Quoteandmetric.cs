using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Quoteandmetric
    {
        public Quoteandmetric()
        {
            Quoteandprices = new HashSet<Quoteandprice>();
        }

        public int Id { get; set; }
        public string Valuation { get; set; }

        public virtual ICollection<Quoteandprice> Quoteandprices { get; set; }
    }
}
