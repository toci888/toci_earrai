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

        protected int categoryIndexColumn;

        // lodziki

        public virtual void ImportProduct(WorkbookRange range) // row? 
        {
            // extract product basic data and insert row
            List<string> rows = range.Values.RootElement.ToString()
                        .Replace("[[", "")
                        .Split("],[").ToList();


            Dictionary<string, Category> categories = CategoriesProvider.GetCategories();

            foreach (string row in rows)
            {
                List<string> productItem = row.Split(",").ToList();

                string productCategory = productItem[categoryIndexColumn].Replace("\"", "").Replace("\"", "");

                if (productCategory == "") continue; // empty category column(propably the whole row is empty)

                int categoryId = categories.ContainsKey(productCategory) ? categories[productCategory].Id : 0; // TODO dummy category
                if (categoryId == 0) continue; // some shit in FLTS row 83

                Product prod = ProductLogic.Insert(new Product() { Description = productItem[3].Replace("\"", "").Replace("\"", ""), Productaccountreference = productItem[2].Replace("\"", "").Replace("\"", ""), Idcategories = categoryId, Idworksheet = 1 });

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
