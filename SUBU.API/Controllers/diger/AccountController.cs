using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.API.Helpers;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Services.Mongo.Managers;

namespace SUBU.API.Controllers.diger
{
    //   -- /Account
    [NonController]
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

  
        //   -- /Account/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model, [FromServices] ITokenHelper tokenHelper)
        {
            User user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest("Username or password is incorrect.");
            }
            else
            {
                string token = tokenHelper.GenerateToken(
                    user.Username, user.Id.ToString(), new string[] { "admin", "manager" });

                return Ok(new { Token = token });
            }
        }
    }
}