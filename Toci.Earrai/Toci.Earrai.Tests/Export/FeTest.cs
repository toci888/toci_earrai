using ExcelLibrary.SpreadSheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Toci.ExcelLibrary.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Tests.Export
{
    [TestClass]
    public class FeTest
    {
        [TestMethod]
        public void dupa()
        {
            FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileStream("D:\\Fe2Excel.xls", FileMode.CreateNew));

            FastExcel.Worksheet worksheet = new FastExcel.Worksheet(fastExcel);

            worksheet.Name = "dupa";
            worksheet.AddRow(new List<string>() { "Id", "Name", "Dupa" });

            fastExcel.Write(worksheet);

            fastExcel.Dispose();
        }

        [TestMethod]
        public void dupa2()
        {
            Workbook wb = new Workbook();

            Dictionary<string, List<List<string>>> elements = new Dictionary<string, List<List<string>>>()
            {
                { "Example", new List<List<string>>() { new List<string>() { "test", "whatever", "another one" } } },
                { "Another Example", new List<List<string>>() { new List<string>() { "test", "whatever", "another one" }, new List<string>() { "test 2", "whatever 2", "another one 2" } } },
            };

            wb.PopulateWorksheets(elements);

            FileStream f = new FileStream("D:\\FeExcel_final.xls", FileMode.CreateNew);

            wb.Save(f);

            f.Close();
        }
    }
}
