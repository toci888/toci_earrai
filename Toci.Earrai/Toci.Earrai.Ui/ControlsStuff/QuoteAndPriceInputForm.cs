using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.Earrai.Ui.ControlsStuff
{
    public class QuoteAndPriceInputForm : InputForm
    {
        public ComboBox Vendors { get; set; }

        public ComboBox PriceKind { get; set; }

        public TextBox Price { get; set; }

        public Button PriceSubmit { get; set; }
    }
}
