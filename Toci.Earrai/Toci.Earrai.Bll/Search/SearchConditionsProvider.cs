using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Search.Distinct;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class SearchConditionsProvider
    {
        protected Dictionary<List<string>, Func<SearchConditionsProvider, int, string, List<string>>> SearchMap = new Dictionary<List<string>, Func<SearchConditionsProvider, int, string, List<string>>>()
        {
            { new List<string> () { Consts.Od, Consts.Id, Consts.Type, Consts.Metric, Consts.Pcs }, (self, worksheetId, option) => self.GetFiltersOptions(worksheetId, option) },
            { new List<string> () { Consts.DimA, Consts.DimB, Consts.Thickness, Consts.Width, Consts.Length }, (self, worksheetId, option) => self.GetFiltersSizes(worksheetId, option) },
            { new List<string> () { Consts.Description }, (self, worksheetId, option) => self.GetFiltersProducts(worksheetId, option) },
            { new List<string>() { Consts.Category }, (self, worksheetId, option) => self.GetFiltersProductsCategories(worksheetId, option) },
            { new List<string>() { Consts.Balance }, (self, worksheetId, option) => self.GetFiltersProductsBalance(worksheetId, option) },
            { new List<string>() { Consts.Area }, (self, worksheetId, option) => self.GetFiltersProductsArea(worksheetId, option) },
            { new List<string>() { Consts.StockTakeValue }, (self, worksheetId, option) => self.GetFiltersProductsStv(worksheetId, option) },
        };

        protected Logic<Productsizesearch> SizeSearchLogic = new Logic<Productsizesearch>();
        protected Logic<Productoptionsearch> OptionsSearchLogic = new Logic<Productoptionsearch>();
        protected IProductLogic ProductSearchLogic = new ProductLogic();

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

        protected virtual List<string> GetFiltersProducts(int worksheetId, string option)
        {
            // TODO option potential recognition for now always description
            List<string> result = ProductSearchLogic.Select(p => p.Idworksheet == worksheetId).Distinct(new ProductEqualityComparer()).Select(m => m.Description).OrderBy(m => m).ToList();

            return result;
        }

        protected virtual List<string> GetFiltersProductsCategories(int worksheetId, string option)
        {
            // TODO option potential recognition for now always description
            List<string> result = ProductSearchLogic.GetProductsByWorksheet(worksheetId).Select(m => m.Category).Distinct(new CategoryEqualityComparer()).Select(m => m.Prefix).OrderBy(m => m).ToList();

            return result;
        }

        protected virtual List<string> GetFiltersProductsBalance(int worksheetId, string option)
        {
            List<string> result = ProductSearchLogic.GetProductsByWorksheet(worksheetId).Select(m => m.Balance).Distinct(new BalanceEqualityComparer()).Select(m => m.ToString()).OrderBy(m => m).ToList();

            return result;
        }

        protected virtual List<string> GetFiltersProductsStv(int worksheetId, string option)
        {
            List<string> result = ProductSearchLogic.GetProductsByWorksheet(worksheetId).Select(m => m.Pricing.StockTakeValue).Distinct(new StockTakeValueEqualityComparer()).Select(m => m.ToString()).OrderBy(m => m).ToList();

            return result;
        }

        protected virtual List<string> GetFiltersProductsArea(int worksheetId, string option)
        {
            List<List<string>> list = ProductSearchLogic.GetProductsByWorksheet(worksheetId).Select(m => m.AreaQuantities.Select(n => n.Areacode).ToList()).ToList();

            Dictionary<string, string> map = new Dictionary<string, string>();

            foreach (List<string> item in list)
            {
                foreach (string category in item)
                {
                    if (!map.ContainsKey(category))
                    {
                        map.Add(category, category);
                    }
                }
            }

            //List<string> result = ProductSearchLogic.GetProductsByWorksheet(worksheetId).Select(m => m.AreaQuantities.Select(n => n.Areacode).ToList()).ToList().Distinct(new AreaEqualityComparer()).Select(m => m.ToString()).OrderBy(m => m).ToList();

            return map.Select(m => m.Key).ToList();
        }
    }
}
