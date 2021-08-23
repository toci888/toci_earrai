using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace Toci.Microsoft.Graph.Excel {
    public class EntityGeneratorService {

        private static GraphServiceClient graphClient;

        public static void SetAuthProvider(IAuthenticationProvider authProvider) {

            graphClient = new GraphServiceClient(authProvider);

        }

        public static async void generateEntitiesForAllSheets(int fileIndex) {

            string _fileId = getFileId(fileIndex);

            generateEntitiesFromListOfWorksheets(_fileId);

            //var readSheet = graphClient.Me.Drive.Items[_fileId].Workbook.Worksheets[_worksheetName];

            //string[] columns = EntityColumnsService.getColumnsFromWorksheet(graphClient)
            
            //EntityGenerator entityGenerator = new EntityGenerator(graphClient, )
            
        }

        public static string getFileId(int fileIndex)
        {
            var allFiles = graphClient.Me.Drive.Root.Children.Request().GetAsync();

            return allFiles.Result[fileIndex].Id;
            
        }

        public static void generateEntitiesFromListOfWorksheets(string _fileId) {

            // table coordinates from input or default data (0, 0, 0)
            /*var positions = new Dictionary<string, int>
            {
                {"rowOfEntityData", 0},
                {"startCell", 0},
                {"endCell", 7},
            };
            var positions2 = new { rowOfEntityData = 0, startCell =  0, endCell = 7 };*/

            foreach (var sheet in graphClient.Me.Drive.Items[_fileId].Workbook.Worksheets.Request().GetAsync().Result) {
                
                var readSheet = graphClient.Me.Drive.Items[_fileId].Workbook.Worksheets[sheet.Name];

                string[] columns = EntityColumnsService.getColumnsFromWorksheet(readSheet, 0, 0, 7);

                EntityGenerator.generateEntity(sheet.Name, columns, 0, 0, 7);


            }

        }



    }
}
