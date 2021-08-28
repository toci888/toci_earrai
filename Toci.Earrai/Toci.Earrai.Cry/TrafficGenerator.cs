using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Cry
{
    public class TrafficGenerator
    {
        protected string letters = "abcdefghijklmnoprstuwxyz";

        protected string GetRandomString()
        {
            Random r = new Random();

            int length = r.Next();

            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                result += letters[r.Next(1, letters.Length - 1)];
            }

            return result;
        }
    }
}
