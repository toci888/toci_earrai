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
        public double KgSheet { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Thickness { get; set; }

        public virtual void AssignValues(List<Productssize> productsizes)
        { }
    }
}
