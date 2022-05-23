using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Models.Erp;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SageController : ApiControllerBase<ISageLogic, Product>
    {
        public SageController(ISageLogic logic) : base(logic)
        {
        }

        // get data to export by datetime = x vs price return List<ProductDto> => jest gotowa logika zasysania calego atomowego preoductdto
        [HttpGet("ExportToSage")]
        public ActionResult<List<List<string>>> GetProductsToExportToSage()
        {
            return Ok(Logic.Export());
        }

        [HttpPost("InsertEiEntity")]
        public ActionResult<int> InsertEiEntity(List<EiEntity> entity)
        {
            return Ok(Logic.Import(entity));
        }

      

        // set data imported from sage => param list<ProductDto>. inserty product ? worksheet ? 
    }
}
