using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class RndsSqrsHolBarCalculation : PriceCalculationBase {

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            try {
                var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
                if (x_ == null) { return dto; }
                double x = Convert.ToDouble(x_.Price);

                var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault(); // TODO option or calc?
                if (y_ == null) { return dto; }
                double y = Convert.ToDouble(y_.Value);

                dto.PoundsPerMeter = (x / 1000) / y;

                dto.PoundsPerLength = dto.PoundsPerMeter * 6.2;
            } catch (Exception) {

                return dto;
            }

            return dto; // TODO Two calcs at once.
        
        }

        // AA AB AC etc is adding to price
    }
}
