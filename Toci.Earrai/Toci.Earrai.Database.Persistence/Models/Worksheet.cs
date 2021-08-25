using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheet
    {
        public Worksheet()
        {
            Worksheetcontents = new HashSet<Worksheetcontent>();
        }

        public int Id { get; set; }
        public int? Idworkbook { get; set; }
        public string Sheetname { get; set; }

        public virtual Workbook IdworkbookNavigation { get; set; }
        public virtual ICollection<Worksheetcontent> Worksheetcontents { get; set; }
    }
}
