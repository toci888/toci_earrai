using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class DescriptionProductSearch : SearchProductBase
    {
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = ProductLogic.Select(p => p.Description == request.Value).ToList();

            return ToProductSearchResponseDto(FilterBySearchQuery(request, result));
        }
    }
}
