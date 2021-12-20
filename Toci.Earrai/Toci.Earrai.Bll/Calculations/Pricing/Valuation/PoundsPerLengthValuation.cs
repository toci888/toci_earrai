using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class PoundsPerLengthValuation : ValuationBase
    {
        public PoundsPerLengthValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double>>()
            {
                { Valuations.PoundsPerTonne, (product) => { if (product.Pricing.KgPerMeter.Value == 0) { return -1; } return product.Pricing.PoundsPerMeter.Value / product.Pricing.KgPerMeter.Value * 1000; } },
            };
        }
    }
}
