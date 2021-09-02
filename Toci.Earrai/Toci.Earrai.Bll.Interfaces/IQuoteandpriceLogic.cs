using System.Collections.Generic;
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
    }
}
