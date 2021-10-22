using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public static class CategoriesProvider
    {                      //prefix
        private static Dictionary<string, Category> Categories = new Dictionary<string, Category>();

        public static Dictionary<string, Category> GetCategories()
        {
            return Categories;
        }

        static CategoriesProvider()
        {
            Logic<Category> CategoriesLogic = new Logic<Category>();

            IEnumerable<Category> categories = CategoriesLogic.Select(m => true);

            foreach (Category item in categories)
            {
                Categories.Add(item.Prefix, item);
            }
        }
    }
}
