using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Workbook
    {
        public Workbook()
        {
            Workbookcontents = new HashSet<Workbookcontent>();
        }

        public int Id { get; set; }
        public int? Idworksheet { get; set; }

        public virtual Worksheet IdworksheetNavigation { get; set; }
        public virtual ICollection<Workbookcontent> Workbookcontents { get; set; }
    }
}
