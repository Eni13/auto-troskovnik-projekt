using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.ViewModels;
using ServiceLayer.Services.UserService;
using System;

namespace PresentationLayer.Presenters.UserControls
{
    public class LoginPresenter : ILoginPresenter
    {
        public event EventHandler ShowRegistrationViewEvent;
        public event EventHandler<UserDTO> ShowMainViewEvent;
        public event EventHandler<DataAccessException> DataAccessExceptionEvent;

        private ILoginViewUC _loginViewUC;
        private IUserService _userService;

        public LoginPresenter(ILoginViewUC loginViewUC,
            IUserService userService)
        {
            _loginViewUC = loginViewUC;
            _userService = userService;
            SubscribeToEvents();
        }

        public ILoginViewUC GetLoginViewUC()
        {
            return _loginViewUC;
        }

        private void SubscribeToEvents()
        {
            _loginViewUC.LoginClickEventRaised += new EventHandler<UserViewModel>(OnLoginClickEventRaised);
            _loginViewUC.RegistrationRedirectClickEventRaised += new EventHandler(OnRegistrationRedirectClickEventRaised);
        }

        private void OnRegistrationRedirectClickEventRaised(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ShowRegistrationViewEvent, e);
        }

        private void OnLoginClickEventRaised(object sender, UserViewModel model)
        {
            try
            {
                UserDTO userDTO = _userService.GetByFirstAndLastName(model.FirstName, model.LastName);
                EventHelpers.RaiseEvent(this, ShowMainViewEvent, userDTO);
            }
            catch (DataAccessException e)
            {
                EventHelpers.RaiseEvent(this, DataAccessExceptionEvent, e);
            }
        }
    }
}
