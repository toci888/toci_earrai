using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Models
{
    public class NewProductDto
    {
        public int WorksheetId { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public List<SoDto> Sizes { get; set; }
        public List<SoDto> Options { get; set; }
    }

    public class SoDto
    {
        public int SoId { get; set; }

        public string Value { get; set; }
    }
}
