using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class ProductMobileLogic : ProductLogic
    {
        public override List<ProductDto> GetProductsByWorksheet(int worksheetId)
        {
            List<Product> products = Select(m => m.Idworksheet == worksheetId).ToList();

            return GetSearchResult(products);
        }

        protected virtual List<ProductDto> GetSearchResult(List<Product> products)
        {
            List<ProductDto> results = new List<ProductDto>();

            foreach (Product item in products)
            {
                ProductDto result = new ProductDto();

                result.Product = item;

                result.AreaQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(item.Id);

                result.Balance = GetBalance(result);

                results.Add(result);
            }

            return results;
        }
    }
}
