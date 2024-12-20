﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Search
{
    public class WidthProductSearch : SearchProductBase
    {
        public override List<ProductDto> Search(ProductSearchRequestDto request)
        {
            List<Product> result = new List<Product>();
            //width ....
            if (request.Name == Consts.Width)
            {
                List<Productssize> elements = GetSizes(Consts.Width, request.Value);
                result = FilterResultsSizesWorksheet(request, elements);
            }

            return ToProductDto(FilterBySearchQuery(request, result));
        }
    }
}
