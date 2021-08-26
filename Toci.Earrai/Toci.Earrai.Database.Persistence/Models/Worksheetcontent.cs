using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheetcontent
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Columnindex { get; set; }
        public int? Rowindex { get; set; }
        public string Value { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}
