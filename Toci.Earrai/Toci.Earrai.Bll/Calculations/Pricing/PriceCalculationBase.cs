using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public abstract class PriceCalculationBase
    {
        // 5 metod wg enum

        public virtual PricingDto GetPrices(ProductDto product) //product
        {
            PricingDto dto = new PricingDto();

            // wyw tych 5 metod i zasilenie dto
            PricePerSheet(product, dto);

            return dto;
        }

        protected abstract PricingDto PricePerSheet(ProductDto product, PricingDto dto);
    }
}
