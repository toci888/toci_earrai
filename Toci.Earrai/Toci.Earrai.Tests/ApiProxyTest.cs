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

            var result = apc.SearchWorksheet(2, "PL");
        }
    }
}
