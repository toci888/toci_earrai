using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class WorksheetContentController : ApiControllerBase<IWorksheetcontentLogic, Worksheetcontent> {
        public WorksheetContentController(IWorksheetcontentLogic logic) : base(logic) { }


        [HttpGet("searchWorksheet/{worksheetId}/{phrase}/{skipCounter}")]
        public List<List<Worksheetcontent>> searchWorksheet(int worksheetId, string phrase, int skipCounter) {

            var workbooks = Logic.SearchWorksheet(worksheetId, phrase, skipCounter);

            return workbooks;
        }


        [HttpGet("GetColumnsForWorksheet/{worksheetId}")]
        public ActionResult<List<List<Worksheetcontent>>> GetColumnsForWorksheet(int worksheetId) {

            var workbooks = Logic.GetColumnsForWorksheet(worksheetId);

            return Ok(workbooks);
        }

        [HttpPost("flushCache")]
        public ActionResult<List<List<Worksheetcontent>>> flushCache(List<Worksheetcontent> worksheetcontentCollection)
        {
            Logic<Worksheetcontentshistory> worksheetContentHistory = new Logic<Worksheetcontentshistory>();

            foreach (var element in worksheetcontentCollection)
            {
                worksheetContentHistory.Insert(new Worksheetcontentshistory()
                {
                    Idworksheet = element.Idworksheet,
                    Columnindex = element.Columnindex,
                    Rowindex = element.Rowindex,
                    Value = element.Value,
                    Createdat = DateTime.Now
                }); 

                Update(element);
            }

            return Ok("OK");
        }

        [HttpPost("GetIncreaseWorksheetcontents")]
        public ActionResult<List<List<Worksheetcontent>>> GetIncreaseWorksheetcontents(MyDatetimeDto date) 
        {
            var dateTime = DateTime.Parse(date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second);

            var newestWorksheets = Logic.Select(x => 
                x.Updatedat > dateTime && 
                x.Idworksheet == date.worksheetId)
                .ToList();

            return Ok(newestWorksheets);
        }
    }
}
