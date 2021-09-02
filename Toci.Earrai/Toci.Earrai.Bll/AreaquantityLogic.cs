using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Select(m => m.Id == areaquantity.Id).FirstOrDefault() == null)
                return null;

            areaquantity.Updatedat = DateTime.Now;

            Update(areaquantity);

            return areaquantity;
        }

        public List<Areaquantity> GetAllAreaQuantitiesFromDb()
        {
            return Select(m => true).ToList();
        }

        public void PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            foreach (var element in areaQuantityCollection)
            {
                Insert(new Areaquantity()
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
