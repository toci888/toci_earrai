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

        public List<Productsoptionsstate> ProductOptions { get; set; }

        public List<Productssize> ProductSize { get; set; }
    }
}
