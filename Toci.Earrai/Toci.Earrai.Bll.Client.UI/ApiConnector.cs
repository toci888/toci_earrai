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
        protected string BaseUrl = "http://20.49.181.92/";

        public virtual List<List<Worksheetcontent>> SearchWorksheet(int worksheetId, string phrase)
        {
            return ApiGet<List<List<Worksheetcontent>>>("api/WorksheetContent/searchWorksheet/" + worksheetId + "/" + phrase);
        }

        public virtual ProductDto GetProduct(int productId)
        {
            return ApiGet<ProductDto>("api/Product/GetProduct/" + productId);
        }

        public virtual User GetUser(int userId)
        {
            return ApiGet<User>("api/");
        }

        public virtual Areaquantity PostAreaQuantities() //POST
        {
            return ApiGet<Areaquantity>("api/AreaQuantity/PostAreaQuantities");
        }

        public virtual Areaquantity UpdateAreaQuantity() //POST
        {
            return ApiGet<Areaquantity>("api/AreaQuantity/UpdateAreaQuantity");
        }
        public virtual Areaquantity DeleteAreaQuantity() //POST
        {
            return ApiGet<Areaquantity>("api/AreaQuantity/UpdateAreaQuantity");
        }

        public virtual Areaquantity DeleteUrl(int id) //POST
        {
            return ApiGet<Areaquantity>("api/AreaQuantity/" + id);
        }

        public virtual Product GetProductsEx() 
        {
            return ApiGet<Product>("api/Product/GetProductsEx");
        }

        public virtual List<Product> GetProductsFromWorksheet(int worksheetId, string phrase, string skip) // phrase, skip? nigdy nie uzywa tego
        {
            return ApiGet<List<Product>>("api/Product/GetProducts/" + worksheetId + "/" + phrase + "/" + skip);
        }

        public virtual List<Worksheet> GetWorksheets(int worksheetId, string phrase, string skip) // phrase, skip? all, from db
        {
            return ApiGet<List<Worksheet>>("api/Worksheet/GetAllWorksheetsFromDb/" + worksheetId + "/" + phrase + "/" + skip);
        }

        public virtual List<Area> GetAreas()
        {
            return ApiGet<List<Area>>("api/Areas");
        }

        public virtual List<Areasquantity> GetAreasQuantitiesByProduct(int productId)
        {
            return ApiGet<List<Areasquantity>>("api/AreasQuantities/GetAreasQuantitiesByProduct/" + productId);
        }

        public virtual List<Commision> GetCommisions(int productId, double price) //price?
        {
            return ApiGet<List<Commision>>("api/Commisions/GetCommisions?productId=" + productId + "&price=" + price);
        }

        public virtual Quoteandprice PostQuoteandPrice(int id) //POST
        {
            return ApiGet<Quoteandprice>("api/QuoteAndPrice/PostQuoteandPrice");
        }

        public virtual List<Vendor> GetVendors(int productId, double price) //price?
        {
            return ApiGet<List<Vendor>>("api/QuoteAndPrice/GetAllVendorsFromDb");
        }

        public virtual List<Quoteandprice> GetQuoteAndMetric()
        {
            return ApiGet<List<Quoteandprice>>("api/QuoteAndMetric");
        }

        public virtual List<Quoteandprice> GetQuotesAndPricesByProductId(int productId)
        {
            return ApiGet<List<Quoteandprice>>("api/QuoteAndPrice/QuoteAndPriceByProductId/" + productId);
        }

        public virtual List<Quoteandprice> GetAvailableValuesForSelectedOption() //TU TO NWM XD
        {
            return ApiGet<List<Quoteandprice>>("api/QuoteAndPrice/QuoteAndPriceByProductId/");
        }

        protected virtual T ApiGet<T>(string url)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = hc.GetAsync(url).Result;

                string content = response.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(content);

                return json.ToObject<T>();
            }
        }

        protected virtual T ApiPost<T>(string url, HttpContent content)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = hc.PostAsync(url, content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(responseContent);

                return json.ToObject<T>();
            }
        }

        public virtual List<string> GetProductsFiltersEx(ProductSearchRequestDto dto) ///api/Product/GetProductsFiltersEx
        {
            HttpContent content = JsonContent.Create<ProductSearchRequestDto>(dto);

            return ApiPost<List<string>>("api/Product/GetProductsFiltersEx", content);
        }
    }
}
