using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IProductSizeLogic : ILogicBase<Productsize>
    {
        List<Productssize> GetProductSizes(int productId);

        List<Sizeworksheetelement> GetProductSizesAvailable(int worksheetId);

        bool SetNewProductSizes(int productId, List<SoDto> options);
    }
}
