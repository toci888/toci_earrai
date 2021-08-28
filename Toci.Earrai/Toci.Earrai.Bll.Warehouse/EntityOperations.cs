using Microsoft.Graph;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations : Logic<Worksheetcontent>, IEntityOperations
    {
        public Worksheetcontentshistory InsertToHistory(int idWorksheet, int columnIndex, int rowIndex, string value)
        {
            Logic<Worksheetcontentshistory> worksheetHistory = new Logic<Worksheetcontentshistory>();

            Worksheetcontent oldCell = Select(m => m.Idworksheet == idWorksheet
                        && m.Columnindex == columnIndex && m.Rowindex == rowIndex).FirstOrDefault();

            if (oldCell is null)
            {
                return null;
            }

            Worksheetcontentshistory wch = worksheetHistory.Insert(new Worksheetcontentshistory()
            {
                Idworksheet = oldCell.Idworksheet,
                Columnindex = oldCell.Columnindex,
                Rowindex = oldCell.Rowindex,
                Value = oldCell.Value,
                Createdat = DateTime.Now
            });

            oldCell.Value = value;

            Update(oldCell);

            return wch;
        }

        public virtual IQueryable<Worksheetcontent> GetIncreaseOffline(DateTime dateTime)
        {
            return Select(m => m.Updatedat > dateTime);
        }

        public void UpdateExcelCell(int rowIndex, int columnIndex, string fileId, string sheetName, string value)
        {
            var appId = "98a98443-1860-405d-9277-b8bccba724f7";

            string[] scopes = new[] { "https://graph.microsoft.com/User.ReadWrite.All", "https://graph.microsoft.com/Files.ReadWrite.All",
            "https://graph.microsoft.com/Files.Read.All", "https://graph.microsoft.com/Sites.Read.All",
            "https://graph.microsoft.com/Sites.ReadWrite.All" }; //api://98a98443-1860-405d-9277-b8bccba724f7/ApiAccess

            // Initialize the auth provider with values from appsettings.json
            var authProvider = new DeviceCodeAuthProvider(appId, scopes);

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var readSheet = graphClient.Me.Drive.Items[fileId].Workbook.Worksheets[sheetName];

            readSheet.Cell(rowIndex - 1, columnIndex - 1).Request().PatchAsync(new WorkbookRange()
            {
                RowIndex = rowIndex,
                ColumnIndex = columnIndex,
                Values = JsonDocument.Parse("[[\"" + value + "\"]]")
            });
        }
    }
}
