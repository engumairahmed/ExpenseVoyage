
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseVoyage.Models
{
    public class UserProfile 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Currency { get; set; }
        public string? ProfilePic {  get; set; }
        public string? Contact { get; set; }
        [ForeignKey("IdentityUser")]
        public string IUserId { get; set; }

        public ICollection<Trips>  Trips { get; set; }
        public ICollection<Expenses> exp { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
