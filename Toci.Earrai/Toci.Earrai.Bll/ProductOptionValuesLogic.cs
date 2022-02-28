using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll
{
    public class ProductOptionValuesLogic : Logic<Productoptionvalue>, IProductOptionValuesLogic
    {
        protected Logic<Productsoptionsstate> ProductsoptionsstateLogic = new Logic<Productsoptionsstate>();
        protected Logic<Optionworksheetelement> OptionWeLogic = new Logic<Optionworksheetelement>();

        public List<Productsoptionsstate> GetProductValues(int productId)
        {
            return ProductsoptionsstateLogic.Select(m => m.Idproducts == productId).ToList();
        }

        public virtual List<Optionworksheetelement> GetProductOptionsAvailable(int worksheetId)
        {
            return OptionWeLogic.Select(m => m.Idworksheet == worksheetId).ToList();
        }

        public virtual bool SetNewProductOptions(int productId, List<SoDto> options)
        {
            foreach (SoDto option in options)
            {
                Insert(new Productoptionvalue() { Idproductoptions = option.SoId, Idproducts = productId, Value = option.Value });
            }

            return true;
        }
    }
}
