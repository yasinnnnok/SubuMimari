using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUBU.Models;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : MyControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Success(_userService.ListAll());
        }

  

        [HttpPost]
        public IActionResult Create([FromBody] UserCreate model)
        {

            var user = _userService.Create(model);
            if (user==true)
            {
                return Success(user, "Kullanıcı oluşturuldu.");
            }
            return Error("Bu kullanıcı ve  yetkisi daha önce atanmıştır.");

        }

    }
}
