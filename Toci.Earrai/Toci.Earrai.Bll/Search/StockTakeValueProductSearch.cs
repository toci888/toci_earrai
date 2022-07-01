using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Search
{
    public class StockTakeValueProductSearch : SearchProductBase
    {
        public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            double stockTake = 0;
            double.TryParse(request.Value, out stockTake);

            List<ProductDto> result = ProductLogic.GetProductsByWorksheet(request.WorksheetId).Where(p => p.Pricing.StockTakeValue == stockTake).ToList();

            return result;
        }
    }
}
