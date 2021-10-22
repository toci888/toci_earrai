using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Tests.Import
{
    public abstract class ImportBase
    {
        protected Logic<Product> ProductLogic = new Logic<Product>();
        // lodziki

        public virtual void ImportProduct() // row? 
        {
            // extract product basic data and insert row
        }

        protected abstract void ImportAreas(int productId);

        protected abstract void ImportSizes();

        protected abstract void ImportOptions();

        protected abstract void ImportPricing();
    }
}
