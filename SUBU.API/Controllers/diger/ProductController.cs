using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.NoContext;
//Log ve cache burada

namespace SUBU.API.Controllers.diger;

//loglama için
[Authorize, NonController, ApiController, Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [AllowAnonymous, HttpGet, Route(ControllerConstants.Route.GetByName)]
    [TypeFilter(typeof(LogFilter<ProductController>))]
    [TypeFilter(typeof(ExceptionFilter<ProductController>))]
    public IActionResult GetByName([FromRoute] string name)
    {
        //_logger.LogInformation("Product creating.. {Name} - {@Model}", model.Name, model);

        int s = 0;
        double a = 10 / s;

        //throw new Exception("asdsad");

        return Ok(true);
    }

    [HttpPost, Route(ControllerConstants.Route.Create)]
    [TypeFilter(typeof(LogFilter<ProductController>))]
    public IActionResult Create([FromBody] ProductCreate model)
    {
        //_logger.LogInformation("Product creating.. {Name} - {@Model}", model.Name, model);

        return Ok(_productService.Create(model));
    }
}
