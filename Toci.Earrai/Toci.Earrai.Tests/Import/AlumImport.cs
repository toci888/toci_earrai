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
            string area1 = row[10];
            string area2 = row[14];

            if (!string.IsNullOrEmpty(area1))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[8], Quantity = row[9], Idarea = AreasProvider.GetAreas()[area1].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[categoryIndexColumn]].Id });
            }

            if (!string.IsNullOrEmpty(area2))
            {
                AreaQuantity.Insert(new Areaquantity() { Length = row[12], Quantity = row[13], Idarea = AreasProvider.GetAreas()[area2].Id, Idproducts = productId, Idcodesdimensions = CodesDimensionProvider.GetCodesDimensions()[row[categoryIndexColumn]].Id });
            }
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            ProductOptionValue.Insert(new Productoptionvalue() { Idproducts = productId, Idproductoptions = (int)ProductOptionsEnum.Type, Value = row[4] });
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            pricesLogic.Insert(new Quoteandprice() {
                Idproducts = productId,
                Idquoteandmetric = (int)QuoteAndMetricEnum.PoundsPerSheet,
                Price = row[16],
            });
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Length, Value = row[5] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Width, Value = row[6] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[7] });
        }
    }
}
