using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public abstract class ApplyToGridBase
    {
        protected List<Func<ProductDto, FlattenedEntity>> WorksheetColumnsMap = new List<Func<ProductDto, FlattenedEntity>>()
        {
            (product) => new FlattenedEntity() { Name = "Id", Value = product.Product.Id.ToString() },
            (product) => new FlattenedEntity() { Name = "Reference", Value = product.Product.Productaccountreference },
            (product) => new FlattenedEntity() { Name = "Balance", Value = product.Balance.ToString() },
            (product) => new FlattenedEntity() { Name = "Stock take value", Value = product.Pricing.StockTakeValue.ToString() },
        };

        protected virtual void AddToMap()
        {
            
        }

        public virtual List<FlattenedEntity> GetFlattenedProduct(ProductDto product)
        {
            AddToMap();

            List<FlattenedEntity> result = new List<FlattenedEntity>();

            int i = 0;

            foreach (Func<ProductDto, FlattenedEntity> delColumn in WorksheetColumnsMap)
            {
                FlattenedEntity fe = delColumn(product);
                fe.GridPosition = i;

                result.Add(fe);

                i++;
            }

            return result;
        }
    }
}
