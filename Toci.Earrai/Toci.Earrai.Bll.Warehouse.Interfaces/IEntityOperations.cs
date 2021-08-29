using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Common.Bll.Interfaces;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse.Interfaces
{
    public interface IEntityOperations : ILogicBase<Worksheetcontent>
    {
        Worksheetcontentshistory InsertToHistory(int idWorksheet, int columnNumber, int rowNumber, string value);

        IQueryable<Worksheetcontent> GetIncreaseOffline(DateTime dateTime);

        Dictionary<string, object> LoadData();
    }
}
