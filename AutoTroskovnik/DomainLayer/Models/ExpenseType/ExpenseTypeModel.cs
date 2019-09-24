using System;

namespace DomainLayer.Models.ExpenseType
{
    public class ExpenseTypeModel : IExpenseTypeModel
    {
        public ExpenseTypeModel() { }

        public int ExpenseTypeId { get; set; }
        public String ExpenseTypeName { get; set; }
    }
}
