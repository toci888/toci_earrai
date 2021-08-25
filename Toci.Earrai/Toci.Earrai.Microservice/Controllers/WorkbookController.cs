using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Toci.Common.Database.Interfaces;
using Toci.Common.Microservices;
using Toci.Common.Microservices.Interfaces;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using IWorksheetLogic = Toci.Earrai.Bll.Interfaces.IWorksheetLogic;

namespace Toci.Earrai.Microservice.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WorkbookController : ApiControllerBase<IWorksheetLogic, Worksheet>
    {
        public WorkbookController(IWorksheetLogic logic) : base(logic) { }

        [HttpGet("GetAllWorksheets/{workbookId}")]
        public ActionResult<IEnumerable<List<Worksheet>>> GetAllWorksheets(string workbookId)
        {

            var allWorksheets = Logic.GetAllWorksheets(workbookId);

            return Ok(allWorksheets);
        }


        [HttpGet("GetAllWorkbooks")]
        public ActionResult<IEnumerable<List<Worksheet>>> GetAllWorkbooks() 
        {

            var allWorkbooks = Logic.GetAllWorkbooks();

            return Ok(allWorkbooks);
        }




    }
}
