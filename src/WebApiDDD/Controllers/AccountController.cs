﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrossCutting.Identity.Data;
using CrossCutting.Identity.Models;
using CrossCutting.Identity.Models.AccountDto;
using CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiDDD.Controllers;

namespace DDD.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : MainController //ControllerBase //: ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentitySqlDbContext _dbContext;
        private readonly IJwtFactory _jwtFactory;


        public AccountController(
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                IdentitySqlDbContext dbContext,
                                IJwtFactory jwtFactory
                                ) : base() //notifications, mediator

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("login")] 
        public async Task<ActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            var appUser = await _userManager.FindByEmailAsync(model.Email);

            if (signInResult.Succeeded) 
            {
                return CustomResponse(await GenerateToken(appUser));
            }

            if (signInResult.IsLockedOut) 
            {
                AdicionarErroProcessamento("Usuário temporariamente Bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var appUser = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var identityResult = await _userManager.CreateAsync(appUser, model.Password);

            if (identityResult.Succeeded) 
            {
                return CustomResponse(await GenerateToken(appUser));
            }
            foreach (var error in identityResult.Errors) 
            {
                AdicionarErroProcessamento(error.Description);
            }
            return CustomResponse();
        }


        // Gerar token para passar para login
        private async Task<TokenDto> GenerateToken(ApplicationUser appUser)
        {
            // Init ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, appUser.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, appUser.Id));

            // Get UserClaims
            var userClaims = await _userManager.GetClaimsAsync(appUser);
            claimsIdentity.AddClaims(userClaims);

            // Get UserRoles
            var userRoles = await _userManager.GetRolesAsync(appUser);
            claimsIdentity.AddClaims(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            // ClaimsIdentity.DefaultRoleClaimType & ClaimTypes.Role is the same

            // Get RoleClaims
            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                claimsIdentity.AddClaims(roleClaims);
            }

            // Generate access token
            var jwtToken = await _jwtFactory.GenerateJwtToken(claimsIdentity);


            /*  
            // Add refresh token  - verificar mais sobre essa atualização e implementar
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString("N"),
                UserId = appUser.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMinutes(90),
                JwtId = jwtToken.JwtId
            };
            await _dbContext.RefreshTokens.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();
            */


            return new TokenDto
            {
                AccessToken = jwtToken.AccessToken,
               // RefreshToken = refreshToken.Token, implementar futuramente
            };

        }




    }
}
