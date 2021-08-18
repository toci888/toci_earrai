using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.CData.ExcelServices;
using System.Threading.Tasks;
using System.Data;
using CData.EntityFrameworkCore;

namespace Toci.Earrai.Tests
{
    [TestClass]
    public class ExcelSharepoint
    {
        [TestMethod]
        public void dupa()
        {
            ExcelServicesConnection excelServicesConnection = 
                new ExcelServicesConnection(@"Url=https://gormleysengineering.sharepoint.com/:x:/r/3184Stock/_layouts/15/Doc.aspx?sourcedoc=%7B77D393F3-BD42-4236-9DC8-33A652DF302F%7D&file=3184%20Gor_Product_Category_List%20%20Images.xlsx&action=default&mobileredirect=true&cid=6a3ef899-21a3-4fd1-8005-eb861892a53b");

            DataSet ds = new DataSet();

            ExcelServicesDataAdapter edr = new ExcelServicesDataAdapter("select * from Alum", excelServicesConnection);

            edr.Fill(ds);

        }

        [TestMethod]
        public void win()
        {
            //CData.EntityFrameworkCore.ExcelServices. 
        }
    }
}
