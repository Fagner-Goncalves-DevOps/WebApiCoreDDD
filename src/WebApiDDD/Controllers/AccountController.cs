using System.Threading.Tasks;
using CrossCutting.Identity.Data;
using CrossCutting.Identity.Models;
using CrossCutting.Identity.Models.AccountDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DDD.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase //: ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IdentitySqlDbContext _dbContext;

        public AccountController(
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,                               
                                    IdentitySqlDbContext dbContext
                                ) : base() //notifications, mediator
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("login")] 
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (!signInResult.Succeeded) 
            {
                return Ok();
            }
            return BadRequest();
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var appUser = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var identityResult = await _userManager.CreateAsync(appUser, model.Password);

            if (identityResult.Succeeded) 
            {
                await _signInManager.SignInAsync(appUser, false);
                return Ok();
            }
            return BadRequest();
        }

    }
}
