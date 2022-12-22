using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using SUBU.API.Helpers;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Services.Contans;
using SUBU.Services.EntityFramework.Managers;
using System.Net.Http.Headers;

namespace SUBU.API.Controllers;


[Route("[controller]/[action]")]
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
    [HttpPost]
    public IActionResult Login([FromBody] LoginModel loginAuthDto)
    {
        var result = _authService.Login(loginAuthDto);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);

  
    
    }
    

  

}
