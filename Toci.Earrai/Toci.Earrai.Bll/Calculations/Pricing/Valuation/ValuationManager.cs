using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class ValuationManager
    {
        protected Dictionary<Valuations, ValuationBase> CentralValuationMap = new Dictionary<Valuations, ValuationBase>()
        {
            { Valuations.PoundsPerTonne, new PoundsPerTonneValuation() },
            { Valuations.PoundsPerLength, new PoundsPerLengthValuation() },
            { Valuations.PoundsPerMeter, new PoundsPerMeterValuation() }, 
            { Valuations.PoundsPerSheet, new PoundsPerSheetValuation() },
            { Valuations.PoundsPerSquareMeter, new PoundsPerSquareMeterValuation() },
        };

        public virtual Dictionary<Valuations, double> GetPrices(Valuations currentValuation, ProductDto product, double valuationPrice)
        {
            if (CentralValuationMap.ContainsKey(currentValuation))
            {
                return CentralValuationMap[currentValuation].GetPrices(product, DoubleUtils.RoundDouble(valuationPrice, DoubleConstants.NumOfDecimalPlaces));
            }

            return null;
        }
    }
}
