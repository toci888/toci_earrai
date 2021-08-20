using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Ui
{
    public class ExcelProxy
    {
        public List<string> GetSuggestions()
        {
            /// query to excel workbook column
            /// 
            return MockSuggestions();
        }

        private List<string> MockSuggestions()
        {
            return new List<string>() 
            {
                "abcdef",
                "bcdef",
                "tomek",
                "kacper",
                "bartek"
            };
        }
    }
}
