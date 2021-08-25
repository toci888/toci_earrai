﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Workbook
    {
        public Workbook()
        {
            Worksheets = new HashSet<Worksheet>();
        }

        public int Id { get; set; }
        public string Filename { get; set; }

        public virtual ICollection<Worksheet> Worksheets { get; set; }
    }
}