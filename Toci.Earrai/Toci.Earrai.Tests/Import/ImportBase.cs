﻿using Microsoft.Graph;
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

        // lodziki

        public virtual void ImportProduct(WorkbookRange range) // row? 
        {
            // extract product basic data and insert row
            List<string> rows = range.Values.RootElement.ToString()
                        .Replace("[[", "")
                        .Split("],[").ToList();

            foreach (string row in rows)
            {
                List<string> productItem = row.Split(",").ToList();

                int categoryId = CategoriesProvider.GetCategories().ContainsKey(productItem[0]) ? CategoriesProvider.GetCategories()[productItem[0]].Id : 0; // TODO dummy category

                Product prod = ProductLogic.Insert(new Product() { Description = productItem[2], Productaccountreference = productItem[1] , Idcategories = categoryId });

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