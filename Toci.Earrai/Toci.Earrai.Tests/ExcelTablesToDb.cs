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
            var authProvider = new DeviceCodeAuthProvider();
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