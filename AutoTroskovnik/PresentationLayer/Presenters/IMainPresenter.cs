using CommonComponents;
using System;

namespace PresentationLayer.Presenters
{
    public interface IMainPresenter
    {
        event EventHandler<DataAccessException> DataAccessExceptionEvent;
        IMainView GetMainView();
        void LoadAll();
    }
}
