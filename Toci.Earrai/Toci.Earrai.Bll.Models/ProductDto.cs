using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models
{
    public class ProductDto
    {
        public Product Product { get; set; }

        public List<Productsoptionsstate> Options { get; set; }

        public List<Productssize> Sizes { get; set; }

        public List<Productsprice> Prices { get; set; }

        public List<Areasquantity> AreaQuantities { get; set; }

        public PricingDto Pricing { get; set; }
    }
}
