using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    public class AlumCalculation : PriceCalculationBase 
    {

        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalSquareMeters = GetAreasQuantitySquareMeters(product);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected virtual PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            dto.StockTakeValue = 0; // TODO

            return dto;
        }

        protected override PricingDto KgPerSqrtMeter(ProductDto product, PricingDto dto) 
        {
            return dto;
        }


        // total Sqrt Meters(m2) = SUMA areaQ1(LxW * Qty) + areaQ2(LxW * Qty)

        // StockTakeValue(const) at O column

        // PoundsPerSheet = StockTake / total Sqrt Meters

    }
}
