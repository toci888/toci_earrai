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
using System.IO;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using System.Reflection;
using ExcelDataReader;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Client.UI.ToGrid;
using Toci.Earrai.Bll.Erp;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Ui.ControlsStuff;
using Toci.Common;

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
        protected Userrole LoggedUser;
        protected LogIn MasterWindow;
        protected Button generateExcelFromView = new ();
        protected List<List<string>> currentGridViewData;
        protected Dictionary<int, List<string>> ImagesMap;
        protected List<PictureBox> ImagesOnLayout = new List<PictureBox>();
        protected Rectangle Monitor;
        protected ScreenManager ScreenManagerInstance;
        protected Dictionary<string, string> sortColumns = new Dictionary<string, string>()
        {
            { "Id", "Id" },
            //{ "Reference", "Reference" },
            { "Balance", "Balance" },
            { "Stock take value", "Stock take value" },
            { "Total weight", "Total weight" },
            { "KgM2", "KgM2" },
            { "KgSheet", "KgSheet" },
            //{ "Length", "Length" },
            //{ "Width", "Width" },
            //{ "Thickness", "Thickness" },
            { "Total square meters", "Total square meters" },
            { "Length", "Length" },
            { "Width", "Width" },
            { "Thickness", "Thickness" },
            //{ "Area", "Area" },
            { "Quantity", "Quantity" },
            //{ "Date", "Date" },
            //{ "Area", "Area" },
            //{ "Quantity", "Quantity" },
            //{ "Date", "Date" },
            //{ "Valuation", "Valuation" },
            { "Price", "Price" },
           // { "Vendor", "Vendor" },
           // { "Date", "Date" },
        };

        public Form1(Userrole loggedUser, LogIn masterWindow)
        {
            CreateImagesMap();
            LoggedUser = loggedUser;
            MasterWindow = masterWindow;

            Monitor = Screen.PrimaryScreen.Bounds;

            ScreenManagerInstance = new ScreenManager(Monitor.Width, Monitor.Height);

            InitializeComponent();

            this.ClientSize = ScreenManagerInstance.GetDimensions(clientX, clientY);

            TaskFactory taskFactory = new TaskFactory();

            Task<List<Area>> taskAreas = taskFactory.StartNew(() => areas = Dm.GetAllAreas());
            Task<List<Vendor>> taskVendors = taskFactory.StartNew(() => vendors = Dm.GetAllVendors());
            Task<List<Quoteandmetric>> taskQuotes = taskFactory.StartNew(() => quotesandprices = Dm.GetQuotesAndMetrics());
            Task<List<Worksheet>> taskWorksheets = taskFactory.StartNew(() => worksheets = Dm.GetWorksheets());

            taskWorksheets.Wait();

            //IsConnected();

            Setup();

            this.users.Visible = false;

            this.FormClosed += (s, e) => MasterWindow.Close();
            generateExcelFromView.Click += GenerateExcelFromView_Click;
            //excelDataGrid.ClientSize = new System.Drawing.Size(1700, 650);
            excelDataGrid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle(new DataGridViewCellStyle() { BackColor = Color.LightBlue });
            excelDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12.75F, FontStyle.Bold);
            excelDataGrid.ColumnHeadersHeight = 95;
            excelDataGrid.SortCompare += customSortCompare;

            if (LoggedUserContext.User.Name == nameof(PrivilegesEnum.Admin))
            {
                this.users.Visible = true;
            }

            AddImages();
        }

        protected virtual void CreateImagesMap()
        {
            ImagesMap = new Dictionary<int, List<string>>()
            {
                { WorksheetsIds.PLTandSHEET, new List<string>() { "pltSheetPL.png", "pltSheetPLCHQ.png" } },
                { WorksheetsIds.MshandExpMetal, new List<string>() { "mshEX_MET.png", "mshMSH.png" } },
                { WorksheetsIds.AnglesplusT, new List<string>() { "anglesT_EA.png", "anglesT_UA.png" } },
                { WorksheetsIds.ChanandBms, new List<string>() { "chanIPE.png", "chanPFC.png", "chanUB.png", "chanUC.png" } },
                { WorksheetsIds.FLTS, new List<string>() { "FLTS_FL.png" } },
                { WorksheetsIds.RHS, new List<string>() { "RHS_RHS.png", "RHS_SHS.png", "Rnds_HB.png", "Rnds_RB_BLK.png", "Rnds_RB_BRI.png", "Rnds_SQ_BLK.png" } },
                { WorksheetsIds.Tube_CHS, new List<string>() { "TubeCHS_CHS.png", "TubeCHS_GCHS.png" } },
            };
        }

        protected virtual void AddImages()
        {
            if (ImagesOnLayout.Any())
            {
                foreach(PictureBox pb in ImagesOnLayout)
                    Controls.Remove(pb);
            }

            if (selectedWorkSheetId > 0 && ImagesMap.ContainsKey(selectedWorkSheetId))
            {
                ImagesOnLayout = new List<PictureBox>();
                int x = 10;
                foreach (string path in ImagesMap[selectedWorkSheetId])
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.ClientSize = new System.Drawing.Size(60, 60);
                    pictureBox.Location = new System.Drawing.Point(x, 10);
                    x += 70;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = new System.Drawing.Bitmap("./assets/" + path);

                    Controls.Add(pictureBox);
                    ImagesOnLayout.Add(pictureBox);
                }
            }
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

            if (worksheets.First() != null)
            {
                SearchCombosHandler(worksheets.First().Id);
            }

            Type dgvType = excelDataGrid.GetType();
                      PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                          BindingFlags.Instance | BindingFlags.NonPublic);
                      pi.SetValue(excelDataGrid, true, null);
        }

        protected virtual void SearchCombosHandler(int worksheetId)
        {
            selectedWorkSheetId = worksheetId;
            KindDdl.DataSource = Sdp.GetDdlItems(worksheetId);

            AddImages();
            //ProductAdd pAdd = new ProductAdd(worksheetId.ToString(), LoggedUserContext.User, areas, vendors, quotesandprices);
            //pAdd.Show();
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
            if (e.RowIndex == -1) // sorting
            {
                return;
            }
            //ProductsFiltered[e.RowIndex].Product.Id

            int productId = int.Parse(excelDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

            Product p = new Product(productId, areas, vendors, LoggedUser, quotesandprices);
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
                List<ProductDto> products = Dm.GetProducts(selectedWorkSheetId, KindDdl.SelectedItem.ToString(), valueDdl.SelectedItem.ToString(), stockTakeValueMin.Text, stockTakeValueMax.Text);

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
                { WorksheetsIds.MshandExpMetal, new Dictionary<string, string>()
                    {
                        { "DimA", "SizeA" },
                        { "DimB", "SizeB" }
                    }
                },
                { WorksheetsIds.AnglesplusT, new Dictionary<string, string>()
                    {
                        { "DimA", "SizeA" },
                        { "DimB", "SizeB" } 
                    } 
                },
                { WorksheetsIds.Rnds_Sqrs_HolBar, new Dictionary<string, string>()
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

        private void customSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string column = e.Column.HeaderText;
            if (sortColumns.ContainsKey(column))
            {
                double one = 0, two = 0;

                double.TryParse(e.CellValue1.ToString(), out one);
                double.TryParse(e.CellValue2.ToString(), out two);

                // If the cell value is already an integer, just cast it instead of parsing

                e.SortResult = one.CompareTo(two);
            }
            else 
            {
                e.SortResult = string.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
            }
            e.Handled = true;
        }

        private void bind2(List<List<FlattenedEntity>> items)
        {
            //excelDataGrid = new DataGridView();
            currentGridViewData = new List<List<string>>();
            Dictionary<string, int> keeper = new Dictionary<string, int>();

            excelDataGrid.Columns.Clear();
            excelDataGrid.Rows.Clear();

            bool columns = false;
            //string dummy = string.Empty;

            foreach (List<FlattenedEntity> item in items)
            {
                if (!columns)
                {
                    int i = 0;
                    int k = 0;
                    foreach (FlattenedEntity element in item)
                    {
                       // dummy += "{ \""+ element.Name + "\", \"" + element.Name + "\" }, " + Environment.NewLine;

                        if (UserRoleManagement.IsColumnAllowed(element.Name))
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
                }

                columns = true;

                List<FlattenedEntity> finalList = new List<FlattenedEntity>();

                foreach (FlattenedEntity fle in item)
                {
                    if (UserRoleManagement.IsColumnAllowed(fle.Name))
                    {
                        finalList.Add(fle);
                    }
                }

                excelDataGrid.RowTemplate.Height = 45;
                excelDataGrid.Rows.Add(finalList.Select(m => m.Value).ToArray());
                currentGridViewData.Add(finalList.Select(m => m.Value).ToList());
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

        private void logout_Click(object sender, EventArgs e)
        {
            LoggedUserContext.User = null;

            this.Dispose();

            LogIn login = new LogIn();
            login.Show();
        }

        private void users_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void addNewProductButton_Click(object sender, EventArgs e)
        {
            ProductAdd pAdd = new ProductAdd(selectedWorkSheetId.ToString(), LoggedUserContext.User, areas, vendors, quotesandprices);
            pAdd.Show();
        }

        protected void GenerateExcelFromView_Click(object sender, EventArgs e)
        {
            ExportLogic el = new ExportLogic();

            el.GenerateGridExcel(currentGridViewData);
        }

        private void sageExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files | *.xls";
            sfd.DefaultExt = "xls";
            sfd.FileName = "SageExport_" + DateTime.Now.ToString("dd-MM-yyyy");

            DialogResult dr = sfd.ShowDialog();

            //List<List<string>> sageData = Dm.ExportToSage();

            ExportLogic el = new ExportLogic();

            el.GenerateExportToSageExcel(sfd.FileName);
            MessageBox.Show("Export done.");
        }

        private void sageImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel files | *.xlsx";

            DialogResult dr = ofd.ShowDialog();

            string path = ofd.FileName;

            ImportLogic il = new ImportLogic();

            il.ReadExcelFile(path);
            MessageBox.Show("Import done.");
        }
    }
}
