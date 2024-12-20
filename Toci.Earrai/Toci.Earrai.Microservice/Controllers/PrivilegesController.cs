﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Common;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = nameof(PrivilegesEnum.Admin))]
        [HttpPost("Increase")]
        public User IncreasePrivileges(User user)
        {
            return Logic.IncreasePrivileges(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Decrease")]
        public User DecreasePrivileges(User user)
        {
            return Logic.DecreasePrivileges(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Change")]
        public User ChangePrivileges(User user, PrivilegesEnum privileges)
        {
            return Logic.ChangePrivileges(user, (int)privileges);
        }
    }
}
