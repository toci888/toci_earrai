
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;

namespace OneDriveWithMSGraph
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Working with Graph and One Drive is fun!");

          

            var appId = "98a98443-1860-405d-9277-b8bccba724f7";
            var scopesString = "";
            string[] scopes = new[] { "https://graph.microsoft.com/User.ReadWrite.All" }; //api://98a98443-1860-405d-9277-b8bccba724f7/ApiAccess

            // Initialize the auth provider with values from appsettings.json
            var authProvider = new DeviceCodeAuthProvider(appId, scopes);

            // Request a token to sign in the user
            var accessToken = authProvider.GetAccessToken().Result; //"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiI5OGE5ODQ0My0xODYwLTQwNWQtOTI3Ny1iOGJjY2JhNzI0ZjciLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0L3YyLjAiLCJpYXQiOjE2Mjk1NTI3NDcsIm5iZiI6MTYyOTU1Mjc0NywiZXhwIjoxNjI5NTU2NjQ3LCJhaW8iOiJBVFFBeS84VEFBQUFiNkdxYzZscXNDbUoraXRqTlhvVitPTUJLK0lCNUZuUWYyeE8rWkYxczQyaXpQaC83MHBmTHIzSVhNcXNLcWhlIiwiYXpwIjoiOThhOTg0NDMtMTg2MC00MDVkLTkyNzctYjhiY2NiYTcyNGY3IiwiYXpwYWNyIjoiMCIsIm5hbWUiOiJCYXJ0xYJvbWllaiBaYXBhcnQiLCJvaWQiOiI4MmYxNWVlOS00NGU3LTRkNTMtOGVmMS0yNmRlOWVkM2IyZDQiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJiemFwYXJ0QHRvY2l6YXBhcnQub25taWNyb3NvZnQuY29tIiwicmgiOiIwLkFRd0FzTUxUNlFYTS1rR2ZSbnVUZDlHaWxFT0VxWmhnR0YxQWtuZTR2TXVuSlBjTUFJVS4iLCJzY3AiOiJBcGlBY2Nlc3MiLCJzdWIiOiJsNmVaZ05BTFdib3pzRlE3VURJVGh3S191WXozVWV2TVdFUzgwUjE1YndNIiwidGlkIjoiZTlkM2MyYjAtY2MwNS00MWZhLTlmNDYtN2I5Mzc3ZDFhMjk0IiwidXRpIjoiVlM1amZaM3ZjVS00dTZVVHFXWTBBQSIsInZlciI6IjIuMCJ9.f7LK83YJ-Dp1D0R2pF9L5LPEV74cdKqkM1oyG0z8u4jF3u-oltNteJD5q7ftcBo9irfNgs3jcwo66jO4d9ke3UCEdAhr4PxiS-lBBfRp8nVS-oURN1FS2kqam54VHuGOpBCM9Kpga76VRyvDQaJaGqSl4flJx4idd--qhdPPHLGfBitv--SVdvxhoHORoAQjaFZpKTkYjqWaxkiwBvb7cpRYEdCs522MY5OE1vnTX0-XRWI6w997evnodoNmNDa18qrVUAesn7zPksvuk7OaPQP9zZSyY9kxt9lT4SIOP1xaMnrtIs2bH1U5g0oRynrKWovTH9i2l8LNTTUx4ILRlA"; //

            GraphHelper.Initialize(authProvider);

            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Display your access token");
                Console.WriteLine("2. Get your OneDrive root folder");
                Console.WriteLine("3. List your OneDrive contents");
                Console.WriteLine("4. List content of oneDrive item");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    // Set to invalid value
                    choice = -1;
                }

                switch (choice)
                {
                    case 0:
                        // Exit the program
                        Console.WriteLine("Goodbye...");
                        break;
                    case 1:
                        // Display access token
                        Console.WriteLine($"The access token is:{accessToken}");
                        break;
                    case 2:
                        // Get OneDrive Info
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        var driveInfo = await GraphHelper.GetOneDriveAsync();
                        Console.WriteLine(FormatDriveInfo(driveInfo));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        // Get OneDrive contents
                        var driveContents = await GraphHelper.GetDriveContentsAsync();
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(ListOneDriveContents(driveContents.ToList()));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        // choose index of file list in directory
                        Console.WriteLine("Choose index of file list in directory");
                        int fileIndex = choice = int.Parse(Console.ReadLine());

                        // Get OneDrive file by index
                        var driveContentsAll = await GraphHelper.GetContentOfFileAsync(fileIndex);
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        GetFileContentAsync(driveContentsAll.ToList()[fileIndex]);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static async Task GetFileContentAsync(DriveItem file)
        {
            
            byte[] result2 = new byte[(int) file.Size];
            var fileContent = await file.Content.ReadAsync(result2, 0, 2);
            
            Console.WriteLine(fileContent);
            
        }





        static IConfigurationRoot LoadAppSettings()
        {
            var appConfig = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            if (string.IsNullOrEmpty(appConfig["appId"]) ||
                string.IsNullOrEmpty(appConfig["scopes"]))
            {
                return null;
            }

            return appConfig;
        }

        static string FormatDriveInfo(Drive drive)
        {
            var str = new StringBuilder();
            str.AppendLine($"The OneDrive Name is: {drive.Name}");
            str.AppendLine($"The OneDrive Ownder is: {drive.Owner.User.DisplayName}");
            str.AppendLine($"The OneDrive id is: {drive.Id}");
            str.AppendLine($"The OneDrive was modified last by: {drive?.LastModifiedBy?.User?.DisplayName}");

            return str.ToString();
        }

        static string ListOneDriveContents(List<DriveItem> contents)
        {
            if (contents == null || contents.Count == 0)
            {
                return "No content found";
            }

            var str = new StringBuilder();
            foreach (var item in contents)
            {
                if (item.Folder != null)
                {
                    str.AppendLine($"'{item.Name}' is a folder ");
                    str.AppendLine($"'{item.Id}' is Ids");
                }
                else if (item.File != null)
                {
                    str.AppendLine($"'{item.Name}' is a file with size {item.Size} ");
                    str.AppendLine($"'{item.Id}' is Ids");
                }
                else if (item.Audio != null)
                {
                    str.AppendLine($"'{item.Audio.Title}' is an audio file with size {item.Size}");
                }
                else
                {
                    str.AppendLine($"Generic drive item found with name {item.Name}");
                }
            }

            return str.ToString();
        }
    }
}