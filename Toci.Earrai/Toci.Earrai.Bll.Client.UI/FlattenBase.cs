using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI
{
    public abstract class FlattenBase
    {
        protected Dictionary<string, Func<object, List<FlattenedEntity>, List<FlattenedEntity>>> FlattenMap = new Dictionary<string, Func<object, List<FlattenedEntity>, List<FlattenedEntity>>>();

        public virtual List<FlattenedEntity> Flatten(object obj)
        {
            List<FlattenedEntity> result = new List<FlattenedEntity>();

            foreach (KeyValuePair<string, Func<object, List<FlattenedEntity>, List<FlattenedEntity>>> item in FlattenMap)
            {
                item.Value(obj, result);
            }

            return result;
        }

        protected virtual List<FlattenedEntity> Flatten<T>(List<T> collection, Func<T, List<FlattenedEntity>> mapper)
        {
            List<FlattenedEntity> result = new List<FlattenedEntity>();

            if (collection != null)
            {
                foreach (T obj in collection)
                {
                    result.AddRange(mapper(obj));
                }
            }

            return result;
        }
    }
}
