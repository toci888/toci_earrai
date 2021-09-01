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
            var areaQuantityOriginal = Select(m => m.Id == areaquantity.Id).FirstOrDefault();
            if (areaQuantityOriginal == null)
                return null;

            areaQuantityOriginal.Idworksheet = areaquantity.Idworksheet;
            areaQuantityOriginal.Idcodesdimensions = areaquantity.Idcodesdimensions;
            areaQuantityOriginal.Idarea = areaquantity.Idarea;
            areaQuantityOriginal.Iduser = areaquantity.Iduser;
            areaQuantityOriginal.Rowindex = areaquantity.Rowindex;
            areaQuantityOriginal.Quantity = areaquantity.Quantity;
            areaQuantityOriginal.Lengthdimensions = areaquantity.Lengthdimensions;
            areaQuantityOriginal.Createdat = areaquantity.Createdat;
            areaQuantityOriginal.Updatedat = DateTime.Now;

            Update(areaQuantityOriginal);

            return areaQuantityOriginal;
        }

        public List<Areaquantity> GetAllAreaQuantitiesFromDb()
        {
            Logic<Areaquantity> areaQuantities = new Logic<Areaquantity>();

            return areaQuantities.Select(m => true).ToList();
        }

        public List<Areasquantity> PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            Logic<Areaquantity> areaQuantity = new Logic<Areaquantity>();

            List<int> ids = new List<int>();
            int counter = 0;

            foreach (var element in areaQuantityCollection)
            {
                counter++;

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
            
            var newList = areasQuantity.Select(item => true).ToList();

            return newList.Take(counter).Reverse().ToList();

            

        }
    }
}
