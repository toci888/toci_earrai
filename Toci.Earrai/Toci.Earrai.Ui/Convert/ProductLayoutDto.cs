using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Ui.Convert
{
    public class ProductLayoutDto
    {
        public string LabelItemName { get; set; }

        public string LabelItemValue { get; set; }

        public int LabelItemId { get; set; }

        public int Kind { get; set; } // sizes - 1, options - 2
    }
}
