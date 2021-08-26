using System.Linq;
using Microsoft.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Earrai.Bll;
using Toci.Microsoft.Graph.Excel;

namespace Toci.Earrai.Tests
{
    [TestClass]
    public class ExcelTablesToDb
    {
        [TestMethod]
        public void GetAllTables()
        {
            var appId = "98a98443-1860-405d-9277-b8bccba724f7";

            string[] scopes = new[] {
                "https://graph.microsoft.com/User.ReadWrite.All",
                "https://graph.microsoft.com/Files.ReadWrite.All",
                "https://graph.microsoft.com/Files.Read.All",
                "https://graph.microsoft.com/Sites.Read.All",
                "https://graph.microsoft.com/Sites.ReadWrite.All" };

            var authProvider = new DeviceCodeAuthProvider(appId, scopes);
            EntityGeneratorService graph = new EntityGeneratorService();

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;

            var readSheets = graphClient.Me.Drive.Items["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Workbook.Worksheets.Request().GetAsync().Result.ToList();

            var tables = graphClient.Me.Drive.Items["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Workbook.Tables
                .Request()
                .GetAsync();
        }
    }
}