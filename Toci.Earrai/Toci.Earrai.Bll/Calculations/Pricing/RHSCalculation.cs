﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing {
    public class RHSCalculation : PriceCalculationBase {

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

            if (kgm != null && dto.TotalMeters.HasValue && dto.PoundsPerTonne.HasValue)
            {
                double.TryParse(kgm.Value, out kgPerMeter);

                dto.StockTakeValue = DoubleUtils.RoundDouble(dto.TotalMeters.Value * dto.PoundsPerTonne.Value * kgPerMeter / 1000, DoubleConstants.NumOfDecimalPlaces);
            }

            return dto;
        }

        // TODO 
        // what to do with Columns Q and R ?
    }
}
