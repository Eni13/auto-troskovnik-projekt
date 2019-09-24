using System;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views.UserControls
{
    public interface ILoginViewUC
    {
        event EventHandler<UserViewModel> LoginClickEventRaised;
        event EventHandler RegistrationRedirectClickEventRaised;
    }
}