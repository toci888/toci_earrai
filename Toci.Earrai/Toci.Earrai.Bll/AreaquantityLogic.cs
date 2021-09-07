using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class AreaquantityLogic : Logic<Areaquantity>, IAreaquantityLogic
    {

        protected Logic<Areasquantity> areasQuantity = new Logic<Areasquantity>();
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

        public List<Areasquantity> PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            List<int> ids = new List<int>();
            int counter = 0;

            foreach (var element in areaQuantityCollection)
            {
                counter++;

                Insert(new Areaquantity()
                {
                    Idworksheet = element.Idworksheet,
                    Idcodesdimensions = element.Idcodesdimensions,
                    Idarea = element.Idarea,
                    Iduser = element.Iduser,
                    Rowindex = element.Rowindex,
                    Quantity = element.Quantity,
                    Length = element.Length,
                    Width = element.Width,
                    Createdat = DateTime.Now,
                    Updatedat = DateTime.Now
                });
                
            }
            
            var newList = areasQuantity.Select(item => true).ToList();

            return newList.Take(counter).Reverse().ToList();
        
        }
    }
}
