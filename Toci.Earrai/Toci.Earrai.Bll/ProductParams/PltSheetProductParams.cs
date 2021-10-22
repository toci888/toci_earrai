using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.ProductParams
{
    public class PltSheetProductParams : ProductParamsBase
    {
        public PltSheetProductParams()
        {
            SizesFillerMap = new Dictionary<string, Func<Productssize, CalculationsBaseDto, CalculationsBaseDto>>()
            {
                { "Width", (po, dto) => { dto.Width = Convert.ToDouble(po.Value); return dto; } },
                { "Length", (po, dto) => { dto.Length = Convert.ToDouble(po.Value); return dto; } },
                { "Thickness", (po, dto) => { dto.Thickness = Convert.ToDouble(po.Value); return dto; } }
            };

            OptionsFillerMap = new Dictionary<string, Func<Productsoptionsstate, CalculationsBaseDto, CalculationsBaseDto>>()
            {

            };
        }
    }
}
