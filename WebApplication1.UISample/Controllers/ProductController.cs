using Microsoft.AspNetCore.Mvc;
using Refit;
using SUBU.Models;
using System.Diagnostics;
using System.Net;
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
		try
		{
			var model = await Extensions.RefitResponseHandler(() => _apiService.SubuApi.GetProducts(), TempData);
			return View(model.Data);
		}
		catch (Exception)
		{
			return View();
		}
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
			try
			{
				var result = await Extensions.RefitResponseHandler(productModel, (x) => _apiService.SubuApi.SaveProduct(x), TempData);
				TempData["Success"] = result.Message;
				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{

			}
		}
		return View(productModel);
	}

	[HttpGet]
	public async Task<IActionResult> Edit([FromRoute] int id)
	{
		try
		{
			var result = await Extensions.RefitResponseHandler(id, (x) => _apiService.SubuApi.GetProductById(id), TempData);
			return View(result.Data);
		}
		catch (Exception) { }
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Edit(ProductQuery productQuery)
	{
		ProductUpdate productUpdate = new ProductUpdate() { Id = productQuery.Id, Name = productQuery.Name, SerialNumber = productQuery.SerialNumber };
		try
		{
			var result = await Extensions.RefitResponseHandler(productUpdate, (x) => _apiService.SubuApi.UpdateProduct(x), TempData);
			TempData["Success"] = result.Message;
			return View();
		}
		catch (Exception) { }
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			var result = await Extensions.RefitResponseHandler(id, (x) => _apiService.SubuApi.DeleteProduct(x), TempData);
			TempData["Success"] = result.Message;
			return RedirectToAction("Index", "Product");
		}
		catch (Exception) { }
		return RedirectToAction("Index", "Product");
	}
}
