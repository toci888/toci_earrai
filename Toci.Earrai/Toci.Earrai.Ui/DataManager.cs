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

        public virtual List<ProductDto> GetProducts(int worksheetId, string fieldName, string fieldValue, string stockTakeMin, string stockTakeMax)
        {
            return ApiProxy.GetProductsEx(new ProductSearchRequestDto()
            {
                WorksheetId = worksheetId,
                Name = fieldName,
                Value = fieldValue,
                StockTakeValueMin = stockTakeMin,
                StockTakeValueMax = stockTakeMax
            });
        }

        public virtual ProductDto GetProduct(int productId)
        {
            return ApiProxy.GetProduct(productId);           
        }

        public virtual List<Category> GetCategoriesForWorksheet(int worksheetId)
        {
            return ApiProxy.GetCategoriesForWorksheet(worksheetId);
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

        public virtual Areaquantity UpdateAreaQuantity(Areaquantity areaquantity)
        {
            return ApiProxy.UpdateAreaQuantity(areaquantity);
        }

        public virtual Quoteandprice UpdateQuoteandprice(Quoteandprice item)
        {
            return ApiProxy.UpdateQuoteAndPrice(item);
        }

        public virtual int DeleteQuoteAndPrice(int id)
        {
            return ApiProxy.DeletePrice(id);
        }

        public virtual int DeleteQuantity(int id)
        {
            return ApiProxy.DeleteQuantity(id);
        }

        public virtual Dictionary<string, double> GetCommissions(int productId, double price)
        {
            return ApiProxy.GetCommissions(productId, price);
        }

        public virtual Userrole Login(string user, string pass)
        {
            return ApiProxy.Login(user, pass);
        }

        public virtual int Register(string firstName, string lastName, string email, string password)
        {
            return ApiProxy.Register(firstName, lastName, email, password);
        }

        public virtual List<Quoteandmetric> GetQuotesAndMetrics()
        {
            return ApiProxy.GetQuoteAndMetric();
        }

        public virtual int AddQuoteandPrice(Quoteandprice item)
        {
            return ApiProxy.PostQuoteandPrice(item);
        }

        public virtual int AddProduct(NewProductDto item)
        {
            return ApiProxy.AddNewProduct(item);
        }

        public virtual List<Areasquantity> GetQuantites(int productId)
        {
            return ApiProxy.GetAreasQuantitiesByProduct(productId);
        }

        public virtual List<Quotesandprice> GetPrices(int productId)
        {
            return ApiProxy.GetQuotesAndPricesByProductId(productId);
        }

        public virtual List<Userrole> GetAllUsers()
        {
            return ApiProxy.GetAllUsers();
        }

        public virtual int ChangePrivileges(User user, int priveleges)
        {
            return ApiProxy.ChangePrivileges(user, priveleges);
        }

        public virtual int CreateUser(User user)
        {
            return ApiProxy.CreateUser(user);
        }

        public virtual int ResetPassword(int userId, string password)
        {
            return ApiProxy.ResetPassword(userId, password);
        }

        public virtual OptionsSizesAvailableDto GetAvailableOptionsSizes(int worksheetId)
        {
            return ApiProxy.GetAvailableOptionsSizes(worksheetId);
        }

        public virtual List<List<string>> ExportToSage()
        {
            return ApiProxy.ExportToSage();
        }
    }
}
