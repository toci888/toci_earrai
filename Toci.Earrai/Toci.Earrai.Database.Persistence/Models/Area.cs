using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Area
    {
        public Area()
        {
            Areaquantities = new HashSet<Areaquantity>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Areaquantity> Areaquantities { get; set; }
    }
}
