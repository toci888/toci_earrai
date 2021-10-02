using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Commision
    {
        public int Id { get; set; }
        public int? Idcategories { get; set; }
        public string Title { get; set; }
        public double? Quotient { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
    }
}
