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
    }
}
