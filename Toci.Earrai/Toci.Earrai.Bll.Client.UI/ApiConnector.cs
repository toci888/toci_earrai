using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Client.UI
{
    public class ApiConnector
    {
        protected string BaseUrl = "http://51.137.109.9/";

        public virtual List<ProductDto> GetProductsByWorksheetId(string worksheetId)
        {
            return ApiGet<List<ProductDto>>("api/Product/GetProducts/" + worksheetId, true);
        }

        public virtual ProductDto GetProduct(int productId)
        {
            return ApiGet<ProductDto>("api/Product/GetProduct/" + productId, false);
        }

        public virtual List<Areaquantity> PostAreaQuantities(Areaquantity item) //POST
        {
            List<Areaquantity> parameter = new List<Areaquantity>()
            {
                item
            };

            return ApiPost<List<Areaquantity>, List<Areaquantity>>("api/AreaQuantity/PostAreaQuantities", parameter, true);
        }

        public virtual Areaquantity UpdateAreaQuantity(Areaquantity item) //POST
        {
            return ApiPost<Areaquantity, Areaquantity>("api/AreaQuantity/UpdateAreaQuantity", item, false);
        }
        //public virtual Areaquantity DeleteAreaQuantity() //DELETE
        //{
        //    return ApiGet<Areaquantity>("api/AreaQuantity/UpdateAreaQuantity");
        //}

        //public virtual Areaquantity DeleteUrl(int id) //POST
        //{
        //    return ApiGet<Areaquantity>("api/AreaQuantity/" + id);
        //}

        public virtual List<Product> GetProductsFromWorksheet(int worksheetId, string phrase, string skip) // phrase, skip? nigdy nie uzywa tego
        {
            return ApiGet<List<Product>>("api/Product/GetProducts/" + worksheetId + "/" + phrase + "/" + skip, true);
        }

        public virtual List<Worksheet> GetWorksheets() // phrase, skip? all, from db
        {
            return ApiGet<List<Worksheet>>("api/Worksheet/GetAllWorksheetsFromDb/", true);
        }

        public virtual List<Area> GetAreas()
        {
            return ApiGet<List<Area>>("api/Areas", true);
        }

        public virtual List<Areasquantity> GetAreasQuantitiesByProduct(int productId)
        {
            return ApiGet<List<Areasquantity>>("api/AreasQuantities/GetAreasQuantitiesByProduct/" + productId, true);
        }

        public virtual Commision GetCommisions(int productId, double price) //price?
        {
            return ApiGet<Commision>("api/Commisions/GetCommisions?productId=" + productId + "&price=" + price, false);
        }

        public virtual int PostQuoteandPrice(Quoteandprice item) //POST
        {
            return ApiPost<int, Quoteandprice>("api/QuoteAndPrice/PostQuoteandPrice", item, false);
        }

        public virtual List<Vendor> GetAllVendors() //price?
        {
            return ApiGet<List<Vendor>>("api/QuoteAndPrice/GetAllVendorsFromDb", true);
        }

        public virtual List<Quoteandmetric> GetQuoteAndMetric()
        {
            return ApiGet<List<Quoteandmetric>>("api/QuoteAndMetric", true);
        }

        public virtual List<Quoteandprice> GetQuotesAndPricesByProductId(int productId)
        {
            return ApiGet<List<Quoteandprice>>("api/QuoteAndPrice/QuoteAndPriceByProductId/" + productId, true);
        }

        protected virtual T ApiGet<T>(string url, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = hc.GetAsync(url).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                
                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        protected virtual T ApiPost<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.PostAsync(url, content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        public virtual List<string> GetProductsFiltersEx(ProductSearchRequestDto dto) ///api/Product/GetProductsFiltersEx
        {
            return ApiPost<List<string>, ProductSearchRequestDto>("api/Product/GetProductsFiltersEx", dto, true);
        }

        public virtual List<ProductDto> GetProductsEx(ProductSearchRequestDto dto) ////api/Product/GetProductsEx
        {
            return ApiPost<List<ProductDto>, ProductSearchRequestDto>("api/Product/GetProductsEx", dto, true);
        }

        public virtual User Login(string username, string password)
        {
            return ApiPost<User, User>("api/Account/Login", new User() { Email = username, Password = password }, false);
        }
    }
}
