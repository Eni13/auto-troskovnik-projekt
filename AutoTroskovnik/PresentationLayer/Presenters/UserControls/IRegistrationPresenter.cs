using System;
using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IRegistrationPresenter
    {
        event EventHandler ShowLoginViewEvent;
        event EventHandler<UserDTO> ShowMainViewEvent;
        event EventHandler<DataAccessException> DataAccessExceptionEvent;
        IRegistrationViewUC GetRegistrationViewUC();
    }
}