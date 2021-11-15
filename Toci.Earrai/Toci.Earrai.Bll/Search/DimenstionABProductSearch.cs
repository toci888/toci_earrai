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

            if (request.Name == Consts.DimA)
            {
                elements = GetSizes(Consts.DimA, request.Value);
            }
            else 
            {
                elements = GetSizes(Consts.DimB, request.Value);
            }

            result = FilterResultsSizesWorksheet(request, elements);

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
