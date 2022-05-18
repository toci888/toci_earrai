using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public class PltSheetPriceCalculation : PriceCalculationBase
    {

        public override PricingDto GetPrices(ProductDto product)
        {
            PricingDto dto = base.GetPrices(product);
            
            dto = GetTotalWeight(product, dto);
            dto = GetStockTakeValue(product, dto);

            return dto;
        }

        protected virtual PricingDto GetTotalWeight(ProductDto product, PricingDto dto)
        {
            if (dto.kgPerSqrtMeter.HasValue)
            {
                dto.TotalWeight =
                    DoubleUtils.RoundDouble(dto.kgPerSqrtMeter.Value * GetAreasQuantitySquareMeters(product),
                        DoubleConstants.NumOfDecimalPlaces);
            }

            return dto;
        }

        protected override PricingDto GetStockTakeValue(ProductDto product, PricingDto dto)
        {
            if (dto.TotalWeight.HasValue && dto.PoundsPerTonne.HasValue)
            {
                dto.StockTakeValue = DoubleUtils.RoundDouble(dto.TotalWeight.Value / 1000 * dto.PoundsPerTonne.Value,
                    DoubleConstants.NumOfDecimalPlaces);
            }

            return dto;
        }


        protected override PricingDto KgPerSqrtMeter(ProductDto product, PricingDto dto)
        {
            try {
                var thickness_ = product.Sizes.Where(size => size.Name == Consts.Thickness).FirstOrDefault();
                if (thickness_ == null) { return dto; }
                if (thickness_.Value == "") { return dto; }
                double thickness = Convert.ToDouble(thickness_.Value);

                dto.kgPerSqrtMeter = DoubleUtils.RoundDouble(thickness * DensityFormKgPerSqrtMeter / 1000, DoubleConstants.NumOfDecimalPlaces); ;
            } catch (Exception) {

                return dto;
            }

            return dto;
        }

        protected override PricingDto KgPerSheet(ProductDto product, PricingDto dto) {

            try {
                var length_ = product.Sizes.Where(m => m.Name == "Length").FirstOrDefault();
                if (length_ == null) { return dto; }
                if (length_.Value == "") { return dto; }
                double length = Convert.ToDouble(length_.Value);

                var width_ = product.Sizes.Where(m => m.Name == "Width").FirstOrDefault();
                if (width_ == null) { return dto; }
                if (width_.Value == "") { return dto; }
                double width = Convert.ToDouble(width_.Value);

                dto.kgPerSheet = DoubleUtils.RoundDouble((length * width * dto.kgPerSqrtMeter.Value) / 1000000, DoubleConstants.NumOfDecimalPlaces); ;
            } catch (Exception) {

                return dto;
            }

            return dto;

        }


        protected override PricingDto PoundPerSheet(ProductDto product, PricingDto dto) {

            try {
                var x_ = product.Prices.Where(price => price.Name == "PoundsPerTonne").FirstOrDefault();
                if (x_ == null) { return dto; }
                double x = Convert.ToDouble(x_.Price);

                dto.PoundsPerTonne = DoubleUtils.RoundDouble(x, DoubleConstants.NumOfDecimalPlaces);
                dto.PoundsPerSheet = DoubleUtils.RoundDouble(x / 1000 * dto.kgPerSheet.Value, DoubleConstants.NumOfDecimalPlaces);
            } catch (Exception) {

                return dto;
            }

            return dto;
        }

        protected override PricingDto PoundsPerTonne(ProductDto product, PricingDto dto)
        {
            if (dto.kgPerSheet != 0 && dto.PoundsPerSheet.HasValue)
            {
                dto.PoundsPerTonne = DoubleUtils.RoundDouble(dto.PoundsPerSheet.Value / dto.kgPerSheet.Value * 1000, DoubleConstants.NumOfDecimalPlaces);
            }

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
