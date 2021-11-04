using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class TubeCHSCalculation : PriceCalculationBase {

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault().Price;
            double x = Convert.ToDouble(x_);

            var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault().Value; // TODO option or calc?
            double y = Convert.ToDouble(y_);

            dto.PoundsPerMeter = (x / 1000) / y;

            dto.PoundsPerLength = dto.PoundsPerMeter * 7.6;

            return dto; // TODO Two calcs at once.
        }
    }
}
