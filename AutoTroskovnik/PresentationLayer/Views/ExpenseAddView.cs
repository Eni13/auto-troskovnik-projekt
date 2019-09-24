using CommonComponents;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ExpenseAddView : Form, IExpenseAddView
    {
        public event EventHandler<ExpenseAddViewModel> ExpenseAddConfirmEventRaised;

        public ExpenseAddView()
        {
            InitializeComponent();
        }

        public void ShowExpenseTypeAddView(List<ExpenseTypeDTO> expenseTypeList)
        {
            expenseTypeCombobox.DataSource = expenseTypeList;
            expenseTypeCombobox.ValueMember = "ExpenseTypeId";
            expenseTypeCombobox.DisplayMember = "ExpenseTypeName";
            ShowDialog();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseAddViewModel vm = new ExpenseAddViewModel();
                vm.ExpenseTypeId = (expenseTypeCombobox.SelectedItem as ExpenseTypeDTO).ExpenseTypeId;
                vm.Date = TimeHelpers.dateTimeToString(datePicker.Value);
                vm.Cost = (double)costPicker.Value;
                EventHelpers.RaiseEvent(this, ExpenseAddConfirmEventRaised, vm);
                Close();
            }
            catch (Exception) { }
        }
    }
}
