using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Rowindex { get; set; }
        public string Category { get; set; }
        public string Productaccountreference { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Thickness { get; set; }

        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}
