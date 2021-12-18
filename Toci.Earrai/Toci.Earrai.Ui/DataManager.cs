using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public class DataManager
    {
        protected ApiConnector ApiProxy = new ApiConnector();

        public DataManager()
        {
            
        }

        public virtual List<ProductDto> GetProducts(int worksheetId, string fieldName, string fieldValue)
        {
            return ApiProxy.GetProductsEx(new ProductSearchRequestDto()
            {
                WorksheetId = worksheetId,
                Name = fieldName,
                Value = fieldValue
            });

            //return new ProductLogic().GetProducts(worksheetId, fieldName, fieldValue); 
        }

        public virtual ProductDto GetProduct(int productId)
        {
            //ApiProxy.

            return new ProductLogic().GetProduct(productId);

            
        }

        public virtual List<Vendor> GetAllVendors()
        {
            //ApiProxy

            return new List<Vendor>()
            {
                new Vendor() { Id = 1, Name = "McCane" },
                new Vendor() { Id = 2, Name = "Wwatson" }
            };
        }

        public virtual List<Area> GetAllAreas()
        {
            //ApiProxy

            return new List<Area>()
            {
                new Area() { Id = 1, Name = "Garages" },
                new Area() { Id = 2, Name = "Back Yard" },
            };
        }

        public virtual List<Worksheet> GetWorksheets()
        {
            return ApiProxy.GetWorksheets();
        }

        public virtual List<ProductDto> GetProductsByWorksheetId(string worksheetId)
        {
            return ApiProxy.GetProductsByWorksheetId(worksheetId);
        }

        public virtual List<string> GetFilters(int worksheetId, string fieldName)
        {
            return ApiProxy.GetProductsFiltersEx(new ProductSearchRequestDto()
            {
                WorksheetId = worksheetId,
                Name = fieldName
            });
        }

    }
}
