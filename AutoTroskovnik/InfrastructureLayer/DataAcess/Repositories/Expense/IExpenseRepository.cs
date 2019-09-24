using CommonComponents.ViewModels;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Services.ExpenseService
{
    public interface IExpenseRepository
    {
        void Create(IExpenseModel expenseModel);
        void Update(IExpenseModel expenseModel);
        void Delete(IExpenseModel expenseModel);

        IEnumerable<IExpenseModel> GetAllByUserId(int UserId);
        IEnumerable<IExpenseModel> GetAllByUserIdAndExpenseType(int UserId, IExpenseTypeModel expenseTypeModel);

        List<int> GetDistinctYears(int UserId);
        IEnumerable<YearCategoryCost> GetTotalCostPerCategoryAndYear(int year, int UserId);
        IEnumerable<MonthCategoryCost> GetTotalCostPerCategoryAndMonth(int year, int month, int UserId);
    }
}
