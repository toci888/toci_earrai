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
            {7, new MshExpMetalCalculation() },
            {6, new ChanBmsCalculation() },
            {3, new AnglesTCalculation() },
            {4, new FLTSCalculation() },
            {5, new RHSCalculation() },
            {8, new TubeCHSCalculation() },
            {9, new RndsSqrsHolBarCalculation() },
        };


        public PriceExecutor(ProductDto productDto) 
        {
            dto = productDto;
        }

        public PricingDto GetPrices() {

            int id = dto.Product.Idworksheet.Value;

            PriceCalculationBase calculator = PricesExecutors[id];

            return calculator.GetPrices(dto);
        }
    }
}
