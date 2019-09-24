using System;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views.UserControls
{
    public interface IRegistrationViewUC
    {
        event EventHandler LoginRedirectEventRaised;
        event EventHandler<UserViewModel> RegistrationClickEventRaised;
    }
}