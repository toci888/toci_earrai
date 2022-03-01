using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Erpproduct
    {
        public string Productaccountreference { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? Idproduct { get; set; }
    }
}
