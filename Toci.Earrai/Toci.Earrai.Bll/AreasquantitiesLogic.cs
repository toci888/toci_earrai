using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class AreasquantitiesLogic : Logic<Areasquantity>, IAreasquantitiesLogic
    {
        public List<Areasquantity> GetAllAreasQuantitiesFromDb()
        {
            Logic<Areasquantity> areasQuantities = new Logic<Areasquantity>();

            return areasQuantities.Select(m => true).ToList();
        }

        public Areasquantity GetAreasQuantitiesByRowIndexAndWorksheet(int rowindex, int worksheetId)
        {
            Logic<Areasquantity> areasQuantities = new Logic<Areasquantity>();

            var result = areasQuantities.Select(m => m.Idworksheet == worksheetId && m.Rowindex == rowindex).FirstOrDefault();

            return result;

        }
    }
}
