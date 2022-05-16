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
    public class AlumCalculation : PriceCalculationBase 
    {

        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);

            dto.TotalSquareMeters = DoubleUtils.RoundDouble(GetAreasQuantitySquareMeters(product), DoubleConstants.NumOfDecimalPlaces);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected override PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            double width = 0;
            double length = 0;

            dto.StockTakeValue = 0;

            Productssize widthPSize = product.Sizes.Where(m => m.Name == ProductSizesEnum.Width.ToString()).FirstOrDefault();
            Productssize lengthPSize = product.Sizes.Where(m => m.Name == ProductSizesEnum.Length.ToString()).FirstOrDefault();

            if (widthPSize != null && lengthPSize != null)
            {
                double.TryParse(widthPSize.Value, out width);
                double.TryParse(lengthPSize.Value, out length);

                double lwResult = width * length / 1000000;

                if (lwResult != 0)
                {
                    dto.StockTakeValue = DoubleUtils.RoundDouble(dto.TotalSquareMeters.Value * dto.PoundsPerSheet.Value / lwResult, DoubleConstants.NumOfDecimalPlaces);
                }
            }

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
