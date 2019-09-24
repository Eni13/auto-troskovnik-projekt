using System;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views
{
    public interface IExpenseTypeAddView
    {
        event EventHandler<ExpenseTypeAddViewModel> ExpenseTypeAddConfirmEventRaised;

        void ShowExpenseAddView();
    }
}