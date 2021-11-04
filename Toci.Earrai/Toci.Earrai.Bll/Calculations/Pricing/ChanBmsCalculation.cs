using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class ChanBmsCalculation : PriceCalculationBase {
        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault().Price;

            if (string.IsNullOrEmpty(x_))
                return dto;

            double x = Convert.ToDouble(x_);

            var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault();

            if (y_ == null)
            {
                return dto;
            }
            double y = Convert.ToDouble(y_.Value);

            dto.PoundsPerMeter = (x / 1000) * y;

            return dto;
        }


        // P column ?
    }
}
