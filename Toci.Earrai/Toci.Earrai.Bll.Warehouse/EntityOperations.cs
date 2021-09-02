using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;
using Workbook = Toci.Earrai.Database.Persistence.Models.Workbook;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations : Logic<Worksheetcontent>, IEntityOperations
    {
        protected Logic<Area> AreaLogic = new Logic<Area>();
        protected Logic<Codesdimension> CdLogic = new Logic<Codesdimension>();
        protected Logic<Workbook> WorkbookLogic = new Logic<Workbook>();
        protected Logic<Worksheet> WorkSheetLogic = new Logic<Worksheet>();
        protected Logic<Worksheetcontent> WorkSheetContentLogic = new Logic<Worksheetcontent>();

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

            //UpdateExcelCell(rowIndex, columnIndex

            return wch;
        }

        public virtual IEnumerable<Worksheetcontent> GetIncreaseOffline(DateTime dateTime)
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

        public virtual Dictionary<string, object> LoadData()
        {
            IEnumerable<Area> areas = AreaLogic.Select(m => true);
            IEnumerable<Codesdimension> categories = CdLogic.Select(m => true);
            IEnumerable<Workbook> workbooks = WorkbookLogic.Select(m => true);
            IEnumerable<Worksheet> worksheets = WorkSheetLogic.Select(m => true);
            IEnumerable<Worksheetcontent> workSheetContent = WorkSheetContentLogic.Select(m => true);

            return new Dictionary<string, object>()
            {
                { "Areas", areas },
                { "Categories", categories },
                { "Workbooks", workbooks },
                { "Worksheets", worksheets },
                { "Worksheetcontents", workSheetContent }
            };
        }
    }
}
