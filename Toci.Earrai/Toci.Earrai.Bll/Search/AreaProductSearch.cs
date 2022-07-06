using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Search
{
    public class AreaProductSearch : SearchProductBase
    {
        public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            List<ProductDto> result = ProductLogic.GetProductsByWorksheet(request.WorksheetId).Where(p => p.AreaQuantities.Where(m => m.Areacode == request.Value).FirstOrDefault() != null).ToList();

            return SearchByStockTakeValue(result, request);
        }
    }
}
