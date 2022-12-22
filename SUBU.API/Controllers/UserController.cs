using Microsoft.AspNetCore.Mvc;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Services.Contans;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers;

//[Authorize]
[ApiController, Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet, Route(ControllerConstants.Route.List)]
    public IActionResult List()
    {
        return Ok(_userService.ListAll());
    }

	[HttpPost, Route(ControllerConstants.Route.Create)]
	[TypeFilter(typeof(LogFilter<UserController>))]
    public IActionResult Create([FromBody] UserCreate model)
    {
        var user = _userService.Create(model);
        
        if (user.Success)
        {
            return Ok(user);
            
        }
        return BadRequest(user.Message);
    }

    [HttpDelete, Route(ControllerConstants.Route.Remove)]
    public IActionResult Remove([FromQuery(Name = ControllerConstants.Params.Id)] int id)
    {
        var result = _userService.Delete(id);
        if (result.Success)
        {
            return Ok(result);

        }
        return BadRequest(result);
    }

	[HttpPut, Route(ControllerConstants.Route.Update)]
	public IActionResult Update([FromQuery(Name = ControllerConstants.Params.Id)] int id, [FromBody] UserUpdate model)
    {
        var user = _userService.Update(id,model);
        if (user.Success)
        {
            return Ok(user);
        }
        return BadRequest(user);
    }

}
