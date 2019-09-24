using System;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IExpenseListPresenter
    {
        event EventHandler RefreshStatisticsEvent;
        IExpenseListViewUC GetExpenseListViewUC();
        void LoadAllExpensesFromDbToGrid();
        void OnDeleteExpenseEventRaised(object sender, EventArgs e);
        void OnEditExpenseEventRaised(object sender, EventArgs e);
    }
}