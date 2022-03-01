using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Erp
{
    public class SageLogic : Logic<Product>, ISageLogic
    {
        IProductLogic ProdLogic = new ProductLogic();
        SageBackendLogic Sbl = new SageBackendLogic();

        public virtual List<ProductDto> Export(DateTime condition)
        {
            List<int> productIds = FilterDataToExport(condition);

            return productIds.Select(id => ProdLogic.GetProduct(id)).ToList();
        }

        protected virtual List<int> FilterDataToExport(DateTime condition)
        {
            return new List<int>() { 1, 8 };
        }

        public virtual int InsertEiEntity(List<EiEntity> entity)
        {
            return Sbl.InsertEiEntity(entity, 2); // todo
        }
    }
}
