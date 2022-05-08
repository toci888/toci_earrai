using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Calculations.Pricing.ParametersProviders;
using Toci.Earrai.Bll.Calculations.Pricing.Valuation;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing
{
    public abstract class PriceCalculationBase
    {
        protected const int DensityFormKgPerSqrtMeter = 7500;

        protected ParameterProviderBase paramsProvBase = new SelfParameterProvider();

        // 5 metod wg enum
        protected Dictionary<string, Func<PricingDto, double, PricingDto>> ValuationsMap = new Dictionary<string, Func<PricingDto, double, PricingDto>>()
        {
            { CalculationsConsts.LPerLength, (dto, valuation) => { dto.PoundsPerLength = valuation; return dto; } },
            { CalculationsConsts.LPerMeter, (dto, valuation) => { dto.PoundsPerMeter = valuation; return dto; }  },
            { CalculationsConsts.LPerSheet, (dto, valuation) => { dto.PoundsPerSheet = valuation; return dto; }  },
            { CalculationsConsts.LPerSquareMeter, (dto, valuation) => { dto.PoundsPerSquareMeter = valuation; return dto; }  },
            { CalculationsConsts.LPerTonne, (dto, valuation) => { dto.PoundsPerTonne = valuation; return dto; } },
        };

        public virtual PricingDto GetPrices(ProductDto product) //product
        {
            product = paramsProvBase.FillWidthAndLength(product);
            product = paramsProvBase.FillMissingOptions(product);

            PricingDto dto = new PricingDto();

            // wyw tych 5 metod i zasilenie dto
            KgPerSqrtMeter(product, dto);
            KgPerSheet(product, dto);
            PoundPerSheet(product, dto);
            PoundsPerMeter(product, dto);
            KgPerMeter(product, dto);
            PoundsPerTonne(product, dto);

            dto = GetPricesFromProduct(product, dto);

            return dto;
        }

        protected virtual double GetAreasQuantitySquareMeters(ProductDto product, bool inclWidth = true)
        {
            if (product.AreaQuantities.Any())
            {
                double result = 0;

                foreach (Areasquantity arQ in product.AreaQuantities)
                {
                    double length = 0;
                    double width = 0;
                    double quantity = 0;

                    double.TryParse(arQ.Width, out width);
                    double.TryParse(arQ.Length, out length);
                    double.TryParse(arQ.Quantity, out quantity);

                    if (inclWidth)
                    {
                        result += width * length * quantity / 1000000;
                    }
                    else
                    {
                        result += length * quantity / 1000000;
                    }
                }

                return result;
            }

            return 0;
        }

        protected virtual double GetAreasQuantityTotalMeters(ProductDto product)
        {
            if (product.AreaQuantities.Any())
            {
                double result = 0;

                foreach (Areasquantity arQ in product.AreaQuantities)
                {
                    double length = 0;
                    double quantity = 0;

                    double.TryParse(arQ.Length, out length);
                    double.TryParse(arQ.Quantity, out quantity);

                  
                    result += length * quantity;
                }

                return result;
            }

            return 0;
        }

        protected virtual PricingDto KgPerSqrtMeter(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto KgPerSheet(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto PoundPerSheet(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto PoundsPerMeter(ProductDto product, PricingDto dto) { return dto; }

        protected virtual PricingDto GetPricesFromProduct(ProductDto product, PricingDto pricingDto)
        {
            List<Quotesandprice> pricesValuation = product.Quotesandprices.OrderByDescending(m => m.Createdat).ToList();

            foreach (KeyValuePair<string, Func<PricingDto, double, PricingDto>> map in ValuationsMap)
            {
                Quotesandprice priceValuation = pricesValuation. Where(m => m.Valuation == map.Key).FirstOrDefault(); // TODO correct one, last or ? 

                if (priceValuation != null)
                {
                    if (string.IsNullOrEmpty(priceValuation.Price))
                    {
                        map.Value(pricingDto, 0);
                    }
                    else
                    {
                        double price = 0;
                        double.TryParse(priceValuation.Price, out price);

                        map.Value(pricingDto, price);
                    }
                }
            }

            return pricingDto;
        }

        protected virtual PricingDto KgPerMeter(ProductDto product, PricingDto dto) 
        {
            Productsoptionsstate kgpermeter = product.Options.Where(m => m.Name == CalculationsConsts.KgM).FirstOrDefault();

            if (kgpermeter != null && !string.IsNullOrEmpty(kgpermeter.Value))
            {
                double KgPerMeter = 0; 
                double.TryParse(kgpermeter.Value, out KgPerMeter);

                dto.KgPerMeter = KgPerMeter;
            }

            return dto; 
        } 

        protected virtual PricingDto PoundsPerTonne(ProductDto product, PricingDto dto) 
        {
            Quotesandprice pricePerMeter = product.Quotesandprices.Where(m => m.Valuation == CalculationsConsts.PoundsPerMeter).FirstOrDefault(); // TODO duplicated calculation logic

            if (pricePerMeter != null && !string.IsNullOrEmpty(pricePerMeter.Price))
            {
                double price = 0;
                double.TryParse(pricePerMeter.Price, out price);

                if (dto.KgPerMeter != 0)
                {
                    dto.PoundsPerTonne = price / dto.KgPerMeter * 1000;
                }
            }

            return dto; 
        }

    }
}
