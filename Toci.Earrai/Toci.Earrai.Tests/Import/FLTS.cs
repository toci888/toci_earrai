﻿using System.Collections.Generic;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public class FLTS : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
            throw new System.NotImplementedException();
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Width, Value = row[3] });
            ProductSizeLogic.Insert(new Productsize() { Idproducts = productId, Idsizes = (int)ProductSizesEnum.Thickness, Value = row[4] });
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            throw new System.NotImplementedException();
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}