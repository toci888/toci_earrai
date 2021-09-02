using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Toci.Common.Microservices;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;

namespace Toci.Earrai.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase<IUserLogic, Userrole>
    {
        public AccountController(IUserLogic logic) : base(logic)
        {
        }

        [HttpPost("register")]
        public int RegisterUser([FromBody] User user)
        {
            user.Initials = "" + user.Firstname[0] + user.Lastname[0];
            return Logic.CreateAccount(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login([FromBody]LoginDto user)
        {
            Userrole loggedUser = Logic.GenerateJwt(user);
            return Ok(loggedUser);
        }
    }
}
