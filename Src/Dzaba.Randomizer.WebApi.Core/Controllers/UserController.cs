﻿using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Core.ActionFilters;
using Dzaba.Randomizer.WebApi.Core.Services;
using Dzaba.Randomizer.WebApi.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.WebApi.Core.Controllers
{
    [Route(Routes.UsersControllerRoute)]
    public class AccountController : Controller
    {
        private readonly IUserDal userDal;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IAuth auth;

        public AccountController(IUserDal userDal,
            ITokenGenerator tokenGenerator,
            IAuth auth)
        {
            Require.NotNull(userDal, nameof(userDal));
            Require.NotNull(tokenGenerator, nameof(tokenGenerator));
            Require.NotNull(auth, nameof(auth));

            this.userDal = userDal;
            this.tokenGenerator = tokenGenerator;
            this.auth = auth;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody][Required] RegisterUser model)
        {
            try
            {
                var data = await auth.Register(model.Email, model.Password);
                return Ok(data);
            }
            catch (IdentityException ex)
            {
                ModelState.CopyErrorsFrom(ex.Errors);
                return BadRequest(ModelState);
            }
        }
    }
}
