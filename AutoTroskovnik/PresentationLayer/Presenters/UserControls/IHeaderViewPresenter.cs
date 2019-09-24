using DomainLayer.Models.User;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IHeaderViewPresenter
    {
        event EventHandler LogoutEvent;
        IExpenseAddView getExpenseAddView();
        IExpenseTypeAddView getExpenseTypeAddView();
        IHeaderViewUC GetHeaderViewUC();
        void setUserInfo(UserDTO userDTO);
    }
}