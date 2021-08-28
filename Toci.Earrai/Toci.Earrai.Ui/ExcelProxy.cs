using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            //HttpClient hc = new HttpClient();

            //hc.BaseAddress
            //var x = hc.GetAsync("api/worksheets/1234");


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
