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
        }

        public virtual ProductDto GetProduct(int productId)
        {
            return ApiProxy.GetProduct(productId);           
        }

        public virtual List<Vendor> GetAllVendors()
        {
            return ApiProxy.GetAllVendors();
        }

        public virtual List<Area> GetAllAreas()
        {
            return ApiProxy.GetAreas();
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

        public virtual List<Areaquantity> PostAreaQuantity(Areaquantity areaquantity)
        {
            return ApiProxy.PostAreaQuantities(areaquantity);
        }


    }
}
