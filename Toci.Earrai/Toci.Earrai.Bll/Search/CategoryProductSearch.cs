using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class CategoryProductSearch : SearchProductBase
    {
        public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            List<ProductDto> result = ProductLogic.GetProductsByWorksheet(request.WorksheetId).Where(p => p.Category.Prefix == request.Value).ToList();

            return SearchByStockTakeValue(result, request);
        }
    }
}
