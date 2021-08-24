using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Database.Interfaces;
using Toci.Earrai.Bll.Models;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Toci.Earrai.Bll.Interfaces;

namespace Toci.Earrai.Bll {
    public class WorksheetLogic : Logic<Worksheet>, IWorksheetLogic {

        private static GraphServiceClient graphClient;
        
        public WorksheetLogic() {
            
            var appId = "98a98443-1860-405d-9277-b8bccba724f7";
            
            string[] scopes = new[] { 
                "https://graph.microsoft.com/User.ReadWrite.All", 
                "https://graph.microsoft.com/Files.ReadWrite.All",
                "https://graph.microsoft.com/Files.Read.All", 
                "https://graph.microsoft.com/Sites.Read.All",
                "https://graph.microsoft.com/Sites.ReadWrite.All" };

            var authProvider = new DeviceCodeAuthProvider(appId , scopes);

            graphClient = new GraphServiceClient(authProvider);
        }


        public async Task<List<Worksheet>> GetAllWorksheets(string fileId)
        {
            List<Worksheet> worksheetsList = new List<Worksheet>();
            var readSheets = graphClient.Me.Drive.Items[fileId].Workbook.Worksheets.Request().GetAsync().Result.ToList();

            foreach (var readsheet in readSheets)
            {
                worksheetsList.Add(new Worksheet() { name = readsheet.Name });
            }

            return worksheetsList;

        }
    }
}
