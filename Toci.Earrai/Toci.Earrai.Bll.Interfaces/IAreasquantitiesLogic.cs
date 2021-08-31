using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IAreasquantitiesLogic : ILogicBase<Areasquantity>
    {
        List<Areasquantity> GetAllAreasQuantitiesFromDb();

        List<Areasquantity> GetAreasQuantitiesByRowIndexAndWorksheet(int rowindex, int worksheetId);
    }
}
