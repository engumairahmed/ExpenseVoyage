using Microsoft.AspNetCore.Mvc;

namespace ExpenseVoyage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
