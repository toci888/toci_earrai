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

        public virtual int Save(List<ProductDto> productDtos)
        {
            int result = 0;

            foreach (ProductDto product in productDtos)
            {
                result += SaveAreas(product.AreaQuantities);
                result += SavePricing(product.Quotesandprices);
            }

            return result;
        }

        protected virtual int SaveAreas(List<Areasquantity> areasquantities)
        {
            int result = 0;

            foreach (Areasquantity areaquantity in areasquantities)
            {
                if (AreaquantityLogic.Select(m => m.Id == areaquantity.Id).FirstOrDefault() == null)
                {
                    AreaquantityLogic.PostAreaQuantities(new List<Areaquantity>() {
                        areaquantity.FromAreasQuantity() });

                    result++;
                }
                else
                {
                    AreaquantityLogic.UpdateAreaQuantities(areaquantity.FromAreasQuantity());
                    result++;
                }
            }

            return result;
        }

        protected virtual int SavePricing(List<Quotesandprice> productsprices)
        {
            int result = 0;

            foreach (Quotesandprice productPrice in productsprices)
            {
                if (QuoteandpriceLogic.Select(m => m.Id == productPrice.Id).FirstOrDefault() == null)
                {
                    QuoteandpriceLogic.PostQuoteAndPrice(productPrice.FromQuotesAndPrice());

                    result++;
                }
                else
                {
                    QuoteandpriceLogic.UpdateQuoteAndPrice(productPrice.FromQuotesAndPrice());
                    result++;
                }
            }

            return result;
        }
    }
}
