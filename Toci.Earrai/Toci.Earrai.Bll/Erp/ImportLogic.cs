using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;

namespace Toci.Earrai.Bll.Erp
{
    public class ImportLogic : EiLogic
    {
        protected ApiConnector apiConnector = new ApiConnector();
        //read the excel file and save the data in the database
        public virtual void ReadExcelFile(string pathToExcel)
        {
            IExcelDataReader rdr = ExcelReaderFactory.CreateOpenXmlReader(new FileStream("e:\\Feilim_Excel.xlsx", FileMode.Open), new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding("UTF-8") });
            
            DataSet dataToImportDs = rdr.AsDataSet();

            ImportProductsDs(dataToImportDs);
        }

        protected virtual void ImportProductsDs(DataSet data)
        {
            int tablesCount = data.Tables.Count;

            List<string> tables = new List<string>();

            for (int i = 0; i < tablesCount; i++)
            {
                tables.Add(data.Tables[i].TableName);
            }

            // todo create a list<productdto>, shoot to api connector
        }
    }
}
