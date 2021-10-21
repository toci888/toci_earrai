using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models.Calculation;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.ProductParams
{
    public abstract class ProductParamsBase
    {
        protected Logic<Productsoptionsstate> ProductOptionsLogic = new Logic<Productsoptionsstate>();
        protected Logic<Productssize> ProductSizeLogic = new Logic<Productssize>();

        protected Dictionary<string, Func<Productsoptionsstate, CalculationsBaseDto, CalculationsBaseDto>> OptionsFillerMap = new Dictionary<string, Func<Productsoptionsstate, CalculationsBaseDto, CalculationsBaseDto>>()
        {
            { "KgM", (po, dto) => { dto.KgM = Convert.ToDouble(po.Value); return dto; } }
        };

        public virtual CalculationsBaseDto GetProductParams(int productId)
        {
            CalculationsBaseDto dto = new CalculationsBaseDto();

            List<Productsoptionsstate> options = GetProductOptions(productId);

            foreach (Productsoptionsstate item in options)
            {
                if (OptionsFillerMap.ContainsKey(item.Name))
                {
                    dto = OptionsFillerMap[item.Name].Invoke(item, dto);
                }
            }



            return dto;
        }

        protected List<Productsoptionsstate> GetProductOptions(int productId)
        {
            return ProductOptionsLogic.Select(m => m.Idproducts == productId).ToList();
        }

        protected List<Productssize> GetProductSize(int productId)
        {
            return ProductSizeLogic.Select(m => m.Idproducts == productId).ToList();
        }
    }
}
