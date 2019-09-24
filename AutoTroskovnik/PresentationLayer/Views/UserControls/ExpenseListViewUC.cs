using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class ExpenseListViewUC : BaseUserControlUC, IExpenseListViewUC
    {
        public event EventHandler EditExpenseMenuClickEventRaised;
        public event EventHandler DeleteExpenseMenuClickEventRaised;

        public ExpenseListViewUC()
        {
            InitializeComponent();
        }

        private void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
        {
            ExpenseListDataGridView.Columns["ExpenseId"].HeaderText = headingsDictionary["ExpenseId"];
            ExpenseListDataGridView.Columns["ExpenseTypeName"].HeaderText = headingsDictionary["ExpenseTypeName"];
            ExpenseListDataGridView.Columns["Date"].HeaderText = headingsDictionary["Date"];
            ExpenseListDataGridView.Columns["Cost"].HeaderText = headingsDictionary["Cost"];
        }

        private void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary, ref int optionsWidth)
        {
            int GridWidth = (ExpenseListDataGridView.Width - ExpenseListDataGridView.RowHeadersWidth -
                       SystemInformation.VerticalScrollBarWidth);

            ExpenseListDataGridView.Columns["ExpenseId"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ExpenseId"]);
            ExpenseListDataGridView.Columns["ExpenseTypeName"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ExpenseTypeName"]);
            ExpenseListDataGridView.Columns["Date"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["Date"]);
            ExpenseListDataGridView.Columns["Cost"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["Cost"]);

            optionsWidth = (int)((GridWidth) * gridColumnWidthsDictionary["Options"]);
        }

        public void LoadExpenseListToGrid(BindingSource expenseListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight)
        {
            ExpenseListDataGridView.RowTemplate.Height = 32;

            ExpenseListDataGridView.DataSource = expenseListBindingSource;

            SetGridHeaderText(headingsDictionary);
            ExpenseListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExpenseListDataGridView.AllowUserToAddRows = false; //Removes blank row at end of grid load
            ExpenseListDataGridView.ReadOnly = true;

            int optionsWidth = 0;
            SetGridColumnWidths(gridColumnWidthsDictionary, ref optionsWidth);
     

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Options";
            imageColumn.Name = "Options";
            imageColumn.Width = optionsWidth;
            imageColumn.Image = Properties.Resources.MoreOptionsBlackDotsOnWhite20x20;
            if (ExpenseListDataGridView.Columns["Options"] == null)
            {
                ExpenseListDataGridView.Columns.Add(imageColumn);
            }
            ExpenseListDataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnUpdateExpenseInGridMenuClick(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDeleteExpenseMenuClick(sender, e);
        }
        private void OnUpdateExpenseInGridMenuClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, EditExpenseMenuClickEventRaised, e);
        }

        private void OnDeleteExpenseMenuClick(object sender, EventArgs e) {
            EventHelpers.RaiseEvent(this, DeleteExpenseMenuClickEventRaised, e);
        }

    private void ExpenseListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ExpenseListDataGridView.Columns["Options"].Index)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
    }
}
