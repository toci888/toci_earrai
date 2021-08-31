﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Areaquantity
    {
        public int Id { get; set; }
        public int? Idworksheet { get; set; }
        public int? Idcodesdimensions { get; set; }
        public int? Idarea { get; set; }
        public int? Iduser { get; set; }
        public int? Rowindex { get; set; }
        public string Quantity { get; set; }
        public string Lengthdimensions { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Area IdareaNavigation { get; set; }
        public virtual Codesdimension IdcodesdimensionsNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
        public virtual Worksheet IdworksheetNavigation { get; set; }
    }
}