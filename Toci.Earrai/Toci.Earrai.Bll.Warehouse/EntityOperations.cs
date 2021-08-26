using System;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations : Logic<Worksheetcontent>, IEntityOperations
    {
        public Worksheetcontentshistory InsertToHistory(int idWorksheet, int columnNumber, int rowNumber, string value)
        {
            Logic<Worksheetcontentshistory> worksheetHistory = new Logic<Worksheetcontentshistory>();

            Worksheetcontent oldCell = Select(m => m.Idworksheet == idWorksheet
                        && m.Columnindex == columnNumber && m.Rowindex == rowNumber).FirstOrDefault();

            if (oldCell is null)
            {
                return null;
            }

            Worksheetcontentshistory wch = worksheetHistory.Insert(new Worksheetcontentshistory()
            {
                Idworksheet = oldCell.Idworksheet,
                Columnnumber = oldCell.Columnindex,
                Rownumber = oldCell.Rowindex,
                Value = oldCell.Value,
                Createdat = oldCell.Createdat,
                Updatedat = DateTime.Now
            });

            oldCell.Value = value;

            Update(oldCell);

            return wch;
        }

        public virtual IQueryable<Worksheetcontent> GetIncreaseOffline(DateTime dateTime)
        {
            return Select(m => m.Updatedat > dateTime);
        }
    }
}
