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
                return graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }

        public static IWorkbookWorksheetsCollectionPage GetWorksheetsFromWorkbook(string _fileId) {
            try
            {
                return graphClient.Me.Drive.Items[_fileId].Workbook.Worksheets.Request().GetAsync().Result;
            } catch (ServiceException ex) {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }


        public static Dictionary<string, List<string>> GetAllWorkbooksAndTheirWorksheets()
        {

            Dictionary<string, List<string>> workbooksAndWorksheets = new Dictionary<string, List<string>>();

            List<string> worksheetsList;
            try {

                var workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;

                foreach (var workbook in workbooks)
                {
                    var workbookId = workbook.Id;

                    var worksheets = graphClient.Me.Drive.Items[workbook.Id].Workbook.Worksheets.Request().GetAsync().Result;
                    worksheetsList = new List<string>();
                    foreach (var worksheet in worksheets)
                    {
                        worksheetsList.Add(worksheet.Name);
                    }

                    workbooksAndWorksheets.Add(workbook.Name, worksheetsList);
                }
                
                return workbooksAndWorksheets;
            } catch (ServiceException ex) {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }


        public static async Task<IEnumerable<DriveItem>> GetContentOfFileAsync() {
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

                Console.WriteLine(tables);

                var values = JsonDocument.Parse("[[5,2,3,4]]");
                //"[[123,"asd","zxc",321]]"

                var workbookRangeFormat = new WorkbookRangeFormat
                {
                    ColumnWidth = 135,
                    VerticalAlignment = "Top",
                    RowHeight = 49,
                    WrapText = false,
                };
                await readSheet
                    .Range("$A$1").Format
                    .Request()
                    .UpdateAsync(workbookRangeFormat);

                var workbookRangeFont = new WorkbookRangeFont
                {
                    Bold = true,
                    Color = "#4B180E",
                    Size = 26,
                };
                await readSheet
                    .Range("$A$2").Format.Font
                    .Request()
                    .UpdateAsync(workbookRangeFont);

                var workbookTableRow = new WorkbookTableRow
                {
                    Index = 99,
                    Values = JsonDocument.Parse(@"""values-value""")
                };
                var y = await readBook.Tables["TabelaBartka"].Rows["{workbookTableRow-id}"]
                    .Request()
                    .GetAsync();

                await readBook.Tables["TabelaBartka"].Rows
                    .Add(null, values)
                    .Request()
                    .PostAsync();

                //var z = await readBook.Tables.Request().GetAsync();
                //var gowno = z[0];
                //gowno.Rows = new WorkbookTableRowsCollectionPage();

                //gowno.Rows.Add(new WorkbookTableRow()
                //{
                //    Values = values
                //});

                //z[0] = gowno;
                //var xyz = readBook.Tables["TabelaBartka"].Rows.Request().GetAsync().Result;
                
                //readBook.Tables[0].Request().PutAsync();

                //gowno.Rows = new 
                //.Add(2, values)
                //.Request()
                //.PostAsync();

                // var gooovno = readSheet.Tables.Add(true).Request().PostAsync().Result;

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