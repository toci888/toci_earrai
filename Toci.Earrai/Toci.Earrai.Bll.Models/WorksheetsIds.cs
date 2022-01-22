using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Models
{
    public static class WorksheetsIds
    {
        public const int PLTandSHEET = 1;
        public const int Alum = 2;
        public const int MshandExpMetal = 3;
        public const int ChanandBms = 4;
        public const int AnglesplusT = 5;
        public const int Tube_CHS = 6;
        public const int FLTS = 7;
        public const int Rnds_Sqrs_HolBar = 8;
        public const int RHS = 9;

        public static List<int> AllWorksheets = new List<int>() 
        {
            PLTandSHEET,
            Alum,
            MshandExpMetal,
            ChanandBms,
            AnglesplusT,
            Tube_CHS,
            FLTS,
            Rnds_Sqrs_HolBar,
            RHS
        };

        public static Dictionary<int, string> AllWorksheetsNames = new Dictionary<int, string>()
        {
            { PLTandSHEET, "PLTandSHEET" },
            { Alum, "Alum" },
            { MshandExpMetal, "MshandExpMetal" },
            { ChanandBms, "ChanandBms" },
            { AnglesplusT, "AnglesplusT" },
            { Tube_CHS, "Tube_CHS" },
            { FLTS, "FLTS" },
            { Rnds_Sqrs_HolBar, "Rnds_Sqrs_HolBar" },
            { RHS, "RHS" }
        };
    }
}
