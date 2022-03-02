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
        Logic<Erpproduct> SageProductLogic = new Logic<Erpproduct>();

        public virtual List<EiEntity> Export(DateTime condition)
        {
            List<EiEntity> result = new List<EiEntity>();
            List<int> productIds = FilterDataToExport(condition);

            List<ProductDto> products = productIds.Select(id => ProdLogic.GetProduct(id)).ToList();

            foreach (ProductDto prod in products)
            {
                List<Erpproduct> data = SageProductLogic.Select(m => m.Idproduct == prod.Product.Id).ToList();

                result.Add(FlattenSageData(data));
            }

            //todo any business logic about the data HERE

            return result;
        }

        protected virtual EiEntity FlattenSageData(List<Erpproduct> productDataCollection)
        {
            EiEntity result = new EiEntity();

            foreach (Erpproduct item in productDataCollection)
            {
                string propName = item.Name.Replace("ProductRecord.", "");

                PropertyInfo propInfo = result.GetType().GetProperty(propName);

                propInfo.SetValue(result, item.Value);
            }

            return result;
        }

        protected virtual List<int> FilterDataToExport(DateTime condition)
        {
            return new List<int>() { 727, 728 }; //todo
        }

        public virtual int InsertEiEntity(List<EiEntity> entity)
        {
            return Sbl.InsertEiEntity(entity, 2); // todo
        }
    }
}
