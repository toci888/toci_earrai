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
            // Initialize the auth provider with values from appsettings.json
            var authProvider = new DeviceCodeAuthProvider();

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var readSheet = graphClient.Me.Drive.Items[fileId].Workbook.Worksheets[sheetName];

            var dupa = readSheet.Cell(rowIndex, columnIndex).Request().PatchAsync(new WorkbookRange()
            {
                RowIndex = rowIndex,
                ColumnIndex = columnIndex,
                Values = JsonDocument.Parse("[[\"" + value + "\"]]")
            }).Result;

        }
    }
}
