using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Views.UserControls;
using System;

namespace PresentationLayer.Presenters.UserControls
{
    public interface ILoginPresenter
    {
        event EventHandler ShowRegistrationViewEvent;
        event EventHandler<UserDTO> ShowMainViewEvent;
        event EventHandler<DataAccessException> DataAccessExceptionEvent;

        ILoginViewUC GetLoginViewUC();
    }
}