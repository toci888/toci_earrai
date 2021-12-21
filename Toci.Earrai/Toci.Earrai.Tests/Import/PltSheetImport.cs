using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.ProductParams;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class PltSheetImport : ImportBase
    {
        public PltSheetImport() 
        {
            categoryIndexColumn = 1;
            areasStart = 9;
            numberOfAreas = 4;
            skipAreaWidth = false;
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.KgM2, Value = row[7] });
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.KgSheet, Value = row[8] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerTonne,
                Price = row[28],
            });

            pricesLogic.Insert(new Quoteandprice()
            {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerMeterSquared,
                Price = row[29],
            });

            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerSheet,
                Price = row[30],
            });
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Length, Value = row[4] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Width, Value = row[5] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[6] });
        }
    }
}
