using ExpenseVoyage.Data;
using ExpenseVoyage.Data.Migrations;
using ExpenseVoyage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseVoyage.Controllers
{
    [Authorize]
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
            t.Budget = t.Remaining_Budget;
                t.user_id = user_id.Id;
                _context.SaveChanges();
            return RedirectToAction("Trip_Create_Trip");
        }
        public IActionResult Trip_View_Trip()
        {
            var user_id = GetUserId();
            var data = _context.Trips.Where(x => x.user_id == user_id.Id);
            return View(data);
        }
        public IActionResult Delete_Trip(int id)
        {
            // Find all expenses related to the trip
            var expenses = _context.Expenses.Where(x => x.trip_id == id).ToList();

            // Remove each expense
            _context.Expenses.RemoveRange(expenses);

            // Find the trip
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound(); // Return 404 if the trip doesn't exist
            }

            // Remove the trip
            _context.Trips.Remove(trip);

            // Save changes to the database
            _context.SaveChanges();

            // Redirect to a list or confirmation page
            return RedirectToAction("Trip_View_Trip"); // Change "Index" to your desired action
        }
        public IActionResult Edit_Trip(int id)
        {
            var trip = _context.Trips.Find(id);
            return View(trip);
        }
        [HttpPost]
        public IActionResult Trip_Update_Trip(Trips updatedTrip)
        {
            // Find the existing trip in the database using the ID from the updatedTrip model
            var existingTrip = _context.Trips.Find(updatedTrip.id);

            if (existingTrip == null)
            {
                return NotFound(); // Return 404 if the trip doesn't exist
            }

            // Calculate the budget difference
            var budgetDifference = updatedTrip.Budget - existingTrip.Budget;

            // If the new budget is greater than the previous one, update Remaining_Budget
            if (budgetDifference > 0)
            {
                existingTrip.Remaining_Budget += budgetDifference;
            }

            // Update the trip details
            existingTrip.trip_name = updatedTrip.trip_name;
            existingTrip.Destination = updatedTrip.Destination;
            existingTrip.start_Date = updatedTrip.start_Date;
            existingTrip.end_Date = updatedTrip.end_Date;
            existingTrip.Budget = updatedTrip.Budget;

            // Save changes to the database
            _context.SaveChanges();

            // Redirect to the Trip_View_Trip page
            return RedirectToAction("Trip_View_Trip");
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
            // Find the trip by its ID
            var check = _context.Trips.Where(x => x.id == e.trip_id).FirstOrDefault();

            if (check == null)
            {
                SetCookie("error-msg", "Trip not found.");
                return RedirectToAction("Expense_Create");
            }

            // Ensure the expense amount doesn't exceed the remaining budget
            if (e.Amount <= check.Remaining_Budget)
            {
                // Check if the trip's end date has not expired
                if (check.end_Date >= DateTime.Now)
                {
                    var user_id = GetUserId();
                    e.user_id = user_id.Id;
                    e.expanse_Date = DateTime.Now;

                    // Add the expense to the database
                    _context.Expenses.Add(e);

                    // Deduct the expense amount from the remaining budget
                    check.Remaining_Budget -= e.Amount;

                    // Save changes to the database
                    _context.SaveChanges();
                }
                else
                {
                    SetCookie("error-msg", "Trip Date Expired");
                }
            }
            else
            {
                SetCookie("error-msg", "Invalid Budget: Expense exceeds remaining budget.");
            }

            return RedirectToAction("Expense_Create");
        }

        public IActionResult Expense_View()
        {
            var data = _context.Expenses.Include(x=>x.trip).Include(x=>x.category).ToList();
            return View(data);
        }
        public IActionResult Delete_Expense(int id)
        {
            var data = _context.Expenses.Find(id);
            var trip = _context.Trips.Where(x => x.id == data.trip_id).FirstOrDefault();
            trip.Remaining_Budget += data.Amount;
            _context.Expenses.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Expense_View");
        }
        public IActionResult Budget_Management()
        {
            return View();
        }
        public IActionResult Upcoming_Trip()
        {
            var data = _context.Trips.Where(x=>x.start_Date>DateTime.Now).ToList();
            return View(data);
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
