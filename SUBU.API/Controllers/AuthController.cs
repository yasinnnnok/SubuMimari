using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using SUBU.API.Helpers;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Services.Contans;
using SUBU.Services.EntityFramework.Managers;
using System.Net.Http.Headers;

namespace SUBU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(ITokenHelper tokenHelper, IAuthService authService)
        {
            _tokenHelper = tokenHelper;
            _authService = authService;
        }

        //
        [HttpPost("LoginService")]
        public IActionResult LoginService([FromBody] LoginModel loginAuthDto)
        {
            var giris = _authService.Login(loginAuthDto);
            if (giris == "yetkisiz")
            {
                return BadRequest(AuthMessages.Unauthorized);
            }
            if (giris == "girishatalı")
            {
                return BadRequest(AuthMessages.WrongPassword);
            }

            return Ok(giris);
        }
        //

        //, [FromServices] ITokenHelper tokenHelper
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginAuthDto)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://apilogin.subu.edu.tr/");


            var response = client.GetAsync($"api/Login?username={loginAuthDto.Username}&password={loginAuthDto.Password}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                //k.adı ve şifre doğrumu ?
                var data = response.Content.ReadAsStringAsync().Result;
                //TODO : servis'e fi
                var user = _authService.Find(loginAuthDto.Username);
                if (user != null)
                {
                    string token = _tokenHelper.GenerateToken(loginAuthDto.Username, new string[] { user });

                    return Ok(new { Token = token });
                }
                //if (data!=null)
                //{
                //    string token = _tokenHelper.GenerateToken(loginAuthDto.Username, new string[] { "admin", "manager" });

                //    return Ok(new { Token = token });
                //}

                return BadRequest(AuthMessages.Unauthorized);
            }
            return BadRequest(AuthMessages.WrongPassword);

        }

      

    }
}
