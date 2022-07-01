using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Search
{
    public class BalanceProductSearch : SearchProductBase
    {
        public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            double requestBalance = 0;
            double.TryParse(request.Value, out requestBalance);

            List<ProductDto> result = ProductLogic.GetProductsByWorksheet(request.WorksheetId).Where(p => p.Balance == requestBalance).ToList();

            return result;
        }
    }
}
