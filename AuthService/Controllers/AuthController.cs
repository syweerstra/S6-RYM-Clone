using AuthService.Business;
using AuthService.DTOs;
using AuthService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(new IdentityUser() { UserName = dto.Username }, dto.Password);

                if (result.Succeeded)
                    return Ok(); //Should be created?
                else
                    return BadRequest(result.Errors);
            }
            else return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await signInManager.PasswordSignInAsync(dto.Username, dto.Password, true, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(dto.Username);
                var token = TokenGenerator.CreateToken(user);

                return Ok(new { token, user.Id });
            }
            else return BadRequest("Incorrect login info");
        }
    }
}