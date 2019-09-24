using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.ViewModels;
using ServiceLayer.Services.ExpenseTypeService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
    public class ExpenseTypeListPresenter : IExpenseTypeListPresenter
    {
        private IExpenseTypeService _expenseTypeService;
        private IExpenseTypeListViewUC _expenseTypeListViewUC;
        private IExpenseTypeDeleteView _expenseTypeDeleteView;
        private IExpenseTypeEditView _expenseTypeEditView;


        //BindingList to load with collection of ExpenseDTOs returned from repository
        //This list will be used to construct the BindingSource for the Views DataGridView
        BindingList<ExpenseTypeDTO> _expenseTypeDtoBindingList;

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource _expenseTypeDtoBindingSource;


        public IExpenseTypeListViewUC GetExpenseTypeListViewUC()
        {
            return _expenseTypeListViewUC;
        }

        public ExpenseTypeListPresenter(
            IExpenseTypeListViewUC expenseTypeListViewUC, 
            IExpenseTypeDeleteView expenseTypeDeleteView,
            IExpenseTypeEditView expenseTypeEditView,
            IExpenseTypeService expenseTypeService)
        {
            this._expenseTypeService = expenseTypeService;
            this._expenseTypeListViewUC = expenseTypeListViewUC;
            this._expenseTypeDeleteView = expenseTypeDeleteView;
            this._expenseTypeEditView = expenseTypeEditView;
            this._expenseTypeService = expenseTypeService;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _expenseTypeListViewUC.EditTypeExpenseMenuClickEventRaised += new EventHandler(OnEditExpenseTypeEventRaised);
            _expenseTypeListViewUC.DeleteTypeExpenseMenuClickEventRaised += new EventHandler(OnDeleteExpenseTypeEventRaised);
            _expenseTypeDeleteView.ExpenseTypeDeleteConfirmBtnClick += new EventHandler(OnDeleteExpenseTypeConfirmEventRaised);
            _expenseTypeEditView.ExpenseTypeEditConfirmEventRaised += new EventHandler<ExpenseTypeEditViewModel>(OnExpenseTypeEditConfirmEventRaised);
        }

        private void OnExpenseTypeEditConfirmEventRaised(object sender, ExpenseTypeEditViewModel args)
        {
            ExpenseTypeDTO expenseTypeDTO = (ExpenseTypeDTO)_expenseTypeDtoBindingSource.Current;
            expenseTypeDTO.ExpenseTypeName = args.ExpenseTypeName;
            _expenseTypeService.Update(expenseTypeDTO);

            LoadAllExpensesFromDbToGrid();
        }

        private void OnDeleteExpenseTypeConfirmEventRaised(object sender, EventArgs e)
        {
            ExpenseTypeDTO expenseTypeDTO = (ExpenseTypeDTO)_expenseTypeDtoBindingSource.Current;
            _expenseTypeService.Delete(expenseTypeDTO);

            LoadAllExpensesFromDbToGrid();
        }

        public void OnEditExpenseTypeEventRaised(object sender, EventArgs e) {
            ExpenseTypeDTO expenseTypeDTO = (ExpenseTypeDTO)_expenseTypeDtoBindingSource.Current;
            _expenseTypeEditView.ShowExpenseTypeEditView(expenseTypeDTO);
        }

        public void OnDeleteExpenseTypeEventRaised(object sender, EventArgs e) {
            ExpenseTypeDTO expenseDTO = (ExpenseTypeDTO)_expenseTypeDtoBindingSource.Current;
            _expenseTypeDeleteView.ShowExpenseTypeDeleteView();
        }

        public void LoadAllExpensesFromDbToGrid()
        {
            int rowHeight = 28;

            BuildDatasourceForExpenseList();

            Dictionary<string, float> gridColumnWidthsDictionary = new Dictionary<string, float>();
            SetExpenseTypeListViewGridColumnWidths(gridColumnWidthsDictionary);

            Dictionary<string, string> headingsDictionary = new Dictionary<string, string>();
            SetExpenseTypeListViewGridHeadings(headingsDictionary);

            _expenseTypeListViewUC.LoadExpenseListToGrid(_expenseTypeDtoBindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight);
        }

        private void BuildDatasourceForExpenseList()
        {
            IEnumerable<ExpenseTypeDTO> allExpenseTypes = _expenseTypeService.GetAll();
            _expenseTypeDtoBindingList = new BindingList<ExpenseTypeDTO>();

            foreach (ExpenseTypeDTO expenseTypeDto in allExpenseTypes)
            {
                _expenseTypeDtoBindingList.Add(expenseTypeDto);
            };

            _expenseTypeDtoBindingSource = new BindingSource();
            _expenseTypeDtoBindingSource.DataSource = _expenseTypeDtoBindingList;
        }

        private void SetExpenseTypeListViewGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
        {
            gridColumnWidthsDictionary["ExpenseTypeId"] = (float)(.3);
            gridColumnWidthsDictionary["ExpenseTypeName"] = (float)(.4);
            gridColumnWidthsDictionary["Options"] = (float)(.3);
        }

        private void SetExpenseTypeListViewGridHeadings(Dictionary<string, string> headingsDictionary)
        {
            headingsDictionary["ExpenseTypeId"] = "Id";
            headingsDictionary["ExpenseTypeName"] = "Naziv kategorije";
            headingsDictionary["Options"] = "Opcije";
        }

    }

}
