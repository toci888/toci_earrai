using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Models.Erp;

namespace Toci.Earrai.Bll.Erp
{
    public class ImportLogic : EiLogic
    {
        protected ApiConnector apiConnector = new ApiConnector();
        //read the excel file and save the data in the database
        public virtual void ReadExcelFile(string pathToExcel)
        {
            if (pathToExcel == string.Empty)
            {
                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            FileStream fs = new FileStream(pathToExcel, FileMode.Open);

            IExcelDataReader rdr = ExcelReaderFactory.CreateOpenXmlReader(fs, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding("UTF-8") });
            
            DataSet dataToImportDs = rdr.AsDataSet();

            fs.Close();

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

            List<EiEntity> importEntities = new List<EiEntity>();
            // todo create a list<productdto>, shoot to api connector

            if (data.Tables.Count > 0)
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    importEntities.Add(RowToEiEntity(row));
                }
            }

            apiConnector.InsertEiEntity(importEntities);
        }
    }
}
