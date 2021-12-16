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
using Microsoft.Graph;
using Toci.Earrai.Bll.Client.UI;

namespace Toci.Earrai.Ui
{
    public partial class Form1 : Form
    {
        protected ConnectionCheck ConnCheck = new ConnectionCheck();
        protected DataManager Dm = new DataManager();
        protected SearchDdlsProvider Sdp = new SearchDdlsProvider();

        protected List<Area> areas;
        protected List<Vendor> vendors;
        protected List<ProductDto> productsFiltered;
        protected List<Worksheet> worksheets;

        public Form1()
        {
            InitializeComponent();

            areas = Dm.GetAllAreas();
            vendors = Dm.GetAllVendors();
            worksheets = Dm.GetWorksheets();
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
            workbookDdl.DataSource = worksheets;
            workbookDdl.ValueMember = "Id";
            workbookDdl.DisplayMember = "Sheetname";

            SearchCombosHandler(worksheets.First().Id);
        }

        protected virtual void SearchCombosHandler(int worksheetId)
        {
            KindDdl.DataSource = Sdp.GetDdlItems(worksheetId);
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


            //productsFiltered = Dm.GetProducts(6, "", "");
            //FlattenManager fm = new FlattenManager();

            ////List<FlattenedEntity> result =  fm.FlattenProduct(productsFiltered);



            //List<List<FlattenedEntity>> tyest = new List<List<FlattenedEntity>>()
            //{
            ////    result
            //};

            //foreach (ProductDto item in productsFiltered)
            //{
            //    tyest.Add(fm.FlattenProduct(item));
            //}

            ////excelDataGrid.BindingContext = new 
            ////excelDataGrid.DataSource = tyest;
            //bind(tyest);
            //excelDataGrid.DataSourceChanged += ExcelDataGrid_DataSourceChanged; // Refresh();
            //excelDataGrid.CellClick += ExcelDataGrid_CellClick;

            ////FillExcelGrid(tempUsers);


        }

        private void ExcelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = new Product(productsFiltered[e.RowIndex].Product.Id, areas, vendors);
            p.Show();
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

        private void internetConnection_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string worksheetId = workbookDdl.SelectedValue.ToString();

            List<ProductDto> products = Dm.GetProductsByWorksheetId(worksheetId);
            //ShowOnGrid(products, (p) => p.Product.Description);
            BindToGrid(products);

        }

        private void showBtn_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void workbookDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string worksheetID = ((ComboBox)sender).SelectedValue.ToString();

            int worksheetId = int.Parse(worksheetID);

            SearchCombosHandler(worksheetId);
        }

        protected virtual void ShowOnGrid<TRecord>(List<TRecord> elements, Func<TRecord, string> colNameIndicator)
        {
            
            foreach (TRecord element in elements)
            {
                excelDataGrid.Columns.Add(colNameIndicator(element), colNameIndicator(element));
            }
        }

        private void bind2(List<List<FlattenedEntity>> items)
        {
            bool columns = false;
            foreach (var item in items)
            {
                if (!columns)
                {
                    foreach (FlattenedEntity element in item)
                    {
                        excelDataGrid.Columns.Add(element.Name, element.Name);
                    }
                }

                columns = true;

                excelDataGrid.Rows.Add(item.Select(m => m.Value).ToArray());
            }

        }

        private void BindToGrid(List<ProductDto> products)
        {
            FlattenManager fm = new FlattenManager();

            List<List<FlattenedEntity>> result = products.Select(product => fm.FlattenProduct(product)).ToList();

            bind2(result);

        }
    }
}
