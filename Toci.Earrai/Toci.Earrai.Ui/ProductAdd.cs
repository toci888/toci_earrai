using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.Earrai.Bll.Calculations.Pricing.Valuation;
using Toci.Earrai.Bll.Client.UI;
using Toci.Earrai.Bll.Client.UI.ProductTotal;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Ui.ControlsStuff;
using Toci.Earrai.Ui.Convert;

namespace Toci.Earrai.Ui
{
    public partial class ProductAdd : Form
    {
        protected string worksheetId;
        protected DataManager Dm = new DataManager();
        protected ConnectionCheck ConnCheck = new ConnectionCheck();
        protected int prodId;
        protected OptionsSizesAvailableDto OsaDto;
        protected ProductOsConverter<Sizeworksheetelement> ProductSwConverter = new ProductOsConverter<Sizeworksheetelement>();
        protected ProductOsConverter<Optionworksheetelement> ProductOwConverter = new ProductOsConverter<Optionworksheetelement>();
        protected ControlsManager ControlMan = new ControlsManager(true);
        protected ValuationManager Vm = new ValuationManager();
        protected TotalResolver Tr = new TotalResolver();

        protected Label CommissionsHeader = null;
        protected Label StockTakeValue = null;
        protected Label TotalValue = null;
        protected DataGridView PricesCommissionsDgv = null;


        protected int ySlided = 0;
        protected int xSlided = 0;
        protected int xSlide = 100;
        protected int ySlide = 30;
        protected int xLeft = 10;
        protected int xOptionsSizes = 350;
        protected int xCommisions = 550;
        protected int xPrices = 800;

        protected List<Area> areas;
        protected List<Vendor> vendors;
        protected List<Quoteandmetric> quotesandmetrics;
        protected User LoggedUser;

        protected List<Quotesandprice> CurrentPrices;
        protected List<Areasquantity> CurrentQuantities;

        protected AreaQuantityInputForm Aqif = new AreaQuantityInputForm();
        protected QuoteAndPriceInputForm Qapif = new QuoteAndPriceInputForm();

        protected List<Control> PricesForPriceList = new List<Control>();

        protected Areasquantity areaQ;
        protected Quotesandprice quote;

        public ProductAdd(string worksId, User loggedUser)
        {
            InitializeComponent();
            worksheetId = worksId;

            LoggedUser = loggedUser;

            OsaDto = Dm.GetAvailableOptionsSizes(worksheetId);

            AddBasicProductInfo();
            AddElementsToLayout(ProductSwConverter.Convert(OsaDto.Sizeworksheetelements, (swe) => { return new ProductLayoutDto() { Kind = (int)SizesOptionsEnum.Sizes, LabelItemId = swe.Idsizes.Value, LabelItemName = swe.Name }; }), xLeft + xOptionsSizes, 20, "Product sizing information.");
            AddElementsToLayout(ProductOwConverter.Convert(OsaDto.Optionworksheetelements, (owe) => { return new ProductLayoutDto() { Kind = (int)SizesOptionsEnum.Options, LabelItemId = owe.Idproductoptions.Value, LabelItemName = owe.Name }; }), xLeft + xOptionsSizes, ySlided + ySlide, "Product options.");
           // AddCommissions();
           // AddAreasQuantitiesForm();
          //  AddPricingForm();
            //IsConnected();

          //  Setup();
        }

        protected virtual void AddBasicProductInfo()
        {
            int y = 10;
            
            Label productaccountreference = ControlMan.CreateLabel("Product Account Reference: ", 90, 20, xLeft, y);
            TextBox productaccountreferenceValue = ControlMan.CreateTextBox("", 90, 20, xLeft + ControlMan.GetSize("Product Account Reference: "), y);

            y += ySlide;

            Label description = ControlMan.CreateLabel("Description: ", 90, 20, xLeft, y);
            TextBox descriptionValue = ControlMan.CreateTextBox("", 90, 20, xLeft + xSlide, y);

            Controls.Add(productaccountreference);
            Controls.Add(productaccountreferenceValue);
            Controls.Add(description);
            Controls.Add(descriptionValue);
        }

