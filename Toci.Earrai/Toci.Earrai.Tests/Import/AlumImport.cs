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
    public class AlumImport : ImportBase
    {
        public AlumImport() {
            categoryIndexColumn = 0;
        }

        protected override void ImportAreas(List<string> row, int productId)
        {
            string area1 = row[9];
            string area2 = row[12];

            if (!string.IsNullOrEmpty(area1))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[7], Quantity = row[8], Idarea = AreasProvider.GetAreas()[area1].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }

            if (!string.IsNullOrEmpty(area2))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[10], Quantity = row[11], Idarea = AreasProvider.GetAreas()[area2].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[0]].Id });
            }
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.Type, Value = row[3] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerSheet,
                Price = row[15],
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
