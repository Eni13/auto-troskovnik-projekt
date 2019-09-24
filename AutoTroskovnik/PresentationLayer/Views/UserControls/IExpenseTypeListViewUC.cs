using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IExpenseTypeListViewUC
    {
        event EventHandler DeleteTypeExpenseMenuClickEventRaised;
        event EventHandler EditTypeExpenseMenuClickEventRaised;
        event EventHandler ExpenseTypeListViewLoadEventRaised;

        void LoadExpenseListToGrid(BindingSource expenseTypeListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight);
    }
}