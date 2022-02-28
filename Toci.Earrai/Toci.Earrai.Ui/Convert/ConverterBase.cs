using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Ui.Convert
{
    public abstract class ConverterBase<TProductDtoItem>
    {
        public abstract List<ProductLayoutDto> Convert(TProductDtoItem item);

        public virtual List<ProductLayoutDto> Convert(List<TProductDtoItem> items, Func<TProductDtoItem, ProductLayoutDto> itemConverter)
        {
            List<ProductLayoutDto> result = new List<ProductLayoutDto>();

            foreach (TProductDtoItem item in items)
            {
                result.Add(itemConverter(item));
            }

            return result;
        }
    }
}
