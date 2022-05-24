using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    public class TubeCHSCalculation : PriceCalculationBase 
    {
        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalMeters = GetAreasQuantityTotalMeters(product);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected override PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            double kgPerMeter = 0;

            dto.StockTakeValue = 0;

            Productsoptionsstate kgm = product.Options.Where(m => m.Name == ProductOptions.KgM).FirstOrDefault();

            if (kgm != null)
            {
                double.TryParse(kgm.Value, out kgPerMeter);

                dto.StockTakeValue = DoubleUtils.RoundDouble(dto.TotalMeters.Value * dto.PoundsPerTonne.Value * kgPerMeter / 1000, DoubleConstants.NumOfDecimalPlaces);
            }

            return dto;
        }

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {


            try {

                var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
                //if (x_ == null) { return dto; }
                double price = Convert.ToDouble(x_.Price);

                var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault(); // TODO option or calc?
                //if (x_ == null) { return dto; }
                double kgM = 0;

                if (y_ != null)
                {
                    double.TryParse(y_.Value, out kgM);
                }

                if (kgM != 0)
                {
                    dto.PoundsPerMeter = (price / 1000) / kgM;
                }

                dto.PoundsPerLength = DoubleUtils.RoundDouble(dto.PoundsPerMeter.Value * 7.6, DoubleConstants.NumOfDecimalPlaces);

            } catch(Exception) {
                return dto;
            }



            return dto; // TODO Two calcs at once.
        }
    }
}
