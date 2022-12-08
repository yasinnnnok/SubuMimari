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
        private readonly IMongoUserService _mongoUserService;

        public AccountController(IMongoUserService mongıUserService)
        {
            _mongoUserService = mongıUserService;
        }

  
        //   -- /Account/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model, [FromServices] ITokenHelper tokenHelper)
        {
            UserMongo user = _mongoUserService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest("Username or password is incorrect.");
            }
            else
            {
                string token = tokenHelper.GenerateToken(
                    user.Username,  new string[] { "admin", "manager" });

                return Ok(new { Token = token });
            }
        }
    }
}