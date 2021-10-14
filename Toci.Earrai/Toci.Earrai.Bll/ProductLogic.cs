using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class ProductLogic : Logic<Product>, IProductLogic
    {
        protected IProductOptionValuesLogic ProductOVLogic = new ProductOptionValuesLogic();
        protected IProductSizeLogic ProductSizeLogic = new ProductSizeLogic();

        public ProductDto GetProduct(int productId)
        {
            ProductDto result = new ProductDto();

            result.Product = Select(m => m.Id == productId).FirstOrDefault();
            result.ProductOptions = ProductOVLogic.GetProductValues(productId);
            result.ProductSize = ProductSizeLogic.GetProductSizes(productId);

            return result;
        }
    }
}
