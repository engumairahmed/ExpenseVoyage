using ExpenseVoyage.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseVoyage.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
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
        public IActionResult Trip_Create_Trip()
        {
            return View();
        }
        public IActionResult Trip_View_Trip()
        {
            return View();
        }
        public IActionResult Expense_Create()
        {
            return View();
        }
        public IActionResult Expense_View()
        {
            return View();
        }
        public IActionResult Budget_Management()
        {
            return View();
        }
        public IActionResult Upcoming_Trip()
        {
            return View();
        }
    }
}
