using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Reflection;
using WebApplication1.UISample.Models;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers
{
	public class UserController : Controller
	{
		private readonly IApiService _apiService;

		public UserController(IApiService apiService)
		{
			_apiService = apiService;
		}



		//Client işlemi apiService'te yapılıyor. API adresi appsettings'te
		public IActionResult Index()
		{
			RestRequest request = new RestRequest("/User/List", Method.Get);
			var model = _apiService.Client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);
			return View(model.data);
		}


		


		public IActionResult İlkYontem()
		{			
			RestClient client = new RestClient("http://localhost:5097"); //api adresini tanımlayalım.			
			RestRequest request = new RestRequest("/User/List", Method.Get); //endpointimizi yazalım.(swagger a bak. controller/action)																			 
			var model = client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);//get put hepsi var. Get<t> - generic hali- bana ne dönecek!!!
			return View(model.data);
		}

	}
}
