using ExpenseVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ExpenseVoyage.Areas.Identity.Pages.Account;
using ExpenseVoyage.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;

namespace ExpenseVoyage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger

            )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new AuthViewModel
            {
                Login = new LoginModel(),
                Register = new RegisterModel()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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
