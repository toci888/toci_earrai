using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class ThicknessProductSearch : SearchProductBase
    {
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = new List<Product>();
            //thickness ....
            if (request.Thickness.HasValue)
            {
                List<Productssize> elements =  GetSizes(Consts.Thickness, request.Thickness.Value.ToString());
                result = FilterResultsSizesWorksheet(request, elements);
            }

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
