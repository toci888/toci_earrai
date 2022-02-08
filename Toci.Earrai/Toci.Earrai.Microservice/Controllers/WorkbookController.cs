using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkbookController : ApiControllerBase<IWorksheetLogic, Worksheet>
    {
        public WorkbookController(IWorksheetLogic logic) : base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllWorksheets/{workbookId}")]
        public ActionResult<IEnumerable<List<Worksheet>>> GetAllWorksheets(string workbookId)
        {
            return Ok(Logic.GetAllWorksheets(workbookId));
        }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllWorkbooks")]
        public ActionResult<IEnumerable<List<Worksheet>>> GetAllWorkbooks() 
        {
            return Ok(Logic.GetAllWorksheetsFromDb());
        }

        //[HttpGet("GetAllWorkbooksFromDb")]
        //public ActionResult<List<Workbook>> GetAllWorkbooksFromDb()
        //{
        //    return Ok(Logic.GetAllWorkbooksFromDb());
        //}

        //[HttpGet("GetAllWorksheetsFromDb/{workbookId}")]
        //public ActionResult<List<Workbook>> GetAllWorksheetsFromDb(string workbookId)
        //{
        //    return Ok(Logic.GetAllWorksheetsFromDb(workbookId));
        //}

    }
}
