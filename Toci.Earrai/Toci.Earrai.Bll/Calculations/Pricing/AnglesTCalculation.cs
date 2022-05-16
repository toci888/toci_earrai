using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    public class AnglesTCalculation : PriceCalculationBase 
    {
        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalMeters = DoubleUtils.RoundDouble(GetAreasQuantityTotalMeters(product), DoubleConstants.NumOfDecimalPlaces);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected override PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            dto.StockTakeValue = DoubleUtils.RoundDouble(dto.PoundsPerMeter.Value * dto.TotalMeters.Value, DoubleConstants.NumOfDecimalPlaces);

            return dto;
        }

        protected override PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) {

            var x_ = product.Prices.Where(price => price.Name == CalculationsConsts.PoundsPerTonne).FirstOrDefault();
            if(x_ == null) { return dto; }
            if (string.IsNullOrEmpty(x_.Price)) { return dto; }

            double price = 0;

            double.TryParse(x_.Price, out price);

            var y_ = product.Options.Where(opt => opt.Name == CalculationsConsts.KgM).FirstOrDefault();
            if (y_ == null) { return dto; }
            if (string.IsNullOrEmpty(y_.Value)) { return dto; }

            double kmperm = 0;

            double.TryParse(y_.Value, out kmperm);

            if (kmperm != 0)
            {
                dto.PoundsPerMeter = DoubleUtils.RoundDouble((price / 1000) / kmperm, DoubleConstants.NumOfDecimalPlaces);
            }

            dto.PoundsPerLength = DoubleUtils.RoundDouble(dto.PoundsPerMeter.Value * 6.2, DoubleConstants.NumOfDecimalPlaces);  

            return dto; // TODO MAKES CALCULATIONS TWO AT ONE
        }
    }
}
