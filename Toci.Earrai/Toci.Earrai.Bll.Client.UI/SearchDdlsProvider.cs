using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll.Client.UI
{
    public class SearchDdlsProvider
    {
        List<string> TypesOfSearch = new List<string>()
        {
            "DimA",
            "DimB",
            "Thickness",
            "Width",
            "OD",
            "DIA", // idx 5
            "Type",
            "Metric",
            "Id",
            "Product Code Short",
            "Description", // idx 10
        };

        Dictionary<int, List<int>> WorksheetSearchMap = new Dictionary<int, List<int>>()
        {
            { 1, new List<int>() { 2 } },
            { 2, new List<int>() { 2 } },
            { 3, new List<int>() { 0, 1 } },
            { 4, new List<int>() { 3 } },
            { 5, new List<int>() { 0, 1 } },
            { 6, new List<int>() { 6, 7 } },
            { 7, new List<int>() { 6, 9, 10 } },
            { 8, new List<int>() { 4 } },
            { 9, new List<int>() { 4, 9 } },
        };

        public virtual List<string> GetDdlItems(int worksheetId)
        {
            List<string> result = new List<string>();

            foreach (int item in WorksheetSearchMap[worksheetId])
            {
                result.Add(TypesOfSearch[item]);
            }

            return result;
        }
    }


}
