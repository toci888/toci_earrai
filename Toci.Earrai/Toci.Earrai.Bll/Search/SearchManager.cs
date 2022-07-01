using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Search
{
    public class SearchManager
    {
        protected Dictionary<string, SearchProductBase> SearchHelpersEx = new Dictionary<string, SearchProductBase>()
        {
            { Consts.DimA, new DimenstionABProductSearch() },
            { Consts.DimB, new DimenstionABProductSearch() },
            { Consts.Od, new OdProductSearch() },
            { Consts.Type, new OdProductSearch() },
            { Consts.Metric, new OdProductSearch() },
            { Consts.Pcs, new OdProductSearch() },
            { Consts.Id, new OdProductSearch() },
            { Consts.Thickness, new ThicknessProductSearch() },
            { Consts.Width, new WidthProductSearch() },
            { Consts.Length, new LengthProductSearch() },
            { Consts.Description, new DescriptionProductSearch() },
            { Consts.Category, new CategoryProductSearch() },
            { Consts.Balance, new BalanceProductSearch() }
        };


        public virtual List<ProductDto> SearchEx(ProductSearchRequestDto request)
        {
            if (SearchHelpersEx.ContainsKey(request.Name))
            {
                return SearchHelpersEx[request.Name].Search(request);
            }

            return null;
        }
    }
}
