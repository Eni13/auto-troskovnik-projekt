using System;

namespace PresentationLayer.Views
{
    public interface IExpenseDeleteView
    {
        event EventHandler ExpenseDeleteConfirmBtnClick;
        void ShowExpenseDeleteView();
    }
}