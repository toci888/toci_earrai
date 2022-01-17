using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Client.UI.ToGrid;
using Toci.Earrai.Bll.Models;

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

            // todo int to string ws name, atgm data to list of string and push to excel
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
