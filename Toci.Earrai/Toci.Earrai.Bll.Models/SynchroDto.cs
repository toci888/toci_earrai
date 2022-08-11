using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models
{
    public class SynchroDto
    {
        public List<Areasquantity> AreasQuantitiesAdded { get; set; }

        public List<int> AreasQuantitiesRemoved { get; set; }

        public List<Areasquantity> AreasQuantitiesUpdated { get; set; }

        public List<Quotesandprice> QuotesAndPricesAdded { get; set; }

        public List<int> QuotesAndPricesRemoved { get; set; }

        public List<Quotesandprice> QuotesAndPricesUpdated { get; set; }
    }
}
