using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUBU.API.Controllers.diger;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Services.Contans;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_userService.ListAll().Data);
        }

  

        [HttpPost]
        [TypeFilter(typeof(LogFilter<UserController>))]
        public IActionResult Create([FromBody] UserCreate model)
        {
            var user = _userService.Create(model);
            
            if (user.Success==true)
            {
                return Ok(user);
                
            }
            return BadRequest(Usermessages.WrongUserAdd);
        }

    }
}
