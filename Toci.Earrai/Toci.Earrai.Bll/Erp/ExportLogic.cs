using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Client.UI.ToExcel;
using Toci.Earrai.Bll.Client.UI.ToGrid;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Models.Erp;
using Toci.ExcelLibrary.Extensions;

namespace Toci.Earrai.Bll.Erp
{
    public class ExportLogic : EiLogic
    {
        protected ApiConnector ApiC = new ApiConnector();
        protected ApplyToGridManager Atgm = new ApplyToGridManager();

        protected Dictionary<string, Func<ProductDto, string>> SageColumnsItemsMap = new Dictionary<string, Func<ProductDto, string>>()
        {
            { "ProductRecord.AccountReference", (product) => product.Product.Productaccountreference },
            { "ProductRecord.Description", (product) => product.Product.Description },    
            //ProductRecord.VATCode   ProductRecord.SalesPrice    ProductRecord.CostPriceStandard ProductRecord.DateLastPurchase  ProductRecord.UnitOfSale    ProductRecord.Location  ProductRecord.SalesNominal  ProductRecord.CategoryNumber    ProductRecord.BarCode   ProductRecord.DepartmentNumber  ProductRecord.SupplierAccountReference  ProductRecord.PartNumber    ProductRecord.QuantityReOrderLevel  ProductRecord.CommodityCode ProductRecord.Weight    ProductRecord.StockTakeDate ProductRecord.QuantityReOrder   ProductRecord.QuantityLastStockTake ProductRecord.InactiveFlag  ProductCategory.Number  ProductRecord.CategoryName  ProductRecord.WebCategory1  ProductRecord.WebCategory2  ProductRecord.WebCategory3  ProductRecord.SupplementaryUnitQuantity Column1 ProductRecord.QuantityOnLastPurchaseOrder   ProductRecord.QuantityOnOrder
        };

        // read the data from our db and create excel
        public virtual Dictionary<string, List<List<string>>> GenerateCompleteExcel(string excelName)
        {
            Dictionary<int, List<ProductDto>> data = GetAllData();
            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>();

            foreach (KeyValuePair<int, List<ProductDto>> worksheetProducts in data)
            {
                List<List<FlattenedEntity>> dataOfWorksheet = Atgm.PrepareLinearData(worksheetProducts.Key, worksheetProducts.Value);

                List<List<string>> resultSet = new List<List<string>>();

                if (dataOfWorksheet.Count > 0)
                {
                    resultSet.Add(dataOfWorksheet.First().Select(m => m.Name).ToList());

                    resultSet.AddRange(GetFlattenedToStringData(dataOfWorksheet));

                    setForExcel.Add(WorksheetsIds.AllWorksheetsNames[worksheetProducts.Key], resultSet);
                }
            }

            return setForExcel;

            Workbook wb = new Workbook();

            wb.PopulateWorksheets(setForExcel);

            FileStream f = new FileStream("D:\\" + excelName + ".xlsx", FileMode.CreateNew);

            wb.Save(f);
            f.Close();
        }

        public virtual void GenerateGridExcel(List<List<string>> data)
        {
            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>();

            setForExcel.Add("Export", data);

            ExportToExcel.ExportDictionaryToExcel(setForExcel, "D:\\Export.xlsx");

            //Workbook wb = new Workbook();

            //wb.PopulateWorksheets(setForExcel);

            //FileStream f = new FileStream("D:\\Export.xlsx", FileMode.CreateNew);

            //wb.Save(f);
            //f.Close();
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

        public virtual void GenerateExportToSageExcel(string excelPath)
        {
          
            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>() {
                { "Export", ApiC.ExportToSage() }
                };

            ExportToExcel.ExportDictionaryToExcel(setForExcel, excelPath);


           // List<List<string>> setForExcelData = new List<List<string>>();


            // create header

            // Workbook wb = new Workbook();

            //wb.PopulateWorksheets(new Dictionary<string, List<List<string>>>() { { "SageExportData", setForExcelData } });

            //FileStream f = new FileStream(excelPath, FileMode.CreateNew);

            // wb.Save(f);
            // f.Close();
        }

        public virtual void GenerateExportViewExcel(string excelPath, List<List<string>> products)
        {
            ExportToExcel.ExportDictionaryToExcel(new Dictionary<string, List<List<string>>>() { { "SageExportData", products } }, excelPath);

            //Workbook wb = new Workbook();

            //wb.PopulateWorksheets(new Dictionary<string, List<List<string>>>() { { "SageExportData", products } });

            //FileStream f = new FileStream(excelPath, FileMode.CreateNew);

            //wb.Save(f);
            //f.Close();
        }
    }
}