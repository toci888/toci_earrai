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
    public class PoundsPerTonneValuation : ValuationBase
    {
        protected double PricePoundsPerMeter = 0;

        public PoundsPerTonneValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double, double>>()
            {
                { Valuations.PoundsPerMeter, (product, price) => GetPoundsPerMeter(product, price) },
                { Valuations.PoundsPerLength, (product, price) => GetPoundsPerLength(product, price) },
                { Valuations.PoundsPerSheet, (product, price) => GetPoundsPerSheet(product, price) },
                { Valuations.PoundsPerSquareMeter, (product, price) => GetPoundsPerMeterSquared(product, price) }
            };
        }

        protected virtual double GetPoundsPerMeter(ProductDto product, double poundsPerTonne)
        {
            double kgPerM = GetKgPerMeter(product);

            PricePoundsPerMeter = DoubleUtils.RoundDouble(poundsPerTonne / 1000 * kgPerM, DoubleConstants.NumOfDecimalPlaces);

            return PricePoundsPerMeter;

            //=tonne/1000*kgperm
            //   if (GetKgPerMeter(product) == 0) { return -1; }
            // return product.Pricing.PoundsPerMeter.Value / GetKgPerMeter(product) * 1000;
        }

        protected virtual double GetPoundsPerLength(ProductDto product, double poundsPerTonne)
        {
            if (PricePoundsPerMeter == 0)
            {
                GetPoundsPerMeter(product, poundsPerTonne);
            }

            return DoubleUtils.RoundDouble(PricePoundsPerMeter * Clp.GetCategoryLength(product.Product.Idcategories.Value), DoubleConstants.NumOfDecimalPlaces);
        }

        protected virtual double GetPoundsPerSheet(ProductDto product, double poundsPerTonne)
        {
            return DoubleUtils.RoundDouble(poundsPerTonne / 1000 * (product.Pricing.kgPerSheet.HasValue ? product.Pricing.kgPerSheet.Value : 0), DoubleConstants.NumOfDecimalPlaces);
        }

        protected virtual double GetPoundsPerMeterSquared(ProductDto product, double poundsPerTonne)
        {
            double kgPerSqrtMeter = product.Pricing.kgPerSqrtMeter.HasValue ? product.Pricing.kgPerSqrtMeter.Value : 0;

            return DoubleUtils.RoundDouble(poundsPerTonne / 1000 * kgPerSqrtMeter, DoubleConstants.NumOfDecimalPlaces);
        }
    }
}
