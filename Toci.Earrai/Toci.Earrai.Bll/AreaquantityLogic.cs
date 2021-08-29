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
        public List<Areaquantity> GetAllAreaQuantitiesFromDb()
        {
            Logic<Areaquantity> areaQuantities = new Logic<Areaquantity>();

            return areaQuantities.Select(m => true).ToList();
        }
    }
}
