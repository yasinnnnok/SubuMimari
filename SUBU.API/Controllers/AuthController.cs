using Microsoft.AspNetCore.Mvc;
using SUBU.API.Helpers;
using SUBU.Models;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers;

[ApiController, Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly ITokenHelper _tokenHelper;

    public AuthController(ITokenHelper tokenHelper, IAuthService authService)
    {
        _tokenHelper = tokenHelper;
        _authService = authService;
    }

    [HttpPost, Route(ControllerConstants.Route.Login)]
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
