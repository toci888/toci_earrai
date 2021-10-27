using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.ProductParams;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Tests.Import.Excel;

namespace Toci.Earrai.Tests.Import
{
    public class MshExpMetal : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
            string area1 = row[10];
            string area2 = row[13];
            string area3 = row[16];

            if (!string.IsNullOrEmpty(area1))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[8], Quantity = row[9], Idarea = AreasProvider.GetAreas()[area1].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area2))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[11], Quantity = row[12], Idarea = AreasProvider.GetAreas()[area2].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area3))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[14], Quantity = row[15], Idarea = AreasProvider.GetAreas()[area3].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            // TODO Column G ???
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[6] });
            //ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum., Value = row[7] });
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.Type, Value = row[4] });
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.SheetSize, Value = row[5] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerSheet,
                Price = row[19],
            });
        }
    }
}