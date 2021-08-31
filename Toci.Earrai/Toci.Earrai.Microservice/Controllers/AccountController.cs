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
        public ActionResult Login([FromBody]LoginDto user)
        {
            string token = Logic.GenerateJwt(user);
            return Ok(token);
        }

        [HttpGet("all0")]
        [Authorize(Roles = "Admin, Pc, User, Office")]
        public ActionResult<IQueryable<User>> GetAll0()
        {
            var users = Logic.GetAll();

            return Ok(users);
        }

        [HttpGet("all1")]
        [Authorize(Roles = "User")]
        public ActionResult<IQueryable<User>> GetAll1()
        {
            var users = Logic.GetAll();

            return Ok(users);
        }

        [HttpGet("all2")]
        [Authorize(Roles = "Office")]
        public ActionResult<IQueryable<User>> GetAll2()
        {
            var users = Logic.GetAll();

            return Ok(users);
        }

        [HttpGet("all3")]
        [Authorize(Roles = "Pc")]
        public ActionResult<IQueryable<User>> GetAll3()
        {
            var users = Logic.GetAll();

            return Ok(users);
        }

        [HttpGet("all4")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<User>> GetAll4()
        {
            var users = Logic.GetAll();

            return Ok(users);
        }
    }
}
