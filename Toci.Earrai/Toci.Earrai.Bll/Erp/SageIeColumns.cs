using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Erp
{
    public static class SageIeColumns
    {
        public const string ProductRecordAccountReference = "ProductRecord.AccountReference"; // yes
        public const string ProductRecordDescription = "ProductRecord.Description"; //yes
        public const string ProductRecordVATCode = "ProductRecord.VATCode"; // ??
        public const string ProductRecordSalesPrice = "ProductRecord.SalesPrice"; // Ł / tonne ?
        public const string ProductRecordCostPriceStandard = "ProductRecord.CostPriceStandard"; // 0 ....
        public const string ProductRecordDateLastPurchase = "ProductRecord.DateLastPurchase"; // empty in xlsx
        public const string ProductRecordUnitOfSale = "ProductRecord.UnitOfSale"; // ea, ?
        public const string ProductRecordLocation = "ProductRecord.Location"; // empty
        public const string ProductRecordSalesNominal = "ProductRecord.SalesNominal"; // 4003 ?
        public const string ProductRecordCategoryNumber = "ProductRecord.CategoryNumber"; // 1 , 3, ??
        public const string ProductRecordBarCode = "ProductRecord.BarCode"; // empty
        public const string ProductRecordDepartmentNumber = "ProductRecord.DepartmentNumber"; // 0
        public const string ProductRecordSupplierAccountReference = "ProductRecord.SupplierAccountReference"; // empty
        public const string ProductRecordPartNumber = "ProductRecord.PartNumber"; //empty
        public const string ProductRecordQuantityReOrderLevel = "ProductRecord.QuantityReOrderLevel"; // 0
        public const string ProductRecordCommodityCode = "ProductRecord.CommodityCode"; // 84313900, ?
        public const string ProductRecordWeight = "ProductRecord.Weight"; // 0
        public const string ProductRecordStockTakeDate = "ProductRecord.StockTakeDate"; // empty
        public const string ProductRecordQuantityReOrder = "ProductRecord.QuantityReOrder"; // 0
        public const string ProductRecordQuantityLastStockTake = "ProductRecord.QuantityLastStockTake"; // 0
        public const string ProductRecordInactiveFlag = "ProductRecord.InactiveFlag"; // 0
        public const string ProductCategoryNumber = "ProductCategory.Number"; // 1, 3 - ??
        public const string ProductRecordCategoryName = "ProductRecord.CategoryName"; // yes, PL_Plate Mild Steel
        public const string ProductRecordWebCategory1 = "ProductRecord.WebCategory1"; // 2
        public const string ProductRecordWebCategory2 = "ProductRecord.WebCategory2"; //2500, length ?
        public const string ProductRecordWebCategory3 = "ProductRecord.WebCategory3"; // 1250, width ? 
        public const string ProductRecordSupplementaryUnitQuantity = "ProductRecord.SupplementaryUnitQuantity"; // 0
        public const string Column1 = "Column1";
        public const string ProductRecordQuantityOnLastPurchaseOrder = "ProductRecord.QuantityOnLastPurchaseOrder"; // 0
        public const string ProductRecordQuantityOnOrder = "ProductRecord.QuantityOnOrder"; // 0

    }
}
