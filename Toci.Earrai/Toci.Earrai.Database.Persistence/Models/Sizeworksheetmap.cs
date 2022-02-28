using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Sizeworksheetmap
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Idsizes { get; set; }

        public virtual Size IdsizesNavigation { get; set; }
        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}
