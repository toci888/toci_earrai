using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Search.Distinct
{
    public class AreaEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.GetHashCode();   
        }
    }
}
