using System;
using System.Collections.Generic;
using DomainLayer.Models.ExpenseType;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views.UserControls
{
    public interface IExpenseAddView
    {
        event EventHandler<ExpenseAddViewModel> ExpenseAddConfirmEventRaised;

        void ShowExpenseTypeAddView(List<ExpenseTypeDTO> expenseTypeList);
    }
}