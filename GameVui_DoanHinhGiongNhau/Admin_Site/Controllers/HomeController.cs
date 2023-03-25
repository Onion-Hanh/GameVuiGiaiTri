using Admin_Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogInAction(IFormCollection form)
        {
            string userName = form["inputUserName"].ToString();
            string password = form["inputPassword"].ToString();
            if (userName == "Hanh" && password == "123")
            {
                ViewData["error"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
                return RedirectToAction("LogIn", "Home");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}