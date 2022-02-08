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
    public class AreaQuantityController : ApiControllerBase<IAreaquantityLogic, Areaquantity>
    {
        public AreaQuantityController(IAreaquantityLogic logic) : base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetAllAreaQuantitiesFromDb")]
        public ActionResult<List<Areaquantity>> GetAllAreaQuantitiesFromDb()
        {
            return Ok(Logic.GetAllAreaQuantitiesFromDb());
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpPost("PostAreaQuantities")]
        public ActionResult<List<Areasquantity>> PostAreaQuantities(List<Areaquantity> areaQuantityCollection)
        {
            return Ok(Logic.PostAreaQuantities(areaQuantityCollection));
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpDelete("{Id}")]
        public ActionResult DeleteById(int Id)
        {
            return Ok(Logic.DeleteById(Id));
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpPut("UpdateAreaQuantity")]
        public ActionResult UpdateModel(Areaquantity areaquantity)
        {
            Logic.UpdateAreaQuantities(areaquantity);

            return Ok(areaquantity);
        }
    }
}
