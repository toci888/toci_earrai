using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.Earrai.Ui.ControlsStuff
{
    public class AreaQuantityInputForm : InputForm
    {
        public ComboBox Area { get; set; }

        public TextBox Width { get; set; }

        public TextBox Length { get; set; }

        public TextBox Quantity { get; set; }

        public Button QuantitySubmit { get; set; }

        public Button QuantityClearCancel { get; set; }
    }
}
