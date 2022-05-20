using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Bll.Extensions;
using Toci.Common;

namespace Toci.Earrai.Bll
{
    public class QuoteandpriceLogic : Logic<Quoteandprice>, IQuoteandpriceLogic
    {
        protected Logic<Quoteandmetric> Quoteandmetric = new Logic<Quoteandmetric>();
        protected Logic<Vendor> Vendor = new Logic<Vendor>();
        protected Logic<Quotesandprice> Quotesandprices = new Logic<Quotesandprice>();
        public List<Quoteandmetric> GetAllQuotesAndMetrics()
        {
            List<Quoteandmetric> quoteandmetric = new List<Quoteandmetric>();
            quoteandmetric = Quoteandmetric.Select(m => true).ToList();
            return quoteandmetric;
        }

        public List<Quoteandprice> GetAllQuotesAndPrices()
        {
            List<Quoteandprice> quoteandprice = new List<Quoteandprice>();
            quoteandprice = Select(m => true).ToList();
            return quoteandprice;
        }

        public List<Quotesandprice> GetAllQuotesAndPricesView(int productId)
        {
            List<Quotesandprice> result = Quotesandprices.Select(m => m.Idproducts == productId).OrderByDescending(m => m.Createdat).ToList();

            foreach (Quotesandprice element in result)
            {
                double price = 0;

                double.TryParse(element.Price, out price);

                element.Price = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString();
            }

            return result;
        }

        public List<Vendor> GetAllVendors()
        {
            List<Vendor> vendor = new List<Vendor>();
            vendor = Vendor.Select(m => true).ToList();
            return vendor;
        }

        public int PostQuoteAndPrice(Quoteandprice quoteandprice)
        {
            int id = Insert(quoteandprice).Id;

            this.SetUpdatedAtProduct(quoteandprice.Idproducts.Value);

            return id;
        }

        public Quoteandprice UpdateQuoteAndPrice(Quoteandprice priceEntity)
        {
            if (Select(m => m.Id == priceEntity.Id).FirstOrDefault() == null)
                return null;

            priceEntity.Updatedat = DateTime.Now;

            Update(priceEntity);

            this.SetUpdatedAtProduct(priceEntity.Idproducts.Value);

            return priceEntity;
        }

        public int DeleteById(int id)
        {
            var quoteAndPrice = Select(m => m.Id == id).FirstOrDefault();
            if (quoteAndPrice == null)
                return 0;
            Delete(quoteAndPrice);

            this.SetUpdatedAtProduct(quoteAndPrice.Idproducts.Value);

            return 1;
        }

    }
}
