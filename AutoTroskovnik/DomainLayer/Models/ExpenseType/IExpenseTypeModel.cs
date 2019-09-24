namespace DomainLayer.Models.ExpenseType
{
    public interface IExpenseTypeModel
    {
        string ExpenseTypeName { get; set; }
        int ExpenseTypeId { get; set; }
    }
}