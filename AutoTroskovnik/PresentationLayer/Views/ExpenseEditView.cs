using CommonComponents;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExpenseEditView : Form, IExpenseEditView
    {
        public event EventHandler<ExpenseEditViewModel> ExpenseEditConfirmEventRaised;

        public ExpenseEditView()
        {
            InitializeComponent();
        }

        public void ShowExpenseEditView(ExpenseDTO expenseDTO, List<ExpenseTypeDTO> expenseTypeList)
        {
            expenseTypeComboBox.DataSource = expenseTypeList;
            expenseTypeComboBox.DisplayMember = "ExpenseTypeName";

            datePicker.Value = expenseDTO.Date;
            costNumericPicker.Value = (decimal)expenseDTO.Cost;
            ShowDialog();
        }

        private void saveChangedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseEditViewModel vm = new ExpenseEditViewModel();
                vm.ExpenseTypeId = (expenseTypeComboBox.SelectedItem as ExpenseTypeDTO).ExpenseTypeId;
                vm.Date = TimeHelpers.dateTimeToString(datePicker.Value);
                vm.Cost = (double)costNumericPicker.Value;

                EventHelpers.RaiseEvent(this, ExpenseEditConfirmEventRaised, vm);
                Close();
            }
            catch (Exception) { }

        }
    }
}
