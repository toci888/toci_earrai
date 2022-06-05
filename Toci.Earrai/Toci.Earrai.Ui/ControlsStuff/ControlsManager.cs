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
        protected bool AutoSize = false;

        public ControlsManager()
        {
            
        }

        public ControlsManager(bool autosize)
        {
            AutoSize = autosize;
        }

        public int GetSize(string text)
        {
            return text.Length * 10;
        }

        public virtual Label CreateLabel(string text, int sizeX, int sizeY, int locX, int locY)
        {
            if (AutoSize)
            {
                sizeX = GetSize(text);
            }
            
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

        public virtual InputTextBox CreateInputTextBox(string text, int sizeX, int sizeY, int locX, int locY, int id, int kind)
        {
            InputTextBox tb = new InputTextBox();

            tb.Text = text;
            tb.Size = new Size(sizeX, sizeY);
            tb.Location = new Point(locX, locY);
            tb.EntryId = id;
            tb.EntryKind = kind;

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

        public virtual Button CreateButton(string text, int sizeX, int sizeY, int locX, int locY, EventHandler submitAction)
        {
            Button submit = new Button();

            submit.Text = text;
            submit.Size = new Size(sizeX, sizeY);
            submit.Location = new Point(locX, locY);
            submit.Click += submitAction;

            return submit;
        }

        public virtual DataGridView CreateGrid(object dataSource, int sizeX, int sizeY, int locX, int locY)
        {
            DataGridView dgv = new DataGridView();

            dgv.DataSource = dataSource;
            dgv.Size = new Size(sizeX, sizeY);
            dgv.Location = new Point(locX, locY);

            return dgv;
        }
    }
}
