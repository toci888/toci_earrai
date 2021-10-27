using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public abstract class ImportBase
    {
        protected Logic<Product> ProductLogic = new Logic<Product>();
        protected Logic<Productsize> ProductSizeLogic = new Logic<Productsize>();
        protected Logic<Productoptionvalue> ProductOptionValue = new Logic<Productoptionvalue>();
        protected Logic<Areaquantity> AreaQuantity = new Logic<Areaquantity>();
        protected Logic<Quoteandprice> pricesLogic = new Logic<Quoteandprice>();
        protected Logic<Worksheet> WorksheetLogic = new Logic<Worksheet>();

        protected int categoryIndexColumn;

        // lodziki

        public virtual void ImportProduct(string worksheet, WorkbookRange range) // row? 
        {
            // extract product basic data and insert row
            List<string> rows = range.Values.RootElement.ToString()
                        .Replace("[[", "")
                        .Split("],[").ToList();

            Worksheet newSheet = WorksheetLogic.Insert(new Worksheet() { Sheetname = worksheet });


            Dictionary<string, Category> categories = CategoriesProvider.GetCategories();

            foreach (string row in rows)
            {
                List<string> productItem = row.Split(",").ToList();

                string productCategory = productItem[categoryIndexColumn].Replace("\"", "").Replace("\"", "");

                for (int i = 0; i < productItem.Count; i++)
                {
                    productItem[i] = productItem[i].Replace("\"", "").Replace("\"", "");
                }

                if (productCategory == "") continue; // empty category column(propably the whole row is empty)

                int categoryId = categories.ContainsKey(productCategory) ? categories[productCategory].Id : 0; // TODO dummy category
                if (categoryId == 0) continue; // some shit in FLTS row 83

                Product prod = ProductLogic.Insert(new Product() { Description = productItem[3].Replace("\"", "").Replace("\"", ""), Productaccountreference = productItem[2].Replace("\"", "").Replace("\"", ""), Idcategories = categoryId, Idworksheet = newSheet.Id });

                ImportAreas(productItem, prod.Id);
                ImportSizes(productItem, prod.Id);
                ImportOptions(productItem, prod.Id);
                ImportPricing(productItem, prod.Id);
            }
        }

        //protected 

        protected abstract void ImportAreas(List<string> row, int productId);

        protected abstract void ImportSizes(List<string> row, int productId);

        protected abstract void ImportOptions(List<string> row, int productId);

        protected abstract void ImportPricing(List<string> row, int productId);
    }
}
