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
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Ui.ControlsStuff;
using Toci.Earrai.Ui.Convert;

namespace Toci.Earrai.Ui
{
    public partial class Product : Form
    {
        protected DataManager Dm = new DataManager();
        protected ConnectionCheck ConnCheck = new ConnectionCheck();
        protected int prodId;
        protected ProductDto product;
        protected ProductSizeConverter ProductSizeConverter = new ProductSizeConverter();
        protected ProductOptionsConverter ProductOptionsConverter = new ProductOptionsConverter();
        protected ControlsManager Cm = new ControlsManager(true);
        protected ValuationManager Vm = new ValuationManager();

        protected Label CommissionsHeader = null;

        protected int ySlided = 0;
        protected int xSlided = 0;
        protected int xSlide = 100;
        protected int ySlide = 30;
        protected int xLeft = 10;
        protected int xOptionsSizes = 350;
        protected int xCommisions = 550;

        protected List<Area> areas;
        protected List<Vendor> vendors;
        protected List<Quoteandmetric> quotesandmetrics;
        protected User LoggedUser;

        protected List<Quotesandprice> CurrentPrices;
        protected List<Areasquantity> CurrentQuantities;

        protected AreaQuantityInputForm Aqif = new AreaQuantityInputForm();
        protected QuoteAndPriceInputForm Qapif = new QuoteAndPriceInputForm();

        protected Areasquantity areaQ;
        protected Quotesandprice quote;

       protected  Dictionary<string, Tuple<Label, Label>> CommissionsView = new Dictionary<string, Tuple<Label, Label>>();

        public Product(int productId, List<Area> _areas, List<Vendor> _vendors, User loggedUser, List<Quoteandmetric> _quotesandmetrics)
        {
            InitializeComponent();
            prodId = productId;

            areas = _areas;
            vendors = _vendors;
            LoggedUser = loggedUser;
            quotesandmetrics = _quotesandmetrics;

            product = Dm.GetProduct(prodId);

            AddBasicProductInfo();
            AddElementsToLayout(ProductSizeConverter.Convert(product.Sizes), xLeft + xOptionsSizes, 20, "Product sizing information.");
            AddElementsToLayout(ProductOptionsConverter.Convert(product.Options), xLeft + xOptionsSizes, ySlided + ySlide, "Product options.");
           // AddCommissions();
            AddAreasQuantitiesForm();
            AddPricingForm();
            //IsConnected();

            Setup();
        }

        protected virtual void AddCommissions(double price)
        {
            bool addToDict = !CommissionsView.Any();
            int y = 10;

            if (addToDict)
            {
                CommissionsHeader = Cm.CreateLabel("Commissions for price: " + price.ToString("0.00"), 90, 20, xLeft + xCommisions, y);

                Controls.Add(CommissionsHeader);

                y += ySlide;
            }
            else
            {
                CommissionsHeader.Text = "Commissions for price: " + price.ToString("0.00");
            }

            Dictionary<string, double> commissions = Dm.GetCommissions(product.Product.Id, price); 

            

            foreach (KeyValuePair<string, double> commission in commissions)
            {
                if (addToDict)
                {
                    Label commKey = Cm.CreateLabel(commission.Key + ": ", 90, 20, xLeft + xCommisions, y);
                    Label commValue = Cm.CreateLabel(commission.Value.ToString("0.00"), 90, 20, xLeft + xCommisions + Cm.GetSize(commission.Key + ": ") + 10, y);

                    Controls.Add(commKey);
                    Controls.Add(commValue);

                    CommissionsView.Add(commission.Key, new Tuple<Label, Label>(commKey, commValue));
                }
                else
                {
                    CommissionsView[commission.Key].Item2.Text = commission.Value.ToString("0.00");
                }

                y += ySlide;
            }
        }

        protected virtual void AddBasicProductInfo()
        {
            int y = 10;
            
            Label productaccountreference = Cm.CreateLabel("Product Account Reference: ", 90, 20, xLeft, y);
            Label productaccountreferenceValue = Cm.CreateLabel(product.Product.Productaccountreference, 90, 20, xLeft + Cm.GetSize("Product Account Reference: "), y);

            y += ySlide;

            Label description = Cm.CreateLabel("Description: ", 90, 20, xLeft, y);
            Label descriptionValue = Cm.CreateLabel(product.Product.Description, 90, 20, xLeft + xSlide, y);

            Controls.Add(productaccountreference);
            Controls.Add(productaccountreferenceValue);
            Controls.Add(description);
            Controls.Add(descriptionValue);
        }

