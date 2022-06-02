using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

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

        Dictionary<string, Codesdimension> CodesDimensions;
        Dictionary<string, Area> Areas;

        protected int indexCounter = 0;
        protected int areasCounter = 0;
        protected int areasStart = 0;
        protected int numberOfAreas = 0;
        protected bool skipAreaWidth = false;

        protected ImportBase()
        {
            CodesDimensions = CodesDimensionProvider.GetCodesDimensions();
            Areas = AreasProvider.GetAreas();
        }
        
        public virtual void ImportProduct(string worksheet, List<List<string>> rows) // row? 
        {
            Worksheet newSheet = WorksheetLogic.Insert(new Worksheet() { Sheetname = worksheet });


            Dictionary<string, Category> categories = CategoriesProvider.GetCategories();
            int counter = 0;

            foreach (List<string> productItem in rows)
            {
                if (counter == 0)
                {
                    counter++;
                    continue;
                }
                
                string productCategory = productItem[categoryIndexColumn].Replace("\"", "").Replace("\"", "");

                for (int i = 0; i < productItem.Count; i++)
                {
                    productItem[i] = productItem[i].Replace("\"", "").Replace("\"", "");
                }

                if (productCategory == "") continue; // empty category column(propably the whole row is empty)
                if (!categories.ContainsKey(productCategory)) continue;
                
                int categoryId = categories[productCategory].Id; // TODO dummy category
                //if (categoryId == 0) continue; // some shit in FLTS row 83

                string productDescription = productItem[3].Replace("\"", "").Replace("\"", "");
                string accountReference = productItem[2].Replace("\"", "").Replace("\"", "");

                if (worksheet == "Tube_CHS" || worksheet == "Angles+T")
                {
                    productDescription = productItem[2].Replace("\"", "").Replace("\"", "");
                    accountReference = productItem[1].Replace("\"", "").Replace("\"", "");
                }
                
                Product prod = ProductLogic.Insert(new Product() { Description = productDescription, Productaccountreference = accountReference, Idcategories = categoryId, Idworksheet = newSheet.Id });

                ImportAreas(productItem, prod.Id);
                ImportSizes(productItem, prod.Id);
                ImportOptions(productItem, prod.Id);
                ImportPricing(productItem, prod.Id);

                counter++;
            }
        }

        //protected 

        protected virtual void ImportAreas(List<string> row, int productId)
        {
            indexCounter = areasStart;

            int idCodeDim = 1;

            if (CodesDimensions.ContainsKey(row[0]))
            {
                idCodeDim = CodesDimensions[row[0]].Id;
            }

            for (int i = 0; i < numberOfAreas; i++)
            {
                Areaquantity areaQuantity = new Areaquantity()
                {
                    Idproducts = productId,
                    Idcodesdimensions = idCodeDim
                };

                areaQuantity.Length = row[indexCounter];

                if (!skipAreaWidth)
                {
                    areaQuantity.Width = row[++indexCounter];
                }

                areaQuantity.Quantity = row[++indexCounter];

                string area = row[++indexCounter];

                if (!string.IsNullOrEmpty(area) && Areas.ContainsKey(area))
                {
                    areaQuantity.Idarea = Areas[area].Id;

                    AreaQuantity.Insert(areaQuantity);
                }

                ++indexCounter;
            }
        }

        protected abstract void ImportSizes(List<string> row, int productId);

        protected abstract void ImportOptions(List<string> row, int productId);

        protected abstract void ImportPricing(List<string> row, int productId);
    }
}
