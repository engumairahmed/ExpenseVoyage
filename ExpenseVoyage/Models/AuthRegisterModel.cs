using ExpenseVoyage.Areas.Identity.Pages.Account;
using ExpenseVoyage.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ExpenseVoyage.Models
{
    public class AuthRegisterModel : RegisterModel
    {
        public AuthRegisterModel(
            UserManager<IdentityUser> userManager, 
            IUserStore<IdentityUser> userStore, 
            SignInManager<IdentityUser> signInManager, 
            ILogger<RegisterModel> logger, 
            IEmailSender emailSender, 
            ApplicationDbContext context
            ) : base(userManager, userStore, signInManager, logger, emailSender, context)
        {
        }
    }
}
