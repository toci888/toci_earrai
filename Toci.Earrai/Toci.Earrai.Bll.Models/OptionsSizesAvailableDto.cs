using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Models
{
    public class OptionsSizesAvailableDto
    {
        public List<Sizeworksheetelement> Sizeworksheetelements { get; set; }

        public List<Optionworksheetelement> Optionworksheetelements { get; set; }
    }
}
