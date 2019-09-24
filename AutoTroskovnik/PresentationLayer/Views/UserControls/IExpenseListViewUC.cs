using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IExpenseListViewUC
    {
        event EventHandler DeleteExpenseMenuClickEventRaised;
        event EventHandler EditExpenseMenuClickEventRaised;

        void LoadExpenseListToGrid(BindingSource expenseListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight);
    }
}