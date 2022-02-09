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
using Toci.Earrai.Ui;

namespace Toci.Earrai.Bll.Client.UI
{
    public class ApiConnector
    {
        protected string BaseUrl = "http://82.153.17.97:8864/";

        public virtual List<ProductDto> GetProductsByWorksheetId(string worksheetId)
        {
            return ApiGet<List<ProductDto>>("api/Product/GetProducts/" + worksheetId, true);
        }

        public virtual ProductDto GetProduct(int productId)
        {
            return ApiGet<ProductDto>("api/Product/GetProduct/" + productId, false);
        }

        public virtual Dictionary<string, double> GetCommissions(int productId, double price)
        {
            return ApiGet<Dictionary<string, double>>("api/Commisions/GetCommisions?productId=" + productId + "&price=" + price, false);
        }

        public virtual List<Areaquantity> PostAreaQuantities(Areaquantity item) //POST
        {
            List<Areaquantity> parameter = new List<Areaquantity>()
            {
                item
            };

            return ApiPost<List<Areaquantity>, List<Areaquantity>>("api/AreaQuantity/PostAreaQuantities", parameter, true);
        }

        public virtual Areaquantity UpdateAreaQuantity(Areaquantity item) //PUT
        {
            return ApiPut<Areaquantity, Areaquantity>("api/AreaQuantity/UpdateAreaQuantity", item, false);
        }

        public virtual Quoteandprice UpdateQuoteAndPrice(Quoteandprice item) //PUT
        {
            return ApiPut<Quoteandprice, Quoteandprice>("api/QuoteAndPrice/UpdateQuoteAndPrice", item, false);
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

        public virtual int DeleteQuantity(int id)
        {
            return ApiDelete<int, int>("api/AreaQuantity/" + id, id, false);
        }

        public virtual int DeletePrice(int id)
        {
            return ApiDelete<int, int>("api/QuoteAndPrice/DeleteQuoteAndPrice/" + id, id, false);    
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

        public virtual List<Quotesandprice> GetQuotesAndPricesByProductId(int productId)
        {
            return ApiGet<List<Quotesandprice>>("api/QuoteAndPrice/QuoteAndPriceByProductId/" + productId, true);
        }

        public virtual int IncreasePrivileges(User user)
        {
            return ApiPost<int, User>("api/Priveleges/Increase", user, false);
        }

        public virtual int DecreasePrivileges(User user)
        {
            return ApiPost<int, User>("api/Priveleges/Decrease", user, false);
        }

        public virtual int ChangePrivileges(User user, int priveleges)
        {
            return ApiPost<int, User>("api/Priveleges/Change?privileges=" + priveleges, user, false);
        }

        protected virtual T ApiGet<T>(string url, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

                HttpResponseMessage response = hc.GetAsync(url).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        protected virtual T ApiPost<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                //todo logout
                if (LoggedUserContext.User != null)
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);
                }
                

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.PostAsync(url, content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        protected virtual T ApiPut<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.SendAsync(new HttpRequestMessage() 
                { Method = HttpMethod.Put, RequestUri = new Uri(url, UriKind.Relative), Content = content }).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        protected virtual T ApiDelete<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

                //  HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.SendAsync(new HttpRequestMessage()
                { Method = HttpMethod.Delete, RequestUri = new Uri(url, UriKind.Relative) }).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

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

        public virtual User Login(string email, string password)
        {
            return ApiPost<User, User>("api/Account/Login", new User() { Email = email, Password = password }, false);
        }

        public virtual int Register(string firstName, string lastName, string email, string password)
        {
            return ApiPost<int, User>("api/Account/Register", new User() { Firstname = firstName, Lastname = lastName, Email = email, Password = password }, false);
        }
    }
}
