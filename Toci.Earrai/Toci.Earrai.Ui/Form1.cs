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
using Toci.Earrai.Bll.Client.UI.ToGrid;

namespace Toci.Earrai.Ui
{
    public partial class Form1 : Form
    {
        protected ConnectionCheck ConnCheck = new ConnectionCheck();
        protected DataManager Dm = new DataManager();
        protected SearchDdlsProvider Sdp = new SearchDdlsProvider();

        protected List<Area> areas;
        protected List<Vendor> vendors;
        protected List<Quoteandmetric> quotesandprices;
        protected List<ProductDto> ProductsFiltered;
        protected List<Worksheet> worksheets;
        protected int selectedWorkSheetId = 0;
        protected User LoggedUser;
        protected LogIn MasterWindow;

        public Form1(User loggedUser, LogIn masterWindow)
        {
            LoggedUser = loggedUser;
            MasterWindow = masterWindow;

            InitializeComponent();

            areas = Dm.GetAllAreas();
            vendors = Dm.GetAllVendors();
            quotesandprices = Dm.GetQuotesAndMetrics();
            worksheets = Dm.GetWorksheets();
            //IsConnected();

            Setup();

            this.FormClosed += (s, e) => MasterWindow.Close();
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
            workbookDdl.ValueMember = "Id";
            workbookDdl.DisplayMember = "Sheetname";
            workbookDdl.DataSource = worksheets;
            
            SearchCombosHandler(worksheets.First().Id);
        }

        protected virtual void SearchCombosHandler(int worksheetId)
        {
            selectedWorkSheetId = worksheetId;
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
                                                            //DataGridViewCellEventHandler
        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = new Product(ProductsFiltered[e.RowIndex].Product.Id, areas, vendors, LoggedUser, quotesandprices);
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

       // private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {

            //Product p = new Product(tempUsers[e.RowIndex].Id, areas, vendors);
            //p.Show();

            /*tempUsers.Add(new TempUser() { Id = 4, Name = "Mati", Profession = "Zul" });
            excelDataGrid.SuspendLayout();
            excelDataGrid.DataSource = tempUsers.ToArray();
            
            excelDataGrid.ResumeLayout();*/

            //excelDataGrid.Rows.Add(4, "Mati", "Zul");
      //  }

        private void ExcelDataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void internetConnection_Click(object sender, EventArgs e)
        {

        }

        //search button
        private void button1_Click(object sender, EventArgs e)
        {
            string worksheetId = workbookDdl.SelectedValue.ToString();

            List<ProductDto> products = Dm.GetProductsByWorksheetId(worksheetId);

            ProductsFiltered = products;

            selectedWorkSheetId = int.Parse(worksheetId);

            //ShowOnGrid(products, (p) => p.Product.Description);
            BindToGrid(products);
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            selectedWorkSheetId = int.Parse(workbookDdl.SelectedValue.ToString());

            if (valueDdl.SelectedItem != null)
            {
                List<ProductDto> products = Dm.GetProducts(selectedWorkSheetId, KindDdl.SelectedItem.ToString(), valueDdl.SelectedItem.ToString());

                ProductsFiltered = products;

                BindToGrid(products);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //kindDdl combo
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> elements = Dm.GetFilters(selectedWorkSheetId, ((ComboBox)sender).SelectedItem.ToString());

            valueDdl.DataSource = elements;
        }

        private void workbookDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string worksheetID = ((ComboBox)sender).SelectedValue.ToString();

            int worksheetId = int.Parse(worksheetID);
            
            SearchCombosHandler(worksheetId);
        }

        private void bind2(List<List<FlattenedEntity>> items)
        {
            //excelDataGrid = new DataGridView();
            Dictionary<string, int> keeper = new Dictionary<string, int>();

            excelDataGrid.Columns.Clear();
            excelDataGrid.Rows.Clear();

            bool columns = false;
            foreach (List<FlattenedEntity> item in items)
            {
                if (!columns)
                {
                    int i = 0;
                    int k = 0;
                    foreach (FlattenedEntity element in item)
                    {
                        excelDataGrid.Columns.Add(element.Name, element.Name);
                        excelDataGrid.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        k++;

                        if (!keeper.ContainsKey(element.Name))
                        {
                            keeper.Add(element.Name, i++);
                        }
                    }
                }

                columns = true;
                int j = 0;
                foreach (FlattenedEntity element in item)
                {
                    //if (keeper[element.Name] == j)
                    //{
                //        excelDataGrid.Rows.Add(element.Value);
                    //}
                    //else
                    //{
                    //    excelDataGrid.Rows.Add("");
                    //}
                    j++;
                }
                excelDataGrid.Rows.Add(item.Select(m => m.Value).ToArray());
            }

        }

        private void BindToGrid(List<ProductDto> products)
        {
            FlattenManager fm = new FlattenManager();
            ApplyToGridManager atgm = new ApplyToGridManager();

            ApplyToGridBase atgLogic = atgm.GetApplyToGridLogic(selectedWorkSheetId);

            List<List<FlattenedEntity>> result = new List<List<FlattenedEntity>>();

            foreach (ProductDto product in products)
            {
                List<FlattenedEntity> element = atgLogic.GetFlattenedProduct(product);
                element = fm.FlattenProduct(product, element);
                result.Add(element);
                
            }
            //List<List<FlattenedEntity>> result = products.Select(product => fm.FlattenProduct(product)).ToList();

            bind2(result);

        }
    }
}
