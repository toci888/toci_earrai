using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheet
    {
        public Worksheet()
        {
            Products = new HashSet<Product>();
            Worksheetcontents = new HashSet<Worksheetcontent>();
            Worksheetcontentshistories = new HashSet<Worksheetcontentshistory>();
        }

        public int Id { get; set; }
        public string Sheetname { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Worksheetcontent> Worksheetcontents { get; set; }
        public virtual ICollection<Worksheetcontentshistory> Worksheetcontentshistories { get; set; }
    }
}
