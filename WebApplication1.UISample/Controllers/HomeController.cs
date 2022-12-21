using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using WebApplication1.UISample.Models;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers
{
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	}
}