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
        protected Userrole LoggedUser;

        TextBox productaccountreferenceValue;
        TextBox descriptionValue;
        List<InputTextBox> inputTbs = new List<InputTextBox>();

        protected virtual void ProductAddConfirm(object sender, EventArgs e)
        {
            NewProductDto newProdDto = new NewProductDto();

            newProdDto.Reference = productaccountreferenceValue.Text;
            newProdDto.Description = descriptionValue.Text;
            newProdDto.WorksheetId = int.Parse(worksheetId);
            newProdDto.Options = new List<SoDto>();
            newProdDto.Sizes = new List<SoDto>();

            foreach (InputTextBox iTb in inputTbs)
            {
                if (!string.IsNullOrEmpty(iTb.Text))
                {
                    if (iTb.EntryKind == (int)SizesOptionsEnum.Sizes)
                    {
                        newProdDto.Sizes.Add(new SoDto() { SoId = iTb.EntryId, Value = iTb.Text });
                    }

                    if (iTb.EntryKind == (int)SizesOptionsEnum.Options)
                    {
                        newProdDto.Options.Add(new SoDto() { SoId = iTb.EntryId, Value = iTb.Text });
                    }
                }
            }

            int newProdId = Dm.AddProduct(newProdDto);

            if (newProdId > 0)
            {
                Product prodEditWindow = new Product(newProdId, areas, vendors, LoggedUser, quotesandmetrics);
                prodEditWindow.Show();
                this.Dispose();
            }
        }

        public ProductAdd(string worksId, Userrole loggedUser, List<Area> _areas, List<Vendor> _vendors, List<Quoteandmetric> _quotesandmetrics)
        {
            InitializeComponent();
            worksheetId = worksId;

            LoggedUser = loggedUser;

            areas = _areas;
            vendors = _vendors;
            quotesandmetrics = _quotesandmetrics;

            OsaDto = Dm.GetAvailableOptionsSizes(worksheetId);

            AddBasicProductInfo();
            AddElementsToLayout(ProductSwConverter.Convert(OsaDto.Sizeworksheetelements, (swe) => { return new ProductLayoutDto() { Kind = (int)SizesOptionsEnum.Sizes, LabelItemId = swe.Idsizes.Value, LabelItemName = swe.Name }; }), xLeft, 90, "Product sizing information.");
            AddElementsToLayout(ProductOwConverter.Convert(OsaDto.Optionworksheetelements, (owe) => { return new ProductLayoutDto() { Kind = (int)SizesOptionsEnum.Options, LabelItemId = owe.Idproductoptions.Value, LabelItemName = owe.Name }; }), xLeft, ySlided + ySlide+10, "Product options.");

            Button submit = ControlMan.CreateButton("Add new product", 90, 40, xLeft+50, ySlided+20, ProductAddConfirm);

            Controls.Add(submit);
        }

        protected virtual void AddBasicProductInfo()
        {
            int y = 10;
            
            Label productaccountreference = ControlMan.CreateLabel("Product Account Reference: ", 90, 20, xLeft, y);
            productaccountreferenceValue = ControlMan.CreateTextBox("", 90, 20, xLeft + ControlMan.GetSize("Product Account Reference: "), y);

            y += ySlide;

            Label description = ControlMan.CreateLabel("Description: ", 90, 20, xLeft, y);
            descriptionValue = ControlMan.CreateTextBox("", 90, 20, xLeft + xSlide, y);

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
                inputTbs.Add(inTb);
                //todo add textboxes on list on purpose of submit action
                newY += ySlide;

                Controls.Add(l);
                Controls.Add(inTb);
            }

            ySlided = newY;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}