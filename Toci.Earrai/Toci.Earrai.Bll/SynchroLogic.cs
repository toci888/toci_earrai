using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Extensions;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class SynchroLogic : ISynchroLogic
    {
        protected IProductLogic ProductLogic = new ProductLogic();
        protected IAreaquantityLogic AreaquantityLogic = new AreaquantityLogic();
        protected IQuoteandpriceLogic QuoteandpriceLogic = new QuoteandpriceLogic();

        public virtual List<ProductDto> Get(DateTime? dateFrom = null)
        {
            List<Product> products = null;
            List<ProductDto> result = new List<ProductDto>();

            if (dateFrom.HasValue)
            {
                products = ProductLogic.Select(m => m.Updatedat > dateFrom).ToList();
            }
            else
            {
                products = ProductLogic.Select(m => true).ToList();
            }

            foreach (Product pr in products)
            {
                result.Add(ProductLogic.GetProduct(pr.Id));
            }
            
            return result;
        }

        public virtual int Save(SynchroDto synchroDto)
        {
            int result = 0;

            result += SaveAreas(synchroDto.AreasQuantitiesAdded);
            result += UpdateAreas(synchroDto.AreasQuantitiesUpdated);
            result += RemoveAreas(synchroDto.AreasQuantitiesRemoved);
            result += SavePricing(synchroDto.QuotesAndPricesAdded);
            result += UpdatePricing(synchroDto.QuotesAndPricesUpdated);
            result += RemoveQuotesAndPrices(synchroDto.QuotesAndPricesRemoved);

            return result;
        }

        protected virtual int SaveAreas(List<Areasquantity> areasquantities)
        {
            int result = 0;

            foreach (Areasquantity areaquantity in areasquantities)
            {
                AreaquantityLogic.PostAreaQuantities(new List<Areaquantity>() {
                    areaquantity.FromAreasQuantity() });

                result++;
            }

            return result;
        }

        protected virtual int UpdateAreas(List<Areasquantity> areasquantities)
        {
            int result = 0;

            foreach (Areasquantity areaquantity in areasquantities)
            {
                AreaquantityLogic.UpdateAreaQuantities(areaquantity.FromAreasQuantity());
                result++;
            }

            return result;
        }

        protected virtual int RemoveAreas(List<int> toRemove)
        {
            int result = 0;

            foreach (int id in toRemove)
            {
                AreaquantityLogic.DeleteById(id);
                result++;
            }

            return result;
        }

        protected virtual int SavePricing(List<Quotesandprice> productsprices)
        {
            int result = 0;

            foreach (Quotesandprice productPrice in productsprices)
            {
                QuoteandpriceLogic.PostQuoteAndPrice(productPrice.FromQuotesAndPrice());

                result++;
            }

            return result;
        }

        protected virtual int UpdatePricing(List<Quotesandprice> productsprices)
        {
            int result = 0;

            foreach (Quotesandprice productPrice in productsprices)
            {
                QuoteandpriceLogic.UpdateQuoteAndPrice(productPrice.FromQuotesAndPrice());
                result++;
            }

            return result;
        }

        protected virtual int RemoveQuotesAndPrices(List<int> toRemove)
        {
            int result = 0;

            foreach (int id in toRemove)
            {
                QuoteandpriceLogic.DeleteById(id);
                result++;
            }

            return result;
        }
    }
}
