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
                m.Idworksheet == worksheetId && m.Value.Contains(phrase))
                .ToList();

            List<int> rows = new List<int>();



            foreach (var worksheetContent in worksheetContentRows)
            {
                if (!rows.Contains(worksheetContent.Columnnumber.Value))
                {
                    rows.Add(worksheetContent.Columnnumber.Value);
                }
            }

            List<List<Worksheetcontent>> returnRows = new List<List<Worksheetcontent>>(); 

            foreach (var row in rows)
            {
                var tempRow =  worksheetLogic.Select(m => m.Columnnumber == row && m.Idworksheet == worksheetId).ToList();

                foreach (var tempRow_ in tempRow)
                {
                    tempRow_.Value.Replace("[", "");
                    tempRow_.Value.Replace("]", "");
                                    tempRow_.Value.Replace("\\\"", "");
                }

                Console.WriteLine(tempRow);

                returnRows.Add(tempRow);

            }
            
            return returnRows;
        }

    }
}
