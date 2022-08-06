//using ExcelLibrary.SpreadSheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Toci.ExcelLibrary.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Erp;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Toci.Earrai.Tests.Export
{
    [TestClass]
    public class FeTest
    {
        [TestMethod]
        public static void ExportDictToExcel(Dictionary<string, List<List<string>>> ds, string destination)
        {
            // https://stackoverflow.com/questions/11811143/export-datatable-to-excel-with-open-xml-sdk-in-c-sharp
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                foreach (KeyValuePair<string, List<List<string>>> table in ds)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.Key };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                    foreach (string value in table.Value[0])
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(value);
                        headerRow.AppendChild(cell);
                    }

                    table.Value.RemoveAt(0);

                    sheetData.AppendChild(headerRow);

                    foreach (List<string> dsrow in table.Value)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (string col in dsrow)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(col); //
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }

            [TestMethod]
        public void ExportEarraiToExcel()
        {
            ExportLogic exL = new ExportLogic();

            ExportDictToExcel(exL.GenerateCompleteExcel("irrelevant"), "D:\\OpenXmlTest.xlsx");

            //exL.GenerateCompleteExcel("Feilim_1st");
        }

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

           /* wb.PopulateWorksheets(elements);

            FileStream f = new FileStream("D:\\FeExcel_final.xls", FileMode.CreateNew);

            wb.Save(f);

            f.Close();*/
        }
    }
}
