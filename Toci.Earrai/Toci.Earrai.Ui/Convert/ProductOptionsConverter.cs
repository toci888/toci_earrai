using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui.Convert
{
    public class ProductOptionsConverter : ConverterBase<List<Productsoptionsstate>>
    {
        public override List<ProductLayoutDto> Convert(List<Productsoptionsstate> item)
        {
            List<ProductLayoutDto> result = new List<ProductLayoutDto>();

            foreach (Productsoptionsstate el in item)
            {
                result.Add(new ProductLayoutDto() { LabelItemName = el.Name, LabelItemValue = el.Value });
            }

            return result;
        }
    }
}
