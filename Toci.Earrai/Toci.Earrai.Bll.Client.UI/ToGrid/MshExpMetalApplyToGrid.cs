using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public class MshExpMetalApplyToGrid : ApplyToGridBase
    {
        public MshExpMetalApplyToGrid()
        {
            WorksheetColumnsMap.Add((product) => new FlattenedEntity() { Name = "Total square meters", Value = product.Pricing.TotalSquareMeters.ToString() });
        }
    }
}
