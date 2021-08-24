using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheet
    {
        public Worksheet()
        {
            Workbooks = new HashSet<Workbook>();
        }

        public int Id { get; set; }

        public virtual ICollection<Workbook> Workbooks { get; set; }
    }
}
