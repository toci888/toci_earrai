using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Extensions
{
    public static class LogicExtension
    {
        public static void SetUpdatedAtProduct<T>(this Logic<T> logic, int productId) where T : class
        {
            Logic<Product> prodLogic = new Logic<Product>();

            Product product = prodLogic.Select(m => m.Id == productId).First();

            product.Updatedat = DateTime.Now;

            prodLogic.Update(product);
        }

        public static Areaquantity FromAreasQuantity(this Areasquantity areasquantity)
        {
            Areaquantity areaquantity = new Areaquantity();

            areaquantity.Id = areasquantity.Id.Value;
            areaquantity.Idproducts = areasquantity.Idproducts;
            areaquantity.Idcodesdimensions = areasquantity.Idcodesdimensions;
            areaquantity.Idarea = areasquantity.Idarea;
            areaquantity.Iduser = areasquantity.Iduser;
            areaquantity.Createdat = areasquantity.Createdat;
            areaquantity.Length = areasquantity.Length;
            areaquantity.Width = areasquantity.Width;
            areaquantity.Quantity = areasquantity.Quantity;
            areaquantity.Updatedat = DateTime.Now;

            return areaquantity;
        }

        public static Quoteandprice FromQuotesAndPrice(this Quotesandprice quotesandprice)
        {
            Quoteandprice quoteandprice = new Quoteandprice();

            quoteandprice.Id = quotesandprice.Id.Value;
            quoteandprice.Createdat = quotesandprice.Createdat;
            quoteandprice.Idproducts = quotesandprice.Idproducts;
            quoteandprice.Idquoteandmetric = quotesandprice.Idquoteandmetric;
            quoteandprice.Iduser = quotesandprice.Iduser;
            quoteandprice.Idvendor = quotesandprice.Idvendor;
            quoteandprice.Price = quotesandprice.Price;
            quoteandprice.Updatedat = DateTime.Now;

            return quoteandprice;
        }
    }
}
