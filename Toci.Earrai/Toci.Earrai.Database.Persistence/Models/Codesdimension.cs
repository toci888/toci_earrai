using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Codesdimension
    {
        public Codesdimension()
        {
            Areaquantities = new HashSet<Areaquantity>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int? Kind { get; set; }

        public virtual ICollection<Areaquantity> Areaquantities { get; set; }
    }
}
