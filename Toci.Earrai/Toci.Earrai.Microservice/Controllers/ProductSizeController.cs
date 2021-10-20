using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Calculations;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models.Calculation;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : ApiControllerBase<IProductSizeLogic, Productsize>
    {
        public ProductSizeController(IProductSizeLogic logic) : base(logic) { }


        [HttpGet("TestGetCalculations/{productId}")]
        public ActionResult<List<Productssize>> TestGetCalculations(int productId) {

            List<Productssize> productsizes = Logic.GetProductSizes(productId);

            KgPerSheetDto kgPerSheetDto = new KgPerSheetDto();

            kgPerSheetDto.AssignValues(productsizes);

            KgPerSheetCalculation kgPerSheetCalculation = new KgPerSheetCalculation();

            double result = kgPerSheetCalculation.Calculate(kgPerSheetDto);

            return Ok(result);

            //return Ok(productsizes);
        }





    }
}
