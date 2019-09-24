using CommonComponents.ViewModels;
using PresentationLayer.Presenters.Common;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.ExpenseService;
using ServiceLayer.Services.ExpenseTypeService;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Presenters.UserControls
{
    public class ExpenseStatisticsPresenter : IExpenseStatisticsPresenter
    {
        private IExpenseStatisticsViewUC _expenseStatisticsViewUC;
        private IExpenseService _expenseService;
        private IExpenseTypeService _expenseTypeService;
        private ISession _session;
        public ExpenseStatisticsPresenter(IExpenseStatisticsViewUC expenseStatisticsViewUC,
            IExpenseService expenseService, IExpenseTypeService expenseTypeService, ISession session)
        {
            _expenseStatisticsViewUC = expenseStatisticsViewUC;
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _session = session;
            SubscribeToEventsSetup();
        }
        public IExpenseStatisticsViewUC GetExpenseStatisticsViewUC()
        {
            return _expenseStatisticsViewUC;
        }
        public void Refresh()
        {
            _expenseStatisticsViewUC.SetDropdowns(_expenseService.GetDistinctYears(_session.GetUser().UserId));
        }
        private void LoadTotalCostsByMonthAndCategory(int year, int month)
        {
            IEnumerable<MonthCategoryCost> monthCategoryCosts = _expenseService.GetTotalCostPerCategoryAndMonth(year, month, _session.GetUser().UserId);
            _expenseStatisticsViewUC.SetMonthStatistics(monthCategoryCosts, _expenseTypeService.GetAll());
        }
        private void LoadTotalCostsByYearAndCategory(int year)
        {
            IEnumerable<YearCategoryCost> yearCategoryCosts = _expenseService.GetTotalCostPerCategoryAndYear(year, _session.GetUser().UserId);
            _expenseStatisticsViewUC.SetYearStatistics(yearCategoryCosts, _expenseTypeService.GetAll());
        }

        private void SubscribeToEventsSetup()
        {
            _expenseStatisticsViewUC.ExpenseStatisticsViewUCLoadEvent += new EventHandler(OnExpenseStatisticsViewUCLoadEvent);
            _expenseStatisticsViewUC.ChangeYearEvent += new EventHandler<Tuple<int, int>>(OnChangeYearEvent);
            _expenseStatisticsViewUC.ChangeMonthEvent += new EventHandler<Tuple<int, int>>(OnChangeMonthEvent);
        }

        private void OnChangeMonthEvent(object sender, Tuple<int, int> e)
        {
            LoadTotalCostsByMonthAndCategory(e.Item1, e.Item2);
        }

        private void OnChangeYearEvent(object sender, Tuple<int, int> e)
        {
            LoadTotalCostsByYearAndCategory(e.Item1);
            LoadTotalCostsByMonthAndCategory(e.Item1, e.Item2);
        }

        private void OnExpenseStatisticsViewUCLoadEvent(object sender, EventArgs e)
        {
            _expenseStatisticsViewUC.SetDropdowns(_expenseService.GetDistinctYears(_session.GetUser().UserId));
        }
    }
}
