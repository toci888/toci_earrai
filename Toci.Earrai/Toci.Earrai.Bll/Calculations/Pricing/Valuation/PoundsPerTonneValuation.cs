using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class PoundsPerTonneValuation : ValuationBase
    {
        public PoundsPerTonneValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double>>()
            {
                { Valuations.PoundsPerMeter, (product) => {  if (GetKgPerMeter(product) == 0) { return -1; } return product.Pricing.PoundsPerMeter.Value / GetKgPerMeter(product) * 1000; } },
                { Valuations.PoundsPerLength, (product) => { return product.Pricing.PoundsPerMeter.Value * Clp.GetCategoryLength(product.Product.Idcategories.Value); } },
                { Valuations.PoundsPerSheet, (product) => { return product.Pricing.PoundsPerTonne.Value / 1000 * product.Pricing.kgPerSheet.Value; } },
            };
        }
    }
}
