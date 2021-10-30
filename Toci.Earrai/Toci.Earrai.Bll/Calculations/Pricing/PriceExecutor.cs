using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public class PriceExecutor
    {
        ProductDto dto;

        protected Dictionary<int, PriceCalculationBase> PricesExecutors = new Dictionary<int, PriceCalculationBase> {
            {1, new PltSheetPriceCalculation() },
            {2, new AlumCalculation() },
            {3, new MshExpMetalCalculation() },
            {4, new ChanBmsCalculation() },
            {5, new AnglesTCalculation() },
            {6, new FLTSCalculation() },
            {7, new RHSCalculation() },
            {8, new TubeCHSCalculation() },
            {9, new RndsSqrsHolBarCalculation() },
        };


        public PriceExecutor(ProductDto productDto) {
            dto = productDto;
        }

        public PricingDto getPrices() {

            int id = dto.Product.Idworksheet.Value;

            var calculator = PricesExecutors[id];

            return calculator.GetPrices(dto);
        }
    }
}
