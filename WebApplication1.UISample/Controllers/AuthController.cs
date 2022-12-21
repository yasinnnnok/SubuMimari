using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebApplication1.UISample.Models;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var result = _loginService.login(model);
                if (result!=null)
                {
                    ViewData["success"] = "kullanıcı başarıyla oluşturuldu.";
                    return RedirectToAction("Index", "User");
                }
                ViewData["success"] = "kullanıcı başarıyla oluşturuldu.";
                return RedirectToAction("login", "Auth");

            }
            return View();
        }

    }

}
