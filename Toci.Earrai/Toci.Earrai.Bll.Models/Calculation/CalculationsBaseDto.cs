using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models.Calculation
{
    public class CalculationsBaseDto
    {
        // ~12 props
        public double KgM { get; set; }

        public virtual void AssignValues(List<Productssize> productsizes)
        { }
    }
}
