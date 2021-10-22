using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public static class AreasProvider
    {                      //prefix
        private static Dictionary<string, Area> Areas = new Dictionary<string, Area>();

        public static Dictionary<string, Area> GetAreas()
        {
            return Areas;
        }

        static AreasProvider()
        {
            Logic<Area> CategoriesLogic = new Logic<Area>();

            IEnumerable<Area> categories = CategoriesLogic.Select(m => true);

            foreach (Area item in categories)
            {
                Areas.Add(item.Code, item);
            }
        }
    }
}
