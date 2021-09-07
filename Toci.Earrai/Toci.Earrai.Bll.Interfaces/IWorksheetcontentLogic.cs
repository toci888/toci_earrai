using System;
using System.Collections.Generic;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Interfaces {
    public interface IWorksheetcontentLogic : ILogicBase<Worksheetcontent>
    {

        List<List<Worksheetcontent>> SearchWorksheet(int workbookId, string phrase, int skipCounter);

        List<List<Worksheetcontent>> GetColumnsForWorksheet(int worksheetId);

    }
}
