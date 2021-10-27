using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Density
    {
        public int Id { get; set; }
        public int? Iddensityopdict { get; set; }
        public int? Iddensitymaterial { get; set; }
        public string Value { get; set; }

        public virtual Densitymaterial IddensitymaterialNavigation { get; set; }
        public virtual Densityopdict IddensityopdictNavigation { get; set; }
    }
}
