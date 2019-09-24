using System;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views
{
    public interface IExpenseTypeEditView
    {
        event EventHandler<ExpenseTypeEditViewModel> ExpenseTypeEditConfirmEventRaised;

        void ShowExpenseTypeEditView(ExpenseTypeDTO expenseDTO);
    }
}