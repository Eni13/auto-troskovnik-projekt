using System;

namespace PresentationLayer.Views.UserControls
{
    public interface IHeaderViewUC
    {
        event EventHandler LogoutClickEventRaised;
        event EventHandler AddExpenseClickEventRaised;
        event EventHandler AddExpenseTypeClickEventRaised;

        void setHeaderText(string firstName, string lastName, string carModel);
    }
}