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
            "Category"
        };

        Dictionary<int, List<int>> WorksheetSearchMap = new Dictionary<int, List<int>>()
        {
            { 1, new List<int>() { 2, 11 } },
            { 2, new List<int>() { 2, 11 } },
            { 3, new List<int>() { 0, 1, 11 } },
            { 4, new List<int>() { 3, 11 } },
            { 5, new List<int>() { 0, 1, 11 } },
            { 6, new List<int>() { 2, 3, 11 } },
            { 7, new List<int>() { 6, 9, 10, 11 } },
            { 8, new List<int>() { 4, 11 } },
            { 9, new List<int>() { 2, 11 } },
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
