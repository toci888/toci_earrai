using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Sizecategory
    {
        public int Id { get; set; }
        public int? Idsizes { get; set; }
        public int? Idcategories { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
    }
}
