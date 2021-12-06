using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Azure.Identity;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Toci.Earrai.Tests
{
    [TestClass]
    public class ExcelSharepoint
    {
    
        [TestMethod]
        public void win()
        {
            //Microsoft.Graph.GraphServiceClient graphServiceClient = new Microsoft.Graph.GraphServiceClient();

        }

        [TestMethod]
        public void graph()
        {


            var client = new GraphServiceClient(new DelegateAuthenticationProvider(async request =>
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", "eyJ0eXAiOiJKV1QiLCJub25jZSI6IlhTNkpUR0IwMkJROGdXVWhlSEtBRUJPaXVmcmdNbTVzbVh3VFdfSHpBY2ciLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQvIiwiaWF0IjoxNjI5NDQ5MDA3LCJuYmYiOjE2Mjk0NDkwMDcsImV4cCI6MTYyOTQ1MjkwNywiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQVRFdDdvQjZiYm9PQ3dnWEhvd01xTHYvTHVOWDZmdnNmSlgwajhMYXduU289IiwiYW1yIjpbInB3ZCJdLCJhcHBfZGlzcGxheW5hbWUiOiJHcmFwaCBFeHBsb3JlciIsImFwcGlkIjoiZGU4YmM4YjUtZDlmOS00OGIxLWE4YWQtYjc0OGRhNzI1MDY0IiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJaYXBhcnQiLCJnaXZlbl9uYW1lIjoiQmFydMWCb21pZWoiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiI4NS4yMjEuMTMwLjIxNiIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDE2RjhBNEU3NSIsInJoIjoiMC5BUXdBc01MVDZRWE0ta0dmUm51VGQ5R2lsTFhJaTk3NTJiRklxSzIzU05weVVHUU1BSVUuIiwic2NwIjoiRmlsZXMuUmVhZCBGaWxlcy5SZWFkLkFsbCBGaWxlcy5SZWFkV3JpdGUgRmlsZXMuUmVhZFdyaXRlLkFsbCBvcGVuaWQgcHJvZmlsZSBTaXRlcy5GdWxsQ29udHJvbC5BbGwgU2l0ZXMuTWFuYWdlLkFsbCBTaXRlcy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCBlbWFpbCIsInN1YiI6ImdNdDl1dzY5aUJOUFAwZFZCMHJnTUdqa25wNTZ4UGdLOUJackVKalpVanMiLCJ0ZW5hbnRfcmVnaW9uX3Njb3BlIjoiRVUiLCJ0aWQiOiJlOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQiLCJ1bmlxdWVfbmFtZSI6ImJ6YXBhcnRAdG9jaXphcGFydC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwidXRpIjoidC1CWlhOcFd2a0dyM2gxVGprNWFBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19zdCI6eyJzdWIiOiJWYkRCek15SmNXMGstUzFPUjVUX3NFOVJsNjhOM1FMMHMwTkpsMnFqZlQ4In0sInhtc190Y2R0IjoxNjI5Mzc1MDEzfQ.hu2lVqfEvCcitRRd64dRcBw9S-v0kOKazSu2L-KYdM9a42U6jjkpuJ8OZ6toG5HLztt9_-FIchux2EmTTohOOEuv6IfhEAn2iJY0-sTvac89pPj9A5VON0DRK7O5KNzRgGizVSLxQMFrKLMeiJAlu4woMek4Ci8oj-fv-RGANAt49bRh8qtcyouhfZ89ozcyV6HNKQq7lPj-10scxYhq38AlI7FJIl65iq4dMxtpcbUZ38ILAIOe3uFAndYRRtfCZIRg5KL1H8vcha65q_P3qD-Y-KHll8cw16AaF3Kt2BVhEEWitY_NdoOz9ApEKsTiOGmoQoQ8LkvZB_j5lg6CAg");
            }));

            var messages = client.Me.Messages.Request().Top(10).GetAsync().Result;

            foreach (var item in messages)
            {
                var x = item.Subject + "   " + item.SentDateTime;
            }

            var s = string.Empty;

        }

        public class UserInfo
        {
            public string Name { get; set; }
            public string Address { get; set; }

        }

        public class UserInfoRequest
        {
            public string index { get; set; }
            public string[][] values { get; set; }
        }

        //string[] scopes = new[] { "https://localhost/api/users" };
        //string oboToken = "Bearer: eyJ0eXAiOiJKV1QiLCJub25jZSI6IjdUc1czYmpRUXRUb2tTWEpDM0hoQkpEdjhWa2FUVnBfT1FYTWtRR0h5aG8iLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQvIiwiaWF0IjoxNjI5NDQ1MTY3LCJuYmYiOjE2Mjk0NDUxNjcsImV4cCI6MTYyOTQ0OTA2NywiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQUtmTGRFUDQvcGZ5QTR3OTYvNi9xNU5rb0JUaStxSHhDc2UrY0MvdWRQbjQ9IiwiYW1yIjpbInB3ZCJdLCJhcHBfZGlzcGxheW5hbWUiOiJHcmFwaCBFeHBsb3JlciIsImFwcGlkIjoiZGU4YmM4YjUtZDlmOS00OGIxLWE4YWQtYjc0OGRhNzI1MDY0IiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJaYXBhcnQiLCJnaXZlbl9uYW1lIjoiQmFydMWCb21pZWoiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiI4NS4yMjEuMTMwLjIxNiIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDE2RjhBNEU3NSIsInJoIjoiMC5BUXdBc01MVDZRWE0ta0dmUm51VGQ5R2lsTFhJaTk3NTJiRklxSzIzU05weVVHUU1BSVUuIiwic2NwIjoiRmlsZXMuUmVhZCBGaWxlcy5SZWFkLkFsbCBGaWxlcy5SZWFkV3JpdGUgRmlsZXMuUmVhZFdyaXRlLkFsbCBvcGVuaWQgcHJvZmlsZSBTaXRlcy5GdWxsQ29udHJvbC5BbGwgU2l0ZXMuTWFuYWdlLkFsbCBTaXRlcy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCBlbWFpbCIsInN1YiI6ImdNdDl1dzY5aUJOUFAwZFZCMHJnTUdqa25wNTZ4UGdLOUJackVKalpVanMiLCJ0ZW5hbnRfcmVnaW9uX3Njb3BlIjoiRVUiLCJ0aWQiOiJlOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQiLCJ1bmlxdWVfbmFtZSI6ImJ6YXBhcnRAdG9jaXphcGFydC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwidXRpIjoiY1hocU14U0FyMENTcm5FSVNMVUpBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19zdCI6eyJzdWIiOiJWYkRCek15SmNXMGstUzFPUjVUX3NFOVJsNjhOM1FMMHMwTkpsMnFqZlQ4In0sInhtc190Y2R0IjoxNjI5Mzc1MDEzfQ.QnvWTu3HanOfrPE3vgIOD1Uj46oeJfpgWOXj3Rg0o6418JrD6RWBjWlBEfl_xgB3CE0yh4Vz6dUTYSqoq9SEcV-DStfJt5JezYql2WmRko0Buuf7KqPYlGjal5xGzBrek1K4bvNsPkIIre9zD8N4fa2XgTo5uw2ReQJAEwYm5yTWMX0_rgdMikPgpGKw1AkvnWRHwgWr5sCtMnY49fBaDh299i_THqmrPC-qc6Zy_75ne9DAJJXIz8Y_qSiaqQRvm0acYD8r_MyVSoYZGJjGcH9liPX5lIw-1poZ8IWelfzSFPM3q1OjvM0FwLcRIdZa3vz40OGjAV4A3W8pEY4k0Q";
        string[] scopes = new[] { "https://graph.microsoft.com/User.Read" };
        string oboToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IjdUc1czYmpRUXRUb2tTWEpDM0hoQkpEdjhWa2FUVnBfT1FYTWtRR0h5aG8iLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQvIiwiaWF0IjoxNjI5NDQ1MTY3LCJuYmYiOjE2Mjk0NDUxNjcsImV4cCI6MTYyOTQ0OTA2NywiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFTUUEyLzhUQUFBQUtmTGRFUDQvcGZ5QTR3OTYvNi9xNU5rb0JUaStxSHhDc2UrY0MvdWRQbjQ9IiwiYW1yIjpbInB3ZCJdLCJhcHBfZGlzcGxheW5hbWUiOiJHcmFwaCBFeHBsb3JlciIsImFwcGlkIjoiZGU4YmM4YjUtZDlmOS00OGIxLWE4YWQtYjc0OGRhNzI1MDY0IiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJaYXBhcnQiLCJnaXZlbl9uYW1lIjoiQmFydMWCb21pZWoiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiI4NS4yMjEuMTMwLjIxNiIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDE2RjhBNEU3NSIsInJoIjoiMC5BUXdBc01MVDZRWE0ta0dmUm51VGQ5R2lsTFhJaTk3NTJiRklxSzIzU05weVVHUU1BSVUuIiwic2NwIjoiRmlsZXMuUmVhZCBGaWxlcy5SZWFkLkFsbCBGaWxlcy5SZWFkV3JpdGUgRmlsZXMuUmVhZFdyaXRlLkFsbCBvcGVuaWQgcHJvZmlsZSBTaXRlcy5GdWxsQ29udHJvbC5BbGwgU2l0ZXMuTWFuYWdlLkFsbCBTaXRlcy5SZWFkLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFVzZXIuUmVhZCBlbWFpbCIsInN1YiI6ImdNdDl1dzY5aUJOUFAwZFZCMHJnTUdqa25wNTZ4UGdLOUJackVKalpVanMiLCJ0ZW5hbnRfcmVnaW9uX3Njb3BlIjoiRVUiLCJ0aWQiOiJlOWQzYzJiMC1jYzA1LTQxZmEtOWY0Ni03YjkzNzdkMWEyOTQiLCJ1bmlxdWVfbmFtZSI6ImJ6YXBhcnRAdG9jaXphcGFydC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwidXRpIjoiY1hocU14U0FyMENTcm5FSVNMVUpBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19zdCI6eyJzdWIiOiJWYkRCek15SmNXMGstUzFPUjVUX3NFOVJsNjhOM1FMMHMwTkpsMnFqZlQ4In0sInhtc190Y2R0IjoxNjI5Mzc1MDEzfQ.QnvWTu3HanOfrPE3vgIOD1Uj46oeJfpgWOXj3Rg0o6418JrD6RWBjWlBEfl_xgB3CE0yh4Vz6dUTYSqoq9SEcV-DStfJt5JezYql2WmRko0Buuf7KqPYlGjal5xGzBrek1K4bvNsPkIIre9zD8N4fa2XgTo5uw2ReQJAEwYm5yTWMX0_rgdMikPgpGKw1AkvnWRHwgWr5sCtMnY49fBaDh299i_THqmrPC-qc6Zy_75ne9DAJJXIz8Y_qSiaqQRvm0acYD8r_MyVSoYZGJjGcH9liPX5lIw-1poZ8IWelfzSFPM3q1OjvM0FwLcRIdZa3vz40OGjAV4A3W8pEY4k0Q";
        IConfidentialClientApplication cca;

        [TestMethod]
        public void AddInfoToExcel()
        {
           
            var tenantId = "e9d3c2b0-cc05-41fa-9f46-7b9377d1a294";

            // Values from app registration
            var clientId = "98a98443-1860-405d-9277-b8bccba724f7";
            var clientSecret = "5798ed19-2416-4215-8e40-7566c3b86ae0";

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            // This is the incoming token to exchange using on-behalf-of flow
            
            cca = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var authProvider = new DelegateAuthenticationProvider(async (request) => {
                var assertion = new UserAssertion(oboToken);
                var result = await cca.AcquireTokenOnBehalfOf(scopes, assertion).ExecuteAsync();

                request.Headers.Authorization =
                     new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
            });

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            graphClient.BaseUrl = "https://graph.microsoft.com/beta";

            var workbookWorksheet = new WorkbookWorksheet
            {
                Position = 99,
                Name = "name-value",
                Visibility = "visibility-value"
            };

            //var x = graphClient.Me.Drive.List;
            var readSheet = graphClient.Me.Drive.Items["01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD"].Workbook.Worksheets["Arkusz1"];

            var readTables = readSheet.Tables.Request().GetAsync().Result;
            string readTableId = readTables[0].Name;
            var table = readSheet.Tables[readTableId].Rows.Request().GetAsync().Result;
            //await graphClient.Me.Drive.Items["{driveItem-id}"].Workbook.Worksheets["{workbookWorksheet-id}"]
            //    .Request()
            //    .UpdateAsync(workbookWorksheet);

        }

        private async void del(HttpRequestMessage request)
        {
            // Use Microsoft.Identity.Client to retrieve token
            
        }
    }
}
