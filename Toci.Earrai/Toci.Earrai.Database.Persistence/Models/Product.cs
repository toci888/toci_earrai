using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Product
    {
        public Product()
        {
            Areaquantities = new HashSet<Areaquantity>();
            Erpproductvalues = new HashSet<Erpproductvalue>();
            Productoptionvalues = new HashSet<Productoptionvalue>();
            Productsizes = new HashSet<Productsize>();
            Quoteandprices = new HashSet<Quoteandprice>();
        }

        public int Id { get; set; }
        public int? Idcategories { get; set; }
        public int? Idworksheet { get; set; }
        public int? Rowindex { get; set; }
        public string Productaccountreference { get; set; }
        public string Description { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
        public virtual Worksheet IdworksheetNavigation { get; set; }
        public virtual ICollection<Areaquantity> Areaquantities { get; set; }
        public virtual ICollection<Erpproductvalue> Erpproductvalues { get; set; }
        public virtual ICollection<Productoptionvalue> Productoptionvalues { get; set; }
        public virtual ICollection<Productsize> Productsizes { get; set; }
        public virtual ICollection<Quoteandprice> Quoteandprices { get; set; }
    }
}
