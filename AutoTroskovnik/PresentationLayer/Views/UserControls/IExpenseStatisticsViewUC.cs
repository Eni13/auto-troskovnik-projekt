using System;
using System.Collections.Generic;
using CommonComponents.ViewModels;
using DomainLayer.Models.ExpenseType;

namespace PresentationLayer.Views.UserControls
{
    public interface IExpenseStatisticsViewUC
    {
        event EventHandler<Tuple<int, int>> ChangeMonthEvent;
        event EventHandler<Tuple<int, int>> ChangeYearEvent;
        event EventHandler ExpenseStatisticsViewUCLoadEvent;

        void SetDropdowns(List<int> years);
        void ClearMonthChart();
        void SetMonthStatistics(IEnumerable<MonthCategoryCost> monthCategoryList, IEnumerable<ExpenseTypeDTO> expenseTypes);
        void SetYearStatistics(IEnumerable<YearCategoryCost> yearCategoryList, IEnumerable<ExpenseTypeDTO> expenseTypes);
    }
}