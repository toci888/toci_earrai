using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Workbookcontent
    {
        public int Id { get; set; }
        public int? Idworkbook { get; set; }
        public int? Columnnumber { get; set; }
        public string Columnname { get; set; }
        public int? Rownumber { get; set; }
        public string Value { get; set; }

        public virtual Workbook IdworkbookNavigation { get; set; }
    }
}
