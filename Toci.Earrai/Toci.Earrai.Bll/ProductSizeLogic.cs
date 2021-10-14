using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class ProductSizeLogic : Logic<Productsize>, IProductSizeLogic
    {
        protected Logic<Productssize> ProductssizeLogic = new Logic<Productssize>();

        public List<Productssize> GetProductSizes(int productId)
        {
            return ProductssizeLogic.Select(m => m.Idproducts == productId).ToList();
        }
    }
}
