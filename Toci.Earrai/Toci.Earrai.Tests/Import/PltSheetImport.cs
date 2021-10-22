using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Tests.Import
{
    public class PltSheetImport : ImportBase
    {
        protected override void ImportAreas(List<string> row, int productId)
        {
            
        }

        protected override void ImportOptions(List<string> row, int productId)
        {
            throw new NotImplementedException();
        }

        protected override void ImportPricing(List<string> row, int productId)
        {
            throw new NotImplementedException();
        }

        protected override void ImportSizes(List<string> row, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
