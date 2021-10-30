using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public class PltSheetPriceCalculation : PriceCalculationBase
    {
        protected override PricingDto PricePerSheet(ProductDto product, PricingDto dto) // product
        {
            dto.Sheet = Convert.ToDouble(product.Prices.Where(m => m.Name == "PoundsPerTonne").FirstOrDefault().Price) / 1000; // kg/sheet value * ;

            return dto;
        }
    }
}
