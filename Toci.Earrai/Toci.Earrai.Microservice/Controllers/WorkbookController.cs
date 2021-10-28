using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

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

        /*[HttpGet("GetAllWorkbooksFromDb")]
        public ActionResult<List<Workbook>> GetAllWorkbooksFromDb()
        {

            List<Workbook> workbooks = Logic.GetAllWorkbooksFromDb();

            return Ok(workbooks);
        }

        [HttpGet("GetAllWorksheetsFromDb/{workbookId}")]
        public ActionResult<List<Workbook>> GetAllWorksheetsFromDb(string workbookId)
        {

            var workbooks = Logic.GetAllWorksheetsFromDb(workbookId);

            return Ok(workbooks);
        }*/

    }
}
