using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public class ChanBms : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
           
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
           
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            
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