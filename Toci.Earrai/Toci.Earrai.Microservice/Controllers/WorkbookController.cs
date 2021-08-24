using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Database.Interfaces;
using Toci.Common.Microservices;
using Toci.Common.Microservices.Interfaces;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
//using Microsoft.Graph;
//using Toci.Microsoft.Graph.Excel;

namespace Toci.Earrai.Microservice.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WorkbookController : ApiControllerBase<IWorksheetLogic, Worksheet>
    {
        public WorkbookController(IWorksheetLogic logic) : base(logic) { }

        [HttpGet("GetAllWorksheets/{fileId}")]
        public ActionResult<IEnumerable<List<Worksheet>>> GetAllWorksheets(string fileId)
        {

            var allWorksheets = Logic.GetAllWorksheets(fileId);

            return Ok(allWorksheets);
        }


    }
}
