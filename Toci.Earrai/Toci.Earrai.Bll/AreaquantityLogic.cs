using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class AreaquantityLogic : Logic<Areaquantity>, IAreaquantityLogic
    {
        public int DeleteById(int id)
        {
            var areaQuantity = Select(m => m.Id == id).FirstOrDefault();
            if (areaQuantity == null)
                return 0;
            Delete(areaQuantity);

            return 1;
        }

        public Areaquantity UpdateAreaQuantities(Areaquantity areaquantity)
        {
            var areaQuantity = Select(m => m.Id == areaquantity.Id).FirstOrDefault();
            if (areaQuantity == null)
                return null;

            return Update(areaquantity);
        }

        public List<Areaquantity> GetAllAreaQuantitiesFromDb()
        {
            Logic<Areaquantity> areaQuantities = new Logic<Areaquantity>();

            return areaQuantities.Select(m => true).ToList();
        }

        public void PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            Logic<Areaquantity> areaQuantity = new Logic<Areaquantity>();

            foreach (var element in areaQuantityCollection)
            {
                areaQuantity.Insert(new Areaquantity()
                {
                    Idworksheet = element.Idworksheet,
                    Idcodesdimensions = element.Idcodesdimensions,
                    Idarea = element.Idarea,
                    Iduser = element.Iduser,
                    Rowindex = element.Rowindex,
                    Quantity = element.Quantity,
                    Lengthdimensions = element.Lengthdimensions,
                    Createdat = DateTime.Now,
                    Updatedat = DateTime.Now
                });
            }
        }
    }
}
