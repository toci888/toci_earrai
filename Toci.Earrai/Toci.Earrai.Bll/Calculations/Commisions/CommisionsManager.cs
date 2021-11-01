using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Commisions
{
    public class CommisionsManager
    {
        protected Dictionary<string, double> CommisionsMap = new Dictionary<string, double>()
        {
            { "30%", 1.3 },
            { "35%", 1.35 },
            { "40%", 1.4 },
            { "50%", 1.5 },
        };

        public virtual Dictionary<string, double> GetPricesForCommisions(double basePrice)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (KeyValuePair<string, double> item in CommisionsMap)
            {
                result.Add(item.Key, basePrice * item.Value);
            }

            return result;
        }
    }
}
