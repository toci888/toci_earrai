using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class PoundsPerSheetValuation : ValuationBase
    {
        public PoundsPerSheetValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double, double>>()
            {
                { Valuations.PoundsPerSquareMeter,  (product, price) => GetPoundsPerMeterSquared(product, price) },
                { Valuations.PoundsPerTonne, (product, price) => GetPoundsPerTonne(product, price) }
            };
        }

        protected virtual double GetPoundsPerTonne(ProductDto product, double poundsPerSheet)
        {
            double poundsPerMeterSquared = GetPoundsPerMeterSquared(product, poundsPerSheet);

            double kgPerSqrtMeter = product.Pricing.kgPerSqrtMeter.HasValue ? product.Pricing.kgPerSqrtMeter.Value : 0;

            if (kgPerSqrtMeter == 0)
            {
                return 0;
            }

            return DoubleUtils.RoundDouble(poundsPerMeterSquared / kgPerSqrtMeter * 1000, DoubleConstants.NumOfDecimalPlaces);
        }

        protected virtual double GetPoundsPerMeterSquared(ProductDto product, double poundsPerSheet)
        {
            Productssize widthEnt = product.Sizes.Where(m => m.Name == Consts.Width).FirstOrDefault();
            Productssize lengthEnt = product.Sizes.Where(m => m.Name == Consts.Length).FirstOrDefault();

            if (widthEnt == null || lengthEnt == null)
            {
                return 0;
            }

            if (string.IsNullOrEmpty(widthEnt.Value) || string.IsNullOrEmpty(lengthEnt.Value))
            {
                return 0;
            }

            double width = double.Parse(widthEnt.Value);
            double length = double.Parse(lengthEnt.Value);

            double divisor = width * length;

            if (divisor == 0)
            {
                return 0;
            }

            return DoubleUtils.RoundDouble(poundsPerSheet / divisor * 1000000, DoubleConstants.NumOfDecimalPlaces);
        }
    }
}
