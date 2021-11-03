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

        [HttpGet("GetAllQuotesAndMetrics")]
        public ActionResult<List<Quoteandmetric>> GetAllQuotesAndMetrics()
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

        [HttpPost("PostQuoteandPrice")]
        public ActionResult<int> PostAreaQuantities(Quoteandprice quoteandprice)
        {
            int id = Logic.PostQuoteAndPrice(quoteandprice);

            return Ok(id);
        }

        [HttpGet("QuoteAndPriceByProductId/{productId}")]
        public ActionResult<List<Quotesandprice>> GetQuoteAndPriceByProductId(int productId)
        {
            return Ok(Logic.GetAllQuotesAndPricesView(productId));
        }

        [HttpPut("UpdateQuoteAndPrice")]
        public ActionResult<Quoteandprice> UpdateQuoteAndPrice(Quoteandprice priceEntity)
        {
            Logic.UpdateQuoteAndPrice(priceEntity);

            return Ok(priceEntity);
        }

        [HttpDelete("DeleteQuoteAndPrice/{id}")]
        public ActionResult<int> DeleteQuoteAndPrice(int id)
        {
            return Logic.DeleteById(id);
        }

    }
}
