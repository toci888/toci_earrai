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
        protected List<Func<ProductDto, FlattenedEntity>> WorksheetColumnsMap = new List<Func<ProductDto, FlattenedEntity>>();

        public virtual List<FlattenedEntity> GetFlattenedProduct(ProductDto product)
        {
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
