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
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = new List<Product>();
            //od ....
            if (request.Name == Consts.Od)
            {
                List<Productsoptionsstate> elements = GetOptions(Consts.Od, request.Value);
                result = FilterResultsOptionsWorksheet(request, elements);
            }

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
