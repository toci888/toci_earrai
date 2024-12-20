﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Search;
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

        [HttpGet("GetProducts/{worksheetId}")]
        public ActionResult<List<ProductDto>> GetProductsByWorksheet(int worksheetId) {
            return Ok(Logic.GetProductsByWorksheet(worksheetId));
        }

        [HttpPost("GetProductsEx")]
        public ActionResult<List<ProductDto>> GetProductsByWorksheet(ProductSearchRequestDto dto)
        {
            SearchManager sm = new SearchManager();

            return Ok(sm.SearchEx(dto));
        }

        [HttpPost("GetProductsFiltersEx")]
        public ActionResult<List<string>> GetProductFiltersByWorksheet(ProductSearchRequestDto dto)
        {
            SearchConditionsProvider scp = new SearchConditionsProvider();

            return Ok(scp.GetFilters(dto.WorksheetId, dto.Name));   
        }

        [HttpPost("AddNewProduct")]
        public ActionResult<int> AddNewProduct(NewProductDto dto)
        {
            return Ok(Logic.AddNewProduct(dto));
        }
    }
}
