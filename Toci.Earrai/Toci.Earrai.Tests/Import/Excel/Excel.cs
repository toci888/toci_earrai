//using ExcelDataReader;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Tests.Import.Excel
{
    public class ExcelEx : ExcelClient
    {
        public virtual Dictionary<string, Dictionary<string, List<List<string>>>> RequestWorkbooksEx()
        {
            Dictionary<string, Dictionary<string, List<List<string>>>> result = new Dictionary<string, Dictionary<string, List<List<string>>>>();

            //var rdr = ExcelReaderFactory.CreateOpenXmlReader(new FileStream("3184 GEng_Stock_Version Dated 2021-11-26.xlsx", FileMode.Open));
            //Excel.ExcelClient ex = new ExcelClient();

            //rdr.d

            
           // IronXL.WorkBook workBook = new IronXL.WorkBook(new FileStream(@"d:\3184 GEng_Stock_Version Dated 2021-11-26.xlsx", FileMode.Open));
           //DataSet ds = workBook.ToDataSet();

            return result;
        }
    }
}
