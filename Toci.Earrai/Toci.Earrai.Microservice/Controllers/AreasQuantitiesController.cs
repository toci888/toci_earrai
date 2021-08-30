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
    public class AreasQuantitiesController : ApiControllerBase<IAreasquantitiesLogic, Areasquantity>
    {
        public AreasQuantitiesController(IAreasquantitiesLogic logic) : base(logic) { }

        [HttpGet("GetAllAreasQuantitiesFromDb")]
        public ActionResult<List<Areasquantity>> GetAllAreasQuantitiesFromDb()
        {

            List<Areasquantity> areasQuantities = Logic.GetAllAreasQuantitiesFromDb();

            return Ok(areasQuantities);
        }

        [HttpGet("GetAreasQuantitiesByRowIndexAndWorksheet/{rowindex}/{worksheetId}")]
        public ActionResult<Areasquantity> GetAreasQuantitiesByRowIndexAndWorksheet(int rowindex, int worksheetId)
        {

            var result = Logic.GetAreasQuantitiesByRowIndexAndWorksheet(rowindex, worksheetId);

            return Ok(result);
        }

    }
}