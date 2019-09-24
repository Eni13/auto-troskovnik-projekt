using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExpenseTypeDeleteView : Form, IExpenseTypeDeleteView
    {
        public event EventHandler ExpenseTypeDeleteConfirmBtnClick;

        public ExpenseTypeDeleteView()
        {
            InitializeComponent();
        }
        public void ShowExpenseTypeDeleteView() {
            this.ShowDialog();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cofirmDeleteBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ExpenseTypeDeleteConfirmBtnClick, e);
            Close();
        }
    }
}
