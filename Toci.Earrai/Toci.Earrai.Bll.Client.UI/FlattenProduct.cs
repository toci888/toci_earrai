﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Client.UI
{
    public class FlattenProduct : FlattenBase
    {
        public FlattenProduct()
        {
            FlattenMap.Add("Id", (ob, input) => { input.Add(new FlattenedEntity() { Name = "Id", Value = ((ProductDto)ob).Product.Id.ToString() }); return input; });
            FlattenMap.Add("Description", (ob, input) => { input.Add(new FlattenedEntity() { Name = "Description", Value = ((ProductDto)ob).Product.Description }); return input; });
            FlattenMap.Add("Balance", (ob, input) => { input.Add(new FlattenedEntity() { Name = "Balance", Value = ((ProductDto)ob).Balance.ToString() }); return input; });
            FlattenMap.Add("Stock take value", (ob, input) => { input.Add(new FlattenedEntity() { Name = "Stock take value", Value = ((ProductDto)ob).Pricing.StockTakeValue.ToString() }); return input; });
        }
    }
}
