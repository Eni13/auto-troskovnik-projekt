using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.ExpenseTypeService;
using System;
using System.Linq;
namespace PresentationLayer.Presenters.UserControls
{
    public class HeaderViewPresenter : IHeaderViewPresenter
    {
        public event EventHandler LogoutEvent;
        private IHeaderViewUC _headerViewUC;
        private IExpenseAddView _expenseAddView;
        private IExpenseTypeAddView _expenseTypeAddView;
        private IExpenseTypeService _expenseTypeService;

        public HeaderViewPresenter(
            IHeaderViewUC headerViewUC,
            IExpenseAddView expenseAddView,
            IExpenseTypeAddView expenseTypeAddView,
            IExpenseTypeService expenseTypeService
            )
        {
            _headerViewUC = headerViewUC;
            _expenseAddView = expenseAddView;
            _expenseTypeAddView = expenseTypeAddView;
            _expenseTypeService = expenseTypeService;
            SubscribeToEvents();
        }

        public IExpenseAddView getExpenseAddView()
        {
            return _expenseAddView;
        }

        public IExpenseTypeAddView getExpenseTypeAddView()
        {
            return _expenseTypeAddView;
        }

        public IHeaderViewUC GetHeaderViewUC()
        {
            return _headerViewUC;
        }

        private void SubscribeToEvents()
        {
            _headerViewUC.LogoutClickEventRaised += new EventHandler(OnLogoutEventRaised);
            _headerViewUC.AddExpenseClickEventRaised += new EventHandler(OnAddExpenseEventRaised);
            _headerViewUC.AddExpenseTypeClickEventRaised += new EventHandler(OnAddExpenseTypeEventRaised);
        }

        private void OnAddExpenseTypeEventRaised(object sender, EventArgs e)
        {
            _expenseTypeAddView.ShowExpenseAddView();
        }

        private void OnAddExpenseEventRaised(object sender, EventArgs e)
        {
            _expenseAddView.ShowExpenseTypeAddView(_expenseTypeService.GetAll().ToList());
        }

        private void OnLogoutEventRaised(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, LogoutEvent, e);
        }

        public void setUserInfo(UserDTO userDTO)
        {
            _headerViewUC.setHeaderText(userDTO.FirstName, userDTO.LastName, userDTO.CarModel);
        }
    }
}
