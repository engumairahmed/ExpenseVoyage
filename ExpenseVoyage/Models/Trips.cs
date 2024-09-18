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
        public string Budget { get; set; }
        [ForeignKey("Profile")]
        public int user_id { get; set; }
        public ICollection<Expenses> exp { get; set; }
        public UserProfile Profile { get; set; }
    }
}
