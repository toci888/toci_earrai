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

        protected int ySlided = 0;
        protected int xSlide = 100;
        protected int ySlide = 30;
        protected int xLeft = 10;

        protected List<Area> areas;
        protected List<Vendor> vendors;

        public Product(int productId, List<Area> _areas, List<Vendor> _vendors)
        {
            InitializeComponent();
            prodId = productId;

            areas = _areas;
            vendors = _vendors;

            product = Dm.GetProduct(prodId);

            AddElementsToLayout(ProductSizeConverter.Convert(product.Sizes), xLeft, 20);
            AddElementsToLayout(ProductOptionsConverter.Convert(product.Options), xLeft, ySlided + ySlide);
            AddAreasQuatntitiesForm();
            AddPricingForm();
            //IsConnected();

            Setup();
        }

        protected virtual void AddElementsToLayout(List<ProductLayoutDto> elements, int xCoord, int yCoord)
        {
            int newY = yCoord;
            foreach (ProductLayoutDto item in elements)
            {
                Label l = new Label();
                l.Text = item.LabelItemName;
                l.Size = new System.Drawing.Size(90, 20);
                l.Location = new Point(xCoord, newY);

                Label lR = new Label();
                lR.Text = item.LabelItemValue;
                lR.Size = new System.Drawing.Size(90, 20);
                lR.Location = new Point(xCoord + xSlide, newY);

                newY += ySlide;
                Controls.Add(l);
                Controls.Add(lR);
            }

            ySlided = newY;
        }

        protected virtual void AddAreasQuatntitiesForm()
        {
            ySlided += ySlide;

            Label widthL = new Label();
            widthL.Text = "Width: ";
            widthL.Size = new System.Drawing.Size(90, 20);
            widthL.Location = new Point(xLeft, ySlided);

            TextBox widthT = new TextBox();
            widthT.Size = new System.Drawing.Size(90, 20);
            widthT.Location = new Point(xLeft + xSlide, ySlided);

            ySlided += ySlide;

            Label lengthL = new Label();
            lengthL.Text = "Length: ";
            lengthL.Size = new System.Drawing.Size(90, 20);
            lengthL.Location = new Point(xLeft, ySlided);

            TextBox lengthR = new TextBox();
            lengthR.Size = new System.Drawing.Size(90, 20);
            lengthR.Location = new Point(xLeft + xSlide, ySlided);

            Controls.Add(widthL);
            Controls.Add(widthT);
            Controls.Add(lengthL);
            Controls.Add(lengthR);

            ySlided += ySlide;

            Label areasLabel = new Label();
            areasLabel.Text = "Area: ";
            areasLabel.Size = new System.Drawing.Size(90, 20);
            areasLabel.Location = new Point(xLeft, ySlided);

            ComboBox vCombo = new ComboBox();

            vCombo.DisplayMember = "Name";
            vCombo.ValueMember = "Id";
            vCombo.DataSource = areas;
            vCombo.Size = new System.Drawing.Size(90, 20);
            vCombo.Location = new Point(xLeft + xSlide, ySlided);

            Controls.Add(areasLabel);
            Controls.Add(vCombo);
        }

        protected virtual void AddPricingForm()
        {
            ySlided += ySlide;

            Label vendorsLabel = new Label();
            vendorsLabel.Text = "Vendor: ";
            vendorsLabel.Size = new System.Drawing.Size(90, 20);
            vendorsLabel.Location = new Point(xLeft, ySlided);

            ComboBox vCombo = new ComboBox();

            vCombo.DisplayMember = "Name";
            vCombo.ValueMember = "Id";
            vCombo.DataSource = vendors;
            vCombo.Size = new System.Drawing.Size(90, 20);
            vCombo.Location = new Point(xLeft + xSlide, ySlided);

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
