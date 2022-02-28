using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Models.Erp
{
    public class EiEntity // : product ?
    {
        public string AccountReference { get; set; }
        public string Description { get; set; }
        public string VATCode { get; set; }
        public string SalesPrice { get; set; }
        public string CostPriceStandard { get; set; }
        public string DateLastPurchase { get; set; }
        public string UnitOfSale { get; set; }
        public string Location { get; set; }
        public string SalesNominal { get; set; }
        public string CategoryNumber { get; set; }
        public string BarCode { get; set; }
        public string DepartmentNumber { get; set; }
        public string SupplierAccountReference { get; set; }
        public string PartNumber { get; set; }
        public string QuantityReOrderLevel { get; set; }
        public string CommodityCode { get; set; }
        public string Weight { get; set; }
        public string StockTakeDate { get; set; }
        public string QuantityReOrder { get; set; }
        public string QuantityLastStockTake { get; set; }
        public string InactiveFlag { get; set; }
        public string Number { get; set; }
        public string CategoryName { get; set; }
        public string WebCategory1 { get; set; }
        public string WebCategory2 { get; set; }
        public string WebCategory3 { get; set; }
        public string SupplementaryUnitQuantity { get; set; }
        public string Column1 { get; set; }
        public string QuantityOnLastPurchaseOrder { get; set; }
        public string QuantityOnOrder { get; set; }

    }
}
