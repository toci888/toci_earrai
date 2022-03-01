using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Erp;

namespace Toci.Earrai.Bll.Erp
{
    public abstract class EiLogic
    {
        
        protected Dictionary<int, Func<DataRow, EiEntity, EiEntity>> EiEntityCreationMap = new Dictionary<int, Func<DataRow, EiEntity, EiEntity>>()
        {
            { 0, (row, eiEnt) => { eiEnt.AccountReference = row[0].ToString(); return eiEnt; } },
            { 1, (row, eiEnt) => { eiEnt.Description = row[1].ToString(); return eiEnt; } },
            { 2, (row, eiEnt) => { eiEnt.VATCode = row[2].ToString(); return eiEnt; } },
            { 3, (row, eiEnt) => { eiEnt.SalesPrice = row[3].ToString(); return eiEnt; } },
            { 4, (row, eiEnt) => { eiEnt.CostPriceStandard = row[4].ToString(); return eiEnt; } },
            { 5, (row, eiEnt) => { eiEnt.DateLastPurchase = row[5].ToString(); return eiEnt; } },
            { 6, (row, eiEnt) => { eiEnt.UnitOfSale = row[6].ToString(); return eiEnt; } },
            { 7, (row, eiEnt) => { eiEnt.Location = row[7].ToString(); return eiEnt; } },
            { 8, (row, eiEnt) => { eiEnt.SalesNominal = row[8].ToString(); return eiEnt; } },
            { 9, (row, eiEnt) => { eiEnt.CategoryNumber = row[9].ToString(); return eiEnt; } },
            { 10, (row, eiEnt) => { eiEnt.BarCode = row[10].ToString(); return eiEnt; } },
            { 11, (row, eiEnt) => { eiEnt.DepartmentNumber = row[11].ToString(); return eiEnt; } },
            { 12, (row, eiEnt) => { eiEnt.SupplierAccountReference = row[12].ToString(); return eiEnt; } },
            { 13, (row, eiEnt) => { eiEnt.PartNumber = row[13].ToString(); return eiEnt; } },
            { 14, (row, eiEnt) => { eiEnt.QuantityReOrderLevel = row[14].ToString(); return eiEnt; } },
            { 15, (row, eiEnt) => { eiEnt.CommodityCode = row[15].ToString(); return eiEnt; } },
            { 16, (row, eiEnt) => { eiEnt.Weight = row[16].ToString(); return eiEnt; } },
            { 17, (row, eiEnt) => { eiEnt.StockTakeDate = row[17].ToString(); return eiEnt; } },
            { 18, (row, eiEnt) => { eiEnt.QuantityReOrder = row[18].ToString(); return eiEnt; } },
            { 19, (row, eiEnt) => { eiEnt.QuantityLastStockTake = row[19].ToString(); return eiEnt; } },
            { 20, (row, eiEnt) => { eiEnt.InactiveFlag = row[20].ToString(); return eiEnt; } },
            { 21, (row, eiEnt) => { eiEnt.Number = row[21].ToString(); return eiEnt; } },
            { 22, (row, eiEnt) => { eiEnt.CategoryName = row[22].ToString(); return eiEnt; } },
            { 23, (row, eiEnt) => { eiEnt.WebCategory1 = row[23].ToString(); return eiEnt; } },
            { 24, (row, eiEnt) => { eiEnt.WebCategory2 = row[24].ToString(); return eiEnt; } },
            { 25, (row, eiEnt) => { eiEnt.WebCategory3 = row[25].ToString(); return eiEnt; } },
            { 26, (row, eiEnt) => { eiEnt.SupplementaryUnitQuantity = row[26].ToString(); return eiEnt; } },
            { 27, (row, eiEnt) => { eiEnt.Column1 = row[27].ToString(); return eiEnt; } },
            { 28, (row, eiEnt) => { eiEnt.QuantityOnLastPurchaseOrder = row[28].ToString(); return eiEnt; } },
            { 29, (row, eiEnt) => { eiEnt.QuantityOnOrder = row[29].ToString(); return eiEnt; } }
        };

        protected virtual EiEntity RowToEiEntity(DataRow row)
        {
            EiEntity result = new EiEntity();

            return EiEntityCreationMap.Aggregate(result, (current, mapItem) => mapItem.Value(row, current));
        }

    }
}
