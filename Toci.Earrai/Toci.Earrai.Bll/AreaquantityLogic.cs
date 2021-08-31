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
        public void DeleteById(int id)
        {
            var areaQuantity = Select(m => m.Id == id).FirstOrDefault();
            Delete(areaQuantity);
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
