using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.ProductParams;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class AnglesT : ImportBase
    {
        public AnglesT()
        {
            areasStart = 7;
            numberOfAreas = 3;
            skipAreaWidth = true;
        }

        protected override void ImportSizes(List<string> row, int productId)
        {


            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.SideA, Value = row[3] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.SideB, Value = row[4] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[5] });

            //  TODO

            // Column Q R
            
        }

        protected override void ImportOptions(List<string> row, int productId)
        {

            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.KgM, Value = row[6] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            // TODO 3 sizes in excel, 2 with calc
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerMeter,
                Price = row[23],
            });
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerLength,
                Price = row[24],
            });
        }
    }
}