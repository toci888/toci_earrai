using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Client.UI
{
    public class ApiConnector
    {
        protected string BaseUrl = "https://localhost:44326/";
        public async Task<string> GetAll()
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                var response = await hc.GetAsync("resource/7");

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public virtual List<List<Worksheetcontent>> SearchWorksheet(int worksheetId, string phrase)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                var response = hc.GetAsync("api/WorksheetContent/searchWorksheet/" + worksheetId + "/" + phrase).Result;

                var dupa = response.Content.ReadAsStringAsync().Result;

                JObject json =  JObject.Parse(dupa);

                return json.ToObject<List<List<Worksheetcontent>>>();
            }
        }

        public virtual List<Worksheetcontent> GetIncrease(DateTime date)
        {
            return ApiGet<List<Worksheetcontent>>("api​/EntityOperations​/GetIncrease?dateTime=" + date.ToString());
        }

        protected virtual T ApiGet<T>(string url)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                var response = hc.GetAsync(url).Result;

                var dupa = response.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(dupa);

                return json.ToObject<T>();
            }
        }
    }
}
