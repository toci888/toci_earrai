using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces
{
    public interface IAreaquantityLogic : ILogicBase<Areaquantity>
    {
        List<Areaquantity> GetAllAreaQuantitiesFromDb();

        void PostAreaQuantities(List<Areaquantity> areaQuantityCollection);

        int DeleteById(int id);

        bool UpdateAreaQuantities(Areaquantity areaquantity);
    }
}
