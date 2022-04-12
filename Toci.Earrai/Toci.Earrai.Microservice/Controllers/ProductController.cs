using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Bll.Search;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Bll;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase<IProductLogic, Product>
    {
        public ProductController(IProductLogic logic) : base(logic) { }

        [Authorize(Roles = PrivelegesRoles.User)]
        [HttpGet("GetProduct/{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            return Ok(Logic.GetProduct(productId));
        }

        //[Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("GetProducts/{worksheetId}")]
        public ActionResult<List<ProductDto>> GetProductsByWorksheet(int worksheetId, bool IsMobileRequest = true) {

            if (IsMobileRequest)
            {
                IProductLogic mobileLogic = new ProductMobileLogic();

                return mobileLogic.GetProductsByWorksheet(worksheetId);
            }

            return Ok(Logic.GetProductsByWorksheet(worksheetId));
        }

        //[Authorize(Roles = PrivilegesEnum.User)]
        [HttpPost("GetProductsEx")]
        public ActionResult<List<ProductDto>> GetProductsByWorksheet(ProductSearchRequestDto dto)
        {
            SearchManager sm = new SearchManager();

            return Ok(sm.SearchEx(dto));
        }

        //[Authorize(Roles = PrivilegesEnum.User)]
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
