using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionValuesController : ApiControllerBase<IProductOptionValuesLogic, Productoptionvalue>
    {
        public ProductOptionValuesController(IProductOptionValuesLogic logic) : base(logic)
        {

        }
    }
}
