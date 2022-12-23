using Microsoft.AspNetCore.Mvc;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Models.diger;
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
    [TypeFilter(typeof(LogFilter<UserController>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResult<IEnumerable<UserQuery>>))]
    public IActionResult List()
    {
        return Ok(_userService.ListAll());
    }

	[HttpPost, Route(ControllerConstants.Route.Create)]
	[TypeFilter(typeof(LogFilter<UserController>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResult<string>))]
        
    public IActionResult Create([FromBody] UserCreate model)
    {
     
        var result = _userService.Create(model);
     
        if (result.Success)
        {
            return Ok(result);
            
        }
        return BadRequest(result);
    
    }

    [HttpDelete, Route(ControllerConstants.Route.Remove)]
    [TypeFilter(typeof(LogFilter<UserController>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResult<string>))]
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
    [TypeFilter(typeof(LogFilter<UserController>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDataResult<UserQuery>))]
    public IActionResult Update([FromQuery(Name = ControllerConstants.Params.Id)] int id, [FromBody] UserUpdate model)
    {
        var result = _userService.Update(id,model);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}
