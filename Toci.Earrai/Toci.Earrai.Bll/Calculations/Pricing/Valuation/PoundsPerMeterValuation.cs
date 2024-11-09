using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class PoundsPerMeterValuation : ValuationBase
    {
        public PoundsPerMeterValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double, double>>()
            {
                //tonne
                { Valuations.PoundsPerTonne, (product, price) => GetPoundsPerTonne(product, price) }
            };
        }

        public override double GetPoundsPerLength(ProductDto product, double poundsPerTonne)
        {
            return 0;
        }

        public override double GetPoundsPerMeter(ProductDto product, double poundsPerTonne)
        {
            return 0; // poundsPerTonne / Clp.GetCategoryLength(product.Product.Idcategories.Value);
        }

        public override double GetPoundsPerMeterSquared(ProductDto product, double poundsPerTonne)
        {
            return 0;
        }

        public override double GetPoundsPerSheet(ProductDto product, double poundsPerTonne)
        {
            return 0;
        }

        protected virtual double GetPoundsPerTonne(ProductDto product, double poundsPerMeter)
        {
            double kgPerMeter = product.Pricing.KgPerMeter.HasValue ? product.Pricing.KgPerMeter.Value : 0;

            if (kgPerMeter == 0)
            {
                return 0;
            }

            return poundsPerMeter / kgPerMeter * 1000;
        }
    }
}
