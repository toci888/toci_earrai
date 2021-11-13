using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search.Distinct
{
    public class SizeEqualityComparer : IEqualityComparer<Productsizesearch>
    {
        public bool Equals(Productsizesearch x, Productsizesearch y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode([DisallowNull] Productsizesearch obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
