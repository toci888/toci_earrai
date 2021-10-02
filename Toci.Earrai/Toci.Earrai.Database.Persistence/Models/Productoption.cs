using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productoption
    {
        public Productoption()
        {
            Productcategoryoptions = new HashSet<Productcategoryoption>();
            Productoptionvalues = new HashSet<Productoptionvalue>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Productcategoryoption> Productcategoryoptions { get; set; }
        public virtual ICollection<Productoptionvalue> Productoptionvalues { get; set; }
    }
}
