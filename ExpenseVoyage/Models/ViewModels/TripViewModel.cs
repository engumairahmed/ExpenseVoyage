namespace ExpenseVoyage.Models.ViewModels
{
    public class TripViewModel
    {
        public Trips Trip { get; set; }
        public List<ExpenseViewModel> Expenses { get; set; }
    }

    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime ExpanseDate { get; set; }
        public string Notes { get; set; }
        public string CategoryName { get; set; }
    }
}
