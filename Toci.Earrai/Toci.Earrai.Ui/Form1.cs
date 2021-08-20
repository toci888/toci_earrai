using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.Earrai.Ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Setup();
        }

        protected virtual void Setup()
        {
            ExcelProxy ep = new ExcelProxy();

            queryTextbox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            queryTextbox.AutoCompleteCustomSource.AddRange(ep.GetSuggestions().ToArray());
        }

        private void queryTextbox_TextChanged(object sender, EventArgs e)
        {
           /* TextBox tb = (TextBox)sender;

            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            acsc.Add("dupa");
            acsc.Add("sraka");

            tb.AutoCompleteCustomSource = acsc;*/
        }
    }
}
