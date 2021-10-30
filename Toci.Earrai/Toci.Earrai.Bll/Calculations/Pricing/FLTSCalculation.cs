using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class FLTSCalculation : PriceCalculationBase {

        protected override PricingDto KgPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Sizes.Where(size => size.Name == "Length").FirstOrDefault().Value;
            double x = Convert.ToDouble(x_);

            var y_ = product.Sizes.Where(size => size.Name == "Thickness").FirstOrDefault().Value;
            double y = Convert.ToDouble(y_);

            var res = (DensityFormKgPerSqrtMeter / 1000000) * x * y;

            dto.KgPerMeter = res;

            return dto;
        }
        
        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == "PricePerTonne").FirstOrDefault().Price;
            double x = Convert.ToDouble(x_);

            var y_ = product.Options.Where(opt => opt.Name == "KgM").FirstOrDefault().Value; // TODO option or calc?
            double y = Convert.ToDouble(y_);

            dto.PoundsPerMeter = (x / 1000) / y;

            return dto; 
        }
        
    }
}
