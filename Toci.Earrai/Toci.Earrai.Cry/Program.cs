
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Warehouse;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Microsoft.Graph.Excel;
using Workbook = Toci.Earrai.Database.Persistence.Models.Workbook;

namespace OneDriveWithMSGraph {
    class Program
    {
        protected static Logic<Workbook> Workbook = new Logic<Workbook>();
        protected static Logic<Worksheet> Worksheet = new Logic<Worksheet>();
        protected static Logic<Worksheetcontent> Worksheetcontent = new Logic<Worksheetcontent>();

        protected static Dictionary<string, List<string[]>> ExcelFilesAccessPoints = new Dictionary<string, List<string[]>>();

        static async Task Main(string[] args) {
            Console.WriteLine("Working with Graph and One Drive is fun!");


            // 01SCYADGNAT2TT2TUGPZF3AMIF4KNILOIS big xlsx

            // Initialize the auth provider with values from appsettings.json
            var authProvider = new DeviceCodeAuthProvider();

            // Request a token to sign in the user
            var accessToken = authProvider.GetAccessToken().Result; //"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiI5OGE5ODQ0My0xODYwLTQwNWQtOTI3Ny1iOGJjY2JhNzI0ZjciLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0L3YyLjAiLCJpYXQiOjE2Mjk1NTI3NDcsIm5iZiI6MTYyOTU1Mjc0NywiZXhwIjoxNjI5NTU2NjQ3LCJhaW8iOiJBVFFBeS84VEFBQUFiNkdxYzZscXNDbUoraXRqTlhvVitPTUJLK0lCNUZuUWYyeE8rWkYxczQyaXpQaC83MHBmTHIzSVhNcXNLcWhlIiwiYXpwIjoiOThhOTg0NDMtMTg2MC00MDVkLTkyNzctYjhiY2NiYTcyNGY3IiwiYXpwYWNyIjoiMCIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwicmgiOiIwLkFRd0FzTUxUNlFYTS1rR2ZSbnVUZDlHaWxFT0VxWmhnR0YxQWtuZTR2TXVuSlBjTUFJVS4iLCJzY3AiOiJBcGlBY2Nlc3MiLCJzdWIiOiJsNmVaZ05BTFdib3pzRlE3VURJVGh3S191WXozVWV2TVdFUzgwUjE1YndNIiwidGlkIjoiZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0IiwidXRpIjoiVlM1amZaM3ZjVS00dTZVVHFXWTBBQSIsInZlciI6IjIuMCJ9.f7LK83YJ-Dp1D0R2pF9L5LPEV74cdKqkM1oyG0z8u4jF3u-oltNteJD5q7ftcBo9irfNgs3jcwo66jO4d9ke3UCEdAhr4PxiS-lBBfRp8nVS-oURN1FS2kqam54VHuGOpBCM9Kpga76VRyvDQaJaGqSl4flJx4idd--qhdPPHLGfBitv--SVdvxhoHORoAQjaFZpKTkYjqWaxkiwBvb7cpRYEdCs522MY5OE1vnTX0-XRWI6w997evnodoNmNDa18qrVUAesn7zPksvuk7OaPQP9zZSyY9kxt9lT4SIOP1xaMnrtIs2bH1U5g0oRynrKWovTH9i2l8LNTTUx4ILRlA"; //

            GraphHelper.Initialize(authProvider);
            EntityGeneratorService.SetAuthProvider(authProvider);

  
            //EntityGenerator entityGenerator =
            //    new EntityGenerator(authProvider, "01SCYADGNAT2TT2TUGPZF3AMIF4KNILOIS", 0, 0, 0);

            //entityGenerator.generateEntity();

            //entityGenerator.ListOfSheets();



            int choice = -1;
            while (choice != 0) {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Get your OneDrive root folder");
                Console.WriteLine("2. List your OneDrive contents");
                Console.WriteLine("3. Generate entities for all file's worksheets (type workbook index)");
                Console.WriteLine("4. GraphHelper.GetContentOfFileAsync");
                Console.WriteLine("5. Seed the db by excel files");
                Console.WriteLine("6. The test of updating excel cells");
                try {
                    choice = int.Parse(Console.ReadLine());
                } catch (System.FormatException) {
                    choice = -1;
                }

                switch (choice) {
                    case 0:
                        Console.WriteLine("Goodbye...");
                        break;
                    case 1:
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        var driveInfo = await GraphHelper.GetOneDriveAsync();
                        Console.WriteLine(FormatDriveInfo(driveInfo));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        // Get OneDrive contents
                        var driveContents = await GraphHelper.GetDriveContentsAsync();
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(ListOneDriveContents(driveContents.ToList()));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        // choose index of file list in directory
                        Console.WriteLine("Choose index of file list in directory");
                        int fileIndex = choice = int.Parse(Console.ReadLine());
                        

                        //var driveContentsAll = await GraphHelper.GetContentOfFileAsync(fileIndex);
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        await CreateEntitiesForAllWorksheets(fileIndex);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        await GraphHelper.GetContentOfFileAsync();
                        break;
                    case 5:

                        /*
                         * First - obtain all workbooks   
                         * Then each workbook provides all its sheets
                         * Then the process of obtaining all cells take a place (according o current sheet)
                         * based on workbook id and sheet name
                         * lastly filtering process of cells take a place
                         * meanwhile db is seeded according to current stage of the entire process
                         */


                        string[] wsadSheet1 = new string[3];
                        string[] wsadSheet2 = new string[2];
                        string[] wsadSheet3 = new string[2];
                        string[] wsadSheet4 = new string[2];
                        string[] wsadSheet5 = new string[2];
                        string[] wsadSheet6 = new string[2];
                        string[] wsadSheet7 = new string[2];
                        string[] wsadSheet8 = new string[2];
                        string[] wsadSheet9 = new string[2];
                        string[] wsadSheet10 = new string[2];
                        string[] wsadSheet11 = new string[2];
                        string[] wsadSheet12 = new string[2];
                        string[] wsadSheet13 = new string[2];

                        wsadSheet1[0] = "Category Setup";
                        wsadSheet1[1] = "A1:U65";
                        wsadSheet1[2] = "3184 Gor_Product_Category_List LIVE.xlsx";

                        wsadSheet2[0] = "PLT & SHEET";
                        wsadSheet2[1] = "A1:Z223";

                        wsadSheet3[0] = "Finish_Prods";
                        wsadSheet3[1] = "A1:H105";

                        wsadSheet4[0] = "Alum";
                        wsadSheet4[1] = "A1:Q16";

                        wsadSheet5[0] = "Msh & Exp.Metal";
                        wsadSheet5[1] = "A1:T17";

                        wsadSheet6[0] = "Chan & Bms";
                        wsadSheet6[1] = "A1:Q41";

                        wsadSheet7[0] = "Angles+T";
                        wsadSheet7[1] = "A1:AB55";

                        wsadSheet8[0] = "FLTS";
                        wsadSheet8[1] = "A1:S86";

                        wsadSheet9[0] = "RHS";
                        wsadSheet9[1] = "A1:S58";

                        wsadSheet10[0] = "Tube_CHS";
                        wsadSheet10[1] = "A1:Z61";

                        wsadSheet11[0] = "Rnds_Sqrs_HolBar";
                        wsadSheet11[1] = "A1:AA89";

                        wsadSheet12[0] = "Density";
                        wsadSheet12[1] = "A1:E25";

                        wsadSheet13[0] = "OEM_Stock";
                        wsadSheet13[1] = "A1:E34";

                        List<string[]> wsadSheets = new List<string[]>();
                        wsadSheets.Add(wsadSheet1);
                        wsadSheets.Add(wsadSheet2);
                        wsadSheets.Add(wsadSheet3);
                        wsadSheets.Add(wsadSheet4);
                        wsadSheets.Add(wsadSheet5);
                        wsadSheets.Add(wsadSheet6);
                        wsadSheets.Add(wsadSheet7);
                        wsadSheets.Add(wsadSheet8);
                        wsadSheets.Add(wsadSheet9);
                        wsadSheets.Add(wsadSheet10);
                        wsadSheets.Add(wsadSheet11);
                        wsadSheets.Add(wsadSheet12);
                        wsadSheets.Add(wsadSheet13);

                        ExcelFilesAccessPoints.Add("01SCYADGNAT2TT2TUGPZF3AMIF4KNILOIS", wsadSheets);

                        wsadSheet1 = new string[3];

                        wsadSheet1[0] = "Arkusz1";
                        wsadSheet1[1] = "A1:T40";
                        wsadSheet1[2] = "excel.xlsx";

                        wsadSheets = new List<string[]>();
                        wsadSheets.Add(wsadSheet1);

                        ExcelFilesAccessPoints.Add("01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4", wsadSheets);

                        wsadSheet1 = new string[3];

                        wsadSheet1[0] = "Arkusz1";
                        wsadSheet1[1] = "A1:T40";
                        wsadSheet1[2] = "onedrive.xlsx";

                        wsadSheets = new List<string[]>();
                        wsadSheets.Add(wsadSheet1);

                        ExcelFilesAccessPoints.Add("01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD", wsadSheets);

                        GraphServiceClient graphClient = new GraphServiceClient(authProvider);

                        foreach (KeyValuePair<string, List<string[]>> ele in ExcelFilesAccessPoints)
                        {
                            int idOfWorkbook = Workbook.Insert(new Workbook()
                            {
                                Idoffile = ele.Key,
                                Filename = ele.Value[0][2],
                                Createdat = DateTime.Now,
                                Updatedat = DateTime.Now
                            }).Id;

                            for(int ii = 0; ii < ele.Value.Count; ii++)
                            {
                                int idOfWorksheet = Worksheet.Insert(new Worksheet()
                                {
                                    Idworkbook = idOfWorkbook,
                                    Sheetname = ele.Value[ii][0],
                                    Createdat = DateTime.Now,
                                    Updatedat = DateTime.Now
                                }).Id;
                          
                                var readSheet = graphClient.Me.Drive.Items[ele.Key].Workbook.Worksheets[ele.Value[ii][0]];
                                var testRange = readSheet.Range(ele.Value[ii][1]).Request().GetAsync().Result;
                                var bazka = testRange.Values.RootElement.ToString()
                                    .Replace("[[", "")
                                    .Split("],[").ToList();

                                for (int i = 0; i < bazka.Count; i++)
                                {
                                    var wierszJakoLista = bazka[i].Split(",").ToList();

                                    for (int j = 0; j < wierszJakoLista.Count; j++)
                                    {
                                        Worksheetcontent.Insert(new Worksheetcontent()
                                        {
                                            Idworksheet = idOfWorksheet,
                                            Rowindex = i,
                                            Columnindex = j,
                                            Value = wierszJakoLista[j].Replace("\"", "").Replace("\"", ""),
                                            Createdat = DateTime.Now,
                                            Updatedat = DateTime.Now
                                        });
                                    }
                                }

                            }
                        }
                        Console.WriteLine("Press any button if finished");
                        Console.ReadKey();
                        choice = 0;
                        break;
                    case 6:
                        var TestObject = new EntityOperations();
                        TestObject.UpdateExcelCell(0, 0, "01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD", "Arkusz1", "dupa22");
                        choice = 0;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static async Task CreateEntitiesForAllWorksheets(int fileIndex) {
            
            EntityGeneratorService.generateEntitiesForAllSheets(fileIndex);
            
            //EntityGenerator entityGenerator =
                //new EntityGenerator(authProvider, "01SCYADGNAT2TT2TUGPZF3AMIF4KNILOIS", 0, 0, 0);

        }

        static IConfigurationRoot LoadAppSettings() {
            var appConfig = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            if (string.IsNullOrEmpty(appConfig["appId"]) ||
                string.IsNullOrEmpty(appConfig["scopes"])) {
                return null;
            }

            return appConfig;
        }

        static string FormatDriveInfo(Drive drive) {
            var str = new StringBuilder();
            str.AppendLine($"The OneDrive Name is: {drive.Name}");
            str.AppendLine($"The OneDrive Ownder is: {drive.Owner.User.DisplayName}");
            str.AppendLine($"The OneDrive id is: {drive.Id}");
            str.AppendLine($"The OneDrive was modified last by: {drive?.LastModifiedBy?.User?.DisplayName}");

            return str.ToString();
        }

        static string ListOneDriveContents(List<DriveItem> contents) {
            if (contents == null || contents.Count == 0) {
                return "No content found";
            }

            var str = new StringBuilder();
            foreach (var item in contents) {
                if (item.Folder != null) {
                    str.AppendLine($"'{item.Name}' is a folder ");
                    str.AppendLine($"'{item.Id}' is Ids");
                } else if (item.File != null) {
                    str.AppendLine($"'{item.Name}' is a file with size {item.Size} ");
                    str.AppendLine($"'{item.Id}' is Ids");
                } else if (item.Audio != null) {
                    str.AppendLine($"'{item.Audio.Title}' is an audio file with size {item.Size}");
                } else {
                    str.AppendLine($"Generic drive item found with name {item.Name}");
                }
            }

            return str.ToString();
        }
    }
}