using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyDatabase.API.Requests;
using System.ComponentModel.DataAnnotations;

namespace SurveyDatabase.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Unauthorized();
        }
    }

}
