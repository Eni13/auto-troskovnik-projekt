using CommonComponents;
using PresentationLayer.Views.ViewModels;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExpenseTypeAddView : Form, IExpenseTypeAddView
    {
        public event EventHandler<ExpenseTypeAddViewModel> ExpenseTypeAddConfirmEventRaised;

        public ExpenseTypeAddView()
        {
            InitializeComponent();
        }

        public void ShowExpenseAddView()
        {
            this.ShowDialog();
        }


        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseTypeAddViewModel vm = new ExpenseTypeAddViewModel();
                vm.ExpenseTypeName = expenseTypeNameTextBox.Text;
                EventHelpers.RaiseEvent(this, ExpenseTypeAddConfirmEventRaised, vm);
                Close();
            }
            catch (Exception) { }
        }
    }
}
