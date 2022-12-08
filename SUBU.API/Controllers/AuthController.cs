using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using SUBU.API.Helpers;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Services.EntityFramework.Managers;
using System.Net.Http.Headers;

namespace SUBU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginAuthDto, [FromServices] ITokenHelper tokenHelper)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://apilogin.subu.edu.tr/");

            //TODO : buraya yetkilimi eklenecek
            var response = client.GetAsync($"api/Login?username={loginAuthDto.Username}&password={loginAuthDto.Password}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                //k.adı ve şifre doğrumu ?
                var data = response.Content.ReadAsStringAsync().Result;
                //TODO : servis'e find metodu ekleyip kullanıcı ve rolü orada varmı diye bakacağız ona göre 

                if (data!=null)
                {
                    string token = tokenHelper.GenerateToken(loginAuthDto.Username, new string[] { "admin", "manager" });

                    return Ok(new { Token = token });
                }

                return BadRequest("Kullanıcı yetkisi bulunmamaktadır.");
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");

        }



    }
}
