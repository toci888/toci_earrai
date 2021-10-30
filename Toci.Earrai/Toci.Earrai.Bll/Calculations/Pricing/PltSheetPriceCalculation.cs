using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public class PltSheetPriceCalculation : PriceCalculationBase
    {


        protected override PricingDto KgPerSqrtMeter(ProductDto product, PricingDto dto)
        {
            int thickness = Convert.ToInt32(product.Sizes.Where(size => size.Name == "Thickness").FirstOrDefault().Value);

            dto.kgPerSqrtMeter = thickness * DensityFormKgPerSqrtMeter / 1000;

            return dto;
        }

        protected override PricingDto KgPerSheet(ProductDto product, PricingDto dto) {

            var length_ = product.Sizes.Where(m => m.Name == "Length").FirstOrDefault().Value;
            double length = Convert.ToDouble(length_);

            var width_ = product.Sizes.Where(m => m.Name == "Width").FirstOrDefault().Value;
            double width = Convert.ToDouble(width_);

            dto.kgPerSheet = (length * width * dto.kgPerSqrtMeter) / 1000;

            return dto;

        }


        protected override PricingDto PoundPerSheet(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == "PoundsPerTonne").FirstOrDefault().Price;
            double x = Convert.ToDouble(x_);

            dto.PoundsPerSheet  = x / 1000 * dto.kgPerSheet;

            return dto;
        }



        // kg/M2 = thickness * density / 1000
        // kg/Sheet = (length * width * kg/M2 ) / 1000000
        // PundPerSheet = PoundPerTonne / 1000 * kg/Sheet

        // -30% PundPerSheet * 0.7
        // -35%
        // -40%
        // -50%
    }
}
