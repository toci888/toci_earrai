using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Models;

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
            "Category",
            "Length"
        };

        Dictionary<int, List<int>> WorksheetSearchMap = new Dictionary<int, List<int>>()
        {
            { WorksheetsIds.PLTandSHEET, new List<int>() { 2, 11 } },
            { WorksheetsIds.Alum, new List<int>() { 2, 11 } },
            { WorksheetsIds.MshandExpMetal, new List<int>() { 3, 12, 11 } },
            { WorksheetsIds.ChanandBms, new List<int>() { 11 } },
            { WorksheetsIds.AnglesplusT, new List<int>() { 0, 1, 11 } },
            { WorksheetsIds.Tube_CHS, new List<int>() { 2, 11 } },
            { WorksheetsIds.FLTS, new List<int>() { 2, 3, 11 } },
            { WorksheetsIds.Rnds_Sqrs_HolBar, new List<int>() { 4, 11 } },
            { WorksheetsIds.RHS, new List<int>() { 2, 11 } },
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
