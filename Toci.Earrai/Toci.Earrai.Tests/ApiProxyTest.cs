using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;

namespace Toci.Earrai.Tests
{
    [TestClass]
    public class ApiProxyTest
    {
        [TestMethod]
        public void Proxy()
        {
            ApiConnector apc = new ApiConnector();

            var result = apc.GetProduct(1);

            var filters = apc.GetProductsFiltersEx(new Bll.Models.ProductSearchRequestDto() { Name = "Thickness", WorksheetId = 1 });

            var search = apc.GetProductsEx(new Bll.Models.ProductSearchRequestDto() { Name = "Thickness", WorksheetId = 1, Value = "8" });
            var areas = apc.GetAreas();
            var area = apc.GetAreasQuantitiesByProduct(1);
            var y = apc.GetCommisions(1, 1.2);
            var z = apc.GetProduct(1);
            var b = apc.GetProductsFiltersEx(new Bll.Models.ProductSearchRequestDto() { Name = "a", Skip = 1, Value = "a", WorksheetId = 1 });
            var c = apc.GetProductsFromWorksheet(1, "2", "2");
            var d = apc.GetQuoteAndMetric();
            var e = apc.GetQuotesAndPricesByProductId(1);
            var g = apc.GetVendors(1, 2);
            var h = apc.GetWorksheets();
            var i = apc.PostAreaQuantities(new Database.Persistence.Models.Areaquantity()
            {
                Idproducts = 4,
                Idcodesdimensions = 1,
                Idarea = 15,
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now,
                Quantity = "1000000"
            });
            var j = apc.PostQuoteandPrice(new Database.Persistence.Models.Quoteandprice() { });
            //var k = apc.UpdateAreaQuantity(new Database.Persistence.Models.Areaquantity()
            //{
            //    Id = i.Id,
            //    Idproducts = 4,
            //    Idcodesdimensions = 1,
            //    Idarea = 15,
            //    Createdat = DateTime.Now,
            //    Updatedat = DateTime.Now,
            //    Quantity = "1000000"
            //}); // errror :)


        }
    }
}
