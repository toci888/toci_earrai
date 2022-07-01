using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Search.Distinct
{
    public class StockTakeValueEqualityComparer : IEqualityComparer<double?>
    {
        public bool Equals(double? x, double? y)
        {
            return x == y;
        }

        public int GetHashCode([DisallowNull] double? obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
}
