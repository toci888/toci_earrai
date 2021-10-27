using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.ProductParams;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class RndsSqrsHolBar : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
            string area1 = row[8];
            string area2 = row[12];
            string area3 = row[16];

            if (!string.IsNullOrEmpty(area1))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[6], Quantity = row[7], Idarea = AreasProvider.GetAreas()[area1].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area2))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[9], Quantity = row[10], Idarea = AreasProvider.GetAreas()[area2].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area3))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[12], Quantity = row[13], Idarea = AreasProvider.GetAreas()[area3].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
          
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.Dia, Value = row[3] });
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.KgM, Value = row[5] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerTonne,
                Price = row[21],
            });
        }
    }
}