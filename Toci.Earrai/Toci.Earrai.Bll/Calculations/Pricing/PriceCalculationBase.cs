using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public abstract class PriceCalculationBase
    {
        protected const int DensityFormKgPerSqrtMeter = 7500;

        // 5 metod wg enum

        public virtual PricingDto GetPrices(ProductDto product) //product
        {
            PricingDto dto = new PricingDto();

            // wyw tych 5 metod i zasilenie dto
            KgPerSqrtMeter(product, dto);
            KgPerSheet(product, dto);
            PoundPerSheet(product, dto);
            PoundsPerMeter(product, dto);
            KgPerMeter(product, dto);
            PoundsPerTonne(product, dto);

            return dto;
        }
        protected virtual PricingDto KgPerSqrtMeter(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto KgPerSheet(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto PoundPerSheet(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto KgPerMeter(ProductDto product, PricingDto dto) 
        {
            Productsoptionsstate kgpermeter = product.Options.Where(m => m.Name == CalculationsConsts.KgM).FirstOrDefault();

            if (kgpermeter != null && !string.IsNullOrEmpty(kgpermeter.Value))
            {
                double KgPerMeter = double.Parse(kgpermeter.Value);
                dto.KgPerMeter = KgPerMeter;
            }

            return dto; 
        } 

        protected virtual PricingDto PoundsPerTonne(ProductDto product, PricingDto dto) 
        {
            Quotesandprice pricePerMeter = product.Quotesandprices.Where(m => m.Valuation == CalculationsConsts.PoundsPerMeter).FirstOrDefault();

            if (pricePerMeter != null)
            {
                double price = double.Parse(pricePerMeter.Price);

                if (dto.KgPerMeter != 0)
                {
                    dto.PoundsPerTonne = price / dto.KgPerMeter * 1000;
                }
            }

            return dto; 
        }

    }
}
