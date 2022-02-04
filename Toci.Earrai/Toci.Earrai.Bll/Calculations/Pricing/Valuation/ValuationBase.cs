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
        protected Dictionary<Valuations, Func<ProductDto, double, double>> ValuationsMap;
        protected CategoryLengthsProvider Clp = new CategoryLengthsProvider();
        //protected Valuations SourceValuation;

        public virtual Dictionary<Valuations, double> GetPrices(ProductDto product, double currentPrice)
        {
            Dictionary<Valuations, double> result = new Dictionary<Valuations, double>();

            foreach (KeyValuePair<Valuations, Func<ProductDto, double, double>> valItem in ValuationsMap)
            {
                result.Add(valItem.Key, valItem.Value(product, currentPrice));
            }
            
            return result;
        }

        protected virtual double GetPriceFromProduct(ProductDto product, string valuation) // unneeded
        {
            Quotesandprice priceValuation = product.Quotesandprices.Where(m => m.Valuation == valuation).FirstOrDefault(); // TODO correct one, last or ? 

            if (priceValuation != null && !string.IsNullOrEmpty(priceValuation.Price))
            {
                return double.Parse(priceValuation.Price);
            }

            return 0;
        }

        protected virtual double GetKgPerMeter(ProductDto product)
        {
            return product.Pricing.KgPerMeter.HasValue ? product.Pricing.KgPerMeter.Value : 0;
        }
        //protected abstract double ToValuation(double sourcePrice, Valuations sourceValuation, Valuations targetValuation);
    }
}
