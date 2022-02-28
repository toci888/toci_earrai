using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Optionworksheetmap
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Idproductoptions { get; set; }

        public virtual Productoption IdproductoptionsNavigation { get; set; }
        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}
