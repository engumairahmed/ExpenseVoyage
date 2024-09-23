using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseVoyage.Models
{
    public class Trips
    {
        public int id { get; set; }
        public string trip_name { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
        public string Destination { get; set; }
        [Required(ErrorMessage = "Budget is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Budget must be a positive number")]
        public int Remaining_Budget { get; set; }
        public int Budget { get; set; }
        [ForeignKey("Profile")]
        public int user_id { get; set; }
        public ICollection<Expenses> exp { get; set; }
        public UserProfile Profile { get; set; }
    }
}
