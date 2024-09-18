using Microsoft.AspNetCore.Mvc;

namespace ExpenseVoyage.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
