using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class FLTS : ImportBase
    {
        public FLTS()
        {
            areasStart = 5;
            numberOfAreas = 3;
            skipAreaWidth = true;
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Width, Value = row[3] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[4] });
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerTonne,
                Price = row[20],
            });

            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerMeter,
                Price = row[21],
            });
        }
    }
}