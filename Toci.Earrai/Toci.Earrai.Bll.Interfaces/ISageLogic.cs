using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface ISageLogic : ILogicBase<Product>
    {
        List<List<string>> Export(DateTime condition);
        int Import(List<EiEntity> entity);
    }
}
