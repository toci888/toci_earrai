using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Search.Distinct;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class SearchConditionsProvider
    {
        protected Dictionary<List<string>, Func<SearchConditionsProvider, int, string, List<string>>> SearchMap = new Dictionary<List<string>, Func<SearchConditionsProvider, int, string, List<string>>>()
        {
            { new List<string> () { Consts.Od, Consts.Type, Consts.Metric }, (self, worksheetId, option) => self.GetFiltersOptions(worksheetId, option) },
            { new List<string> () { Consts.DimA, Consts.DimB, Consts.Thickness, Consts.Width }, (self, worksheetId, option) => self.GetFiltersSizes(worksheetId, option) }
        };

        protected Logic<Productsizesearch> SizeSearchLogic = new Logic<Productsizesearch>();
        protected Logic<Productoptionsearch> OptionsSearchLogic = new Logic<Productoptionsearch>();

        public virtual List<string> GetFilters(int worksheetId, string option)
        {
            foreach (KeyValuePair<List<string>, Func<SearchConditionsProvider, int, string, List<string>>> item in SearchMap)
            {
                if (item.Key.Contains(option))
                {
                    return item.Value(this, worksheetId, option);
                }
            }

            return new List<string>();
        }

        protected virtual List<string> GetFiltersOptions(int worksheetId, string option)
        {
            List<string> result = new List<string>();

            //OptionsSearchLogic
            List<Productoptionsearch> sizeResult = OptionsSearchLogic.Select(m => m.Idworksheet == worksheetId && m.Name == option).Distinct(new OptionEqualityComparer()).ToList();

            foreach (Productoptionsearch item in sizeResult)
            {
                result.Add(item.Value);
            }

            return result.OrderBy(m => m).ToList();
        }

        protected virtual List<string> GetFiltersSizes(int worksheetId, string option)
        {
            List<string> result = new List<string>();

            List<Productsizesearch> sizeResult = SizeSearchLogic.Select(m => m.Idworksheet == worksheetId && m.Name == option).Distinct(new SizeEqualityComparer()).ToList();

                foreach (Productsizesearch item in sizeResult)
                {
                    result.Add(item.Value);
                }
            

            return result.OrderBy(m => m).ToList();
        }
    }
}
