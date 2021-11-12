using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class DimenstionABProductSearch : SearchProductBase
    {
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            List<Productssize> elements = new List<Productssize>();
            List<Product> result = new List<Product>();

            if (request.DimA.HasValue && request.DimB.HasValue)
            {
                //elements = ;
            }
            else if (request.DimA.HasValue)
            {
                elements = GetSizes(Consts.DimA, request.DimA.Value.ToString());
            }
            else if (request.DimB.HasValue)
            {
                elements = GetSizes(Consts.DimB, request.DimB.Value.ToString());
            }

            result = FilterResultsSizesWorksheet(request, elements);

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
