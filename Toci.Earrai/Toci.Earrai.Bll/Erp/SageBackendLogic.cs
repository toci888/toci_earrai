using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Erp
{
    public class SageBackendLogic : Logic<Erpproductvalue>
    {
        protected Logic<Product> Products = new Logic<Product>();

        protected virtual Dictionary<string, int> GetErpColumns()
        {
            Logic<Erpcolumn> erpColumns = new Logic<Erpcolumn>();

            List<Erpcolumn> allColumns = erpColumns.Select(x => true).ToList();

            return allColumns.ToDictionary(column => column.Name, column => column.Id);
        }

        public virtual int InsertEiEntity(List<EiEntity> entities)
        {
            Dictionary<string, int> ErpColumns = GetErpColumns();

            foreach (EiEntity entity in entities)
            {
                Product prod = Products.Insert(new Product()
                {
                    Productaccountreference = entity.AccountReference,
                    Description = entity.Description
                });

                foreach (KeyValuePair<string, int> column in ErpColumns)
                {
                    PropertyInfo property = entity.GetType().GetProperty(column.Key.Replace("ProductRecord.", ""));

                    if (property != null)
                    {
                        Insert(new Erpproductvalue()
                        {
                            Iderpcolumn = column.Value,
                            Value = property.GetValue(entity).ToString(),
                            Idproduct = prod.Id
                        });
                    }
                }
            }
            
            return 0;
        }
    }
}