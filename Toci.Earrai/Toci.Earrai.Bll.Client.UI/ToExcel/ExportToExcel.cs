using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.ToExcel
{
    public static class ExportToExcel
    {
        public static void ExportDictionaryToExcel(Dictionary<string, List<List<string>>> ds, string destination)
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
    }
}
