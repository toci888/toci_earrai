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

        protected Dictionary<string, Func<ProductDto, string>> SageColumnsItemsMap = new Dictionary<string, Func<ProductDto, string>>()
        {
            { "ProductRecord.AccountReference", (product) => product.Product.Productaccountreference },
            { "ProductRecord.Description", (product) => product.Product.Description },    
            //ProductRecord.VATCode   ProductRecord.SalesPrice    ProductRecord.CostPriceStandard ProductRecord.DateLastPurchase  ProductRecord.UnitOfSale    ProductRecord.Location  ProductRecord.SalesNominal  ProductRecord.CategoryNumber    ProductRecord.BarCode   ProductRecord.DepartmentNumber  ProductRecord.SupplierAccountReference  ProductRecord.PartNumber    ProductRecord.QuantityReOrderLevel  ProductRecord.CommodityCode ProductRecord.Weight    ProductRecord.StockTakeDate ProductRecord.QuantityReOrder   ProductRecord.QuantityLastStockTake ProductRecord.InactiveFlag  ProductCategory.Number  ProductRecord.CategoryName  ProductRecord.WebCategory1  ProductRecord.WebCategory2  ProductRecord.WebCategory3  ProductRecord.SupplementaryUnitQuantity Column1 ProductRecord.QuantityOnLastPurchaseOrder   ProductRecord.QuantityOnOrder
        };

        // read the data from our db and create excel
        public virtual void GenerateCompleteExcel(string excelName)
        {
            Dictionary<int, List<ProductDto>> data = GetAllData();
            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>();

            foreach (KeyValuePair<int, List<ProductDto>> worksheetProducts in data)
            {
                List<List<FlattenedEntity>> dataOfWorksheet = Atgm.PrepareLinearData(worksheetProducts.Key, worksheetProducts.Value);

                List<List<string>> resultSet = new List<List<string>>();

                resultSet.Add(dataOfWorksheet.First().Select(m => m.Name).ToList());

                resultSet.AddRange(GetFlattenedToStringData(dataOfWorksheet));

                setForExcel.Add(WorksheetsIds.AllWorksheetsNames[worksheetProducts.Key], resultSet);
            }

            Workbook wb = new Workbook();

            wb.PopulateWorksheets(setForExcel);

            FileStream f = new FileStream("D:\\" + excelName + ".xlsx", FileMode.CreateNew);

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

        public virtual void GenerateExportToSageExcel(string excelName)
        {
            //todo based on what create list<productdto> ?
            List<ProductDto> exportDataResult = new List<ProductDto>(); // todo get to api, some condition etc.

            Dictionary<string, List<List<string>>> setForExcel = new Dictionary<string, List<List<string>>>();

            List<List<string>> setForExcelData = new List<List<string>>();

            setForExcelData.Add(SageColumnsItemsMap.Select(m => m.Key).ToList());

            foreach (ProductDto item in exportDataResult)
            {
                List<string> record = new List<string>();

                foreach (KeyValuePair<string, Func<ProductDto, string>> element in SageColumnsItemsMap)
                {
                    record.Add(element.Value(item));
                }

                setForExcelData.Add(record);
            }

            setForExcel.Add("SageReportData", setForExcelData);

            Workbook wb = new Workbook();

            wb.PopulateWorksheets(setForExcel);

            FileStream f = new FileStream("D:\\" + excelName + ".xlsx", FileMode.CreateNew);

            wb.Save(f);
            f.Close();
        }
    }
}