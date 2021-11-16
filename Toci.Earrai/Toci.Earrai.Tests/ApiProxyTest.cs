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

         //  var result = apc.GetProduct(1);

         //   var filters = apc.GetProductsFiltersEx(new Bll.Models.ProductSearchRequestDto() { Name = "Thickness", WorksheetId = 1 });

            var search = apc.GetProductsEx(new Bll.Models.ProductSearchRequestDto() { Name = "Thickness", WorksheetId = 1, Value = "8" });
        }
    }
}
