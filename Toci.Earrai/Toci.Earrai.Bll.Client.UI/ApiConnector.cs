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

                JArray json = JArray.Parse(responseContent);

                return json.ToObject<T>();
            }
        }

        public virtual List<string> GetProductsFiltersEx(ProductSearchRequestDto dto) ///api/Product/GetProductsFiltersEx
        {
            HttpContent content = JsonContent.Create<ProductSearchRequestDto>(dto);

            return ApiPost<List<string>>("api/Product/GetProductsFiltersEx", content);
        }

        public virtual List<ProductDto> GetProductsEx(ProductSearchRequestDto dto) ////api/Product/GetProductsEx
        {
            HttpContent content = JsonContent.Create<ProductSearchRequestDto>(dto);

            return ApiPost<List<ProductDto>>("api/Product/GetProductsEx", content);
        }
    }
}
