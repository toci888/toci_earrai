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
    public class PoundsPerLengthValuation : ValuationBase
    {
        public PoundsPerLengthValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double, double>>()
            {
                { Valuations.PoundsPerTonne, (product, price) => GetPoundsPerTonne(product, price) },
                { Valuations.PoundsPerMeter, (product, price) => GetPoundsPerMeter(product, price)}
            };
        }

        protected virtual double GetPoundsPerTonne(ProductDto product, double poundsPerLength)
        {
            if (!product.Pricing.KgPerMeter.HasValue || product.Pricing.KgPerMeter.Value == 0) 
            { 
                return 0; 
            }

            return DoubleUtils.RoundDouble(GetPoundsPerMeter(product, poundsPerLength) / product.Pricing.KgPerMeter.Value * 1000, DoubleConstants.NumOfDecimalPlaces);
        }

        protected virtual double GetPoundsPerMeter(ProductDto product, double poundsPerLength)
        {
            return DoubleUtils.RoundDouble(poundsPerLength / Clp.GetCategoryLength(product.Product.Idcategories.Value), DoubleConstants.NumOfDecimalPlaces);
        }
    }
}
