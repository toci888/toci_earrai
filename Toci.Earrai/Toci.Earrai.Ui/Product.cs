using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        protected int ySlided = 0;
        protected int xSlided = 0;
        protected int xSlide = 100;
        protected int ySlide = 30;
        protected int xLeft = 10;

        protected List<Area> areas;
        protected List<Vendor> vendors;

        protected AreaQuantityInputForm Aqif = new AreaQuantityInputForm();

        public Product(int productId, List<Area> _areas, List<Vendor> _vendors)
        {
            InitializeComponent();
            prodId = productId;

            areas = _areas;
            vendors = _vendors;

            product = Dm.GetProduct(prodId);

            AddElementsToLayout(ProductSizeConverter.Convert(product.Sizes), xLeft, 20);
            AddElementsToLayout(ProductOptionsConverter.Convert(product.Options), xLeft, ySlided + ySlide);
            AddAreasQuantitiesForm();
            AddPricingForm();
            //IsConnected();

            Setup();
        }

        protected virtual void AddElementsToLayout(List<ProductLayoutDto> elements, int xCoord, int yCoord)
        {
            int newY = yCoord;
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

            Controls.Add(widthL);
            Controls.Add(Aqif.Width);
            Controls.Add(lengthL);
            Controls.Add(Aqif.Length);
            Controls.Add(areasLabel);
            Controls.Add(Aqif.Area);
            Controls.Add(quantityL);
            Controls.Add(Aqif.Quantity);
            Controls.Add(Aqif.QuantitySubmit);
        }

        protected virtual void QuantityAdd(object sender, EventArgs e)
        {
            int areaId = int.Parse(Aqif.Area.SelectedValue.ToString());                                               //todo
            Areaquantity areaquantity = new Areaquantity() { Idarea = areaId, Idproducts = product.Product.Id, Iduser = 1, Quantity = Aqif.Quantity.Text, Length = Aqif.Length.Text, Width = Aqif.Width.Text };

            Dm.PostAreaQuantity(areaquantity);
        }

        protected virtual void AddPricingForm()
        {
            ySlided += ySlide;

            Label vendorsLabel = Cm.CreateLabel("Vendor: ", 90, 20, xLeft, ySlided);

            ComboBox vCombo = Cm.CreateComboBox(vendors, "Name", 180, 20, xLeft + xSlide, ySlided, "Id");

            Controls.Add(vendorsLabel);
            Controls.Add(vCombo);
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

        private void queryTextbox_TextChanged(object sender, EventArgs e)
        {
            /* TextBox tb = (TextBox)sender;

             AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
             acsc.Add("dupa");
             acsc.Add("sraka");

             tb.AutoCompleteCustomSource = acsc;*/
        }

        private void excelDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExcelDataGrid_DataSourceChanged(object sender, EventArgs e)
        {

        }
    }
}
