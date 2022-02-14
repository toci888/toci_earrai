using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Erp
{
    public class SageLogic : Logic<Product>, ISageLogic
    {
        IProductLogic ProdLogic = new ProductLogic();

        public virtual List<ProductDto> Export(DateTime condition)
        {
            List<int> productIds = FilterDataToExport(condition);

            List<ProductDto> result = new List<ProductDto>();

            foreach (int id in productIds)
            {
                result.Add(ProdLogic.GetProduct(id));
            }

            return result;
        }

        protected virtual List<int> FilterDataToExport(DateTime condition)
        {
            return new List<int>() { 1, 8 };
        }
    }
}
