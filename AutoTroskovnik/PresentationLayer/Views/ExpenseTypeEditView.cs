using CommonComponents;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExpenseTypeEditView : Form, IExpenseTypeEditView
    {

        public event EventHandler<ExpenseTypeEditViewModel> ExpenseTypeEditConfirmEventRaised;

        public ExpenseTypeEditView()
        {
            InitializeComponent();
        }
        public void ShowExpenseTypeEditView(ExpenseTypeDTO expenseDTO)
        {
            this.ShowDialog();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            ExpenseTypeEditViewModel vm = new ExpenseTypeEditViewModel();
            vm.ExpenseTypeName = expenseTypeNameTextBox.Text;
            EventHelpers.RaiseEvent(this, ExpenseTypeEditConfirmEventRaised, vm);
            Close();
        }
    }
}
