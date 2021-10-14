using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class ProductOptionValuesLogic : Logic<Productoptionvalue>, IProductOptionValuesLogic
    {
        protected Logic<Productsoptionsstate> ProductsoptionsstateLogic = new Logic<Productsoptionsstate>();

        public List<Productsoptionsstate> GetProductValues(int productId)
        {
            return ProductsoptionsstateLogic.Select(m => m.Idproducts == productId).ToList();
        }
    }
}
