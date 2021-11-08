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
    public partial class Product : Form
    {
        protected ConnectionCheck ConnCheck = new ConnectionCheck();


        public Product(int productId)
        {
            InitializeComponent();

            //IsConnected();

            Setup();
        }

        protected virtual void IsConnected()
        {
            while (true)
            {
                ConnCheck.IsOnline();
            }
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

        private void excelDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
           
        }

        private void ExcelDataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            
        }
    }
}
