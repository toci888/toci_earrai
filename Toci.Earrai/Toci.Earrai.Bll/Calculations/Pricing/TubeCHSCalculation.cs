using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class TubeCHSCalculation : PriceCalculationBase {

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {


            try {

                var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
                //if (x_ == null) { return dto; }
                double price = Convert.ToDouble(x_.Price);

                var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault(); // TODO option or calc?
                //if (x_ == null) { return dto; }
                double kgM = Convert.ToDouble(y_.Value);

                dto.PoundsPerMeter = (price / 1000) / kgM;

                dto.PoundsPerLength = dto.PoundsPerMeter * 7.6;


            } catch(Exception) {
                return dto;
            }



            return dto; // TODO Two calcs at once.
        }
    }
}
