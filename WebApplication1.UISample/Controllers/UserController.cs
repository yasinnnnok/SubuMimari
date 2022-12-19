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
		private readonly IUserUIService _userService;

		public UserController(IApiService apiService, IUserUIService userService)
		{
			_apiService = apiService;
			_userService= userService;
		}



		//Client işlemi apiService'te yapılıyor. API adresi appsettings'te
		public IActionResult Index()
		{
			RestRequest request = new RestRequest("/User/List", Method.Get);
			var model = _apiService.Client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);
			return View(model.data);
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
                _userService.Create(model);

                ViewData["success"] = "Kullanıcı başarıyla oluşturuldu.";

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
		 



        public IActionResult IlkYontem()
		{			
			RestClient client = new RestClient("http://localhost:5097"); //api adresini tanımlayalım.			
			RestRequest request = new RestRequest("/User/List", Method.Get); //endpointimizi yazalım.(swagger a bak. controller/action)																			 
			var model = client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);//get put hepsi var. Get<t> - generic hali- bana ne dönecek!!!
			return View(model.data);
		}

	}
}
