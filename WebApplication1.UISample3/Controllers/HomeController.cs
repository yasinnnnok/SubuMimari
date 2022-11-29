using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SUBUAPI;
using System.Diagnostics;
using WebApplication1.UISample3.Models;

namespace WebApplication1.UISample3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string url = _configuration.GetValue<string>("ApiService:Endpoint");
            HttpClient httpClient = new HttpClient();
            SUBUAPIClient client = new SUBUAPIClient(url, httpClient);

            var response = client.ListAsync().Result;
            var data = response.Data;

            return View(data);
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