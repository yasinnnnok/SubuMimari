using Microsoft.AspNetCore.Mvc;

using RestSharp;
using SUBU.Models;
using System.Collections;
using System.Reflection;
using WebApplication1.UISample.Services;
using Newtonsoft.Json;
using Nancy.Json;
using System.Text.Json;
using System;

namespace WebApplication1.UISample.Controllers;

public class UserController : Controller
{
	private readonly IApiService _apiService;
	private readonly IUserUIService _userService;

	public UserController(IApiService apiService, IUserUIService userService)
	{
		_apiService = apiService;
		_userService = userService;
	}


	//Client işlemi apiService'te yapılıyor. API adresi appsettings'te
	public IActionResult Index()
	{
		var result = _userService.List();
		return View(result.Data);

	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}


	[HttpPost]
	public IActionResult Create(UserCreate model)
	{
		//ModelState.AddModelError(string.Empty, "Bu kullanıcı sistemde var.");
		//ModelState.AddModelError(nameof(model.UserName),"Usernameeee");


		if (ModelState.IsValid)
		{

			var result = _userService.Create(model);
			if (result.Success)
			{
				TempData["Success"] = result.Message;
				return RedirectToAction(nameof(Index));
			}

			TempData["Error"] = result.Message;
			return RedirectToAction("Create", "User");
		}
		TempData["Error"] = "Bir değer giriniz";
		return View(model);
	}


	[HttpGet]
	public IActionResult Update([FromRoute] int id)
	{
		RestRequest request = new RestRequest($"/User/FindById?id={id}", Method.Get);
		var response = _apiService.Client.Execute(request);
		//1.YÖNTEM
		var userResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["data"].ToString();
		var serializer = new JavaScriptSerializer();
		var user = serializer.Deserialize<UserUpdate>(userResponse);
		return View(user);

		//2.YÖNTEM
		//var user2 = JsonConvert.DeserializeObject<ApiResponse<UserUpdate>>(response.Content);
		//return View(user2.data);
	}


	[HttpPost]
	public IActionResult Update(int id, UserUpdate model)
	{
		var result = _userService.Update(id,model);
		if (result.Success)
		{
			TempData["Success"] = result.Message;
			return RedirectToAction("Index", "User");
		}
		TempData["Error"] = result.Message;
		return RedirectToAction("Update", "User",model);

	}





	public IActionResult Delete(int id)
	{
		var result = _userService.Delete(id);
		if (result.Success)
		{
			TempData["Success"] = result.Message;
			return RedirectToAction("Index", "User");
		}
		TempData["Error"] = result.Message;
		return RedirectToAction("Update", "User");

	}

	public IActionResult IlkYontem()
	{
		RestClient client = new RestClient("http://localhost:5097"); //api adresini tanımlayalım.			
		RestRequest request = new RestRequest("/User/List", Method.Get); //endpointimizi yazalım.(swagger a bak. controller/action)																			 
		var model = client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);//get put hepsi var. Get<t> - generic hali- bana ne dönecek!!!
		return View(model.Data);
	}

}
