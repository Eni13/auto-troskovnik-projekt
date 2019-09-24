using CommonComponents;
using DomainLayer.Models.Expense;
using PresentationLayer.Presenters.Common;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.ViewModels;
using ServiceLayer.Services.ExpenseService;
using ServiceLayer.Services.ExpenseTypeService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
    public class ExpenseListPresenter : IExpenseListPresenter
    {
        public event EventHandler RefreshStatisticsEvent;

        private IExpenseService _expenseService;
        private IExpenseTypeService _expenseTypeService;
        private IExpenseListViewUC _expenseListViewUC;
        private IExpenseDeleteView _expenseDeleteView;
        private IExpenseEditView _expenseEditView;
        private ISession _session;


        //BindingList to load with collection of ExpenseDTOs returned from repository
        //This list will be used to construct the BindingSource for the Views DataGridView
        BindingList<ExpenseDTO> _expenseDtoBindingList;

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource _expenseDtoBindingSource;


        public IExpenseListViewUC GetExpenseListViewUC()
        {
            return _expenseListViewUC;
        }

        public ExpenseListPresenter(
            IExpenseService expenseService, 
            IExpenseListViewUC expenseListViewUC, 
            IExpenseDeleteView expenseDeleteView,
            IExpenseEditView expenseEditView,
            IExpenseTypeService expenseTypeService,
            ISession session)
        {
            _expenseService = expenseService;
            _expenseListViewUC = expenseListViewUC;
            _expenseDeleteView = expenseDeleteView;
            _expenseEditView = expenseEditView;
            _expenseTypeService = expenseTypeService;
            _session = session;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _expenseListViewUC.EditExpenseMenuClickEventRaised += new EventHandler(OnEditExpenseEventRaised);
            _expenseListViewUC.DeleteExpenseMenuClickEventRaised += new EventHandler(OnDeleteExpenseEventRaised);
            _expenseDeleteView.ExpenseDeleteConfirmBtnClick += new EventHandler(OnDeleteExpenseConfirmEventRaised);
            _expenseEditView.ExpenseEditConfirmEventRaised += new EventHandler<ExpenseEditViewModel>(OnExpenseEditConfirmEventRaised);

        }

        private void OnExpenseEditConfirmEventRaised(object sender, ExpenseEditViewModel args)
        {
            ExpenseDTO expenseDTO = (ExpenseDTO)_expenseDtoBindingSource.Current;
            expenseDTO.Cost = args.Cost;
            expenseDTO.Date = DateTime.Parse(args.Date);
            expenseDTO.ExpenseTypeId = args.ExpenseTypeId;
            _expenseService.Update(expenseDTO);

            LoadAllExpensesFromDbToGrid();
            EventHelpers.RaiseEvent(this, RefreshStatisticsEvent, null);
        }

        private void OnDeleteExpenseConfirmEventRaised(object sender, EventArgs e)
        {
            ExpenseDTO expenseDTO = (ExpenseDTO)_expenseDtoBindingSource.Current;
            _expenseService.Delete(expenseDTO);

            LoadAllExpensesFromDbToGrid();
            EventHelpers.RaiseEvent(this, RefreshStatisticsEvent, null);
        }

        public void OnEditExpenseEventRaised(object sender, EventArgs e) {
            ExpenseDTO expenseDTO = (ExpenseDTO)_expenseDtoBindingSource.Current;
            _expenseEditView.ShowExpenseEditView(expenseDTO, _expenseTypeService.GetAll().ToList());
        }
        public void OnDeleteExpenseEventRaised(object sender, EventArgs e) {
            ExpenseDTO expenseDTO = (ExpenseDTO)_expenseDtoBindingSource.Current;
            _expenseDeleteView.ShowExpenseDeleteView();
        }

        public void LoadAllExpensesFromDbToGrid()
        {
            int rowHeight = 28;

            BuildDatasourceForExpenseList();

            Dictionary<string, float> gridColumnWidthsDictionary = new Dictionary<string, float>();
            SetExpenseListViewGridColumnWidths(gridColumnWidthsDictionary);

            Dictionary<string, string> headingsDictionary = new Dictionary<string, string>();
            SetExpenseListViewGridHeadings(headingsDictionary);

            _expenseListViewUC.LoadExpenseListToGrid(_expenseDtoBindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight);
        }

        private void BuildDatasourceForExpenseList()
        {
            IEnumerable<ExpenseDTO> allExpenses = _expenseService.GetAllByUserId(_session.GetUser().UserId);
            _expenseDtoBindingList = new BindingList<ExpenseDTO>();

            foreach (ExpenseDTO expenseDto in allExpenses)
            {
                _expenseDtoBindingList.Add(expenseDto);
            };

            _expenseDtoBindingSource = new BindingSource();
            _expenseDtoBindingSource.DataSource = _expenseDtoBindingList;
        }

        private void SetExpenseListViewGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
        {
            gridColumnWidthsDictionary["ExpenseId"] = (float)(.2);
            gridColumnWidthsDictionary["ExpenseTypeName"] = (float)(.2);
            gridColumnWidthsDictionary["Date"] = (float)(.2);
            gridColumnWidthsDictionary["Cost"] = (float)(.2);
            gridColumnWidthsDictionary["Options"] = (float)(.2);
        }

        private void SetExpenseListViewGridHeadings(Dictionary<string, string> headingsDictionary)
        {
            headingsDictionary["ExpenseId"] = "Id";
            headingsDictionary["ExpenseTypeName"] = "Kategorija troška";
            headingsDictionary["Date"] = "Datum";
            headingsDictionary["Cost"] = "Iznos";
            headingsDictionary["Options"] = "Opcije";
        }

    }

}
