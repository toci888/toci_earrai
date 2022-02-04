using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public class AnglesTApplyToGrid : ApplyToGridBase 
    {
        public AnglesTApplyToGrid()
        {
            WorksheetColumnsMap.Add((product) => new FlattenedEntity() { Name = "Total metres", Value = product.Pricing.TotalMeters.ToString() });
        }
    }
}
