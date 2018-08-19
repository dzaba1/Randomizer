using Dzaba.Randomizer.Contracts;
using Dzaba.Randomizer.DataAccess.EntityFramework;
using Dzaba.Randomizer.Utils;
using Dzaba.Randomizer.WebApi.Core.ActionFilters;
using Dzaba.Randomizer.WebApi.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.WebApi.Core.Controllers
{
    [Route(Routes.AuthControllerRoute)]
    public class AuthController : Controller
    {
        private readonly IAuth auth;

        public AuthController(IAuth auth)
        {
            Require.NotNull(auth, nameof(auth));

            this.auth = auth;
        }

        [HttpPost("register")]
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

        [HttpPost("login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody][Required] LoginUser model)
        {
            try
            {
                var data = await auth.Login(model.Email, model.Password);
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
