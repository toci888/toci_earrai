using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IQuoteandpriceLogic : ILogicBase<Quoteandprice>
    {
        List<Quoteandprice> GetAllQuotesAndPrices();
        List<Vendor> GetAllVendors();
        List<Quoteandmetric> GetAllQuotesAndMetrics();
        List<Quotesandprice> GetAllQuotesAndPricesView(int productId);

        int PostQuoteAndPrice(Quoteandprice quoteandprice);

        Quoteandprice UpdateQuoteAndPrice(Quoteandprice priceEntity);
        int DeleteById(int id);
    }
}
