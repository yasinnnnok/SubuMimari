using Microsoft.AspNetCore.Mvc;
using SUBU.Models;
using WebApplication1.UISample.Services;

namespace WebApplication1.UISample.Controllers;

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
    public IActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = _loginService.login(model);
            
            if (result.Success)
            {
                ViewData["success"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            ViewData["success"] = result.Message;
            return RedirectToAction("login", "Auth");

        }
        return View();
    }

}
