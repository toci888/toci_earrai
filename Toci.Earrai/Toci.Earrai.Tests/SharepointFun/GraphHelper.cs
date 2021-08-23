using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace OneDriveWithMSGraph
{
    public class GraphHelper
    {
        private static GraphServiceClient graphClient;
        public static void Initialize(IAuthenticationProvider authProvider)
        {
            graphClient = new GraphServiceClient(authProvider);
            //graphClient.BaseUrl = "https://graph.microsoft.com/beta";
        }

        public static async Task<User> GetMeAsync()
        {
            try
            {
                // GET /me
                return await graphClient.Me.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }

        public static async Task<Drive> GetOneDriveAsync()
        {
            try
            {
                // GET /me
                return await graphClient.Me.Drive.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting OneDrive data: {ex.Message}");
                return null;
            }
        }






        public static async Task<IEnumerable<DriveItem>> GetDriveContentsAsync()
        {
            try
            {
                return await graphClient.Me.Drive.Root.Children.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }

        public static async Task<IEnumerable<DriveItem>> GetContentOfFileAsync(int fileIndex) {
            try
            {

                //var x = await graphClient.Me.Drive.Items[fileIndex]
                var x = await graphClient.Me.Drive.Root.Children.Request().GetAsync();


                var w = graphClient.Me.Drive.Root.Children["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Content.Request()
                    .GetAsync();

                Console.WriteLine(w);

                var readBook = graphClient.Me.Drive.Items["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Workbook;
                    
                var readSheet = readBook.Worksheets["Arkusz1"];

                var tables = readSheet.Tables.Request().GetAsync().Result;

                var gooovno = readSheet.Tables.Add(true).Request().PostAsync().Result;

                tables = readSheet.Tables.Request().GetAsync().Result;

                var readTables = readSheet.Cell(0, 0).Request().GetAsync().Result;

                var wt = readBook.Tables.Request().GetAsync(); //.AddAsync(new WorkbookTable()).Result;

                //wt.

                //var tets = readSheet.Cell(0, 0).Insert("A1").Request().PostAsync().Result;

                WorkbookTableRow newRow = new WorkbookTableRow
                {
                    Values = JsonDocument.Parse("{\"dupa\": \"dafaq\"}")
                };
                
                //var outputSheet = graphClient.Me.Drive.Items["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Workbook.Worksheets["Arkusz1"];
                var outputTables = readSheet.Tables.Request().GetAsync().Result;
                string outputTableId = outputTables[0].Name;
                var outputResult = readSheet.Tables[outputTableId].Rows.Request().AddAsync(newRow).Result;
                

                Console.WriteLine(readTables);

                //string readTableId = readTables[0].Name;
                //var table = readSheet.Tables[readTableId].Rows.Request().GetAsync().Result;

                Console.WriteLine(readSheet);


                return x;
            } catch (ServiceException ex) {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }
    }
}