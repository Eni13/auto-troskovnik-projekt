using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExpenseDeleteView : Form, IExpenseDeleteView
    {
        public event EventHandler ExpenseDeleteConfirmBtnClick;

        public ExpenseDeleteView()
        {
            InitializeComponent();
        }

        public void ShowExpenseDeleteView()
        {
            this.ShowDialog();
        }

        private void deleteConfirmBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ExpenseDeleteConfirmBtnClick, e);
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
