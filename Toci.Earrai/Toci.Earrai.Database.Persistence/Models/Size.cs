using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Size
    {
        public Size()
        {
            Productsizes = new HashSet<Productsize>();
            Sizecategories = new HashSet<Sizecategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Productsize> Productsizes { get; set; }
        public virtual ICollection<Sizecategory> Sizecategories { get; set; }
    }
}
