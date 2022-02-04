using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    class ChanBmsCalculation : PriceCalculationBase 
    {
        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalMeters = GetAreasQuantityTotalMeters(product);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected virtual PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            dto.StockTakeValue = dto.PoundsPerMeter * dto.TotalMeters;

            return dto;
        }

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            try {
                var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();

                if (x_ == null)
                {
                    return dto;
                }

                double x = Convert.ToDouble(x_.Price);

                var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault().Value;
                double y = Convert.ToDouble(y_);

                dto.PoundsPerMeter = (x / 1000) * y;

                return dto;

            } catch(Exception) {
                return dto;
            }
            /*var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
            if (x_ == null) { return dto; }
            if (x_.Price == "") { return dto; }
            double x = Convert.ToDouble(x_.Price);
            var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault();
            if (y_ == null) { return dto; }
            if (y_.Value == "") { return dto; }
            double y = Convert.ToDouble(y_.Value);
            return dto;*/
        }


        // P column ?
    }
}
