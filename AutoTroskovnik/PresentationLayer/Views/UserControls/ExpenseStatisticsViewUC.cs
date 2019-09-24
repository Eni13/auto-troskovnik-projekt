using System;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;
using CommonComponents.ViewModels;
using DomainLayer.Models.ExpenseType;
using CommonComponents;
using System.Linq;

namespace PresentationLayer.Views.UserControls
{
    public partial class ExpenseStatisticsViewUC : BaseUserControlUC, IExpenseStatisticsViewUC
    {
        public event EventHandler ExpenseStatisticsViewUCLoadEvent;
        public event EventHandler<Tuple<int, int>> ChangeYearEvent;
        public event EventHandler<Tuple<int, int>> ChangeMonthEvent;


        public void SetYearStatistics(IEnumerable<YearCategoryCost> yearCategoryList, IEnumerable<ExpenseTypeDTO> expenseTypes)
        {
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            foreach (ExpenseTypeDTO expenseType in expenseTypes)
            {
                values.Add(GetYearCostValue(yearCategoryList, expenseType.ExpenseTypeId));
                labels.Add(expenseType.ExpenseTypeName);
            }

            ClearYearChart();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Godišnja potrošnja",
                    Values = new ChartValues<double>(values),
                    DataLabels = true,

                }
            };
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Kategorija troška",
                Labels = labels,
                ShowLabels = true,
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Iznos troška",
                LabelFormatter = value => value.ToString("N")
            });
        }
        private double GetYearCostValue(IEnumerable<YearCategoryCost> list, int expenseTypeId)
        {
            foreach (YearCategoryCost i in list)
            {
                if (i.ExpenseTypeId == expenseTypeId)
                {
                    return i.TotalCost;
                }
            }
            return 0;
        }
        private double GetMonthCostValue(IEnumerable<MonthCategoryCost> list, int expenseTypeId)
        {
            foreach (MonthCategoryCost i in list)
            {
                if (i.ExpenseTypeId == expenseTypeId)
                {
                    return i.TotalCost;
                }
            }
            return 0;
        }
        public void SetMonthStatistics(IEnumerable<MonthCategoryCost> monthCategoryList, IEnumerable<ExpenseTypeDTO> expenseTypes)
        {
            List<double> values = new List<double>();
            List<string> labels = new List<string>();
            foreach (ExpenseTypeDTO expenseType in expenseTypes)
            {
                values.Add(GetMonthCostValue(monthCategoryList, expenseType.ExpenseTypeId));
                labels.Add(expenseType.ExpenseTypeName);
            }
            ClearMonthChart();

            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Mjesečnja potrošnja",
                    Values = new ChartValues<double>(values)
                }
            };
            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Kategorija troška",
                Labels = labels,
                ShowLabels = true,
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Iznos troška",
                LabelFormatter = value => value.ToString("N")
            });
        }

        public ExpenseStatisticsViewUC()
        {
            InitializeComponent();
        }

        public void ClearYearChart()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
        }

        public void ClearMonthChart()
        {
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();
        }

        private void ExpenseStatisticsViewUC_Load(object sender, EventArgs e)
        {

            EventHelpers.RaiseEvent(this, ExpenseStatisticsViewUCLoadEvent, e);
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yearComboBox.SelectedValue != null && monthComboBox.SelectedValue != null)
            {
                EventHelpers.RaiseEvent(this, ChangeYearEvent, new Tuple<int, int>((int)yearComboBox.SelectedValue, (int)monthComboBox.SelectedValue));
            }
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monthComboBox.SelectedValue != null && yearComboBox.SelectedValue != null)
            {
                EventHelpers.RaiseEvent(this, ChangeMonthEvent, new Tuple<int, int>((int)yearComboBox.SelectedValue, (int)monthComboBox.SelectedValue));
            }
        }

        public void SetDropdowns(List<int> years)
        {
            if (years.Count > 0)
            {
                monthComboBox.DataSource = Enumerable.Range(1, 12).ToList();
                yearComboBox.DataSource = years;
            }
            else {
                monthComboBox.DataSource = null;
                yearComboBox.DataSource = null;
                ClearYearChart();
                ClearMonthChart();
            }
  
        }
    }
}
