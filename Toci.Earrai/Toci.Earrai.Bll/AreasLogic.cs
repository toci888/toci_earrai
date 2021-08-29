using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class AreasLogic : Logic<Area>, IAreasLogic
    {
        public List<Area> GetAllAreasFromDb()
        {
            Logic<Area> areas = new Logic<Area>();

            return areas.Select(m => true).ToList();
        }

        public List<Codesdimension> GetAllCodesDimensionsFromDb()
        {
            Logic<Codesdimension> codesDimensions = new Logic<Codesdimension>();

            return codesDimensions.Select(m => true).ToList();
        }
    }
}
