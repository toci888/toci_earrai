using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class OdProductSearch : SearchProductBase
    {
        protected List<string> Options = new List<string>() { Consts.Od, Consts.Id, Consts.Type, Consts.Metric, Consts.Pcs   };
    public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = new List<Product>();
            //od ....
            if (Options.IndexOf(request.Name) > -1)
            {
                List<Productsoptionsstate> elements = GetOptions(request.Name, request.Value);
                result = FilterResultsOptionsWorksheet(request, elements);
            }

            return SearchByStockTakeValue(ToProductDto(FilterBySearchQuery(request, result)), request);
        }
    }
}
