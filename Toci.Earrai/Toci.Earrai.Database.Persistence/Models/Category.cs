using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Category
    {
        public Category()
        {
            Commisions = new HashSet<Commision>();
            Productcategoryoptions = new HashSet<Productcategoryoption>();
            Products = new HashSet<Product>();
            Sizecategories = new HashSet<Sizecategory>();
        }

        public int Id { get; set; }
        public int? Idcategorygroups { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public virtual Categorygroup IdcategorygroupsNavigation { get; set; }
        public virtual ICollection<Commision> Commisions { get; set; }
        public virtual ICollection<Productcategoryoption> Productcategoryoptions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Sizecategory> Sizecategories { get; set; }
    }
}
