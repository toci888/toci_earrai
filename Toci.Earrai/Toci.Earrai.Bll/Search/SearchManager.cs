using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Search
{
    public class SearchManager
    {
        protected Dictionary<int, SearchProductBase> SearchHelpers = new Dictionary<int, SearchProductBase>()
        {
            { 1, new ThicknessProductSearch() },
        };
    }
}
