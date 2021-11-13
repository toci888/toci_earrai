using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Models
{
    public class ProductSearchRequestDto
    {
        public int WorksheetId { get; set; }
        public int Skip { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
