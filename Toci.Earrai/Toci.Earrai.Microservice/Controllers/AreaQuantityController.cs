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

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaQuantityController : ApiControllerBase<IAreaquantityLogic, Areaquantity>
    {
        public AreaQuantityController(IAreaquantityLogic logic) : base(logic) { }

        [HttpGet("GetAllAreaQuantitiesFromDb")]
        public ActionResult<List<Areaquantity>> GetAllAreaQuantitiesFromDb()
        {

            List<Areaquantity> areaQuantities = Logic.GetAllAreaQuantitiesFromDb();

            return Ok(areaQuantities);
        }

        [HttpPost("PostAreaQuantities")]
        public ActionResult PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            Logic.PostAreaQuantities(areaQuantityCollection);

            return Ok("OK");
        }

        [HttpDelete("DeleteById")]
        public ActionResult DeleteById(int Id)
        {
            Logic.DeleteById(Id);

            return Ok("OK");
        }
    }



}
