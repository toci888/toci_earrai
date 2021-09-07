using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;

namespace Toci.Earrai.Tests
{
    public class WorksheetContentCredentialsForAreaQuantity
    {
        public string fileName = "GEng_Stock_2021-08-31_Standard_Items_LIVE_Retrieved_3-9-2021_18_41.xlsx";
        public List<string> workSheetNames = new List<string>()
        { "PLT & SHEET", "Alum", "Msh & Exp.Metal", "Chan & Bms", "Angles+T", "FLTS", "Tube_CHS", "RHS", "Rnds_Sqrs_HolBar" };

        public string ObtainIdWorkBook()
        {
            string res = "";
            var authProvider = new DeviceCodeAuthProvider();
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            var workbooks = graphClient.Me.Drive.Root.Children.Request().GetAsync().Result;
            List<string> Ids = new List<string>();
            foreach (var workbookfile in workbooks)
            {
                Ids.Add(workbookfile.Id);
            }
            res = Ids[2];
            return res;
        }

        public List<DataForAreaQuantity> PrepareDataForAreaQuantity()
        {
            List<DataForAreaQuantity> areaQuantityWsad = new List<DataForAreaQuantity>();

            DataForAreaQuantity pltsheet = new DataForAreaQuantity();
            pltsheet.shName = "PLT & SHEET";
            pltsheet.rowStart = 2;
            pltsheet.rowEnd = 159;
            pltsheet.LengthColumn = 4;
            pltsheet.WidthColumn = 5;
            pltsheet.AreaQuantityRanges = new List<int[]>();
            pltsheet.AreaQuantityRanges.Add(new int[] { 10, 11, 12 });
            pltsheet.AreaQuantityRanges.Add(new int[] { 14, 15, 16 });
            pltsheet.AreaQuantityRanges.Add(new int[] { 18, 19, 20 });
            areaQuantityWsad.Add(pltsheet);

            DataForAreaQuantity alum = new DataForAreaQuantity();
            alum.shName = "Alum";
            alum.rowStart = 2;
            alum.rowEnd = 11;
            alum.LengthColumn = 3;
            alum.WidthColumn = 4;
            alum.AreaQuantityRanges = new List<int[]>();
            alum.AreaQuantityRanges.Add(new int[] { 6, 7, 8 });
            alum.AreaQuantityRanges.Add(new int[] { 9, 10, 11 });
            areaQuantityWsad.Add(alum);

            DataForAreaQuantity msh = new DataForAreaQuantity();
            msh.shName = "Msh & Exp.Metal";
            msh.rowStart = 2;
            msh.rowEnd = 15;
            msh.LengthColumn = 5;
            msh.WidthColumn = 6;
            msh.AreaQuantityRanges = new List<int[]>();
            msh.AreaQuantityRanges.Add(new int[] { 7,8,9 });
            msh.AreaQuantityRanges.Add(new int[] { 10,11,12 });
            msh.AreaQuantityRanges.Add(new int[] { 13,14,15 });
            areaQuantityWsad.Add(msh);

            DataForAreaQuantity chan = new DataForAreaQuantity();
            chan.shName = "Chan & Bms";
            chan.rowStart = 2;
            chan.rowEnd = 39;
            chan.LengthColumn = -1;
            chan.WidthColumn = -1;
            chan.AreaQuantityRanges = new List<int[]>();
            chan.AreaQuantityRanges.Add(new int[] { 5,6,7});
            chan.AreaQuantityRanges.Add(new int[] { 8,9,10 });
            chan.AreaQuantityRanges.Add(new int[] { 11,12,13 });
            areaQuantityWsad.Add(chan);

            DataForAreaQuantity angles = new DataForAreaQuantity();
            angles.shName = "Angles+T";
            angles.rowStart = 2;
            angles.rowEnd = 53;
            angles.LengthColumn = -1;
            angles.WidthColumn = -1;
            angles.AreaQuantityRanges = new List<int[]>();
            angles.AreaQuantityRanges.Add(new int[] {7,8,9});
            angles.AreaQuantityRanges.Add(new int[] { 10,11,12 });
            angles.AreaQuantityRanges.Add(new int[] { 13,14,15});
            areaQuantityWsad.Add(angles);

            DataForAreaQuantity flts = new DataForAreaQuantity();
            flts.shName = "FLTS";
            flts.rowStart = 2;
            flts.rowEnd = 85;
            flts.LengthColumn = -1;
            flts.WidthColumn = -1;
            flts.AreaQuantityRanges = new List<int[]>();
            flts.AreaQuantityRanges.Add(new int[] { 5,6,7 });
            flts.AreaQuantityRanges.Add(new int[] { 8,9,10 });
            flts.AreaQuantityRanges.Add(new int[] { 11,12,13 });
            areaQuantityWsad.Add(flts);

            DataForAreaQuantity tube = new DataForAreaQuantity();
            tube.shName = "Tube_CHS";
            tube.rowStart = 2;
            tube.rowEnd = 59;
            tube.LengthColumn = -1;
            tube.WidthColumn = -1;
            tube.AreaQuantityRanges = new List<int[]>();
            tube.AreaQuantityRanges.Add(new int[] { 6,7,8});
            tube.AreaQuantityRanges.Add(new int[] {9,10,11 });
            tube.AreaQuantityRanges.Add(new int[] { 12,13,14 });
            areaQuantityWsad.Add(tube);

            DataForAreaQuantity rhs = new DataForAreaQuantity();
            rhs.shName = "RHS";
            rhs.rowStart = 2;
            rhs.rowEnd = 55;
            rhs.LengthColumn = -1;
            rhs.WidthColumn = -1;
            rhs.AreaQuantityRanges = new List<int[]>();
            rhs.AreaQuantityRanges.Add(new int[] { 6, 7, 8 });
            rhs.AreaQuantityRanges.Add(new int[] { 9, 10, 11 });
            rhs.AreaQuantityRanges.Add(new int[] { 12, 13, 14 });
            areaQuantityWsad.Add(rhs);

            DataForAreaQuantity rnds = new DataForAreaQuantity();
            rnds.shName = "Rnds_Sqrs_HolBar";
            rnds.rowStart = 2;
            rnds.rowEnd = 86;
            rnds.LengthColumn = -1;
            rnds.WidthColumn = -1;
            rnds.AreaQuantityRanges = new List<int[]>();
            rnds.AreaQuantityRanges.Add(new int[] { 5,6,7});
            rnds.AreaQuantityRanges.Add(new int[] { 8,9,10 });
            rnds.AreaQuantityRanges.Add(new int[] { 11,12,13});
            areaQuantityWsad.Add(rnds);

            return areaQuantityWsad;
        }

 

    }

    public class DataForAreaQuantity
    {
        public int rowStart;
        public int rowEnd;
        public string shName;
        public int LengthColumn { get; set; }
        public int WidthColumn { get; set; }
        public List<int[]> AreaQuantityRanges { get; set; }
    }

}
