using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;

namespace Toci.Earrai.Bll.Calculations
{
    public class KgPerSheetCalculation : Calculation
    {
        /// 

        public override double Calculate(CalculationsBaseDto factors)
        {
            KgPerSheetDto data = (KgPerSheetDto)factors;

            double result = 1.00;

            
            result *= data.Length_;
            result *= data.Width_;
            result *= data.Thickness_;

            result /= 1000000;

            return result;
        }
    }
}
