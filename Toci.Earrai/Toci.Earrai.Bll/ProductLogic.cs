using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Calculations.Pricing;
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

        public virtual ProductDto GetProduct(int productId)
        {
            ProductDto result = new ProductDto();
            result.Product = Select(m => m.Id == productId).FirstOrDefault();
            result.Options = ProductOVLogic.GetProductValues(productId);
            result.Sizes = ProductSizeLogic.GetProductSizes(productId);
            result.Prices = ProductPriceLogic.Select(m => m.Idproducts == productId).ToList();
            result.AreaQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(productId);

            PriceExecutor priceExec = new PriceExecutor(result);

            result.Pricing = priceExec.getPrices();

            return result;
        }

        public virtual List<ProductDto> GetProducts(int worksheetId, string fieldName, string fieldValue)
        {
            List<ProductDto> result = new List<ProductDto>();

            List<Product> products = Select(m => m.Idworksheet == worksheetId).ToList();

            foreach (Product item in products)
            {
                result.Add(GetProduct(item.Id));
            }

            return result;
        }

        public List<ProductDto> GetProductsByWorksheet(int worksheetId) 
        {
            List<Product> products = Select(m => m.Idworksheet == worksheetId).ToList();

            return products.Select(item => GetProduct(item.Id)).ToList();
        }
    }
}
