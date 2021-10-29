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
            Logic<Area> areasLogic = new Logic<Area>();

            List<Area> areas = areasLogic.Select(m => true).ToList();

            foreach(Area area in areas) {
                area.Name = area.Name.Trim().Replace("\r", "");
            }

            return areas;
        }

        public List<Codesdimension> GetAllCodesDimensionsFromDb()
        {
            Logic<Codesdimension> codesDimensions = new Logic<Codesdimension>();

            return codesDimensions.Select(m => true).ToList();
        }
    }
}
