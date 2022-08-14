using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ApiControllerBase<ICategoryLogic, Category>
    {
        public CategoriesController(ICategoryLogic logic) : base(logic)
        {
        }

        [HttpGet("GetCategoriesForWorksheet")]
        public List<Category> GetCategoriesForWorksheet(int worksheetId)
        {
            return Logic.Select(m => m.Idworksheet == worksheetId).ToList();
        }
    }
}
