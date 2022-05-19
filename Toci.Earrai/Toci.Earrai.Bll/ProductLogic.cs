using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
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
        protected IQuoteandpriceLogic QuoteandpriceLogic = new QuoteandpriceLogic();

        public virtual ProductDto GetProduct(int productId)
        {
            ProductDto result = new ProductDto();
            result.Product = Select(m => m.Id == productId).FirstOrDefault();
            result.Options = RoundKgSheet(ProductOVLogic.GetProductValues(productId));
            result.Sizes = ProductSizeLogic.GetProductSizes(productId);
            result.Prices = RoundPrices(ProductPriceLogic.Select(m => m.Idproducts == productId).ToList());
            result.AreaQuantities = ProductQuantitesLogic.GetAreasQuantitiesByRowIndexAndWorksheet(productId);
            result.Quotesandprices = RoundQuotesAndPrices(QuoteandpriceLogic.GetAllQuotesAndPricesView(productId));

            PriceExecutor priceExec = new PriceExecutor(result);

            result.Pricing = priceExec.GetPrices();

            result.Balance = GetBalance(result);

            return result;
        }

        protected virtual List<Productsoptionsstate> RoundKgSheet(List<Productsoptionsstate> productsoptionsstate)
        {
            foreach (Productsoptionsstate item in productsoptionsstate)
            {
                double price = 0;

                double.TryParse(item.Value, out price);

                item.Value = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString();
            }

            return productsoptionsstate;
        }

        protected virtual List<Quotesandprice> RoundQuotesAndPrices(List<Quotesandprice> quotesandprices)
        {
            foreach (Quotesandprice item in quotesandprices)
            {
                double price = 0;

                double.TryParse(item.Price, out price);

                item.Price = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString();
            }

            return quotesandprices;
        }

        protected virtual List<Productsprice> RoundPrices(List<Productsprice> prices)
        {
            foreach (Productsprice item in prices)
            {
                double price = 0;

                double.TryParse(item.Price, out price);

                item.Price = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString();
            }

            return prices;
        }

        public virtual int AddNewProduct(NewProductDto dto)
        {
            Product newProduct = Insert(new Product() { Description = dto.Description, Idworksheet = dto.WorksheetId, Productaccountreference = dto.Reference });

            ProductOVLogic.SetNewProductOptions(newProduct.Id, dto.Options);
            ProductSizeLogic.SetNewProductSizes(newProduct.Id, dto.Sizes);

            return newProduct.Id;
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

        public virtual  List<ProductDto> GetProductsByWorksheet(int worksheetId) 
        {
            List<Product> products = Select(m => m.Idworksheet == worksheetId).ToList();

            return products.Select(item => GetProduct(item.Id)).ToList();
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
    }
}
