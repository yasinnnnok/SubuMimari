using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using SUBU.API.Helpers;
using SUBU.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SUBU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
     {


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
                var modell = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginModel>(data);

                return Ok();
            }
            return Ok();






        }



    }
}
