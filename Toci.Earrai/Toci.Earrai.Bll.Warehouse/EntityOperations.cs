using Microsoft.Graph;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations : Logic<Worksheetcontent>, IEntityOperations
    {
        public Worksheetcontentshistory InsertToHistory(int idWorksheet, int columnIndex, int rowIndex, string value)
        {
            Logic<Worksheetcontentshistory> worksheetHistory = new Logic<Worksheetcontentshistory>();

            Worksheetcontent oldCell = Select(m => m.Idworksheet == idWorksheet
                        && m.Columnindex == columnIndex && m.Rowindex == rowIndex).FirstOrDefault();

            if (oldCell is null)
            {
                return null;
            }

            Worksheetcontentshistory wch = worksheetHistory.Insert(new Worksheetcontentshistory()
            {
                Idworksheet = oldCell.Idworksheet,
                Columnindex = oldCell.Columnindex,
                Rowindex = oldCell.Rowindex,
                Value = oldCell.Value,
                Createdat = DateTime.Now
            });

            oldCell.Value = value;

            Update(oldCell);

            return wch;
        }

        public virtual IQueryable<Worksheetcontent> GetIncreaseOffline(DateTime dateTime)
        {
            return Select(m => m.Updatedat > dateTime);
        }

        public async void OneDriveTest()
        {
            var appId = "98a98443-1860-405d-9277-b8bccba724f7";
            var scopesString = "";
            string[] scopes = new[] { "https://graph.microsoft.com/User.ReadWrite.All", "https://graph.microsoft.com/Files.ReadWrite.All",
            "https://graph.microsoft.com/Files.Read.All", "https://graph.microsoft.com/Sites.Read.All",
            "https://graph.microsoft.com/Sites.ReadWrite.All" }; //api://98a98443-1860-405d-9277-b8bccba724f7/ApiAccess

            // Initialize the auth provider with values from appsettings.json
            var authProvider = new DeviceCodeAuthProvider(appId, scopes);

            // Request a token to sign in the user
            var accessToken = authProvider.GetAccessToken().Result; //"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiI5OGE5ODQ0My0xODYwLTQwNWQtOTI3Ny1iOGJjY2JhNzI0ZjciLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0L3YyLjAiLCJpYXQiOjE2Mjk1NTI3NDcsIm5iZiI6MTYyOTU1Mjc0NywiZXhwIjoxNjI5NTU2NjQ3LCJhaW8iOiJBVFFBeS84VEFBQUFiNkdxYzZscXNDbUoraXRqTlhvVitPTUJLK0lCNUZuUWYyeE8rWkYxczQyaXpQaC83MHBmTHIzSVhNcXNLcWhlIiwiYXpwIjoiOThhOTg0NDMtMTg2MC00MDVkLTkyNzctYjhiY2NiYTcyNGY3IiwiYXpwYWNyIjoiMCIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwicmgiOiIwLkFRd0FzTUxUNlFYTS1rR2ZSbnVUZDlHaWxFT0VxWmhnR0YxQWtuZTR2TXVuSlBjTUFJVS4iLCJzY3AiOiJBcGlBY2Nlc3MiLCJzdWIiOiJsNmVaZ05BTFdib3pzRlE3VURJVGh3S191WXozVWV2TVdFUzgwUjE1YndNIiwidGlkIjoiZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0IiwidXRpIjoiVlM1amZaM3ZjVS00dTZVVHFXWTBBQSIsInZlciI6IjIuMCJ9.f7LK83YJ-Dp1D0R2pF9L5LPEV74cdKqkM1oyG0z8u4jF3u-oltNteJD5q7ftcBo9irfNgs3jcwo66jO4d9ke3UCEdAhr4PxiS-lBBfRp8nVS-oURN1FS2kqam54VHuGOpBCM9Kpga76VRyvDQaJaGqSl4flJx4idd--qhdPPHLGfBitv--SVdvxhoHORoAQjaFZpKTkYjqWaxkiwBvb7cpRYEdCs522MY5OE1vnTX0-XRWI6w997evnodoNmNDa18qrVUAesn7zPksvuk7OaPQP9zZSyY9kxt9lT4SIOP1xaMnrtIs2bH1U5g0oRynrKWovTH9i2l8LNTTUx4ILRlA"; //

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            /*

            //Initialize ExcelEngine
            ExcelEngine excelEngine = new ExcelEngine();

            //Initialize IApplication
            IApplication application = excelEngine.Excel;

            //Enable fast record parsing
            application.UseFastRecordParsing = true;

            Stream stream = await graphClient.Me.Drive.Items["01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD"].Content.Request().GetAsync();

            //Set the stream position as '0'
            stream.Position = 0;
            //Initialize new MemoryStream and copy the existing stream to this new MemeoryStream
            MemoryStream file = new MemoryStream();
            stream.CopyTo(file);


            //Set the stream position as '0'
            file.Position = 0;

            //Load the stream into IWorkbook
            IWorkbook workbookPracka = application.Workbooks.Open(file);


            //Modify the Excel document
            workbookPracka.Worksheets[0].Range["A2"].Text = "Syncfusion Essential XlsIO";


            //Save the modified Excel document as new MemoryStream
            MemoryStream outputStream = new MemoryStream();
            workbookPracka.SaveAs(outputStream);

            //Set the stream position as '0'
            outputStream.Position = 0;

            //Upload the modified Excel document to OneDrive again
            await graphClient.Me.Drive.Items["01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD"].Content.Request().PutAsync<Microsoft.Graph.DriveItem>(outputStream);

            //Close the workbook
            workbookPracka.Close();

            //Dispose the ExcelEngine
            excelEngine.Dispose();

            */

            var cell = graphClient.Me.Drive.Items["01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD"].Workbook.Worksheets["Arkusz1"]
         .Cell(0, 0)
         .Request()
         .GetAsync()
         .Result
         .Values
         .RootElement
         .ToString();

            var readSheet = graphClient.Me.Drive.Items["01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD"].Workbook.Worksheets["Arkusz1"];

            var dupa = readSheet.Cell(0, 0).Request().PatchAsync(new WorkbookRange()
            {
                RowIndex = 1,
                ColumnIndex = 1,
                Values = JsonDocument.Parse("[[\"Toci 123\"]]")
            }).Result;

           // readSheet.Request().PutAsync(readSheet);
       

            /*
            WorkbookRange newContent = new WorkbookRange()
            {
                // Inspired from https://github.com/microsoftgraph/botframework-csharp-excelbot-rest-sample/blob/master/ExcelBot/Workers/CellWorker.cs#L64
                //   [Values = JToken.Parse($"[[\"{value}\"]]")]
                Values = Newtonsoft.Json.Linq.JToken.Parse("[[ \"dog\" ]]")
            };
            */

            var testRange = readSheet.Range("A2:A2").Request().GetAsync().Result;
            var bazka = testRange.Values.RootElement.ToString()
                .Replace("[[", "")
                .Replace("]]", "")
                .Split("],[").ToList();

        }




    }
}
