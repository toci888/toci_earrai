using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;
using Workbook = Microsoft.Graph.Workbook;

namespace Toci.Earrai.Bll
{
    public class WorksheetLogic : Logic<Worksheet>, IWorksheetLogic
    {

        private static GraphServiceClient graphClient;

        public WorksheetLogic()
        {
            var authProvider = new DeviceCodeAuthProvider();

            graphClient = new GraphServiceClient(authProvider);
        }


        public async Task<List<Worksheet>> GetAllWorksheets(string fileId)
        {
            List<Worksheet> worksheetsList = new List<Worksheet>();
            var readSheets = graphClient.Me.Drive.Items[fileId].Workbook.Worksheets.Request().GetAsync().Result.ToList();

            foreach (var readsheet in readSheets)
            {
                worksheetsList.Add(new Worksheet() { Sheetname = readsheet.Name });
            }

            return worksheetsList;
        }


        public async Task<List<object>> GetAllWorkbooks()
        {
            List<object> worksheetsList = new List<object>();
            var workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;

            foreach (var wokbook in workbooks)
            {
                worksheetsList.Add(new { Name = wokbook.Name, Id = wokbook.Id });
            }

            return worksheetsList;
        }

        public List<Database.Persistence.Models.Workbook> GetAllWorkbooksFromDb()
        {
            Logic<Database.Persistence.Models.Workbook> workbook = new Logic<Database.Persistence.Models.Workbook>();

            return workbook.Select(m => true).ToList();
        }

        public List<Worksheet> GetAllWorksheetsFromDb(string workbookId)
        {
            Logic<Database.Persistence.Models.Workbook> workbooks = new Logic<Database.Persistence.Models.Workbook>();

            Database.Persistence.Models.Workbook workbook = workbooks.Select(m => m.Idoffile == workbookId).FirstOrDefault();

            return Select(x => x.Idworkbook == workbook.Id).ToList();
        }


        public List<Worksheet> SearchWorksheet(string workbookId, string phrase)
        {
            Logic<Database.Persistence.Models.Workbook> workbooks = new Logic<Database.Persistence.Models.Workbook>();

            Database.Persistence.Models.Workbook workbook = workbooks.Select(m => m.Idoffile == workbookId).FirstOrDefault();

            return Select(x => x.Idworkbook == workbook.Id).ToList();
        }
    }
}