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
    }
}
