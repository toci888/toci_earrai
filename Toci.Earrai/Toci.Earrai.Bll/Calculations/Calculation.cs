using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;

namespace Toci.Earrai.Bll.Calculations
{
    public abstract class Calculation
    {
        protected abstract double Calculate(CalculationsBaseDto factors);
    }
}