        protected virtual void AddElementsToLayout(List<ProductLayoutDto> elements, int xCoord, int yCoord, string header)
        {
            int newY = yCoord;

            Label head = Cm.CreateLabel(header, 90, 20, xCoord, newY);

            Controls.Add(head);

            newY += ySlide;

            foreach (ProductLayoutDto item in elements)
            {
                Label l = Cm.CreateLabel(item.LabelItemName, 90, 20, xCoord, newY);
                Label lR = Cm.CreateLabel(item.LabelItemValue, 90, 20, xCoord + xSlide, newY);

                newY += ySlide;

                Controls.Add(l);
                Controls.Add(lR);
            }

            ySlided = newY;
        }

        protected virtual void AddAreasQuantitiesForm()
        {
            ySlided += ySlide;

            Label widthL = Cm.CreateLabel("Width: ", 90, 20, xLeft, ySlided);

            xSlided = xLeft + Cm.GetSize("Width: "); 

            Aqif.Width = Cm.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label lengthL = Cm.CreateLabel("Length: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + Cm.GetSize("Length: ");

            Aqif.Length = Cm.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label quantityL = Cm.CreateLabel("Quantity: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + Cm.GetSize("Quantity: ");

            Aqif.Quantity = Cm.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xLeft + xSlide;

            Label areasLabel = Cm.CreateLabel("Area: ", 90, 20, xSlided, ySlided);

            xSlided += xLeft + Cm.GetSize("Area: ");

            Aqif.Area = Cm.CreateComboBox(areas, "Name", 180, 20, xSlided, ySlided, "Id");

            xSlided += xLeft + xSlide + xSlide;

            Aqif.QuantitySubmit = Cm.CreateButton("Add", 90, 20, xSlided, ySlided, QuantityAdd);

            ySlided += ySlide;

            Aqif.DisplayGrid = Cm.CreateGrid(GetQuantities(prodId), 1000, 200, xLeft, ySlided);
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
                Idarea = areaId, Idproducts = product.Product.Id, Iduser = LoggedUser.Id, Quantity = Aqif.Quantity.Text, Length = Aqif.Length.Text, Width = Aqif.Width.Text };

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

            Label vendorsLabel = Cm.CreateLabel("Vendor: ", 90, 20, xLeft, ySlided);

            xSlided += xLeft + Cm.GetSize("Vendor: ");

            Qapif.Vendors = Cm.CreateComboBox(vendors, "Name", 90, 20, xSlided, ySlided, "Id");

            xSlided += xSlide;

            Label valuationLabel = Cm.CreateLabel("Price kind: ", 90, 20, xSlided, ySlided);

            xSlided += Cm.GetSize("Price kind: ");

            Qapif.PriceKind = Cm.CreateComboBox(quotesandmetrics, "Valuation", 90, 20, xSlided, ySlided, "Id");

            xSlided += xSlide;

            Label priceLabel = Cm.CreateLabel("Price: ", 90, 20, xSlided, ySlided);

            xSlided += Cm.GetSize("Price: "); ;

            Qapif.Price = Cm.CreateTextBox("", 90, 20, xSlided, ySlided);

            xSlided += xSlide;

            Qapif.PriceSubmit = Cm.CreateButton("Add", 90, 20, xSlided, ySlided, PriceAdd);

            ySlided += ySlide;

            Qapif.DisplayGrid = Cm.CreateGrid(GetPrices(prodId), 1000, 200, xLeft, ySlided);
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
                Idproducts = product.Product.Id,
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

                AddCommissions(priceD);
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

                AddCommissions(price);

                Qapif.Vendors.SelectedValue = quote.Idvendor;
                Qapif.Price.Text = quote.Price;
                Qapif.PriceKind.SelectedValue = quote.Idquoteandmetric;
                Qapif.PriceSubmit.Text = "Update";

                Dictionary<Valuations, double> pricesForPrice = Vm.GetPrices(ValuationsMapUtil.EnumifyStringValuation(quote.Valuation), product, price);
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