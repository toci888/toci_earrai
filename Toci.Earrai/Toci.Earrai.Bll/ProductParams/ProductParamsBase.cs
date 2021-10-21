using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;

namespace Toci.Earrai.Bll.ProductParams
{
    public abstract class ProductParamsBase
    {
        public abstract CalculationsBaseDto GetProductParams(int productId);
    }
}
