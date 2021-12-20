using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public abstract class ValuationBase
    {
        protected Dictionary<Valuations, Func<ProductDto, double>> ValuationsMap;
        protected CategoryLengthsProvider Clp = new CategoryLengthsProvider();
        //protected Valuations SourceValuation;

        public virtual double GetPrice(Valuations targetValuation, ProductDto product)
        {
            if (ValuationsMap.ContainsKey(targetValuation))
            {
                return ValuationsMap[targetValuation](product);
            }

            return -1;
        }

        protected virtual double GetPriceFromProduct(ProductDto product, string valuation)
        {
            Quotesandprice priceValuation = product.Quotesandprices.Where(m => m.Valuation == valuation).FirstOrDefault();

            if (priceValuation != null && !string.IsNullOrEmpty(priceValuation.Price))
            {
                return double.Parse(priceValuation.Price);
            }

            return 0;
        }

        protected virtual double GetKgPerMeter(ProductDto product)
        {
            return product.Pricing.KgPerMeter.Value;
        }
        //protected abstract double ToValuation(double sourcePrice, Valuations sourceValuation, Valuations targetValuation);
    }
}
