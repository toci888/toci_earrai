using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models.Calculation {
    public class KgPerSqrtMeterDto {

        protected const int Density = 8500;

        protected const int DivideBy = 1000;

        public int getValue() {
            return Density / DivideBy;
        }
    }
}
