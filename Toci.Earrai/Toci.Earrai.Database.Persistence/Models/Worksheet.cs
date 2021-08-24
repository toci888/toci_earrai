using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheet
    {
        public Worksheet()
        {
            InverseIdworkbooksNavigation = new HashSet<Worksheet>();
            Worksheetcontents = new HashSet<Worksheetcontent>();
        }

        public int Id { get; set; }
        public int? Idworkbooks { get; set; }
        public string Sheetname { get; set; }

        public virtual Worksheet IdworkbooksNavigation { get; set; }
        public virtual ICollection<Worksheet> InverseIdworkbooksNavigation { get; set; }
        public virtual ICollection<Worksheetcontent> Worksheetcontents { get; set; }
    }
}
