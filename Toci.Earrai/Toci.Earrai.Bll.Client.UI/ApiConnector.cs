using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toci.Common.Microservices;

namespace Toci.Earrai.Bll.Client.UI
{
    public class ApiConnector
    {
        protected string BaseUrl = "http://something.com/api/";
        public async Task<string> GetAll()
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                var response = await hc.GetAsync("resource/7");

                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
