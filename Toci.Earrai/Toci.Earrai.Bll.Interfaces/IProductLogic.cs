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
    public interface IProductLogic : ILogicBase<Product>
    {
        ProductDto GetProduct(int productId);

        List<ProductDto> GetProductsByWorksheet(int worksheetId);

        int AddNewProduct(NewProductDto dto);
    }
}
