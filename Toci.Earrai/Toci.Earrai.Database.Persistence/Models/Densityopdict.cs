using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Densityopdict
    {
        public Densityopdict()
        {
            Densities = new HashSet<Density>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Density> Densities { get; set; }
    }
}
