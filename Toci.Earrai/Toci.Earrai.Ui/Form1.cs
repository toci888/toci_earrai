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
        protected ConnectionCheck ConnCheck = new ConnectionCheck();

        public List<TempUser> tempUsers = new List<TempUser>()
        {
            new TempUser() {Id = 1, Name = "Bartus", Profession = "Rolnik"},
            new TempUser() { Id = 2, Name = "Tomek", Profession = "Sinior Pehape Developer" },
            new TempUser() { Id = 3, Name = "Kacper", Profession = "zawodnik Fame MMA" }
        };
        public Form1()
        {
            InitializeComponent();

            IsConnected();

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

            /*tempUsers = new List<TempUser>();
            tempUsers.Add(new TempUser() { Id = 1, Name = "Bartus", Profession = "Rolnik" });
            tempUsers.Add(new TempUser() { Id = 2, Name = "Tomek", Profession = "Sinior Pehape Developer" });
            tempUsers.Add(new TempUser() { Id = 3, Name = "Kacper", Profession = "zawodnik Fame MMA" });*/

            excelDataGrid.DataSource = tempUsers;



        }

        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            tempUsers.Add(new TempUser() { Id = 4, Name = "Mati", Profession = "Zul" });

            excelDataGrid.DataSource = tempUsers;

            excelDataGrid.Rows.Add(4, "Mati", "Zul");
        }
    }
}
