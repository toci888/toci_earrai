﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase<IProductLogic, Product>
    {
        public ProductController(IProductLogic logic) : base(logic)
        {

        }

        [HttpGet("GetProduct/{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            return Ok(Logic.GetProduct(productId));
        }

        [HttpGet("GetProducts/{worksheetId}/{phrase}/{skip}")]
        public ActionResult<ProductDto> GetProductsByWorksheet(int worksheetId, string phrase, int skip) {
            return Ok(Logic.GetProductsByWorksheet(worksheetId, phrase, skip));
        }
    }
}
