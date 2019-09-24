using System;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class HeaderViewUC : BaseUserControlUC, IHeaderViewUC
    {
        public event EventHandler LogoutClickEventRaised;
        public event EventHandler AddExpenseClickEventRaised;
        public event EventHandler AddExpenseTypeClickEventRaised;

        public HeaderViewUC()
        {
            InitializeComponent();
        }

        public void setHeaderText(string firstName, string lastName, string carModel) {
            headerText.Text = firstName + " " + lastName + " (" + carModel + ")";
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, LogoutClickEventRaised, e);
        }

        private void addExpenseBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, AddExpenseClickEventRaised, e);
        }

        private void addExpenseTypeBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, AddExpenseTypeClickEventRaised, e);
        }
    }
}
