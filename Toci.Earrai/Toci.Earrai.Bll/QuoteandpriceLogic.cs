using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class QuoteandpriceLogic : Logic<Quoteandprice>, IQuoteandpriceLogic
    {
        protected Logic<Quoteandmetric> Quoteandmetric = new Logic<Quoteandmetric>();
        protected Logic<Vendor> Vendor = new Logic<Vendor>();
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

        public List<Vendor> GetAllVendors()
        {
            List<Vendor> vendor = new List<Vendor>();
            vendor = Vendor.Select(m => true).ToList();
            return vendor;
        }

        public int PostQuoteAndPrice(Quoteandprice quoteandprice)
        {
            int id = Insert(quoteandprice).Id;
            /*
            int id = Insert(new Quoteandprice()
            {
                Idworksheet = quoteandprice.Idworksheet,
                Rowindex = quoteandprice.Rowindex,
                Price = quoteandprice.Price,
                Idvendor = quoteandprice.Idvendor,
                Idquoteandmetric = quoteandprice.Idquoteandmetric,
                Iduser = quoteandprice.Iduser
            }).Id;
            */

            return id;
        }
    }
}
