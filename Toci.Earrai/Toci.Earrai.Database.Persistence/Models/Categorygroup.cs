using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Categorygroup
    {
        public Categorygroup()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
