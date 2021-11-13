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
        protected Dictionary<int, SearchProductBase> SearchHelpers = new Dictionary<int, SearchProductBase>()
        {
            { 1, new ThicknessProductSearch() },
            { 2, new ThicknessProductSearch() },
            { 4, new DimenstionABProductSearch() },
            { 5, new DimenstionABProductSearch() },
            { 6, new WidthProductSearch() },
            { 7, new DimenstionABProductSearch() },
            { 8, new OdProductSearch() },
        };

        protected Dictionary<string, SearchProductBase> SearchHelpersEx = new Dictionary<string, SearchProductBase>()
        {
            { Consts.DimA, new DimenstionABProductSearch() },
            { Consts.DimB, new DimenstionABProductSearch() },
            { Consts.Od, new OdProductSearch() },
            { Consts.Thickness, new ThicknessProductSearch() },
            { Consts.Width, new WidthProductSearch() }
        };

        public virtual List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            if (SearchHelpers.ContainsKey(request.WorksheetId))
            {
                return SearchHelpers[request.WorksheetId].Search(request);
            }

            return null;
        }

        public virtual List<ProductSearchResponseDto> SearchEx(ProductSearchRequestDto request)
        {
            if (SearchHelpersEx.ContainsKey(request.Name))
            {
                return SearchHelpersEx[request.Name].Search(request);
            }

            return null;
        }
    }
}
