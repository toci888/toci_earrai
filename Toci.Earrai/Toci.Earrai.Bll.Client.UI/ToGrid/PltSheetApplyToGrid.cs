using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public class PltSheetApplyToGrid : ApplyToGridBase
    {
        public PltSheetApplyToGrid()
        {
            WorksheetColumnsMap.Add((product) => new FlattenedEntity() { Name = "Total weight", Value = product.Pricing.TotalWeight.ToString() });
        }
    }
}
