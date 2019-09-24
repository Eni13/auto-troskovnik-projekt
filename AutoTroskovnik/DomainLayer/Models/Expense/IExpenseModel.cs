namespace DomainLayer.Models.Expense
{
    public interface IExpenseModel
    {
        double Cost { get; set; }
        string Date { get; set; }
        int ExpenseId { get; set; }
        int ExpenseTypeId { get; set; }
        int UserId { get; set; }
    }
}