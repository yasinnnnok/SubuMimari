using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Services.NoContext;
//Log ve cache burada

namespace SUBU.API.Controllers.diger
{

    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
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

        [HttpPost]
        [TypeFilter(typeof(LogFilter<ProductController>))]
        public IActionResult Create([FromBody] ProductCreate model)
        {
            //_logger.LogInformation("Product creating.. {Name} - {@Model}", model.Name, model);

            return Ok(_productService.Create(model));
        }
    }
}
