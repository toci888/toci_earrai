using System;
using System.Linq;
using System.Text.Json;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Bll.Warehouse
{
    public class EntityOperations
    {
        public void InsertHistory(int id, JsonElement json)
        {
            Logic<Worksheetcontent> worksheet = new Logic<Worksheetcontent>();
            Logic<Worksheetcontentshistory> worksheetHistory = new Logic<Worksheetcontentshistory>();

            var x = worksheet.Select(m => m.Id == id).FirstOrDefault();

            worksheetHistory.Insert(new Worksheetcontentshistory()
            {
                
            });

        }
    }
}
