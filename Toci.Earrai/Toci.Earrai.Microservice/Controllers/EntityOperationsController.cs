using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Warehouse;
using Toci.Earrai.Bll.Warehouse.Interfaces;
using Toci.Earrai.Database.Persistence.Models;
using Worksheet = Toci.Earrai.Bll.Models.Worksheet;

namespace Toci.Earrai.Microservice.Controllers
{
    public class EntityOperationsController : ApiControllerBase<IEntityOperations, Worksheetcontent>
    {
        public EntityOperationsController(IEntityOperations logic) : base(logic)
        {
            
        }

        [HttpPost]
        public ActionResult<Worksheetcontentshistory> InsertToHistory(int idWorksheet, int columnNumber, int rowNumber, string value)
        {
            var historyContent = Logic.InsertToHistory(idWorksheet, columnNumber, rowNumber, value);
            return Ok(historyContent);
        }
    }
}
