using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WorksheetContentController : ApiControllerBase<IWorksheetcontentLogic, Worksheetcontent> {
        public WorksheetContentController(IWorksheetcontentLogic logic) : base(logic) { }


        [HttpGet("searchWorksheet/{worksheetId}/{phrase}")]
        public ActionResult<List<List<Worksheetcontent>>> searchWorksheet(int worksheetId, string phrase) {

            var workbooks = Logic.SearchWorksheet(worksheetId, phrase);

            return Ok(workbooks);
        }


        [HttpGet("GetColumnsForWorksheet/{worksheetId}")]
        public ActionResult<List<List<Worksheetcontent>>> GetColumnsForWorksheet(int worksheetId) {

            var workbooks = Logic.GetColumnsForWorksheet(worksheetId);

            return Ok(workbooks);
        }

        [HttpPost("flushCache")]
        public ActionResult<List<List<Worksheetcontent>>> flushCache(List<Worksheetcontent> worksheetcontentCollection ) {

            // wstawiasz do worksheetcontentHistory z datą aktualną

            // updateujesz worksheetcontent



            //var workbooks = Logic.GetColumnsForWorksheet(worksheetId);

            return Ok("OK");
        }

        [HttpPost("GetIncreaseWorksheetcontents")]
        public ActionResult<List<List<Worksheetcontent>>> GetIncreaseWorksheetcontents(object dateTime) {
            // rekordy z worksheetcontentHistory po tym czasie

            //var workbooks = Logic.GetColumnsForWorksheet(worksheetId);

            return Ok("OK");
        }
    }
}
