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
    public interface IProductOptionValuesLogic : ILogicBase<Productoptionvalue>
    {
        List<Productsoptionsstate> GetProductValues(int productId);

        List<Optionworksheetelement> GetProductOptionsAvailable(int worksheetId);

        bool SetNewProductOptions(int productId, List<SoDto> options);
    }
}
