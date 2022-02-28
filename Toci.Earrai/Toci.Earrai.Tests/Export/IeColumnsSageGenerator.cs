using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Tests.Export
{
    [TestClass]
    public class IeColumnsSageGenerator
    {
        [TestMethod]
        public void GenerateConstEntries()
        {
            string rawColumns = "ProductRecord.AccountReference	ProductRecord.Description	ProductRecord.VATCode	ProductRecord.SalesPrice	ProductRecord.CostPriceStandard	ProductRecord.DateLastPurchase	ProductRecord.UnitOfSale	ProductRecord.Location	ProductRecord.SalesNominal	ProductRecord.CategoryNumber	ProductRecord.BarCode	ProductRecord.DepartmentNumber	ProductRecord.SupplierAccountReference	ProductRecord.PartNumber	ProductRecord.QuantityReOrderLevel	ProductRecord.CommodityCode	ProductRecord.Weight	ProductRecord.StockTakeDate	ProductRecord.QuantityReOrder	ProductRecord.QuantityLastStockTake	ProductRecord.InactiveFlag	ProductCategory.Number	ProductRecord.CategoryName	ProductRecord.WebCategory1	ProductRecord.WebCategory2	ProductRecord.WebCategory3	ProductRecord.SupplementaryUnitQuantity	Column1	ProductRecord.QuantityOnLastPurchaseOrder	ProductRecord.QuantityOnOrder";

            List<string> columns = rawColumns.Split("\t", StringSplitOptions.TrimEntries).ToList();

            string result = "";

            foreach (string column in columns)
            {
                result += "public const string " + column.Replace(".", "") + " = \"" + column + "\"; " + Environment.NewLine;
            }
        }

        [TestMethod]
        public void GenerateDtoEntries()
        {
            string rawColumns = "ProductRecord.AccountReference	ProductRecord.Description	ProductRecord.VATCode	ProductRecord.SalesPrice	ProductRecord.CostPriceStandard	ProductRecord.DateLastPurchase	ProductRecord.UnitOfSale	ProductRecord.Location	ProductRecord.SalesNominal	ProductRecord.CategoryNumber	ProductRecord.BarCode	ProductRecord.DepartmentNumber	ProductRecord.SupplierAccountReference	ProductRecord.PartNumber	ProductRecord.QuantityReOrderLevel	ProductRecord.CommodityCode	ProductRecord.Weight	ProductRecord.StockTakeDate	ProductRecord.QuantityReOrder	ProductRecord.QuantityLastStockTake	ProductRecord.InactiveFlag	ProductCategory.Number	ProductRecord.CategoryName	ProductRecord.WebCategory1	ProductRecord.WebCategory2	ProductRecord.WebCategory3	ProductRecord.SupplementaryUnitQuantity	Column1	ProductRecord.QuantityOnLastPurchaseOrder	ProductRecord.QuantityOnOrder";

            List<string> columns = rawColumns.Split("\t", StringSplitOptions.TrimEntries).ToList();

            string result = "";

            foreach (string column in columns)
            {
                result += "public string " + column.Replace("ProductRecord.", "") + " { get; set; } " + Environment.NewLine;
            }
        }

        [TestMethod]
        public void GenerateMapEntries()
        {
            string rawColumns = "ProductRecord.AccountReference	ProductRecord.Description	ProductRecord.VATCode	ProductRecord.SalesPrice	ProductRecord.CostPriceStandard	ProductRecord.DateLastPurchase	ProductRecord.UnitOfSale	ProductRecord.Location	ProductRecord.SalesNominal	ProductRecord.CategoryNumber	ProductRecord.BarCode	ProductRecord.DepartmentNumber	ProductRecord.SupplierAccountReference	ProductRecord.PartNumber	ProductRecord.QuantityReOrderLevel	ProductRecord.CommodityCode	ProductRecord.Weight	ProductRecord.StockTakeDate	ProductRecord.QuantityReOrder	ProductRecord.QuantityLastStockTake	ProductRecord.InactiveFlag	Number	ProductRecord.CategoryName	ProductRecord.WebCategory1	ProductRecord.WebCategory2	ProductRecord.WebCategory3	ProductRecord.SupplementaryUnitQuantity	Column1	ProductRecord.QuantityOnLastPurchaseOrder	ProductRecord.QuantityOnOrder";

            List<string> columns = rawColumns.Split("\t", StringSplitOptions.TrimEntries).ToList();

            string result = "";
            int i = 0;
            foreach (string column in columns)
            {
                result += "{ " + i + ", (row, eiEnt) => { eiEnt." + column.Replace("ProductRecord.", "") + " = row["+i+"].ToString(); return eiEnt; } }, " + Environment.NewLine;
                i++;
            }
        }
    }
}
