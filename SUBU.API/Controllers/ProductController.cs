using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUBU.API.Filters;
using SUBU.Models;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers
{
	[ApiController, Route("[controller]")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ILogger<ProductController> _logger;
		
		public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
			_productService = productService;
			_logger = logger;
		}

		[HttpGet, Route(ControllerConstants.Route.List)]
		[TypeFilter(typeof(LogFilter<ProductController>))]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResult<IEnumerable<ProductQuery>>))]
		public IActionResult List()
		{
			var result = _productService.ListAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost, Route(ControllerConstants.Route.Save)]
		[TypeFilter(typeof(LogFilter<ProductController>))]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResult<string>))]

		public IActionResult Create([FromBody] ProductCreate model)
		{
			var result = _productService.Create(model);

			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpDelete, Route(ControllerConstants.Route.Delete)]
		[TypeFilter(typeof(LogFilter<ProductController>))]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResult<string>))]
		public IActionResult Delete([FromQuery(Name = ControllerConstants.Params.Id)] int id)
		{
			var result = _productService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPut, Route(ControllerConstants.Route.Update)]
		[TypeFilter(typeof(LogFilter<ProductController>))]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResult<ProductUpdate>))]
		public IActionResult Update([FromBody] ProductUpdate model)
		{
			var result = _productService.Update(model);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet, Route(ControllerConstants.Route.FindById)]
		[TypeFilter(typeof(LogFilter<ProductController>))]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResult<ProductQuery>))]
		public IActionResult FindById([FromQuery(Name = ControllerConstants.Params.Id)] int id)
		{
			var result = _productService.FindById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
