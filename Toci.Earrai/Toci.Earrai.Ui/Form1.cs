using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using System.Reflection;
using Toci.Earrai.Bll.Client.UI;

namespace Toci.Earrai.Ui
{
    public partial class Form1 : Form
    {
        protected ConnectionCheck ConnCheck = new ConnectionCheck();
        protected DataManager Dm = new DataManager();

        protected List<Area> areas;
        protected List<Vendor> vendors;

       

        public Form1()
        {
            InitializeComponent();

            areas = Dm.GetAllAreas();
            vendors = Dm.GetAllVendors();

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
            List<ProductDto> tempUsers = Dm.GetProducts(6, "", "");
            FlattenManager fm = new FlattenManager();

            List<FlattenedEntity> result =  fm.FlattenProduct(tempUsers[0]);
            List<List<FlattenedEntity>> tyest = new List<List<FlattenedEntity>>()
            {
                result
            };
            //excelDataGrid.BindingContext = new 
            //excelDataGrid.DataSource = tyest;
            bind(tyest);
            excelDataGrid.DataSourceChanged += ExcelDataGrid_DataSourceChanged; // Refresh();

            //FillExcelGrid(tempUsers);


        }

        private void bind(List<List<FlattenedEntity>> items)
        {
            foreach (var item in items)
            {

                foreach (FlattenedEntity element in item)
                {
                    excelDataGrid.Columns.Add(element.Name, element.Name);
                }

                excelDataGrid.Rows.Add(item.Select(m => m.Value).ToArray());
            }

        }

        private void FillExcelGrid(List<ProductDto> products)
        {
            SingleObjFill(products[0].Product);
            //SingleObjFill(products[0].Sizes[]);
        }

        private void SingleObjFill(object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                excelDataGrid.Columns.Add(prop.Name, prop.Name); //prop.GetValue(obj)
            }
        }

        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {

            //Product p = new Product(tempUsers[e.RowIndex].Id, areas, vendors);
            //p.Show();

            /*tempUsers.Add(new TempUser() { Id = 4, Name = "Mati", Profession = "Zul" });
            excelDataGrid.SuspendLayout();
            excelDataGrid.DataSource = tempUsers.ToArray();
            
            excelDataGrid.ResumeLayout();*/

            //excelDataGrid.Rows.Add(4, "Mati", "Zul");
        }

        private void ExcelDataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            
        }
    }
}
