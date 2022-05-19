using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Erp;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Export
{
    [TestClass]
    public class IeColumnsSageGenerator
    {
        private EiEntity IamDesignedForDelegate(DataRow dr, EiEntity ent)
        {
            return new EiEntity();
            // ???????
        }
        [TestMethod]
        public void GenerateConstEntries()
        {
            Func<DataRow, EiEntity, EiEntity> hahaha = IamDesignedForDelegate; // new Func<DataRow, EiEntity, EiEntity>();
            //hahaha += 


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
            int i = 0;
            foreach (string column in columns)
            {
                result += "public const int " + column.Replace("ProductRecord.", "") + " =  " +i+"; " + Environment.NewLine;
                i++;
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

        [TestMethod]
        public void TestSageExport()
        {
            SageLogic sl = new SageLogic();

            List<EiEntity> result = sl.Export(DateTime.Now);
        }

        [TestMethod]
        public void GenerateErpColumns() // TODO run on prod
        {
            Logic<Erpcolumn> erpColumns = new Logic<Erpcolumn>();

            FieldInfo[] columns = typeof(SageIeColumns).GetFields();

            foreach (FieldInfo col in columns)
            {
                if (col.Name.Contains("ProductRecord"))
                {
                    erpColumns.Insert(new Erpcolumn()
                    {
                        Name = col.GetValue(col).ToString()
                    });
                }
            }
        }
    }
}
