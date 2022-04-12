using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.ParametersProviders
{
    public class SelfParameterProvider : ParameterProviderBase
    {
        public override ProductDto FillMissingOptions(ProductDto product)
        {
            //todo
            //product.Options.Remove(product.Options.Where(m => m.Name == "KgSheet").First());
            //product.Options.Add(new Productsoptionsstate() { Name = "KgSheet", Value = "8.8"});

            return product;
        }

        public override ProductDto FillWidthAndLength(ProductDto product)
        {
            Areasquantity area = product.AreaQuantities.FirstOrDefault();

            //if (product.Sizes.Where(m => m.Value == Consts.Length).Count() > 0)

            if (area != null)
            {
                foreach (Productssize item in product.Sizes)
                {
                    if (item.Name == Consts.Length && string.IsNullOrEmpty(item.Value))
                    {
                        item.Value = area.Length;
                    }

                    if (item.Name == Consts.Width && string.IsNullOrEmpty(item.Value))
                    {
                        item.Value = area.Width;
                    }
                }
                //product.Sizes.Add(new Productssize() { Name = Consts.Length, Value = area.Length });
                //product.Sizes.Add(new Productssize() { Name = Consts.Width, Value = area.Width });
            }

            return product;
        }
    }
}
