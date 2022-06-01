using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search.Distinct
{
    public class CategoryEqualityComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Prefix == y.Prefix;
        }

        public int GetHashCode([DisallowNull] Category obj)
        {
            return obj.Prefix.GetHashCode();
        }
    }
}
