using CommonComponents;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Presenters.Common;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.ViewModels;
using ServiceLayer.Services.ExpenseService;
using ServiceLayer.Services.ExpenseTypeService;
using ServiceLayer.Services.UserService;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        public event EventHandler<DataAccessException> DataAccessExceptionEvent;

        private IMainView _mainView;
        private Panel _headerPanel;
        private Panel _basePanel;
        private TabControl _tabControl;
        private ISession _session;
        private IExpenseListPresenter _expenseListPresenter;
        private IExpenseTypeListPresenter _expenseTypeListPresenter;
        private IExpenseStatisticsPresenter _expenseStatisticsPresenter;
        private IHeaderViewPresenter _headerViewPresenter;
        private IExpenseService _expenseService;
        private IExpenseTypeService _expenseTypeService;
        private IUserService _userService;
        public MainPresenter() { }
        public MainPresenter(IMainView mainView,
            ISession session,
            IExpenseListPresenter expenseListPresenter,
            IExpenseTypeListPresenter expenseTypeListPresenter,
            IExpenseStatisticsPresenter expenseStatisticsPresenter,
            IHeaderViewPresenter headerViewPresenter,
            IExpenseService expenseService,
            IExpenseTypeService expenseTypeService,
            IUserService userService
            )
        {
            _mainView = mainView;
            _session = session;

            _headerPanel = _mainView.GetHeaderPanel();
            _tabControl = _mainView.GetTabControl();
            _basePanel = _mainView.GetBasePanel();

            _expenseListPresenter = expenseListPresenter;
            _expenseTypeListPresenter = expenseTypeListPresenter;
            _expenseStatisticsPresenter = expenseStatisticsPresenter;
            _headerViewPresenter = headerViewPresenter;
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _userService = userService;
            SubscribeToEventsSetup();
        }

        public IMainView GetMainView()
        {
            return _mainView;
        }

        private void SubscribeToEventsSetup()
        {
            _headerViewPresenter.getExpenseAddView().ExpenseAddConfirmEventRaised += new EventHandler<ExpenseAddViewModel>(OnExpenseAddConfirmEventRaised);
            _headerViewPresenter.getExpenseTypeAddView().ExpenseTypeAddConfirmEventRaised += new EventHandler<ExpenseTypeAddViewModel>(OnExpenseTypeAddConfirmEventRaised);
            _expenseListPresenter.RefreshStatisticsEvent += new EventHandler(OnRefreshStatisticsEvent);
        }

        private void OnRefreshStatisticsEvent(object sender, EventArgs e)
        {
            _expenseStatisticsPresenter.Refresh();
        }

        private void OnExpenseTypeAddConfirmEventRaised(object sender, ExpenseTypeAddViewModel e)
        {
            try
            {
                ExpenseTypeDTO dto = new ExpenseTypeDTO();
                dto.ExpenseTypeName = e.ExpenseTypeName;
                _expenseTypeService.Create(dto);
                _expenseTypeListPresenter.LoadAllExpensesFromDbToGrid();
                _expenseStatisticsPresenter.Refresh();
            }
            catch (DataAccessException ex)
            {
                EventHelpers.RaiseEvent(this, DataAccessExceptionEvent, ex);
            }
        }

        private void OnExpenseAddConfirmEventRaised(object sender, ExpenseAddViewModel args)
        {
            try
            {
                ExpenseDTO dto = new ExpenseDTO();
                dto.Cost = args.Cost;
                dto.Date = DateTime.Parse(args.Date);
                dto.ExpenseTypeId = args.ExpenseTypeId;
                dto.UserId = _session.GetUser().UserId;
                _expenseService.Create(dto);
                _expenseListPresenter.LoadAllExpensesFromDbToGrid();
                _expenseStatisticsPresenter.Refresh();
            }
            catch (DataAccessException ex)
            {
                EventHelpers.RaiseEvent(this, DataAccessExceptionEvent, ex);
            }
        }

        public void LoadAll()
        {
            AssignUserControlToTabContentPanel((BaseUserControlUC)_expenseListPresenter.GetExpenseListViewUC(), 0);
            AssignUserControlToTabContentPanel((BaseUserControlUC)_expenseTypeListPresenter.GetExpenseTypeListViewUC(), 1);
            AssignUserControlToTabContentPanel((BaseUserControlUC)_expenseStatisticsPresenter.GetExpenseStatisticsViewUC(), 2);

            _expenseListPresenter.LoadAllExpensesFromDbToGrid();
            _expenseTypeListPresenter.LoadAllExpensesFromDbToGrid();
            _expenseStatisticsPresenter.Refresh();
            showHeader();
        }
        private void AssignUserControlToTabContentPanel(BaseUserControlUC baseUserControl, int index)
        {
            baseUserControl.SetParentSizeLocationAnchor(_tabControl.TabPages[index]);
        }

        private void showHeader()
        {
            _headerViewPresenter.setUserInfo(_session.GetUser());
            ((BaseUserControlUC)_headerViewPresenter.GetHeaderViewUC()).SetParentSizeLocationAnchor(_headerPanel);
        }
    }
}
