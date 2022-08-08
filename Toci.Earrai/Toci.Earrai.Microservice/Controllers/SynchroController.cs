using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynchroController : ApiSimpleControllerBase<ISynchroLogic>
    {
        public SynchroController(ISynchroLogic logic) : base(logic)
        {

        }

        [HttpGet("GetProducts")]
        public List<ProductDto> GetProducts() // todo datetime
        {
            return Logic.Get();
        }

        [HttpPost("SetPRoducts")]
        public int SetProducts([FromBody] List<ProductDto> products)
        {
            return Logic.Save(products);
        }
    }
}
