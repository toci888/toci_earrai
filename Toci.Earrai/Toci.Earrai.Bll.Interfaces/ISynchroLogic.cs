using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface ISynchroLogic
    {
        int Save(List<ProductDto> productDtos);

        List<ProductDto> Get(DateTime? dateFrom = null);
    }
}
