using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Client.UI
{
    public class FlattenCollections : FlattenBase
    {
        public FlattenCollections()
        {
            //FlattenMap.Add("Price", (ob, input) => { input.AddRange(Flatten(((ProductDto)ob).Prices, (obj) => new FlattenedEntity() { Name = (obj).Name, Value = (obj).Price })); return input; });
            FlattenMap.Add("Options", (ob, input) => { input.AddRange(Flatten(((ProductDto)ob).Options, (obj) => new FlattenedEntity() { Name = (obj).Name, Value = (obj).Value })); return input; });
            FlattenMap.Add("Sizes", (ob, input) => { input.AddRange(Flatten(((ProductDto)ob).Sizes, (obj) => new FlattenedEntity() { Name = (obj).Name, Value = (obj).Value })); return input; });
            FlattenMap.Add("AreasQuantities", (ob, input) => { input.AddRange(Flatten(((ProductDto)ob).AreaQuantities, (obj) => new FlattenedEntity() { Name = "Area - Quantity - Date", Value = (obj).Areaname + " - " + (obj).Quantity + " - " + (obj).Createdat.Value.ToString(Consts.DateFormat) })); return input; });
            FlattenMap.Add("QuotesAndPrices", (ob, input) => { input.AddRange(Flatten(((ProductDto)ob).Quotesandprices, (obj) => new FlattenedEntity() { Name = "Valuation - Price - Vendor - Date", Value = (obj).Valuation + " - " + (obj).Price + " - " + (obj).Vendor + " - " + (obj).Createdat.Value.ToString(Consts.DateFormat) })); return input; });

            //FlattenMap.Add("Description", (ob, input) => { input.Add(new FlattenedEntity() { Name = "Description", Value = ((ProductDto)ob).Product.Description }); return input; });
        }
    }
}
