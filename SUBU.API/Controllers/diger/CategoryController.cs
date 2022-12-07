using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.Core.Extensions;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Services.Mongo.Managers;
using System.Security.Claims;

namespace SUBU.API.Controllers.diger
{
    [Authorize(Roles = "admin,manager")]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[AllowAnonymous]
        [HttpGet]
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            return Ok(_categoryService.Delete(id.ToObjectId()));
        }


        [HttpPost]
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

    public class AddressCreate
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _AddressService;

        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_AddressService.List());
        }


        [HttpPost]
        public IActionResult Create([FromBody] AddressCreate model)
        {
            return Ok(_AddressService.Create(
                new Address
                {
                    Name = model.Name,
                    Location = model.Location
                }));
        }
    }
}