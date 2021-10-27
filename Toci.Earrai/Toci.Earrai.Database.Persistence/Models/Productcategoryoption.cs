using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productcategoryoption
    {
        public int Id { get; set; }
        public int? Idcategories { get; set; }
        public int? Idproductoptions { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
    }
}
