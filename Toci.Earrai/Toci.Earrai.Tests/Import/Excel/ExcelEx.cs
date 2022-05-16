//using ExcelDataReader;
using ExcelDataReader;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Extensibility;

namespace Toci.Earrai.Tests.Import.Excel
{
    public class ExcelEx : ExcelClient
    {
        public virtual Dictionary<string, List<List<string>>> RequestWorkbooksEx()
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                var rdr = ExcelReaderFactory.CreateOpenXmlReader(new FileStream(@"C:\Users\bzapa\Downloads\GEng_Stock_Version.xlsx", FileMode.Open), new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding("UTF-8") } );
                //Excel.ExcelClient ex = new ExcelClient();

                DataSet ds = rdr.AsDataSet();

                //ds.Tables[0].Rows[0].

                Dictionary<string, List<List<string>>>  result = ds.AsDictionary();

                impMan.EntireImport(result);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
