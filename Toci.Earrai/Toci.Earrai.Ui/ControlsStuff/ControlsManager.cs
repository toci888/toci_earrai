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
        protected ScreenManager ScreenManagerInstance;

        public ControlsManager(bool autosize, ScreenManager scm)
        {
            AutoSize = autosize;
            ScreenManagerInstance = scm;
        }

        public int GetSize(string text)
        {
            return text.Length * 12;
        }

        public virtual Label CreateLabel(string text, int sizeX, int sizeY, int locX, int locY)
        {
            if (AutoSize)
            {
                sizeX = GetSize(text);
            }
            
            Label label = new Label();

            label.Text = text;
            label.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            label.Location = ScreenManagerInstance.GetLocation(locX, locY); //new Point(locX, locY);

            return label;
        }

        public virtual TextBox CreateTextBox(string text, int sizeX, int sizeY, int locX, int locY)
        {
            TextBox tb = new TextBox();

            tb.Text = text;
            tb.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            tb.Location = ScreenManagerInstance.GetLocation(locX, locY);

            return tb;
        }

        public virtual InputTextBox CreateInputTextBox(string text, int sizeX, int sizeY, int locX, int locY, int id, int kind)
        {
            InputTextBox tb = new InputTextBox();

            tb.Text = text;
            tb.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            tb.Location = ScreenManagerInstance.GetLocation(locX, locY);
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
            combo.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            combo.Location = ScreenManagerInstance.GetLocation(locX, locY);

            return combo;
        }

        public virtual Button CreateButton(string text, int sizeX, int sizeY, int locX, int locY, EventHandler submitAction)
        {
            Button submit = new Button();

            submit.Text = text;
            submit.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            submit.Location = ScreenManagerInstance.GetLocation(locX, locY);
            submit.Click += submitAction;

            return submit;
        }

        public virtual DataGridView CreateGrid(object dataSource, int sizeX, int sizeY, int locX, int locY)
        {
            DataGridView dgv = new DataGridView();

            dgv.DataSource = dataSource;
            dgv.ClientSize = ScreenManagerInstance.GetDimensions(sizeX, sizeY);// new Size(sizeX, sizeY);
            dgv.Location = ScreenManagerInstance.GetLocation(locX, locY);

            return dgv;
        }
    }
}
