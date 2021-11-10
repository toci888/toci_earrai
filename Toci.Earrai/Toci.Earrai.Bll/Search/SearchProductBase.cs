using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public abstract class SearchProductBase
    {
        protected Logic<Product> ProductLogic = new Logic<Product>();
        protected Logic<Productsoptionsstate> ProductOptionsLogic = new Logic<Productsoptionsstate>();

        public abstract List<ProductSearchResponseDto> Search(ProductSearchRequestDto request);

        protected virtual List<Product> GetProductsBasic(ProductSearchRequestDto request)
        {
            return ProductLogic.Select(prod => prod.Description.Contains(request.Name) && prod.Idworksheet == request.WorksheetId).ToList();
        }

        protected virtual List<Productsoptionsstate> GetOptions(string option, string value)
        {
            return ProductOptionsLogic.Select(m => m.Name == option && m.Value == value).ToList();
        }

        protected virtual List<Product> FilterResultsOptionsWorksheet(ProductSearchRequestDto request, List<Productsoptionsstate> productFilteredByOption)
        {
            List<Product> result = new List<Product>();

            foreach (Productsoptionsstate item in productFilteredByOption)
            {
                Product element = ProductLogic.Select(m => m.Idworksheet == request.WorksheetId && m.Id == item.Idproducts).First();

                if (element != null)
                {
                    result.Add(element);
                }
            }

            return result;
        }
    }
}
