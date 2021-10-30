using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.ProductParams;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class ChanBms : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
            string area1 = row[8];
            string area2 = row[11];
            string area3 = row[14];

            if (!string.IsNullOrEmpty(area1))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[7], Quantity = row[8], Idarea = AreasProvider.GetAreas()[area1].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area2))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[10], Quantity = row[11], Idarea = AreasProvider.GetAreas()[area2].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area3))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[13], Quantity = row[14], Idarea = AreasProvider.GetAreas()[area3].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
           
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.KgM, Value = row[5] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerTonne,
                Price = row[16],
            });

            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerMeter,
                Price = row[17],
            });
        }
    }
}