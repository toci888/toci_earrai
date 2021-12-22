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
            { WorksheetsIds.PLTandSHEET, new PltSheetPriceCalculation() },
            { WorksheetsIds.Alum, new AlumCalculation() },
            { WorksheetsIds.MshandExpMetal, new MshExpMetalCalculation() },
            { WorksheetsIds.ChanandBms, new ChanBmsCalculation() },
            { WorksheetsIds.AnglesplusT, new AnglesTCalculation() },
            { WorksheetsIds.FLTS, new FLTSCalculation() },
            { WorksheetsIds.RHS, new RHSCalculation() },
            { WorksheetsIds.Tube_CHS, new TubeCHSCalculation() },
            { WorksheetsIds.Rnds_Sqrs_HolBar, new RndsSqrsHolBarCalculation() },
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
