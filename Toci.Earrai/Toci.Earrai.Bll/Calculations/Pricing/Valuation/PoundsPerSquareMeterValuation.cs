using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class PoundsPerSquareMeterValuation : ValuationBase
    {
        public PoundsPerSquareMeterValuation()
        {
            ValuationsMap = new Dictionary<Valuations, Func<ProductDto, double, double>>()
            {
                //sheet
                { Valuations.PoundsPerSheet, (product, price) => GetPoundsPerSheet(product, price) }
            };
        }

        public override double GetPoundsPerLength(ProductDto product, double poundsPerTonne)
        {
            throw new NotImplementedException();
        }

        public override double GetPoundsPerMeter(ProductDto product, double poundsPerTonne)
        {
            throw new NotImplementedException();
        }

        public override double GetPoundsPerMeterSquared(ProductDto product, double poundsPerTonne)
        {
            throw new NotImplementedException();
        }


        public override double GetPoundsPerSheet(ProductDto product, double poundsPerSquareMeter)
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

            double multiplier = width * length;

            return poundsPerSquareMeter * multiplier / 1000000;
        }
    }
}
