namespace DomainLayer.Models.Expense
{
    public class ExpenseModel : IExpenseModel
    {
        public ExpenseModel() { }
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }
        public string Date { get; set; }
        public double Cost { get; set; }
        public int UserId { get; set; }
    }
}
