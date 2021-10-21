using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.ProductParams;

namespace Toci.Earrai.Bll.Managers.Base
{
    public abstract class PdManagerBase
    {
        protected Dictionary<string, ProductParamsBase> ProductParamsDataSourceMap;
    }
}
