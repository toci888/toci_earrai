using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Earrai.Database.Persistence.Models
{
    public partial class Productssize
    {
        public int? Id { get; set; }
        public int? Idproducts { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }
}
