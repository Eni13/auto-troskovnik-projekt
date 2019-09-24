using DomainLayer.Models.User;
using PresentationLayer.Views;

namespace PresentationLayer.Presenters
{
    public interface IRootPresenter
    {
        IRootView GetRootView();
        void ShowErrorMessage(string windowTitle, string errorMessage);
        void ShowLoginView();
        void ShowMainView(UserDTO user);
        void ShowRegistrationView();
    }
}