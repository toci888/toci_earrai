using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Calculations;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
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

            KgPerSqrtMeterDto kgPerSqrtMeterDto = new KgPerSqrtMeterDto();

            kgPerSqrtMeterDto.AssignValues(productsizes);

            KgPerSheetDto kgPerSheetDto = new KgPerSheetDto(kgPerSqrtMeterDto);

            kgPerSheetDto.AssignValues(productsizes);


            KgPerSheetCalculation kgPerSheetCalculation = new KgPerSheetCalculation();

            double result = kgPerSheetCalculation.Calculate(kgPerSheetDto);

            return Ok(result);

            //return Ok(productsizes);
        }

        [HttpGet("GetAvailableOptionsSizes/{worksheetId}")]
        public ActionResult<OptionsSizesAvailableDto> GetAvailableOptionsSizes(int worksheetId)
        {
            IProductOptionValuesLogic povLogic = new ProductOptionValuesLogic();

            OptionsSizesAvailableDto result = new OptionsSizesAvailableDto();

            result.Sizeworksheetelements = Logic.GetProductSizesAvailable(worksheetId);
            result.Optionworksheetelements = povLogic.GetProductOptionsAvailable(worksheetId);

            return Ok(result);
        }
    }
}
