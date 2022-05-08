using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Calculations.Pricing.ParametersProviders
{
    public abstract class ParameterProviderBase
    {
        public abstract ProductDto FillWidthAndLength(ProductDto product);

        public abstract ProductDto FillMissingOptions(ProductDto product);
    }
}
