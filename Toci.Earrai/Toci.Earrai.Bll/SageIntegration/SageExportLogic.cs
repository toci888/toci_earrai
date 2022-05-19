using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.SageIntegration
{
    public class SageExportLogic
    {
        protected Logic<Category> CategoryLogic = new Logic<Category>();

        public virtual List<List<string>> GetExportDataForProductDtos(List<ProductDto> productDtos)
        {
            List<List<string>> result = new List<List<string>>();

            result.Add(GenerateHeader());

            foreach (ProductDto productDto in productDtos)
            {
                result.Add(GetRecord(productDto));
            }

            return result;
        }

        protected virtual List<string> GetRecord(ProductDto product)
        {
            List<string> record = new List<string>();

            record[SageConsts.PartNumber] = record[SageConsts.AccountReference] = product.Product.Productaccountreference;
            record[SageConsts.Description] = product.Product.Description;
            record[SageConsts.VATCode] = "T1";

            Quotesandprice qPrice = product.Quotesandprices.OrderByDescending(x => x.Createdat).FirstOrDefault();
            double price = 0;

            if (qPrice != null)
            {
                double.TryParse(qPrice.Price, out price);
                price *= 1.35;
            }

            record[SageConsts.SalesPrice] = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString(); //??

            record[SageConsts.UnitOfSale] = GetUnitOfSale(product).ToString();

            Areasquantity aQ = product.AreaQuantities.OrderByDescending(m => m.Createdat).FirstOrDefault();

            if (aQ != null)
            {
                record[SageConsts.Location] = aQ.Areacode;
            }

            record[SageConsts.SalesNominal] = "4003";

            Category cat = CategoryLogic.Select(m => m.Id == product.Product.Idcategories).First();

            record[SageConsts.ProductCategoryNumber] = record[SageConsts.CategoryNumber] = cat.Code;
            record[SageConsts.CategoryName] = cat.Name;
            record[SageConsts.CommodityCode] = "7208400010";
            record[SageConsts.Weight] = GetWeight(product).ToString();


            return record;
        }

        protected virtual double GetUnitOfSale(ProductDto product)
        {
            if (WorksheetsIds.MshandExpMetal == product.Product.Idworksheet
                || WorksheetsIds.Alum == product.Product.Idworksheet
                || WorksheetsIds.PLTandSHEET == product.Product.Idworksheet)
            {
                // Ł / m2
                if (product.Pricing.PoundsPerSquareMeter.HasValue)
                    return DoubleUtils.RoundDouble(product.Pricing.PoundsPerSquareMeter.Value, DoubleConstants.NumOfDecimalPlaces);
            }
            else
            {
                // Ł / m
                if (product.Pricing.PoundsPerMeter.HasValue)
                    return DoubleUtils.RoundDouble(product.Pricing.PoundsPerMeter.Value, DoubleConstants.NumOfDecimalPlaces);

            }
                return 0;
        }

        protected virtual double GetWeight(ProductDto product)
        {
            if (WorksheetsIds.MshandExpMetal == product.Product.Idworksheet
                || WorksheetsIds.Alum == product.Product.Idworksheet
                || WorksheetsIds.PLTandSHEET == product.Product.Idworksheet)
            {
                // kg / m2
                if (product.Pricing.kgPerSqrtMeter.HasValue)
                    return DoubleUtils.RoundDouble(product.Pricing.kgPerSqrtMeter.Value, DoubleConstants.NumOfDecimalPlaces);
            }
            else
            {
                // kg / m
                if (product.Pricing.KgPerMeter.HasValue)
                    return DoubleUtils.RoundDouble(product.Pricing.KgPerMeter.Value, DoubleConstants.NumOfDecimalPlaces);

            }
            return 0;
        }

        protected virtual List<string> GenerateHeader()
        {
            string[] elements = "ProductRecord.AccountReference	ProductRecord.Description	ProductRecord.VATCode	ProductRecord.SalesPrice	ProductRecord.CostPriceStandard	ProductRecord.DateLastPurchase	ProductRecord.UnitOfSale	ProductRecord.Location	ProductRecord.SalesNominal	ProductRecord.CategoryNumber	ProductRecord.BarCode	ProductRecord.DepartmentNumber	ProductRecord.SupplierAccountReference	ProductRecord.PartNumber	ProductRecord.QuantityReOrderLevel	ProductRecord.CommodityCode	ProductRecord.Weight	ProductRecord.StockTakeDate	ProductRecord.QuantityReOrder	ProductRecord.QuantityLastStockTake	ProductRecord.InactiveFlag	ProductCategory.Number	ProductRecord.CategoryName	ProductRecord.WebCategory1	ProductRecord.WebCategory2	ProductRecord.WebCategory3	ProductRecord.SupplementaryUnitQuantity	Column1	ProductRecord.QuantityOnLastPurchaseOrder	ProductRecord.QuantityOnOrder".Split("\t", StringSplitOptions.None);

            return elements.ToList();
        }
    }
}
