using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.Core.Extensions;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.Mongo.Managers;
using System.Security.Claims;

namespace SUBU.API.Controllers.diger;

[NonController, Authorize(Roles = "admin,manager"), ApiController, Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
        [NonAction]
	// [AllowAnonymous]
	[HttpGet, Route(ControllerConstants.Route.List)]
	public IActionResult Get()
    {
        //Claim claim = User.Claims.FirstOrDefault(x => x.Value == "username");
        //if (claim.Value == "codeove")
        //{
        //    IEnumerable<CategoryQuery> categories = 
        //        _categoryService.List<CategoryQuery>();

        //    return base.Ok(categories);
        //}

        IEnumerable<CategoryQuery> categories =
                _categoryService.List<CategoryQuery>();

        return base.Ok(categories);
    }

    [HttpDelete, Route(ControllerConstants.Route.Delete)]
    public IActionResult Delete([FromRoute] string id)
    {
        return Ok(_categoryService.Delete(id.ToObjectId()));
    }


    [HttpPost, Route(ControllerConstants.Route.Create)]
    public IActionResult Create([FromBody] CategoryCreate model)
    {
        return Ok(_categoryService.Create(
            new Category
            {
                Name = model.Name,
                Description = model.Description,
                ProductCount = model.ProductCount,
                //Description2 = model.Description2
            }));
    }
}