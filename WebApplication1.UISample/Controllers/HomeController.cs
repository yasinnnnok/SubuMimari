using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using WebApplication1.UISample.Models;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArtistUIService _artistUIService;

        public HomeController(IArtistUIService artistUIService)
        {
            _artistUIService = artistUIService;
        }

        public IActionResult Index()
        {
            return View(_artistUIService.List());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistCreate model)
        {
            //ModelState.AddModelError(string.Empty, "Bu kullanıcı sistemde var.");

            if (ModelState.IsValid)
            {
                _artistUIService.Create(model);

                ViewData["success"] = "Artist başarıyla oluşturuldu.";

                //return RedirectToAction(nameof(Index));
            }

            return View(model);
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