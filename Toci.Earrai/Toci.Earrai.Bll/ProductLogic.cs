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
        protected Logic<Quoteandprice> ProductPriceLogic = new Logic<Quoteandprice>();
        protected IAreasquantitiesLogic ProductQuantitesLogic = new AreasquantitiesLogic();

        public ProductDto GetProduct(int productId)
        {
            ProductDto result = new ProductDto();

            result.Product = Select(m => m.Id == productId).FirstOrDefault();
            result.ProductOptions = ProductOVLogic.GetProductValues(productId);
            result.ProductSize = ProductSizeLogic.GetProductSizes(productId);
            result.ProductPrices = ProductPriceLogic.Select(m => m.Idproducts == productId).ToList();
            result.ProductQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(productId);

            return result;
        }
    }
}
