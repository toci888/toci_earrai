using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Erpcolumn
    {
        public Erpcolumn()
        {
            Erpproductvalues = new HashSet<Erpproductvalue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Erpproductvalue> Erpproductvalues { get; set; }
    }
}
