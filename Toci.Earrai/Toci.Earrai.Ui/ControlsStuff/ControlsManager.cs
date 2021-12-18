using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.Earrai.Ui.ControlsStuff
{
    public class ControlsManager
    {
        public virtual Label CreateLabel(string text, int sizeX, int sizeY, int locX, int locY)
        {
            Label label = new Label();

            label.Text = text;
            label.Size = new Size(sizeX, sizeY);
            label.Location = new Point(locX, locY);

            return label;
        }

        public virtual TextBox CreateTextBox(string text, int sizeX, int sizeY, int locX, int locY)
        {
            TextBox tb = new TextBox();

            tb.Text = text;
            tb.Size = new Size(sizeX, sizeY);
            tb.Location = new Point(locX, locY);

            return tb;
        }

        public virtual ComboBox CreateComboBox(object data, string displayMember, int sizeX, int sizeY, int locX, int locY, string valueMember = "")
        {
            ComboBox combo = new ComboBox();

            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DataSource = data;
            combo.Size = new Size(sizeX, sizeY);
            combo.Location = new Point(locX, locY);

            return combo;
        }
    }
}
