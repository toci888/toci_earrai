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
        protected Logic<Productsizesearch> SizeSearchLogic = new Logic<Productsizesearch>();
        protected Logic<Productoptionsearch> OptionsSearchLogic = new Logic<Productoptionsearch>();

        public virtual List<string> GetFilters(int worksheetId, string option)
        {
            List<string> result = new List<string>();

            if (option == Consts.Od)
            {
                //OptionsSearchLogic
                List<Productoptionsearch> sizeResult = OptionsSearchLogic.Select(m => m.Idworksheet == worksheetId && m.Name == option).Distinct(new OptionEqualityComparer()).ToList();

                foreach (Productoptionsearch item in sizeResult)
                {
                    result.Add(item.Value);
                }
            }
            else
            {
                List<Productsizesearch> sizeResult = SizeSearchLogic.Select(m => m.Idworksheet == worksheetId && m.Name == option).Distinct(new SizeEqualityComparer()).ToList();

                foreach (Productsizesearch item in sizeResult)
                {
                    result.Add(item.Value);
                }
            }

            return result.OrderBy(m => m).ToList();
        }
    }
}
