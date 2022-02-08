using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorksheetController : ApiControllerBase<IWorksheetLogic, Worksheet> {

        public WorksheetController(IWorksheetLogic logic) : base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllWorksheetsFromDb")]
        public ActionResult<List<Worksheet>> GetAllWorksheetsFromDb() 
        {
            return Ok(Logic.GetAllWorksheetsFromDb());
        }
    }
}
