using System;
using System.Collections.Generic;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views
{
    public interface IExpenseEditView
    {
        event EventHandler<ExpenseEditViewModel> ExpenseEditConfirmEventRaised;

        void ShowExpenseEditView(ExpenseDTO expenseDTO, List<ExpenseTypeDTO> expenseTypeList);
    }
}