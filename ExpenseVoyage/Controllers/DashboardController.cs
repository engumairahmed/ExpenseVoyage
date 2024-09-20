using Microsoft.AspNetCore.Mvc;

namespace ExpenseVoyage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
	     public IActionResult Table()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

	}
}
