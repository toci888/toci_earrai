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
            return Select(m => true).ToList();
        }

        public List<Areasquantity> GetAreasQuantitiesByRowIndexAndWorksheet(int rowindex, int productId)
        {
            return Select(m => m.Idproducts == productId && m.Rowindex == rowindex).OrderBy(m => m.Createdat).ToList();
        }
    }
}
