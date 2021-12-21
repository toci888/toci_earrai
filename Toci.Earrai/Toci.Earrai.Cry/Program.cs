
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
using Toci.Earrai.Tests;
using Toci.Earrai.Tests.Import.Excel;
using Toci.Microsoft.Graph.Excel;
//using Workbook = Toci.Earrai.Database.Persistence.Models.Workbook;

namespace OneDriveWithMSGraph {
    class Program
    {
        //protected static Logic<Workbook> Workbook = new Logic<Workbook>();
        protected static Logic<Worksheet> Worksheet = new Logic<Worksheet>();
        protected static Logic<Worksheetcontent> Worksheetcontent = new Logic<Worksheetcontent>();

        protected static Dictionary<string, List<string[]>> ExcelFilesAccessPoints = new Dictionary<string, List<string[]>>();

        static async Task Main(string[] args) {
            Console.WriteLine("Working with Graph and One Drive is fun!");


         


            int choice = -1;
            while (choice != 0) {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Get your OneDrive root folder");
                Console.WriteLine("2. List your OneDrive contents");
                Console.WriteLine("3. Generate entities for all file's worksheets (type workbook index)");
                Console.WriteLine("4. GraphHelper.GetContentOfFileAsync");
                Console.WriteLine("5. Seed the db by excel file");
                Console.WriteLine("6. The test of updating excel cells");
                Console.WriteLine("7. Seed the db");
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

                        Console.WriteLine("Lets start");

                        ExcelEx client1 = new ExcelEx();

                        client1.RequestWorkbooksEx();

                        Console.WriteLine("Finished");
                        //Console.ReadKey();
                        //choice = 0;
                        break;
                    case 6:
                        var TestObject = new EntityOperations();
                        TestObject.UpdateExcelCell(0, 0, "01SCYADGJKJP7FBEP3MFHZ77VLHI7AJ5RD", "Arkusz1", "dupa22");
                        choice = 0;
                        break;
                    case 7:
                        SeedDb seedDb = new SeedDb();

                        seedDb.SeedAllDb();
                        Console.WriteLine("Finished");
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