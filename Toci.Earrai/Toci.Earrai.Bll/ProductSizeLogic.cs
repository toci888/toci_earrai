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
    public class ProductSizeLogic : Logic<Productsize>, IProductSizeLogic
    {
        protected Logic<Productssize> ProductssizeLogic = new Logic<Productssize>();
        protected Logic<Sizeworksheetelement> SizeWeLogic = new Logic<Sizeworksheetelement>();

        public List<Productssize> GetProductSizes(int productId)
        {
            return ProductssizeLogic.Select(m => m.Idproducts == productId).ToList();
        }

        public virtual List<Sizeworksheetelement> GetProductSizesAvailable(int worksheetId)
        {
            return SizeWeLogic.Select(m => m.Idworksheet == worksheetId).ToList();
        }

        public virtual bool SetNewProductSizes(int productId, List<SoDto> options)
        {
            foreach (SoDto option in options)
            {
                Insert(new Productsize() { Idsizes = option.SoId, Idproducts = productId, Value = option.Value });
            }

            return true;
        }
    }
}
