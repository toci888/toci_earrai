using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public class CategoryLengthsProvider
    {
        Dictionary<int, double> CategoryLengthsMap = new Dictionary<int, double>();

        public virtual double GetCategoryLength(int categoryId)
        {
            return 6.1; // TODO
        }
    }
}
