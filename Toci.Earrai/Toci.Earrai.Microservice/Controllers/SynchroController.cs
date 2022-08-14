﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("SetProducts")]
        public int SetProducts([FromBody] SynchroDto products)
        {
            return Logic.Save(products);
        }
    }
}