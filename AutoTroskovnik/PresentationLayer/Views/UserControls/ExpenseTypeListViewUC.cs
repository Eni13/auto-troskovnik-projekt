using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class ExpenseTypeListViewUC : BaseUserControlUC, IExpenseTypeListViewUC
    {

        public event EventHandler ExpenseTypeListViewLoadEventRaised;
        public event EventHandler EditTypeExpenseMenuClickEventRaised;
        public event EventHandler DeleteTypeExpenseMenuClickEventRaised;
        public ExpenseTypeListViewUC()
        {
            InitializeComponent();
        }
        private void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
        {
            ExpenseTypeListDataGridView.Columns["ExpenseTypeId"].HeaderText = headingsDictionary["ExpenseTypeId"];
            ExpenseTypeListDataGridView.Columns["ExpenseTypeName"].HeaderText = headingsDictionary["ExpenseTypeName"];
        }
        private void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary, ref int optionsWidth)
        {
            int GridWidth = (ExpenseTypeListDataGridView.Width - ExpenseTypeListDataGridView.RowHeadersWidth -
                       SystemInformation.VerticalScrollBarWidth);

            ExpenseTypeListDataGridView.Columns["ExpenseTypeId"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ExpenseTypeId"]);
            ExpenseTypeListDataGridView.Columns["ExpenseTypeName"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ExpenseTypeName"]);

            optionsWidth = (int)((GridWidth) * gridColumnWidthsDictionary["Options"]);
        }


        public void LoadExpenseListToGrid(BindingSource expenseTypeListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight)
        {
            this.ExpenseTypeListDataGridView.RowTemplate.Height = 32;

            this.ExpenseTypeListDataGridView.DataSource = expenseTypeListBindingSource;

            SetGridHeaderText(headingsDictionary);
            ExpenseTypeListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExpenseTypeListDataGridView.AllowUserToAddRows = false; //Removes blank row at end of grid load
            ExpenseTypeListDataGridView.ReadOnly = true;

            int optionsWidth = 0;
            SetGridColumnWidths(gridColumnWidthsDictionary, ref optionsWidth);


            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Options";
            imageColumn.Name = "Options";
            imageColumn.Width = optionsWidth;
            imageColumn.Image = Properties.Resources.MoreOptionsBlackDotsOnWhite20x20;
            if (ExpenseTypeListDataGridView.Columns["Options"] == null)
            {
                ExpenseTypeListDataGridView.Columns.Add(imageColumn);
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnUpdateTypeExpenseInGridMenuClick(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDeleteExpenseMenuClick(sender, e);
        }

        private void OnUpdateTypeExpenseInGridMenuClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, EditTypeExpenseMenuClickEventRaised, e);
        }

        private void OnDeleteExpenseMenuClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, DeleteTypeExpenseMenuClickEventRaised, e);
        }

        private void ExpenseTypeListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ExpenseTypeListDataGridView.Columns["Options"].Index)
            {
                contextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
    }

}

