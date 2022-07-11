using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Earrai.Tests.Endpoints
{
    [TestClass]
    public class AuthorizeTest
    {
        [TestMethod]
        public void UnitTest1()
        {
            HttpClient client = new HttpClient();

            Task<HttpResponseMessage> response = client.GetAsync("http://127.0.0.1:8642/api/areas");
            HttpResponseMessage x = response.Result;
        }
    }
}