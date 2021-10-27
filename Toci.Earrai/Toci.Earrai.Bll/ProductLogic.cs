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
        protected Logic<Productsprice> ProductPriceLogic = new Logic<Productsprice>();
        protected IAreasquantitiesLogic ProductQuantitesLogic = new AreasquantitiesLogic();

        public ProductDto GetProduct(int productId)
        {
            ProductDto result = new ProductDto();

            result.Product = Select(m => m.Id == productId).FirstOrDefault();
            result.Options = ProductOVLogic.GetProductValues(productId);
            result.Sizes = ProductSizeLogic.GetProductSizes(productId);
            result.Prices = ProductPriceLogic.Select(m => m.Idproducts == productId).ToList();
            result.AreaQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(productId);

            return result;
        }

        public List<Product> GetProductsByWorksheet(int worksheetId) {
            List<Product> result = new List<Product>();

            result = Select(m => m.Idworksheet == worksheetId).Take(5).ToList();
            //result.ProductOptions = ProductOVLogic.GetProductValues(worksheetId);
            //result.ProductSize = ProductSizeLogic.GetProductSizes(worksheetId);
            //result.ProductPrices = ProductPriceLogic.Select(m => m.Idproducts == worksheetId).ToList();
            //result.ProductQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(worksheetId);

            return result;
        }
    }
}
