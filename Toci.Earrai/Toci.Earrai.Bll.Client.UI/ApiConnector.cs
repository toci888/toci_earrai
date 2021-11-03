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

        public virtual List<List<Worksheetcontent>> SearchWorksheet(int worksheetId, string phrase)
        {
            return ApiGet<List<List<Worksheetcontent>>>("api/WorksheetContent/searchWorksheet/" + worksheetId + "/" + phrase);
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
    }
}
