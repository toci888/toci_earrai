﻿using System;
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
        public ActionResult<List<Workbook>> searchWorksheet(int worksheetId, string phrase) {

            var workbooks = Logic.SearchWorksheet(worksheetId, phrase);

            return Ok(workbooks);
        }

    }
}
