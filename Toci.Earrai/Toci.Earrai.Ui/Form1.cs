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

            TaskFactory taskFactory = new TaskFactory();

            Task<List<Area>> taskAreas = taskFactory.StartNew(() => areas = Dm.GetAllAreas());
            Task<List<Vendor>> taskVendors = taskFactory.StartNew(() => vendors = Dm.GetAllVendors());
            Task<List<Quoteandmetric>> taskQuotes = taskFactory.StartNew(() => quotesandprices = Dm.GetQuotesAndMetrics());
            Task<List<Worksheet>> taskWorksheets = taskFactory.StartNew(() => worksheets = Dm.GetWorksheets());

            taskWorksheets.Wait();

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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
                                                            //DataGridViewCellEventHandler
        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = new Product(ProductsFiltered[e.RowIndex].Product.Id, areas, vendors, LoggedUser, quotesandprices);
            p.Show();
        }

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
            Dictionary<int, Dictionary<string, string>> Remapper = new Dictionary<int, Dictionary<string, string>>()
            {
                { 5, new Dictionary<string, string>()
                    {
                        { "DimA", "SizeA" },
                        { "DimB", "SizeB" } 
                    } 
                },
                { 8, new Dictionary<string, string>()
                    {
                        { "OD", "ChsOd" }
                    }
                },
            };

            string selectedItem = ((ComboBox)sender).SelectedItem.ToString();

            if (Remapper.ContainsKey(selectedWorkSheetId))
            {
                if (Remapper[selectedWorkSheetId].ContainsKey(selectedItem))
                {
                    selectedItem = Remapper[selectedWorkSheetId][selectedItem];
                }
            }

            List<string> elements = Dm.GetFilters(selectedWorkSheetId, selectedItem);

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
                
                excelDataGrid.Rows.Add(item.Select(m => m.Value).ToArray());
            }

        }

        private void BindToGrid(List<ProductDto> products)
        {
            FlattenManager fm = new FlattenManager();
            ApplyToGridManager atgm = new ApplyToGridManager();

            ApplyToGridBase atgLogic = atgm.GetApplyToGridLogic(selectedWorkSheetId);

            List<List<FlattenedEntity>> result = new List<List<FlattenedEntity>>();

            products = atgm.EnlargeAreasQuantities(products);

            foreach (ProductDto product in products)
            {
                List<FlattenedEntity> element = atgLogic.GetFlattenedProduct(product);
                element = fm.FlattenProduct(product, element);
                result.Add(element);
                
            }
          
            bind2(result);

        }
    }
}
