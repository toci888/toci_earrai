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
            { 3, new DimenstionABProductSearch() },
            { 5, new DimenstionABProductSearch() },
            { 4, new WidthProductSearch() },
            { 7, new DimenstionABProductSearch() },
            { 8, new OdProductSearch() },
        };

        public virtual List<ProductSearchResponseDto> Search(ProductSearchRequestDto request)
        {
            if (SearchHelpers.ContainsKey(request.WorksheetId))
            {
                return SearchHelpers[request.WorksheetId].Search(request);
            }

            return null;
        }
    }
}
