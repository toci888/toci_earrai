using System;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations : IEntityOperations
    {
        public Worksheetcontentshistory InsertToHistory(int idWorksheet, int columnNumber, int rowNumber, string value)
        {
            Logic<Worksheetcontent> worksheetcontent = new Logic<Worksheetcontent>();
            Logic<Worksheetcontentshistory> worksheetHistory = new Logic<Worksheetcontentshistory>();

            Worksheetcontent oldCell = worksheetcontent.Select(m => m.Idworksheet == idWorksheet
                        && m.Columnnumber == columnNumber && m.Rownumber == rowNumber).FirstOrDefault();

            if (oldCell is null)
            {
                return null;
            }

            return worksheetHistory.Insert(new Worksheetcontentshistory()
            {
                Idworksheet = oldCell.Idworksheet,
                Columnnumber = oldCell.Columnnumber,
                Columnname = oldCell.Columnname,
                Rownumber = oldCell.Rownumber,
                Value = oldCell.Value,
                Createdat = oldCell.Createdat,
                Updatedat = DateTime.Now
            });
        }
    }
}
