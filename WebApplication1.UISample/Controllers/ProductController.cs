using Microsoft.AspNetCore.Mvc;
using SUBU.Models;
using System.Diagnostics;
using System.Reflection;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers;

public class ProductController : Controller
{
	private readonly IApiService _apiService;

	public ProductController(IApiService apiService)
	{
		_apiService = apiService;
	}

	public async Task<IActionResult> Index()
	{
		var model = await _apiService.SubuApi.GetProducts();
		return View(model.Data);
	}

	[HttpGet]
	public IActionResult Save()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Save(ProductCreate productModel)
	{
		if (ModelState.IsValid)
		{
			var result = await _apiService.SubuApi.SaveProduct(productModel);
			if (result.Success)
			{
				ViewData["Success"] = result.Message;
				return RedirectToAction(nameof(Index));
			}
		}
		ViewData["Error"] = "Alanları kontrol ediniz!";
		return View(productModel);
	}

	[HttpGet]
	public async Task<IActionResult> Edit([FromRoute] int id)
	{
		var result = await _apiService.SubuApi.GetProductById(id);
		return View(result.Data);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(ProductQuery productQuery)
	{
		ProductUpdate productUpdate = new ProductUpdate() { Name = productQuery.Name, SerialNumber = productQuery.SerialNumber };
		var result = await _apiService.SubuApi.UpdateProduct(productQuery.Id, productUpdate);
		if (result.Success)
		{
			TempData["Success"] = result.Message;
			return View();
		}
		TempData["Error"] = result.Message;
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await _apiService.SubuApi.DeleteProduct(id);
		if (result.Success)
		{
			TempData["Success"] = result.Message;
			return RedirectToAction("Index", "Product");
		}
		TempData["Error"] = result.Message;
		return RedirectToAction("Index", "Product");
	}
}
