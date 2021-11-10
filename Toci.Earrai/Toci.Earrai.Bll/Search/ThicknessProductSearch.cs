using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Search
{
    public class ThicknessProductSearch : SearchProductBase
    {
        public override List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            //thickness ....

            if (string.IsNullOrEmpty(request.Name))
            {
                
            }

            return null;
        }
    }
}
