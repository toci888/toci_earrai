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
    public class SageController : ApiControllerBase<ISageLogic, Product>
    {
        public SageController(ISageLogic logic) : base(logic)
        {
        }

        // get data to export by datetime = x vs price return List<ProductDto> => jest gotowa logika zasysania calego atomowego preoductdto

        // set data imported from sage => param list<ProductDto>. inserty product ? worksheet ? 
    }
}
