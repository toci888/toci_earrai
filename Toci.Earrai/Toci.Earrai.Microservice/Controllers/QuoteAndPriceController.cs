using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("GetAllQuotesAndPricesFromDb")]
        public ActionResult<List<Quoteandprice>> GetAllQuotesAndPricesFromDb()
        {
            return Ok(Logic.GetAllQuotesAndPrices());
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("GetAllQuotesAndMetrics")]
        public ActionResult<List<Quoteandmetric>> GetAllQuotesAndMetrics()
        {
            return Ok(Logic.GetAllQuotesAndMetrics());
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("GetAllVendorsFromDb")]
        public ActionResult<List<Vendor>> GetAllVendorsFromDb()
        {
            return Ok(Logic.GetAllVendors());
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpPost("PostQuoteandPrice")]
        public ActionResult<int> PostAreaQuantities(Quoteandprice quoteandprice)
        {
            return Ok(Logic.PostQuoteAndPrice(quoteandprice));
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpGet("QuoteAndPriceByProductId/{productId}")]
        public ActionResult<List<Quotesandprice>> GetQuoteAndPriceByProductId(int productId)
        {
            return Ok(Logic.GetAllQuotesAndPricesView(productId));
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpPut("UpdateQuoteAndPrice")]
        public ActionResult<Quoteandprice> UpdateQuoteAndPrice(Quoteandprice priceEntity)
        {
            Logic.UpdateQuoteAndPrice(priceEntity);

            return Ok(priceEntity);
        }

        [Authorize(Roles = PrivelegesRoles.Office)]
        [HttpDelete("DeleteQuoteAndPrice/{id}")]
        public ActionResult<int> DeleteQuoteAndPrice(int id)
        {
            return Logic.DeleteById(id);
        }
    }
}