        protected virtual void AddElementsToLayout(List<ProductLayoutDto> elements, int xCoord, int yCoord, string header)
        {
            int newY = yCoord;

            Label head = ControlMan.CreateLabel(header, 90, 20, xCoord, newY);

            Controls.Add(head);

            newY += ySlide;

            foreach (ProductLayoutDto item in elements)
            {
                Label l = ControlMan.CreateLabel(item.LabelItemName, 90, 20, xCoord, newY);
                InputTextBox inTb = ControlMan.CreateInputTextBox(item.LabelItemValue, 90, 20, xCoord + xSlide, newY, item.LabelItemId, item.Kind);
                //todo add textboxes on list on purpose of submit action
                newY += ySlide;

                Controls.Add(l);
                Controls.Add(inTb);
            }

            ySlided = newY;
        }

        protected virtual void AddAreasQuantitiesForm()
        {
            ySlided += ySlide;

            Label widthL = ControlMan.CreateLabel("Width: ", 90, 20, xLeft, ySlided);

            xSlided = xLeft + ControlMan.GetSize("Width: "); 

            Aqif.Width = ControlMan.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label lengthL = ControlMan.CreateLabel("Length: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + ControlMan.GetSize("Length: ");

            Aqif.Length = ControlMan.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label quantityL = ControlMan.CreateLabel("Quantity: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + ControlMan.GetSize("Quantity: ");

            Aqif.Quantity = ControlMan.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label areasLabel = ControlMan.CreateLabel("Area: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + ControlMan.GetSize("Area: ");

            Aqif.Area = ControlMan.CreateComboBox(areas, "Name", 180, 20, xSlided, ySlided, "Id");

            xSlided += xLeft + xSlide + xSlide;

            Aqif.QuantitySubmit = ControlMan.CreateButton("Add", 90, 20, xSlided, ySlided, QuantityAdd);

            ySlided += ySlide;

            Aqif.DisplayGrid = ControlMan.CreateGrid(GetQuantities(prodId), 1000, 200, xLeft, ySlided);
            Aqif.DisplayGrid.CellClick += QuantitiesCellClick;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            Aqif.DisplayGrid.Columns.Add(deleteButton);

            Aqif.DisplayGrid.DataBindingComplete += (sn, evA) =>
            {
                List<string> colsHide = new List<string>() { "Id", "Idproducts", "Idcodesdimensions", "Idarea", "Iduser", "Rowindex" };

                foreach (string column in colsHide)
                {
                    Aqif.DisplayGrid.Columns[column].Visible = false;
                }
            };

            ySlided += 200;

            Controls.Add(widthL);
            Controls.Add(Aqif.Width);
            Controls.Add(lengthL);
            Controls.Add(Aqif.Length);
            Controls.Add(areasLabel);
            Controls.Add(Aqif.Area);
            Controls.Add(quantityL);
            Controls.Add(Aqif.Quantity);
            Controls.Add(Aqif.QuantitySubmit);
            Controls.Add(Aqif.DisplayGrid);
        }

        protected virtual List<Areasquantity> GetQuantities(int productId)
        {
            CurrentQuantities = Dm.GetQuantites(productId);

            return CurrentQuantities;
        }

        protected virtual void QuantityAdd(object sender, EventArgs e)
        {
            if (Aqif.Width.Text == string.Empty || Aqif.Length.Text == string.Empty || Aqif.Quantity.Text == string.Empty)
            {
                return;
            }

            int areaId = int.Parse(Aqif.Area.SelectedValue.ToString());                                               
            Areaquantity areaquantity = new Areaquantity() {          
                Idarea = areaId, Idproducts = 1, Iduser = LoggedUser.Id, Quantity = Aqif.Quantity.Text, Length = Aqif.Length.Text, Width = Aqif.Width.Text };

            List<Areaquantity> result = new List<Areaquantity>();

            if (Aqif.QuantitySubmit.Text == "Update")
            {
                areaquantity.Id = areaQ.Id.Value;
                areaquantity.Createdat = areaQ.Createdat;
                areaquantity.Updatedat = DateTime.Now;

                result.Add(Dm.UpdateAreaQuantity(areaquantity));
            }
            else
            {
                result = Dm.PostAreaQuantity(areaquantity);
            }

            if (result[0].Id > 0)
            {
                Aqif.Quantity.Text = "";
                Aqif.Length.Text = "";
                Aqif.Width.Text = "";
                Aqif.DisplayGrid.DataSource = GetQuantities(prodId);
                Aqif.QuantitySubmit.Text = "Add";
            }
        }

        protected virtual void AddPricingForm()
        {
            ySlided += ySlide;
            xSlided = 0;

            Label vendorsLabel = ControlMan.CreateLabel("Vendor: ", 90, 20, xLeft, ySlided);

            xSlided += xLeft + ControlMan.GetSize("Vendor: ");

            Qapif.Vendors = ControlMan.CreateComboBox(vendors, "Name", 90, 20, xSlided, ySlided, "Id");

            xSlided += xSlide;

            Label valuationLabel = ControlMan.CreateLabel("Price kind: ", 90, 20, xSlided, ySlided);

            xSlided += ControlMan.GetSize("Price kind: ");

            Qapif.PriceKind = ControlMan.CreateComboBox(quotesandmetrics, "Valuation", 90, 20, xSlided, ySlided, "Id");

            xSlided += xSlide;

            Label priceLabel = ControlMan.CreateLabel("Price: ", 90, 20, xSlided, ySlided);

            xSlided += ControlMan.GetSize("Price: "); ;

            Qapif.Price = ControlMan.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xSlide;

            Qapif.PriceSubmit = ControlMan.CreateButton("Add", 90, 20, xSlided, ySlided, PriceAdd);

            ySlided += ySlide;

            Qapif.DisplayGrid = ControlMan.CreateGrid(GetPrices(prodId), 1000, 200, xLeft, ySlided);
            Qapif.DisplayGrid.CellClick += PricesCellClick;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            Qapif.DisplayGrid.Columns.Add(deleteButton);

            Qapif.DisplayGrid.DataBindingComplete += (sn, evA) =>
            {
                List<string> colsHide = new List<string>() { "Id", "Idproducts", "Idquoteandmetric", "Idvendor", "Iduser", "Rowindex" };

                foreach (string column in colsHide)
                {
                    Qapif.DisplayGrid.Columns[column].Visible = false;
                }
            };

            Controls.Add(vendorsLabel);
            Controls.Add(priceLabel);
            Controls.Add(Qapif.Vendors);
            Controls.Add(valuationLabel);
            Controls.Add(Qapif.PriceKind);
            Controls.Add(Qapif.Price);
            Controls.Add(Qapif.PriceSubmit);
            Controls.Add(Qapif.DisplayGrid);
        }
        protected virtual List<Quotesandprice> GetPrices(int productId)
        {
            CurrentPrices = Dm.GetPrices(productId);

            return CurrentPrices;
        }

        protected virtual void PriceAdd(object sender, EventArgs e)
        {
            if (Qapif.Price.Text == string.Empty)
            {
                return;
            }

            int vendorId = int.Parse(Qapif.Vendors.SelectedValue.ToString());
            int quoteandmetricId = int.Parse(Qapif.PriceKind.SelectedValue.ToString());

            Quoteandprice price = new Quoteandprice()
            {
                Idvendor = vendorId,
                Idquoteandmetric = quoteandmetricId,
                Idproducts = 1,
                Iduser = LoggedUser.Id,
                Price = Qapif.Price.Text
            };

            Quoteandprice res = null; 
            int result = 0;

            if (Qapif.PriceSubmit.Text == "Update")
            {
                price.Id = quote.Id.Value;
                price.Createdat = quote.Createdat;
                price.Updatedat = DateTime.Now;

                res = Dm.UpdateQuoteandprice(price);
            }
            else
            {
                result = Dm.AddQuoteandPrice(price);
            }


            if (result > 0 || res != null)
            {
                Qapif.Price.Text = "";
                Qapif.DisplayGrid.DataSource = GetPrices(prodId);
                Qapif.PriceSubmit.Text = "Add";

                double priceD = 0;

                double.TryParse(price.Price, out priceD);
            }
        }

        protected virtual void QuantitiesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            areaQ = CurrentQuantities.ElementAtOrDefault(e.RowIndex);

            if (e.ColumnIndex == 0)
            {
                string message = string.Format("You are attempting to erase quantity {0} created at {1} by user {2}. ", areaQ.Quantity, areaQ.Createdat, areaQ.Initials);

                DialogResult dialogResult = MessageBox.Show(message + "Are you sure ?", "Quantities delete warning.", MessageBoxButtons.YesNo);

                if (dialogResult.ToString() == "Yes")
                {
                    Dm.DeleteQuantity(areaQ.Id.Value);

                    Aqif.DisplayGrid.DataSource = GetQuantities(prodId);

                    return;
                }
            }

            if (areaQ != null)
            {
                Aqif.Area.SelectedValue = areaQ.Idarea;
                Aqif.Length.Text = areaQ.Length;
                Aqif.Quantity.Text = areaQ.Quantity;
                Aqif.Width.Text = areaQ.Width;
                Aqif.QuantitySubmit.Text = "Update";
            }
        }

        protected virtual void PricesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            quote = CurrentPrices.ElementAtOrDefault(e.RowIndex);

            if (e.ColumnIndex == 0)
            {
                string message = string.Format("You are attempting to erase quote price {0} created at {1} by user {2}. ", quote.Price, quote.Createdat, quote.Initials);

                DialogResult dialogResult = MessageBox.Show(message + "Are you sure ?", "Price quote delete warning.", MessageBoxButtons.YesNo);

                if (dialogResult.ToString() == "Yes")
                {
                    Dm.DeleteQuoteAndPrice(quote.Id.Value);

                    Qapif.DisplayGrid.DataSource = GetPrices(prodId);

                    return;
                }
            }

            if (quote != null)
            {
                double price = 0;

                double.TryParse(quote.Price, out price);

                //AddCommissions(price);

                Qapif.Vendors.SelectedValue = quote.Idvendor;
                Qapif.Price.Text = quote.Price;
                Qapif.PriceKind.SelectedValue = quote.Idquoteandmetric;
                Qapif.PriceSubmit.Text = "Update";

              
            }
        }

        protected virtual void PricesAndCommissionsToGrid(Valuations valuation, ProductDto product, double price)
        {
            Dictionary<Valuations, double> prices = Vm.GetPrices(valuation, product, price);

            List<List<string>> dgvData = new List<List<string>>();

            List<string> headers = new List<string>() { "Valuation", "Price", "30%", "35%", "40%", "50%" };

            dgvData.Add(headers);

            foreach (KeyValuePair<Valuations, double> singlePrice in prices)
            {
                Dictionary<string, double> commissions = Dm.GetCommissions(product.Product.Id, singlePrice.Value);

                List<string> record = new List<string>() { singlePrice.Key.ToString(), singlePrice.Value.ToString() };

                record.AddRange(commissions.Select(m => m.Value.ToString()));

                dgvData.Add(record);
            }

            if (PricesCommissionsDgv != null)
            {
                Controls.Remove(PricesCommissionsDgv);
            }
            
            PricesCommissionsDgv = ControlMan.CreateGrid(null, 650, 250, 600, 10);

            ShowOnGrid(PricesCommissionsDgv, dgvData);

            Controls.Add(PricesCommissionsDgv);
        }

        protected virtual void ShowOnGrid(DataGridView dataGrid, List<List<string>> items)
        {
            bool columns = true;
            bool hasAddedCols = false;

            foreach (List<string> item in items)
            {
                if (columns)
                {
                    foreach (string element in item)
                    {
                        dataGrid.Columns.Add(element, element);
                        //excelDataGrid.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }

                    hasAddedCols = true;
                }

                columns = false;

                if (!hasAddedCols)
                {
                    dataGrid.Rows.Add(item.Select(m => m).ToArray());
                }

                hasAddedCols = false;
            }
        }

        protected virtual void RenderPricesForPrice(Dictionary<Valuations, double> prices)
        {
            if (PricesForPriceList.Count > 0)
            {
                foreach (Control c in PricesForPriceList)
                {
                    Controls.Remove(c);
                }

                PricesForPriceList = new List<Control>();
            }


            int y = 10;

            foreach (KeyValuePair<Valuations, double> price in prices)
            {
                Label priceKey = ControlMan.CreateLabel(ValuationsMapUtil.StringifyEnumValuation(price.Key) + ": ", 90, 20, xLeft + xPrices, y);
                Label priceValue = ControlMan.CreateLabel(price.Value.ToString("0.00"), 90, 20, xLeft + xPrices + ControlMan.GetSize(ValuationsMapUtil.StringifyEnumValuation(price.Key) + ": ") + 10, y);

                Controls.Add(priceKey);
                Controls.Add(priceValue);

                PricesForPriceList.Add(priceKey);
                PricesForPriceList.Add(priceValue);

                y += 25;
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}