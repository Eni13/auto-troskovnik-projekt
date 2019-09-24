using System;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IExpenseTypeListPresenter
    {
        IExpenseTypeListViewUC GetExpenseTypeListViewUC();
        void LoadAllExpensesFromDbToGrid();
        void OnDeleteExpenseTypeEventRaised(object sender, EventArgs e);
        void OnEditExpenseTypeEventRaised(object sender, EventArgs e);
    }
}