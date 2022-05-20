using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.SageIntegration
{
    public class SageExportLogic : Logic<Product>, ISageLogic
    {
        protected Logic<Category> CategoryLogic = new Logic<Category>();
        protected ProductLogic ProductLogic = new ProductLogic();
        protected QuoteAndMetricLogic quoteAndMetricLogic = new QuoteAndMetricLogic();
        protected Logic<Vendor> vendorsLogic = new Logic<Vendor>();
        protected QuoteandpriceLogic quoteandpriceLogic = new QuoteandpriceLogic();

        public List<List<string>> Export(DateTime condition)
        {
            List<ProductDto> productDtos = ProductLogic.GetProductsByWorksheet(2);

            return GetExportDataForProductDtos(productDtos);
        }

        public int Import(List<EiEntity> entity)
        {
            foreach (var e in entity)
            {
                Category category = CategoryLogic.Select(x => x.Code == e.CategoryNumber).FirstOrDefault();

                if (category == null)
                {
                    continue;
                }

                Product product = Select(x => x.Productaccountreference == e.AccountReference).FirstOrDefault();

                if (product != null)
                {
                    product.Updatedat = DateTime.Now;
                    product = Update(product);
                }
                else
                {
                    product = Insert(new Product()
                    {
                        Idcategories = category.Id,
                        Idworksheet = category.Idworksheet,
                        Productaccountreference = e.AccountReference,
                        Description = e.Description
                    });
                }

                if (e.CostPriceStandard != string.Empty)
                {
                    AddQuoteAndPrice(product.Id, e.CostPriceStandard, "Hannon", "£/Tonne");
                }
            }

            return entity.Count;
        }

        // todo ? - any area quantity ?

        protected virtual bool AddQuoteAndPrice(int productId, string price, string vendor, string valuationKind)
        {
            Vendor vnd = vendorsLogic.Select(m => m.Name == vendor).FirstOrDefault();
            Quoteandmetric quoteandmetric = quoteAndMetricLogic.Select(m => m.Valuation == valuationKind).FirstOrDefault();

            if (vnd != null && quoteandmetric != null)
            { // todo user id -> sage
                quoteandpriceLogic.Insert(new Quoteandprice() { Idproducts = productId, Idvendor = vnd.Id, Iduser = 1, Idquoteandmetric = quoteandmetric.Id, Price = price });

                return true;
            }

            return false;
        }

        protected virtual List<List<string>> GetExportDataForProductDtos(List<ProductDto> productDtos)
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
            string[] record = new string[30];

            record[SageConsts.PartNumber] = record[SageConsts.AccountReference] = product.Product.Productaccountreference;

            string recordDescription = product.Product.Description;

            if (product.Product.Idworksheet != WorksheetsIds.PLTandSHEET && product.Product.Idworksheet != WorksheetsIds.Tube_CHS && product.Product.Idworksheet != WorksheetsIds.AnglesplusT)
            {
                recordDescription = string.Format("{0} {1}", product.Product.Productaccountreference, product.Product.Description);
            }

            record[SageConsts.Description] = recordDescription;
            record[SageConsts.VATCode] = "T1";

            Quotesandprice qPrice = product.Quotesandprices.OrderByDescending(x => x.Createdat).FirstOrDefault();
            double price = 0;
            string dateLast = string.Empty;

            if (qPrice != null)
            {
                dateLast = qPrice.Createdat.ToString();
                double.TryParse(qPrice.Price, out price);
                
            }

            record[SageConsts.SalesPrice] = DoubleUtils.RoundDouble(price * 1.35, DoubleConstants.NumOfDecimalPlaces).ToString(); //??
            record[SageConsts.CostPriceStandard] = DoubleUtils.RoundDouble(price, DoubleConstants.NumOfDecimalPlaces).ToString();
            record[SageConsts.DateLastPurchase] = dateLast;

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
            record[SageConsts.StockTakeDate] = dateLast;
            record[SageConsts.QuantityLastStockTake] = GetQuantityLastStockTake(product).ToString(); //.Balance.ToString(); //

            Productssize width = product.Sizes.Where(m => m.Name == "Width").FirstOrDefault();
            Productssize length = product.Sizes.Where(m => m.Name == "Length").FirstOrDefault();
            Productssize thickness = product.Sizes.Where(size => size.Name == Consts.Thickness).FirstOrDefault();

            if (width != null)
            {
                record[SageConsts.WebCategory1] = width.Value;
            }

            if (length != null)
            {
                record[SageConsts.WebCategory2] = length.Value;
            }

            if (thickness != null)
            {
                record[SageConsts.WebCategory3] = thickness.Value;
            }

            //record[SageConsts.Web]

            return record.ToList();
        }

        protected virtual double GetQuantityLastStockTake(ProductDto product)
        {
            if (WorksheetsIds.MshandExpMetal == product.Product.Idworksheet
                || WorksheetsIds.Alum == product.Product.Idworksheet
                || WorksheetsIds.PLTandSHEET == product.Product.Idworksheet)
            {
                
                    return product.Balance;
            }
            else
            {
                // total meters
                if (product.Pricing.TotalMeters.HasValue)
                    return DoubleUtils.RoundDouble(product.Pricing.TotalMeters.Value, DoubleConstants.NumOfDecimalPlaces);

            }
            return 0;
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
