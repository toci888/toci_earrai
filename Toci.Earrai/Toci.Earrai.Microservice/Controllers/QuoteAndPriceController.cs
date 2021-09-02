using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toci.Common.Microservices;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteAndPriceController : ApiControllerBase<IQuoteandpriceLogic, Quoteandprice>
    {
        public QuoteAndPriceController(IQuoteandpriceLogic logic) : base(logic) { }

        [HttpGet("GetAllQuotesAndPricesFromDb")]
        public ActionResult<List<Quoteandprice>> GetAllQuotesAndPricesFromDb()
        {

            List<Quoteandprice> quoteandprice = Logic.GetAllQuotesAndPrices();

            return Ok(quoteandprice);
        }

        [HttpGet("GetAllQuotesAndMetricsFromDb")]
        public ActionResult<List<Quoteandmetric>> GetAllQuotesAndMetricsFromDb()
        {

            List<Quoteandmetric> quoteandmetric = Logic.GetAllQuotesAndMetrics();

            return Ok(quoteandmetric);
        }

        [HttpGet("GetAllVendorsFromDb")]
        public ActionResult<List<Vendor>> GetAllVendorsFromDb()
        {

            List<Vendor> vendors = Logic.GetAllVendors();

            return Ok(vendors);
        }
    }
}
