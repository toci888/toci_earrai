using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public abstract class SearchProductBase
    {
        protected IProductLogic ProductLogic = new ProductLogic();
        protected Logic<Productsoptionsstate> ProductOptionsLogic = new Logic<Productsoptionsstate>();
        protected Logic<Productssize> ProductSizesLogic = new Logic<Productssize>();
        protected Logic<Areasquantity> AreasquantityLogic = new Logic<Areasquantity>();
        
        public abstract List<ProductDto> Search(ProductSearchRequestDto request);

        protected virtual List<ProductDto> SearchByStockTakeValue(List<ProductDto> products, ProductSearchRequestDto request)
        {
            double min = 0;
            double max = 0;

            double.TryParse(request.StockTakeValueMin, out min);
            double.TryParse(request.StockTakeValueMax, out max);

            if (min > 0 && max > 0)
            {
                return products.Where(m => m.Balance > min && m.Balance < max).ToList();
            }

            if (min > 0)
            {
                return products.Where(m => m.Balance > min).ToList();
            }

            if (max > 0)
            {
                return products.Where(m => m.Balance < max).ToList();
            }

            return products;
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

        protected virtual List<Productssize> GetSizes(string sizeKind, string value)
        {
            return ProductSizesLogic.Select(m => m.Name == sizeKind && m.Value == value).ToList();
        }

        protected virtual List<Product> FilterResultsSizesWorksheet(ProductSearchRequestDto request, List<Productssize> productFilteredBySize)
        {
            List<Product> result = new List<Product>();

            foreach (Productssize item in productFilteredBySize)
            {
                Product element = ProductLogic.Select(m => m.Idworksheet == request.WorksheetId && m.Id == item.Idproducts).FirstOrDefault();

                if (element != null)
                {
                    result.Add(element);
                }
            }

            return result;
        }

        protected virtual List<ProductDto> ToProductDto(List<Product> items)
        {
            List<ProductDto> result = new List<ProductDto>();

            foreach (Product item in items)
            {
                ProductDto pDto = ProductLogic.GetProduct(item.Id);

                result.Add(pDto);
            }

            return result;
        }

        

        protected virtual List<Product> FilterBySearchQuery(ProductSearchRequestDto request, List<Product> result)
        {
       
            return result;
        }
    }
}
