using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    public class MshExpMetalCalculation : PriceCalculationBase 
    {
        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalSquareMeters = GetAreasQuantitySquareMeters(product);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected override PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            dto.StockTakeValue = DoubleUtils.RoundDouble(dto.PoundsPerSquareMeter.Value * dto.TotalSquareMeters.Value, DoubleConstants.NumOfDecimalPlaces);

            return dto;
        }

        
    }
}
