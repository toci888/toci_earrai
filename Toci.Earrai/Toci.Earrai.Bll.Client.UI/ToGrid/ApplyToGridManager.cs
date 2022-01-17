using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public class ApplyToGridManager
    {
        protected Dictionary<int, ApplyToGridBase> Map = new Dictionary<int, ApplyToGridBase>()
        {
            { WorksheetsIds.PLTandSHEET, new PltSheetApplyToGrid() },
            { WorksheetsIds.Alum, new AlumApplyToGrid() },
            { WorksheetsIds.MshandExpMetal, new MshExpMetalApplyToGrid() },
            { WorksheetsIds.ChanandBms, new ChanBmsApplyToGrid() },
            { WorksheetsIds.AnglesplusT, new AnglesTApplyToGrid() },
            { WorksheetsIds.FLTS, new FLTSApplyToGrid() },
            { WorksheetsIds.RHS, new RHSApplyToGrid() },
            { WorksheetsIds.Tube_CHS, new TubeCHSApplyToGrid() },
            { WorksheetsIds.Rnds_Sqrs_HolBar, new RndsSqrsHolBarApplyToGrid() },
        };

        public virtual ApplyToGridBase GetApplyToGridLogic(int worksheetId)
        {
            return Map.ContainsKey(worksheetId) ? Map[worksheetId] : null;
        }

        public virtual List<List<FlattenedEntity>> PrepareLinearData(int worksheetId, List<ProductDto> products)
        {
            List<List<FlattenedEntity>> result = new List<List<FlattenedEntity>>();

            FlattenManager fm = new FlattenManager();

            foreach (ProductDto product in products)
            {
                List<FlattenedEntity> element = Map[worksheetId].GetFlattenedProduct(product);
                element = fm.FlattenProduct(product, element);
                result.Add(element);
            }

            return result;
        }
    }
}
