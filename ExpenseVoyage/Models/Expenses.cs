using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseVoyage.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        [ForeignKey("profile")]
        public int user_id { get; set; }
        [ForeignKey("trip")]
        public int trip_id { get; set; }
        public int Amount { get; set; }
        [ForeignKey("category")]
        public int category_id { get; set; }
        public DateTime expanse_Date { get; set; }
        public string notes { get; set; }

        public UserProfile profile { get; set; }
        public Trips trip { get; set; }
        public Category category { get; set; }
    }
}
