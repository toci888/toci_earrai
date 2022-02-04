using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI.ToGrid
{
    public class AlumApplyToGrid : ApplyToGridBase
    {
        public AlumApplyToGrid()
        {
            WorksheetColumnsMap.Add((product) => new FlattenedEntity() { Name = "Total square meters", Value = product.Pricing.TotalSquareMeters.ToString() });
        }
    }
}
