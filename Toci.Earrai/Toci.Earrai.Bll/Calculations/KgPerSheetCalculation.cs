﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;

namespace Toci.Earrai.Bll.Calculations
{
    public class KgPerSheetCalculation : Calculation
    {
        protected override double Calculate(CalculationsBaseDto factors)
        {
            KgPerSheetDto data = (KgPerSheetDto)factors;

            return 0;
        }
    }
}
