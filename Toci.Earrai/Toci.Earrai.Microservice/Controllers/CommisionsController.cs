using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Commisions;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommisionsController : ControllerBase
    {
        protected CommisionsManager ComManager = new CommisionsManager();

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("GetCommisions")]
        public ActionResult<Dictionary<string, double>> GetCommisions(int productId, double price)
        {
            return Ok(ComManager.GetPricesForCommisions(price));
        }
    }
}
