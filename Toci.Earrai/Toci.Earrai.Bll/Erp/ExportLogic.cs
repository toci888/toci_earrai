using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Client.UI.ToGrid;
using Toci.Earrai.Bll.Models;
using Toci.ExcelLibrary.Extensions;

namespace Toci.Earrai.Bll.Erp
{
    public class ExportLogic : EiLogic
    {
        protected ApiConnector ApiC = new ApiConnector();
        protected ApplyToGridManager Atgm = new ApplyToGridManager();

        // read the data from our db and create excel
        public virtual void GenerateCompleteExcel(string excelName)
        {
            Dictionary<int, List<ProductDto>> data = GetAllData();
            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>();

            // todo int to string ws name, atgm data to list of string and push to excel

            foreach (KeyValuePair<int, List<ProductDto>> worksheetProducts in data)
            {
                List<List<string>> resultSet = GetFlattenedToStringData(Atgm.PrepareLinearData(worksheetProducts.Key, worksheetProducts.Value));

                setForExcel.Add(WorksheetsIds.AllWorksheetsNames[worksheetProducts.Key], resultSet);
            }

            Workbook wb = new Workbook();

            wb.PopulateWorksheets(setForExcel);

            FileStream f = new FileStream("D:\\" + excelName + ".xls", FileMode.CreateNew);

            wb.Save(f);
            f.Close();
        }

        protected virtual List<List<string>> GetFlattenedToStringData(List<List<FlattenedEntity>> entities)
        {
            List<List<string>> result = new List<List<string>>();

            foreach (List<FlattenedEntity> entity in entities)
            {
                result.Add(entity.Select(m => m.Value).ToList());
            }

            return result;
        }

        protected virtual Dictionary<int, List<ProductDto>> GetAllData()
        {
            Dictionary<int, List<ProductDto>> result = new Dictionary<int, List<ProductDto>>();

            foreach (int worksheetId in WorksheetsIds.AllWorksheets)
            {
                result.Add(worksheetId, ApiC.GetProductsByWorksheetId(worksheetId.ToString()));
            }

            return result;
        }
    }
}
