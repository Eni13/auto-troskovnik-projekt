using DomainLayer.Models.ExpenseType;
using System.Collections.Generic;

namespace ServiceLayer.Services.ExpenseTypeService
{
    public interface IExpenseTypeRepository
    {
        void Create(IExpenseTypeModel expenseTypeModel);
        void Update(IExpenseTypeModel expenseTypeModel);
        void Delete(IExpenseTypeModel expenseTypeModel);

        IEnumerable<IExpenseTypeModel> GetAll();

        IExpenseTypeModel GetById(int Id);
    }
}
