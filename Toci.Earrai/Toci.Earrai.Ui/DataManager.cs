using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Ui
{
    public class DataManager
    {
        protected ApiConnector ApiProxy = new ApiConnector();

        public DataManager()
        {
            
        }

        public virtual ProductDto GetProduct(int productId)
        {
            //ApiProxy.

            return new ProductDto()
            {
                Sizes = new List<Productssize>()
                {
                    new Productssize() { Name = "Thickness", Value = "0.2" },
                    new Productssize() { Name = "Length", Value = "8" }
                },
                Options = new List<Productsoptionsstate>()
                {
                    new Productsoptionsstate() { Name = "Kg/M" , Value = "2" },
                    new Productsoptionsstate() { Name = "????" , Value = "dummy" }
                }
            };
        }

        public virtual List<Vendor> GetAllVendors()
        {
            //ApiProxy

            return new List<Vendor>()
            {
                new Vendor() { Id = 1, Name = "McCane" },
                new Vendor() { Id = 2, Name = "Wwatson" }
            };
        }

        public virtual List<Area> GetAllAreas()
        {
            //ApiProxy

            return new List<Area>()
            {
                new Area() { Id = 1, Name = "Garages" },
                new Area() { Id = 2, Name = "Back Yard" },
            };
        }
    }
}
