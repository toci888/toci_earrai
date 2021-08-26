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

        public List<Worksheetcontent> SearchWorksheet(int worksheetId, string phrase) {

            Logic<Worksheetcontent> worksheetlocic = new Logic<Worksheetcontent>();

            List<Worksheetcontent> worksheetContentRows = worksheetlocic.Select(m => 
                m.Idworksheet == worksheetId && m.Value.Contains(phrase))
                .ToList();

            return worksheetContentRows;
        }

    }
}
