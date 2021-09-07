using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Worksheet
    {
        public Worksheet()
        {
            Areaquantities = new HashSet<Areaquantity>();
            Quoteandprices = new HashSet<Quoteandprice>();
            Stocks = new HashSet<Stock>();
            Worksheetcontents = new HashSet<Worksheetcontent>();
            Worksheetcontentshistories = new HashSet<Worksheetcontentshistory>();
        }

        public int Id { get; set; }
        public int? Idworkbook { get; set; }
        public string Sheetname { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Workbook IdworkbookNavigation { get; set; }
        public virtual ICollection<Areaquantity> Areaquantities { get; set; }
        public virtual ICollection<Quoteandprice> Quoteandprices { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Worksheetcontent> Worksheetcontents { get; set; }
        public virtual ICollection<Worksheetcontentshistory> Worksheetcontentshistories { get; set; }
    }
}
