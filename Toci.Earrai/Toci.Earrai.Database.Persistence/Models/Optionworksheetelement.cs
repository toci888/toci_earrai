using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Optionworksheetelement
    {
        public int? Idworksheet { get; set; }
        public int? Idproductoptions { get; set; }
        public string Name { get; set; }
    }
}
