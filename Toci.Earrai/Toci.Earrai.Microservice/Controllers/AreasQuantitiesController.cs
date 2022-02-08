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
    public class AreasQuantitiesController : ApiControllerBase<IAreasquantitiesLogic, Areasquantity>
    {
        public AreasQuantitiesController(IAreasquantitiesLogic logic) : base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllAreasQuantitiesFromDb")]
        public ActionResult<List<Areasquantity>> GetAllAreasQuantitiesFromDb()
        {
            return Ok(Logic.GetAllAreasQuantitiesFromDb());
        }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAreasQuantitiesByProduct/{productId}")]
        public ActionResult<List<Areasquantity>> GetAreasQuantitiesByProduct(int productId)
        {
            return Ok(Logic.GetAreasQuantitiesByRowIndexAndWorksheet(productId));
        }

    }
}