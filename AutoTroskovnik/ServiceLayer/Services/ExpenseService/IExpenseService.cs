using CommonComponents.ViewModels;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.ExpenseService
{
    public interface IExpenseService
    {
        void Create(ExpenseDTO expenseDTO);
        void Update(ExpenseDTO expenseDTO);
        void Delete(ExpenseDTO expenseDTO);

        IEnumerable<ExpenseDTO> GetAllByUserId(int UserId);
        IEnumerable<ExpenseDTO> GetAllByUserIdAndExpenseType(int UserId, ExpenseTypeDTO expenseTypeDTO);


        List<int> GetDistinctYears(int UserId);
        IEnumerable<YearCategoryCost> GetTotalCostPerCategoryAndYear(int year, int UserId);
        IEnumerable<MonthCategoryCost> GetTotalCostPerCategoryAndMonth(int year, int month, int UserId);
    }
}
