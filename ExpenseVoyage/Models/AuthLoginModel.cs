using ExpenseVoyage.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace ExpenseVoyage.Models
{
    public class AuthLoginModel : LoginModel
    {
        public AuthLoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger) : base(signInManager, logger)
        {
        }
    }
}
