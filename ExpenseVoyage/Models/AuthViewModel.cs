using ExpenseVoyage.Areas.Identity.Pages.Account;

namespace ExpenseVoyage.Models
{
    public class AuthViewModel
    {
        public LoginModel Login { get; set; }
        public RegisterModel Register { get; set; }
    }
}
