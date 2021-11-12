using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui.Convert
{
    public class ProductSizeConverter : ConverterBase<List<Productssize>>
    {
        public override List<ProductLayoutDto> Convert(List<Productssize> item)
        {
            List<ProductLayoutDto> result = new List<ProductLayoutDto>();

            foreach (Productssize el in item)
            {
                result.Add(new ProductLayoutDto() { LabelItemName = el.Name, LabelItemValue = el.Value });
            }

            return result;
        }
    }
}
