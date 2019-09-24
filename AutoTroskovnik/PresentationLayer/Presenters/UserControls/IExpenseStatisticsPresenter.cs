using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IExpenseStatisticsPresenter
    {
        IExpenseStatisticsViewUC GetExpenseStatisticsViewUC();
        void Refresh();
    }
}