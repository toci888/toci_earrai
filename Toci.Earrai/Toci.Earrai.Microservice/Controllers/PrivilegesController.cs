using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Common.Microservices;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegesController : ApiControllerBase<IPrivilegesLogic, User>
    {
        public PrivilegesController(IPrivilegesLogic logic) : base(logic)
        {
        }

        [HttpPost("increase")]
        public User IncreasePrivileges(User user)
        {
            return Logic.IncreasePrivileges(user);
        }

        [HttpPost("decrease")]
        public User DecreasePrivileges(User user)
        {
            return Logic.DecreasePrivileges(user);
        }

        [HttpPost("change")]
        public User ChangePrivileges(User user, int privileges)
        {
            return Logic.ChangePrivileges(user, privileges);
        }
    }
}
