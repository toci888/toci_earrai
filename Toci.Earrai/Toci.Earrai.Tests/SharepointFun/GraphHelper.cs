﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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


                var w = graphClient.Me.Drive.Items["01SCYADGKGME2QYGJYXFE2IDMHAVAIUIN4"].Content.Request().GetAsync().Result;

                Console.WriteLine(w);


                return x;
            } catch (ServiceException ex) {
                Console.WriteLine($"Error getting One Drive contents: {ex.Message}");
                return null;
            }
        }
    }
}