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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_userService.ListAll());
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

        
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdate model)
        {
            var user = _userService.Update(id,model);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

    }
}
