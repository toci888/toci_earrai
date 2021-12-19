using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class FLTSCalculation : PriceCalculationBase {

        protected override PricingDto KgPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Sizes.Where(size => size.Name == "Length").FirstOrDefault();
            if (x_ == null) { return dto; }
            if(x_.Value == "") { return dto; }
            double x = Convert.ToDouble(x_.Value);

            var y_ = product.Sizes.Where(size => size.Name == Consts.Thickness).FirstOrDefault();
            if (y_ == null) { return dto; }
            if (y_.Value == "") { return dto; }
            double y = Convert.ToDouble(y_.Value);

            var res = (DensityFormKgPerSqrtMeter / 1000000) * x * y;

            dto.KgPerMeter = res;

            return dto;
        }
        
        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
            if (x_ == null) { return dto; }
            if (x_.Price == "") { return dto; }
            double x = Convert.ToDouble(x_.Price);

            var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault(); // TODO option or calc?
            if (y_ == null) { return dto; }
            if (y_.Value == "") { return dto; }
            double y = Convert.ToDouble(y_.Value);

            dto.PoundsPerMeter = (x / 1000) / y;

            return dto; 
        }
        
    }
}
