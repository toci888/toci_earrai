using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Calculations.Pricing.Valuation
{
    public enum Valuations
    {
        PoundsPerTonne,
        PoundsPerMeter,
        PoundsPerSheet,
        PoundsPerLength,
        PoundsPerSquareMeter
    }

    public static class ValuationsMapUtil
    {
        static Dictionary<Valuations, string> map = new Dictionary<Valuations, string>()
        {
            { Valuations.PoundsPerTonne, CalculationsConsts.LPerTonne },
            { Valuations.PoundsPerSquareMeter, CalculationsConsts.LPerSquareMeter},
            { Valuations.PoundsPerSheet, CalculationsConsts.LPerSheet },
            { Valuations.PoundsPerMeter, CalculationsConsts.LPerMeter },
            { Valuations.PoundsPerLength, CalculationsConsts.LPerLength },
        };

        static Dictionary<string, Valuations> viceVersa = new Dictionary<string, Valuations>()
        {
            { CalculationsConsts.LPerTonne, Valuations.PoundsPerTonne },
            { CalculationsConsts.LPerSquareMeter, Valuations.PoundsPerSquareMeter },
            { CalculationsConsts.LPerSheet, Valuations.PoundsPerSheet},
            { CalculationsConsts.LPerMeter, Valuations.PoundsPerMeter },
            { CalculationsConsts.LPerLength, Valuations.PoundsPerLength },
        };

        public static string StringifyEnumValuation(Valuations valuation)
        {
            return map[valuation];
        }

        public static Valuations EnumifyStringValuation(string valuation)
        {
            return viceVersa[valuation];
        }
    }
}
