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

                pDto.Balance = GetBalance(pDto);

                result.Add(pDto);
            }

            return result;
        }

        protected virtual double GetBalance(ProductDto product)
        {
            //List<Areasquantity> areasquantities = AreasquantityLogic.Select(m => m.Idproducts == productId).ToList();
            double balance = 0;

            foreach (Areasquantity item in product.AreaQuantities)
            {
                double x = 0;

                double.TryParse(item.Quantity, out x);

                balance += x;
            }

            return balance;
        }

        protected virtual List<Product> FilterBySearchQuery(ProductSearchRequestDto request, List<Product> result)
        {
            /*if (!string.IsNullOrEmpty(request.Name))
            {
                if (result == null)
                {
                    //result = ProductLogic.Select(prod => prod.Description.Contains(phrase) && prod.Idworksheet == worksheetId).ToList();
                }
                else
                {
                    result = result.Where(m => m.Description.Contains(request.Name)).ToList();
                }
            }*/

            return result;
        }
    }
}
