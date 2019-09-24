using DomainLayer.Models.ExpenseType;
using System.Collections.Generic;

namespace ServiceLayer.Services.ExpenseTypeService
{
    public interface IExpenseTypeService
    {
        void Create(ExpenseTypeDTO expenseTypeDTO);
        void Update(ExpenseTypeDTO expenseTypeDTO);
        void Delete(ExpenseTypeDTO expenseTypeDTO);

        IEnumerable<ExpenseTypeDTO> GetAll();

        ExpenseTypeDTO GetById(int Id);
    }
}
