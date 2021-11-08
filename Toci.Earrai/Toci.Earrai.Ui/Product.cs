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

        public Product(int productId)
        {
            InitializeComponent();
            prodId = productId;
            product = Dm.GetProduct(prodId);

            AddElementsToLayout(ProductSizeConverter.Convert(product.Sizes), 10, 20);
            AddElementsToLayout(ProductOptionsConverter.Convert(product.Options), 10, ySlided + ySlide);

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


        }

        private void excelDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
           
        }

        private void ExcelDataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        protected virtual void AddElementsToLayout(List<ProductLayoutDto> elements, int xCoord, int yCoord)
        {
            int newY = yCoord;
            foreach (ProductLayoutDto item in elements)
            {
                Label l = new Label();
                l.Text = item.LabelItemName;
                l.Size = new Size(90, 20);
                l.Location = new Point(xCoord, newY);

                Label lR = new Label();
                lR.Text = item.LabelItemValue;
                lR.Size = new Size(90, 20);
                lR.Location = new Point(xCoord + xSlide, newY);

                newY += ySlide;
                Controls.Add(l);
                Controls.Add(lR);
            }

            ySlided = newY;
        }
    }
}
