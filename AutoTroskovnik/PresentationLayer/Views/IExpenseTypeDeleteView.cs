using System;

namespace PresentationLayer.Views
{
    public interface IExpenseTypeDeleteView
    {
        event EventHandler ExpenseTypeDeleteConfirmBtnClick;

        void ShowExpenseTypeDeleteView();
    }
}