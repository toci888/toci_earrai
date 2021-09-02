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

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityOperationsController : ApiControllerBase<IEntityOperations, Worksheetcontent>
    {
        public EntityOperationsController(IEntityOperations logic) : base(logic)
        {
            
        }

        [HttpGet]
        [Route("LoadData")]
        public Dictionary<string, object> LoadData()
        {
            return Logic.LoadData();
        }

        [HttpPost]
        [Route("SetCell")]
        public ActionResult<Worksheetcontentshistory> InsertToHistory(int idWorksheet, int columnNumber, int rowNumber, string value)
        {
            var historyContent = Logic.InsertToHistory(idWorksheet, columnNumber, rowNumber, value);
            return Ok(historyContent);
        }

        [HttpGet]
        [Route("GetIncrease")]
        public IEnumerable<Worksheetcontent> GetIncreaseWorksheetcontents(DateTime dateTime)
        {
            return Logic.GetIncreaseOffline(dateTime);
        }
    }
}
