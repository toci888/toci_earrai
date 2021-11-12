using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class WidthProductSearch : SearchProductBase
    {
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = new List<Product>();
            //width ....
            if (request.Width.HasValue)
            {
                List<Productssize> elements = GetSizes(Consts.Width, request.Width.Value.ToString());
                result = FilterResultsSizesWorksheet(request, elements);
            }

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
