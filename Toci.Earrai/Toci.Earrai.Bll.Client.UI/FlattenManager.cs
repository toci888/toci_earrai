using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Client.UI
{
    public class FlattenManager
    {
        protected Dictionary<string, FlattenBase> Flatteners = new Dictionary<string, FlattenBase>()
        {
            { "Product", new FlattenProduct() },
            { "Prices", new FlattenCollections() },
        };
        public virtual List<FlattenedEntity> FlattenProduct(ProductDto product)
        {
            List<FlattenedEntity> result = new List<FlattenedEntity>();

            foreach (KeyValuePair<string, FlattenBase> flatItem in Flatteners)
            {
                result.AddRange(flatItem.Value.Flatten(product));
            }

            return result;
        }
    }
}
