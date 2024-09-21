using ExpenseVoyage.Data;
using ExpenseVoyage.Data.Migrations;
using ExpenseVoyage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseVoyage.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public UserProfile GetUserId()
        {
            // Get the logged-in user's ID
            string userId = _userManager.GetUserId(User);
            var user =_context.UserProfiles.Where(x => x.IUserId == userId).FirstOrDefault();
            // Use the userId as needed
            return user;
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
        [HttpPost]
        public IActionResult Trip_Create_Trip(Trips t)
        {
            var user_id=GetUserId();
       _context.Trips.Add(t);
                t.user_id = user_id.Id;
                _context.SaveChanges();
            return RedirectToAction("Trip_Create_Trip");
        }
        public IActionResult Trip_View_Trip()
        {
            return View();
        }
        public IActionResult Expense_Create()
        {
            var user_id = GetUserId();
            var data=_context.Trips.Where(x => x.user_id == user_id.Id).ToList();
            TempData["trips"] = data;
            var category= _context.categories.ToList();
            TempData["category"] = category;
            return View();
        }
        [HttpPost]
        public IActionResult Expense_Create(Expenses e)
        {
            var check = _context.Trips.Where(x => x.id == e.trip_id).FirstOrDefault();
            if (e.Amount <= check.Budget)
            {
                if (check.end_Date >= DateTime.Now)
                {
                    var user_id = GetUserId();
                    _context.Expenses.Add(e);
                    e.expanse_Date = DateTime.Now;
                    e.user_id = user_id.Id;
                    check.Budget = (e.Amount - check.Budget);
                    _context.SaveChanges();
                }
                else
                {
                    SetCookie("error-msg", "Trip Date Expired");
                }
            }
            else
            {
                SetCookie("error-msg", "Invalid Budget");
            }
            return RedirectToAction("Expense_Create");
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
        private void SetCookie(string cookieName, string cookieValue)
        {
            Response.Cookies.Append(cookieName, cookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(1)
            });
        }

    }
}
