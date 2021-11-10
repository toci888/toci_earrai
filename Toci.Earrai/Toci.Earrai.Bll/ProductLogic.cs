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

        public ProductDto GetProduct(int productId)
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

        public List<Product> GetProductsByWorksheet(int worksheetId, string phrase, int skip) {
            List<Product> result = new List<Product>();

            int toSkip = skip * 5;

            phrase = phrase == "empty" ? "" : phrase;

            result = Select(prod => prod.Description.Contains(phrase) && prod.Idworksheet == worksheetId)
                        .Skip(toSkip)
                        .Take(5)
                        .ToList();

            //result.ProductOptions = ProductOVLogic.GetProductValues(worksheetId);
            //result.ProductSize = ProductSizeLogic.GetProductSizes(worksheetId);
            //result.ProductPrices = ProductPriceLogic.Select(m => m.Idproducts == worksheetId).ToList();
            //result.ProductQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(worksheetId);

            return result;
        }
    }
}
