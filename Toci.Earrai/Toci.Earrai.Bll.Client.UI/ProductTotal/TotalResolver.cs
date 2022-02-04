using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Client.UI.ProductTotal
{
    public class TotalResolver
    {
        protected Dictionary<int, Func<ProductDto, TotalEntity>> Map = new Dictionary<int, Func<ProductDto, TotalEntity>>()
        {
            { WorksheetsIds.PLTandSHEET, (product) => new TotalEntity() { Label = "Total weight: ", Amount = product.Pricing.TotalWeight.ToString() } },
            { WorksheetsIds.Alum, (product) => new TotalEntity() { Label = "Total square metres: ", Amount = product.Pricing.TotalSquareMeters.ToString() } },
            { WorksheetsIds.MshandExpMetal, (product) => new TotalEntity() { Label = "Total square metres: ", Amount = product.Pricing.TotalSquareMeters.ToString() }  },
            { WorksheetsIds.ChanandBms, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
            { WorksheetsIds.AnglesplusT, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
            { WorksheetsIds.FLTS, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
            { WorksheetsIds.RHS, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
            { WorksheetsIds.Tube_CHS, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
            { WorksheetsIds.Rnds_Sqrs_HolBar, (product) => new TotalEntity() { Label = "Total metres: ", Amount = product.Pricing.TotalMeters.ToString() } },
        };

        public virtual TotalEntity GetLabelAmount(ProductDto product)
        {
            if (Map.ContainsKey(product.Product.Idworksheet.Value))
            {
                return Map[product.Product.Idworksheet.Value](product);
            }

            return new TotalEntity();
        }
    }
}
