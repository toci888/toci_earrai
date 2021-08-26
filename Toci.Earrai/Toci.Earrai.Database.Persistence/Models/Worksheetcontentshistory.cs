using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheetcontentshistory
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Columnnumber { get; set; }
        public string Columnname { get; set; }
        public int? Rownumber { get; set; }
        public string Value { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}
