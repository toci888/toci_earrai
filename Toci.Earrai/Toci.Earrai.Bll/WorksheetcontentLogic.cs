using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll {
    public class WorksheetcontentLogic : Logic<Worksheetcontent>, IWorksheetcontentLogic {

        public List<List<Worksheetcontent>> SearchWorksheet(int worksheetId, string phrase) {

            Logic<Worksheetcontent> worksheetLogic = new Logic<Worksheetcontent>();

            List<Worksheetcontent> worksheetContentRows = worksheetLogic.Select(m => 
                m.Idworksheet == worksheetId && m.Value.Contains(phrase) && m.Rowindex > 1)
                .ToList();

            List<int> rows = new List<int>();



            foreach (var worksheetContent in worksheetContentRows)
            {
                if (!rows.Contains(worksheetContent.Rowindex.Value))
                {
                    rows.Add(worksheetContent.Rowindex.Value);
                }
            }

            List<List<Worksheetcontent>> returnRows = new List<List<Worksheetcontent>>();

            int counter = 0;
            foreach (var row in rows)
            {
                var tempRow =  worksheetLogic.Select(m => m.Rowindex == row && m.Idworksheet == worksheetId).ToList();

                foreach (var tempRow_ in tempRow)
                {
                    tempRow_.Value.Replace("[", "")
                                    .Replace("]", "")
                                    .Replace("\\\"", "");
                }
                
                returnRows.Add(tempRow);
                if (counter++ > 3) break;

            }
            
            return returnRows;
        }



        public List<List<Worksheetcontent>> GetColumnsForWorksheet(int worksheetId) {

            Logic<Worksheetcontent> worksheetLogic = new Logic<Worksheetcontent>();

            List<Worksheetcontent> worksheetContentRows = worksheetLogic.Select(m =>
                    m.Idworksheet == worksheetId && (m.Rowindex == 0 || m.Rowindex == 1))
                    .ToList();

            List<List<Worksheetcontent>> returnColumns = new List<List<Worksheetcontent>>();

            int half = worksheetContentRows.Count / 2;

            returnColumns.Add(worksheetContentRows.Take(half).ToList());
            returnColumns.Add(worksheetContentRows.Skip(half).ToList());




            return returnColumns;
        }

    }
}
