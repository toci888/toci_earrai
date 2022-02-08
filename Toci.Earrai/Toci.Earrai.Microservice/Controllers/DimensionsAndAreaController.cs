using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsAndAreaController : ApiControllerBase<IAreasLogic, Area>
    {
        public DimensionsAndAreaController(IAreasLogic logic): base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllAreasFromDb")]
        public ActionResult<List<Area>> GetAllAreasFromDb()
        {
            return Ok(Logic.GetAllAreasFromDb());
        }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllCodesDimensionsFromDb")]
        public ActionResult<List<Codesdimension>> GetAllCodesDimensionsFromDb()
        {
            return Ok(Logic.GetAllCodesDimensionsFromDb());
        }
    }
}
