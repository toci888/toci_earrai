using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Product
    {
        public Product()
        {
            Productoptionvalues = new HashSet<Productoptionvalue>();
            Productsizes = new HashSet<Productsize>();
        }

        public int Id { get; set; }
        public int? Idcategories { get; set; }
        public int? Idworksheet { get; set; }
        public int? Rowindex { get; set; }
        public string Productaccountreference { get; set; }
        public string Description { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
        public virtual Worksheet IdworksheetNavigation { get; set; }
        public virtual ICollection<Productoptionvalue> Productoptionvalues { get; set; }
        public virtual ICollection<Productsize> Productsizes { get; set; }
    }
}
