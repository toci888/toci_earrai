using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productoptionsearch
    {
        public int? Idproduct { get; set; }
        public int? Idworksheet { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
}
